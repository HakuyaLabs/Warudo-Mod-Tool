using System;
using System.IO;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Warudo.Core.Utils;

namespace Warudo.Core.Localization {
    public class LocalizationMonitor {

        private readonly string monitorPath;
        
        private FileSystemWatcher watcher;

        public LocalizationMonitor(string monitorPath) {
            this.monitorPath = monitorPath;
        }
        
        public async UniTask Start() {
            LogMessage($"Started monitoring localization files ({monitorPath})");

            watcher = new FileSystemWatcher(monitorPath);
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
            watcher.Filter = "*.json";
            watcher.Error += async (sender, e) => {
                await UniTask.SwitchToMainThread();
                PrintException(e.GetException());
            };
            
            bool IsLocalizationFile(string path) {
                var directoryInfo = new DirectoryInfo(path).Parent;
                if (directoryInfo == null) return false;
                var dirName = directoryInfo.Name;
                return dirName == "Localizations" && Path.GetExtension(path).ToLowerOptimized() == ".json";
            }

            async void OnHotReload(object sender, FileSystemEventArgs args) {
                if (!IsLocalizationFile(args.FullPath)) return;
                
                await UniTask.SwitchToMainThread();
                await LoadLocalizationFile(args.FullPath);
            }

            watcher.Created += OnHotReload;
            watcher.Renamed += OnHotReload;
            watcher.Changed += OnHotReload;

            foreach (var fileEntry in Directory.GetFiles(monitorPath, "*.json", SearchOption.AllDirectories)) {
                if (!IsLocalizationFile(fileEntry)) continue;

                await LoadLocalizationFile(fileEntry);
            }
        }

        private async UniTask LoadLocalizationFile(string filePath) {
            if (!Application.isPlaying) return;
            try {
                LogMessage($"Loading localization file {filePath}");
                var content = await File.ReadAllTextAsync(filePath);
                var jObject = JObject.Parse(content);
                Context.LocalizationManager.LoadLocalizedStrings(jObject);
            } catch (Exception e) {
                Log.UserError($"Failed to load localization file from {filePath}", e);
            }
        }

        public void Dispose() {
            watcher.Dispose();
        }

        private static void LogMessage(string o) {
            Debug.Log("[LocalizationMonitor] " + o);
        }

        private static void PrintException(Exception ex) {
            while (true) {
                if (ex != null) {
                    LogMessage($"Exception: {ex.Message}");
                    Debug.Log("Stacktrace:");
                    Debug.Log(ex.StackTrace);
                    ex = ex.InnerException;
                    continue;
                }
                break;
            }
        }
    }
}
