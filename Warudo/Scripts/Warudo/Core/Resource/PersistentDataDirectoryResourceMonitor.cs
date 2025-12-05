using System;
using System.Collections.Generic;
using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core.Scenes;
using Warudo.Core.Utils;

namespace Warudo.Core.Resource {
    public class PersistentDataDirectoryResourceMonitor {

        private readonly string monitorPath;

        private readonly string scheme;
        private FileSystemWatcher watcher;
        private HashSet<string> extensions;
        private readonly Func<Asset, string, bool> matchAssetFunc;
        private readonly Action<Asset> reloadAssetAction;

        public PersistentDataDirectoryResourceMonitor(string scheme, string monitorPath, HashSet<string> extensions, Func<Asset, string, bool> matchAssetFunc, Action<Asset> reloadAssetAction) {
            this.scheme = scheme;
            this.monitorPath = monitorPath;
            this.extensions = extensions;
            this.matchAssetFunc = matchAssetFunc;
            this.reloadAssetAction = reloadAssetAction;
        }

        public void Start() {
            LogMessage($"Started monitoring {Path.GetFileName(monitorPath)} ({monitorPath})");
            
            watcher = new FileSystemWatcher(monitorPath);
            watcher.Filter = "*.*";
            watcher.Error += async (sender, e) => {
                await UniTask.SwitchToMainThread();
                PrintException(e.GetException());
            };
            
            async void OnHotReload(object sender, FileSystemEventArgs args) {
                await UniTask.SwitchToMainThread();
                if (!extensions.Contains(Path.GetExtension(args.FullPath).ToLowerInvariant())) return;
                try {
                    LoadWarudoFile(args.FullPath);
                } catch (Exception e) {
                    PrintException(e);
                }
            }

            watcher.IncludeSubdirectories = false;
            watcher.EnableRaisingEvents = true;
            watcher.Created += OnHotReload;
            watcher.Deleted += OnHotReload;
            watcher.Changed += OnHotReload;
        }

        private void LoadWarudoFile(string filePath) {
            if (!File.Exists(filePath)) {
                LogMessage("Resource file deleted: " + filePath);
                return;
            }

            var relativePath = Path.GetRelativePath(Context.PersistentDataManager.GetBasePath(), filePath);
            relativePath = relativePath.Replace("\\", "/");
            if (relativePath.StartsWith("/")) {
                relativePath = relativePath[1..];
            }
            var sourcePath = $"{scheme}://data/{relativePath}";
            LogMessage($"Checking references to {sourcePath}");

            if (Context.OpenedScene == null) return;
            foreach (var asset in Context.OpenedScene.GetAssets().Values) {
                if (matchAssetFunc(asset, sourcePath)) {
                    LogMessage($"Reloading asset: {asset.Name} ({asset.Id})");
                    reloadAssetAction(asset);
                }
            }
        }

        public void Dispose() {
            watcher.Dispose();
        }
        
        private static void LogMessage(string o) {
            Debug.Log("[LocalResourceMonitor] " + o);
        }

        private static void PrintException(Exception ex) {
            while (true) {
                if (ex != null) {
                    Log.UserError($"[LocalResourceMonitor] Exception: {ex.Message}");
                    Log.UserError("Stacktrace:");
                    Log.UserError(ex.StackTrace);
                    ex = ex.InnerException;
                    continue;
                }
                break;
            }
        }
    }
}
