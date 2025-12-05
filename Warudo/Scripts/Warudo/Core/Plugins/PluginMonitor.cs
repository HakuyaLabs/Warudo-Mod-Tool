using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UMod;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Server;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Utils;

namespace Warudo.Core.Plugins {
    public class PluginMonitor {

        public static Action<string> OnPluginFilename;

        private readonly string monitorPath;
        
        private FileSystemWatcher watcher;
        private Dictionary<string, List<Plugin>> loadedFiles = new();
        private Dictionary<string, PluginTypeCheckpoint> pluginTypeCheckpoints = new();

        public PluginMonitor(string monitorPath) {
            this.monitorPath = monitorPath;
        }

        public async UniTask Start() {
            LogMessage($"Started monitoring plugins ({monitorPath})");
            
            watcher = new FileSystemWatcher(monitorPath);
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
            watcher.Filter = "*.warudo";
            watcher.Error += async (sender, e) => {
                await UniTask.SwitchToMainThread();
                PrintException(e.GetException());
            };
            
            bool IsPluginFile(string path) {
                var directoryInfo = new DirectoryInfo(path).Parent;
                if (directoryInfo == null) return false;
                var dirName = directoryInfo.Name;
                return dirName == "Plugins" && Path.GetExtension(path).ToLowerOptimized() == ".warudo";
            }
            
            async void OnHotReload(object sender, FileSystemEventArgs args) {
                if (!IsPluginFile(args.FullPath)) return;
                
                await UniTask.SwitchToMainThread();
                try {
                    await LoadPluginFile(args.FullPath, true, false);
                } catch (Exception e) {
                    PrintException(e);
                }
            }

            watcher.Created += OnHotReload;
            watcher.Deleted += OnHotReload;
            watcher.Changed += OnHotReload;
            
            foreach (var fileEntry in Directory.GetFiles(monitorPath, "*.warudo", SearchOption.AllDirectories)) {
                if (!IsPluginFile(fileEntry)) continue;

                await LoadPluginFile(fileEntry, false, true);
            }
        }

        public async UniTask LoadPluginFile(string filePath, bool updateClient, bool asyncLoad) {
            OnPluginFilename?.Invoke(Path.GetFileNameWithoutExtension(filePath));

            var normalizedFilePath = NormalizePath(filePath);
            if (loadedFiles.ContainsKey(normalizedFilePath)) {
                foreach (var plugin in loadedFiles[normalizedFilePath]) {
                    LogMessage("Disabling plugin: " + plugin.GetType().Name);
                    pluginTypeCheckpoints[plugin.Type.Id] = Context.PluginTypeRegistry.CheckpointType(plugin.Type.Id);
                }
                loadedFiles.Remove(normalizedFilePath);
            }
            
            if (!File.Exists(filePath)) {
                LogMessage(".warudo file deleted: " + filePath);
                return;
            }
            
            LogMessage("Loading .warudo file: " + filePath);
            var path = new Uri(filePath);

            ModHost host;
            if (asyncLoad && false) { // Disable async loading for now since it's exceptionally slow
                var operation = Mod.LoadAsync(path);
                await operation;
                host = operation.Result;
            } else {
                host = Mod.Load(path);
            }

            LogMessage("Loaded .warudo file: " + filePath);
            
            if (!host.IsModLoaded) {
                Log.UserError("Failed to load user plugin at " + path + ": " + host.LoadResult.Message);
                return;
            }
            
            LogMessage(host.Assets.AssetCount + " assets found in .warudo file: " + filePath);
            foreach (var localizationFile in host.Assets.FindAllInFolderWithExtension("Localizations", ".json")) {
                var textAsset = localizationFile.Load<TextAsset>();
                var jObject = JObject.Parse(textAsset.text);
                Context.LocalizationManager.LoadLocalizedStrings(jObject);
                LogMessage("Loaded localization file: " + localizationFile.Name);
            }
            
            if (host.HasScripts) {
                foreach (var assembly in host.ScriptDomain.Assemblies) {
                    // Add to type registry
                    foreach (var type in assembly.FindAllTypes().Select(it => it.RawType)) {
                        Context.TypeRegistry.AddType(type);
                    }
                    
                    var types = assembly.FindAllSubTypesOf<Plugin>();
                    foreach (var pluginType in types) {
                        try {
                            LogMessage("Found plugin type in .warudo file: " + pluginType.RawType.Name);
                            var plugin = await LoadPlugin(pluginType.RawType, host);
                            if (!loadedFiles.ContainsKey(normalizedFilePath)) {
                                loadedFiles[normalizedFilePath] = new List<Plugin>();
                            }
                            loadedFiles[normalizedFilePath].Add(plugin);
                        } catch (Exception e) {
                            Log.UserError("Failed to load user plugin at " + path + " of type " + pluginType.RawType, e);
                        }
                    }
                }
            } else {
                LogMessage("No scripts found in .warudo file: " + filePath);
            }
            
            if (updateClient) {
                Context.Service?.BroadcastNodeTypeList(Context.NodeTypeRegistry.Serialize());
                Context.Service?.BroadcastAssetTypeList(Context.AssetTypeRegistry.Serialize());
                Context.Service?.BroadcastOpenedScene();
            }
        }

        public async UniTask<Plugin> LoadPlugin(Type type, ModHost modHost) {
            var pluginTypeAttribute = type.GetCustomAttribute<PluginTypeAttribute>();
            if (pluginTypeAttribute == null) {
                throw new UserException($"Plugin type {type.FriendlyFullName()} does not have an ID");
            }
            var typeId = pluginTypeAttribute.Id;

            Context.PluginTypeRegistry.RegisterType(typeId, type);
                
            var plugin = await Context.PluginManager.EnablePlugin(type, modHost);
            if (pluginTypeCheckpoints.ContainsKey(typeId)) {
                Context.PluginTypeRegistry.RestoreTypeCheckpoint(pluginTypeCheckpoints[typeId]);
                pluginTypeCheckpoints.Remove(typeId);
                LogMessage("Reloaded plugin: " + type.Name);
                Context.Service.Toast(ToastSeverity.Success, "Plugin hot-reloaded", "Plugin \"" + plugin.GetType().Name + "\" has been hot-reloaded.");
            } else {
                LogMessage("Loaded plugin: " + type.Name);
            }

            return plugin;
        }

        public void Dispose() {
            watcher.Dispose();
        }
        
        private static void LogMessage(string o) {
            Debug.Log("[PluginMonitor] " + o);
        }

        private static void PrintException(Exception ex) {
            while (true) {
                if (ex != null) {
                    Log.UserError($"[PluginMonitor] Exception: {ex.Message}");
                    Log.UserError("Stacktrace:");
                    Log.UserError(ex.StackTrace);
                    ex = ex.InnerException;
                    continue;
                }
                break;
            }
        }
        
        private static string NormalizePath(string path) {
            return Path.GetFullPath(new Uri(path).LocalPath)
                .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                .ToUpperInvariant();
        }
    }
}
