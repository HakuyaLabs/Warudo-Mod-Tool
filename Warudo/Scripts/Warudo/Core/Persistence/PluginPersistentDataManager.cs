using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;

namespace Warudo.Core.Persistence {
    /// <summary>
    /// Provides sandboxed file system access for plugins. Each plugin can only access its own dedicated directory.
    /// </summary>
    public sealed class PluginPersistentDataManager {
        private readonly string rootPath;
        private readonly string pluginId;
        
        private static readonly JsonSerializerSettings JsonSerializerSettings = new() {
            TypeNameHandling = TypeNameHandling.None,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        /// <summary>
        /// Internal constructor - only PluginManager should create instances
        /// </summary>
        internal PluginPersistentDataManager(string pluginId, string basePath) {
            this.pluginId = pluginId ?? throw new ArgumentNullException(nameof(pluginId));
            
            // Each plugin gets its own directory under StreamingAssets/Plugins/Data/{pluginId}/
            rootPath = Path.GetFullPath(Path.Combine(basePath, "Plugins", "Data", pluginId));
            
            // Ensure the directory exists
            Directory.CreateDirectory(rootPath);
        }

        /// <summary>
        /// Sanitizes and validates a relative path to ensure it stays within the plugin's sandbox
        /// </summary>
        private string SanitizePath(string relativePath) {
            if (string.IsNullOrWhiteSpace(relativePath)) {
                relativePath = "";
            }

            // Remove any leading/trailing slashes and normalize
            relativePath = relativePath.Trim('/', '\\');
            
            // Get the full path and ensure it's within our sandbox
            var fullPath = Path.GetFullPath(Path.Combine(rootPath, relativePath));
            
            // Security check: ensure the resolved path is still within our root
            if (!fullPath.StartsWith(rootPath + Path.DirectorySeparatorChar) && fullPath != rootPath) {
                throw new UnauthorizedAccessException($"Attempted to access path outside plugin sandbox: {relativePath}");
            }

            return fullPath;
        }

        /// <summary>
        /// Gets the plugin-specific base path
        /// </summary>
        public string GetBasePath() {
            return rootPath;
        }

        /// <summary>
        /// Gets the full path for a relative path within the plugin's sandbox
        /// </summary>
        public string GetFullPath(string relativePath) {
            return SanitizePath(relativePath);
        }

        /// <summary>
        /// Enumerates files within the plugin's directory
        /// </summary>
        public IEnumerable<FileEntry> GetFileEntries(string relativePath = "", string searchPattern = "*.*", Func<string, bool> predicate = null) {
            var searchPath = SanitizePath(relativePath);
            
            if (!Directory.Exists(searchPath)) {
                return Enumerable.Empty<FileEntry>();
            }

            var files = Directory.EnumerateFiles(searchPath, searchPattern, SearchOption.AllDirectories);
            if (predicate != null) {
                files = files.Where(predicate);
            }

            return files.Select(filePath => {
                var relativeToRoot = Path.GetRelativePath(rootPath, filePath).Replace('\\', '/');
                var relativeToSearch = Path.GetRelativePath(searchPath, filePath).Replace('\\', '/');
                
                return new FileEntry {
                    path = relativeToRoot,
                    relativePath = relativeToSearch,
                    absolutePath = filePath,
                    fileName = Path.GetFileName(filePath),
                    lastModifiedTime = new DateTimeOffset(File.GetLastWriteTimeUtc(filePath)).ToUnixTimeMilliseconds()
                };
            });
        }

        /// <summary>
        /// Checks if a file exists within the plugin's sandbox
        /// </summary>
        public bool HasFile(string relativePath) {
            try {
                var fullPath = SanitizePath(relativePath);
                return File.Exists(fullPath);
            } catch (UnauthorizedAccessException) {
                return false;
            }
        }

        // --- Async Write Methods ---

        public async UniTask WriteFileAsync(string relativePath, string contents) {
            var fullPath = SanitizePath(relativePath);
            var directory = Path.GetDirectoryName(fullPath);
            if (!string.IsNullOrEmpty(directory)) {
                Directory.CreateDirectory(directory);
            }
            await File.WriteAllTextAsync(fullPath, contents);
        }

        public async UniTask WriteFileBytesAsync(string relativePath, byte[] bytes) {
            var fullPath = SanitizePath(relativePath);
            var directory = Path.GetDirectoryName(fullPath);
            if (!string.IsNullOrEmpty(directory)) {
                Directory.CreateDirectory(directory);
            }
            await File.WriteAllBytesAsync(fullPath, bytes);
        }
        
        public async UniTask WriteFileAsync<T>(string relativePath, T data) {
            var content = JsonConvert.SerializeObject(data, JsonSerializerSettings);
            await WriteFileAsync(relativePath, content);
        }

        // --- Sync Write Methods ---

        public void WriteFile(string relativePath, string contents) {
            var fullPath = SanitizePath(relativePath);
            var directory = Path.GetDirectoryName(fullPath);
            if (!string.IsNullOrEmpty(directory)) {
                Directory.CreateDirectory(directory);
            }
            File.WriteAllText(fullPath, contents);
        }

        public void WriteFileBytes(string relativePath, byte[] bytes) {
            var fullPath = SanitizePath(relativePath);
            var directory = Path.GetDirectoryName(fullPath);
            if (!string.IsNullOrEmpty(directory)) {
                Directory.CreateDirectory(directory);
            }
            File.WriteAllBytes(fullPath, bytes);
        }
        
        public void WriteFile<T>(string relativePath, T data) {
            var content = JsonConvert.SerializeObject(data, JsonSerializerSettings);
            WriteFile(relativePath, content);
        }

        // --- Async Read Methods ---

        public async UniTask<string> ReadFileAsync(string relativePath = "") {
            var fullPath = SanitizePath(relativePath);
            if (!File.Exists(fullPath)) {
                throw new FileNotFoundException($"File not found: {relativePath}");
            }
            return await File.ReadAllTextAsync(fullPath);
        }

        public async UniTask<byte[]> ReadFileBytesAsync(string relativePath = "") {
            var fullPath = SanitizePath(relativePath);
            if (!File.Exists(fullPath)) {
                throw new FileNotFoundException($"File not found: {relativePath}");
            }
            return await File.ReadAllBytesAsync(fullPath);
        }

        public async UniTask<T> ReadFileAsync<T>(string relativePath = "") {
            var content = await ReadFileAsync(relativePath);
            return JsonConvert.DeserializeObject<T>(content, JsonSerializerSettings);
        }

        // --- Sync Read Methods ---

        public string ReadFile(string relativePath = "") {
            var fullPath = SanitizePath(relativePath);
            if (!File.Exists(fullPath)) {
                throw new FileNotFoundException($"File not found: {relativePath}");
            }
            return File.ReadAllText(fullPath);
        }

        public byte[] ReadFileBytes(string relativePath = "") {
            var fullPath = SanitizePath(relativePath);
            if (!File.Exists(fullPath)) {
                throw new FileNotFoundException($"File not found: {relativePath}");
            }
            return File.ReadAllBytes(fullPath);
        }

        public T ReadFile<T>(string relativePath = "") {
            var content = ReadFile(relativePath);
            return JsonConvert.DeserializeObject<T>(content, JsonSerializerSettings);
        }

        // --- Delete Methods ---

        public void DeleteFile(string relativePath) {
            var fullPath = SanitizePath(relativePath);
            if (File.Exists(fullPath)) {
                File.Delete(fullPath);
            }
        }

        public void DeleteDirectory(string relativePath, bool recursive = false) {
            var fullPath = SanitizePath(relativePath);
            if (Directory.Exists(fullPath)) {
                Directory.Delete(fullPath, recursive);
            }
        }

        // --- Directory Methods ---

        public void CreateDirectory(string relativePath) {
            var fullPath = SanitizePath(relativePath);
            Directory.CreateDirectory(fullPath);
        }

        public bool DirectoryExists(string relativePath) {
            try {
                var fullPath = SanitizePath(relativePath);
                return Directory.Exists(fullPath);
            } catch (UnauthorizedAccessException) {
                return false;
            }
        }

        public IEnumerable<string> GetDirectories(string relativePath = "", string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly) {
            var fullPath = SanitizePath(relativePath);
            if (!Directory.Exists(fullPath)) {
                return Enumerable.Empty<string>();
            }

            return Directory.EnumerateDirectories(fullPath, searchPattern, searchOption)
                .Select(dir => Path.GetRelativePath(rootPath, dir).Replace('\\', '/'));
        }

        public IEnumerable<string> GetFiles(string relativePath = "", string searchPattern = "*.*", SearchOption searchOption = SearchOption.TopDirectoryOnly) {
            var fullPath = SanitizePath(relativePath);
            if (!Directory.Exists(fullPath)) {
                return Enumerable.Empty<string>();
            }

            return Directory.EnumerateFiles(fullPath, searchPattern, searchOption)
                .Select(file => Path.GetRelativePath(rootPath, file).Replace('\\', '/'));
        }
    }
}