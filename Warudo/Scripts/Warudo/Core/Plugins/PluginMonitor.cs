using System;
using System.Collections.Generic;
using System.IO;
using Cysharp.Threading.Tasks;
using UMod;
using Warudo.Core.Utils;

namespace Warudo.Core.Plugins {
    public sealed class PluginMonitor {
        public static Action<string> OnPluginFilename;
        private readonly string monitorPath;
        private readonly string dataDirectory;
        private readonly Dictionary<string, int> revisions = new(StringComparer.OrdinalIgnoreCase);
        private FileSystemWatcher watcher;
        private bool disposed;

        public PluginMonitor(string monitorPath) {
            this.monitorPath = Path.GetFullPath(monitorPath);
            dataDirectory = Path.GetFullPath(Path.Combine(UnityEngine.Application.streamingAssetsPath, "Plugins", "ModManager")) + Path.DirectorySeparatorChar;
        }

        public async UniTask Start() {
            watcher = new FileSystemWatcher(monitorPath) {
                IncludeSubdirectories = true,
                Filter = "*.warudo",
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size
            };
            watcher.Created += OnFileChanged;
            watcher.Deleted += OnFileChanged;
            watcher.Changed += OnFileChanged;
            watcher.Renamed += OnFileRenamed;
            watcher.Error += OnWatcherError;
            watcher.EnableRaisingEvents = true;
            foreach (var path in Directory.GetFiles(monitorPath, "*.warudo", SearchOption.AllDirectories)) {
                if (IsPluginFile(path)) await NotifyWithRetry(path, false);
            }
        }

        private bool IsPluginFile(string path) =>
            !Path.GetFullPath(path).StartsWith(dataDirectory, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(Path.GetFileName(Path.GetDirectoryName(path)), "Plugins", StringComparison.OrdinalIgnoreCase) &&
            string.Equals(Path.GetExtension(path), ".warudo", StringComparison.OrdinalIgnoreCase);

        private async void OnFileChanged(object sender, FileSystemEventArgs args) {
            await NotifyChange(args.FullPath);
        }

        private async void OnFileRenamed(object sender, RenamedEventArgs args) {
            await NotifyChange(args.OldFullPath);
            await NotifyChange(args.FullPath);
        }

        private async UniTask NotifyChange(string path) {
            if (!IsPluginFile(path)) return;
            await UniTask.SwitchToMainThread();
            if (disposed) return;
            var revision = revisions.TryGetValue(path, out var previous) ? previous + 1 : 1;
            revisions[path] = revision;
            await UniTask.Delay(300);
            if (disposed || !revisions.TryGetValue(path, out var latest) || latest != revision) return;
            await NotifyWithRetry(path, true);
            if (revisions.TryGetValue(path, out latest) && latest == revision) revisions.Remove(path);
        }

        private async UniTask NotifyWithRetry(string path, bool updateClient) {
            for (var attempt = 0; attempt < 5 && !disposed; attempt++) {
                try {
                    // Discovery only: no ModHost loading or plugin type registration here.

                    // Doesn't exists in Mod SDK, but here notifying files.
                    return;
                } catch (Exception e) {
                    if (attempt < 4 && (e is IOException || e is ModArchiveException)) {
                        await UniTask.Delay(300);
                        continue;
                    }
                    Log.UserError("Failed to inspect plugin mod at " + path, e);
                    return;
                }
            }
        }

        private async void OnWatcherError(object sender, ErrorEventArgs args) {
            await UniTask.SwitchToMainThread();
            if (!disposed) Log.Error("Plugin file watcher failed: " + monitorPath, args.GetException());
        }

        public void Dispose() {
            disposed = true;
            watcher?.Dispose();
        }
    }
}
