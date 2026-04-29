using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using Application = UnityEngine.Device.Application;

namespace Warudo.Core.Persistence {
    public class PersistentDataManager {

        private readonly string basePath = Application.streamingAssetsPath + "/";
        private static readonly JsonSerializerSettings JsonSerializerSettings = new() {
            TypeNameHandling = TypeNameHandling.None,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
        
        public IEnumerable<FileEntry> GetFileEntries(string relativePath, string searchPattern = "*.*", Func<string, bool> predicate = null) {
            CheckPathAccess(Assembly.GetCallingAssembly(), relativePath);
            var e = Directory.EnumerateFiles(basePath + relativePath + Path.DirectorySeparatorChar, searchPattern, SearchOption.AllDirectories);
            if (predicate != null) e = e.Where(predicate);
            return e.Select(it => new FileEntry {
                path = Path.GetRelativePath(basePath, it).Replace('\\', '/'),
                relativePath = Path.GetRelativePath(basePath + relativePath, it).Replace('\\', '/'),
                absolutePath = basePath + Path.GetRelativePath(basePath, it).Replace('\\', '/'),
                fileName = Path.GetFileName(it),
                lastModifiedTime = new DateTimeOffset(File.GetLastWriteTimeUtc(it)).ToUnixTimeMilliseconds()
            });
        }

        public async UniTask WriteFileAsync(string relativePath, string contents) {
            CheckPathAccess(Assembly.GetCallingAssembly(), relativePath);
            Directory.CreateDirectory(Path.GetDirectoryName(basePath + relativePath)!);
            await File.WriteAllTextAsync(basePath + relativePath, contents);
        }
        
        public async UniTask WriteFileBytesAsync(string relativePath, byte[] bytes) {
            CheckPathAccess(Assembly.GetCallingAssembly(), relativePath);
            Directory.CreateDirectory(Path.GetDirectoryName(basePath + relativePath)!);
            await File.WriteAllBytesAsync(basePath + relativePath, bytes);
        }
        
        public void WriteFile(string relativePath, string contents) {
            CheckPathAccess(Assembly.GetCallingAssembly(), relativePath);
            Directory.CreateDirectory(Path.GetDirectoryName(basePath + relativePath)!);
            File.WriteAllText(basePath + relativePath, contents);
        }
        
        public void WriteFileBytes(string relativePath, byte[] bytes) {
            CheckPathAccess(Assembly.GetCallingAssembly(), relativePath);
            Directory.CreateDirectory(Path.GetDirectoryName(basePath + relativePath)!);
            File.WriteAllBytes(basePath + relativePath, bytes);
        }
        
        public bool HasFile(string relativePath) {
            CheckPathAccess(Assembly.GetCallingAssembly(), relativePath);
            return File.Exists(basePath + relativePath);
        }
        
        public string GetBasePath() {
            return basePath;
        }
        
        public string GetFullPath(string relativePath) {
            return basePath + relativePath;
        }
        
        public async UniTask<string> ReadFileAsync(string relativePath = "") {
            CheckPathAccess(Assembly.GetCallingAssembly(), relativePath);
            return await File.ReadAllTextAsync(basePath + relativePath);
        }
        
        public async UniTask<byte[]> ReadFileBytesAsync(string relativePath = "") {
            CheckPathAccess(Assembly.GetCallingAssembly(), relativePath);
            return await File.ReadAllBytesAsync(basePath + relativePath);
        }
        
        public string ReadFile(string relativePath = "") {
            CheckPathAccess(Assembly.GetCallingAssembly(), relativePath);
            return File.ReadAllText(basePath + relativePath);
        }
        
        public byte[] ReadFileBytes(string relativePath = "") {
            CheckPathAccess(Assembly.GetCallingAssembly(), relativePath);
            return File.ReadAllBytes(basePath + relativePath);
        }
        
        public async UniTask<T> ReadFileAsync<T>(string relativePath = "") {
            CheckPathAccess(Assembly.GetCallingAssembly(), relativePath);
            if (!HasFile(relativePath)) throw new Exception($"File {relativePath} does not exist");
            return JsonConvert.DeserializeObject<T>(await File.ReadAllTextAsync(basePath + relativePath), JsonSerializerSettings);
        }
        
        public T ReadFile<T>(string relativePath = "") {
            CheckPathAccess(Assembly.GetCallingAssembly(), relativePath);
            if (!HasFile(relativePath)) throw new Exception($"File {relativePath} does not exist");
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(basePath + relativePath), JsonSerializerSettings);
        }
        
        public void DeleteFile(string relativePath) {
            CheckPathAccess(Assembly.GetCallingAssembly(), relativePath);
            File.Delete(basePath + relativePath);
        }

        private void CheckPathAccess(Assembly assembly, string relativePath) {
            Debug.Log($"Checking path access for {assembly.FullName}");
            if (assembly == typeof(PersistentDataManager).Assembly || assembly == Context.Instance.CoreAssembly || assembly == Context.Instance.PluginsCoreAssembly) {
                if (Application.isEditor) Debug.LogWarning($"Accessing file system {relativePath} from Warudo.Core. Bypassing path access check.");
                return;
            }
            var fullPath = Path.GetFullPath(Path.Combine(basePath, relativePath));
            relativePath = Path.GetRelativePath(basePath, fullPath);
            if (relativePath.StartsWith(".") || relativePath.StartsWith("Binaries") || relativePath.StartsWith("Clients") || relativePath.StartsWith("Playground") || relativePath.StartsWith("Plugins")) {
                if (Application.isEditor) {
                    Debug.LogWarning($"Accessing restricted path {relativePath} from {assembly.FullName}. Bypassing path access check in editor.");
                    return;
                }
                // TODO: REMOVE v
                if (relativePath.Contains("Warudo.SOOP")) {
                    return;
                }
                // TODO: REMOVE ^
                throw new UnauthorizedAccessException($"Access to {relativePath} is restricted");
            }
        }
        
    }
}
