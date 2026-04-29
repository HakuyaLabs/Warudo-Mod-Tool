using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using Warudo.Core.Localization;
using Warudo.Core.Serializations;
using Warudo.Core.Server;
using Warudo.Scripts.Warudo.Core.Events;

namespace Warudo.Core.Scenes {
    public class SceneManager {
        private readonly static char[] ReservedChars = { 
            '<', '>', ':', '"', '/', '\\', '|', '?', '*',
        };

        private static readonly Dictionary<char, char> EncodeMap = new Dictionary<char, char>();
        private static readonly Dictionary<char, char> DecodeMap = new Dictionary<char, char>();

        static SceneManager()
        {
            // Remap reserved characters to a range of Unicode characters in the Private Use Area from U+F110 (PUA is from U+E000-U+F8FF)
            int baseCode = 0xF110;
            for (int i = 0; i < ReservedChars.Length; i++)
            {
                char original = ReservedChars[i];
                char mapped = (char)(baseCode + i);

                EncodeMap[original] = mapped;
                DecodeMap[mapped] = original;
            }
        }

        public SceneEntry[] GetScenes() {
            return Context.PersistentDataManager.GetFileEntries("Scenes", "*.json")
                .Select(it => new SceneEntry {
                    name = GetOriginalSceneName(Path.GetFileNameWithoutExtension(it.path)),
                    lastModifiedTime = it.lastModifiedTime
                })
                .OrderByDescending(it => it.lastModifiedTime)
                .ToArray();
        }

        public string GetSafeSceneName(string name) {
            var safeFileName = new StringBuilder(name.Length);
            foreach (char c in name)
            {
                if (EncodeMap.TryGetValue(c, out char mapped))
                    safeFileName.Append(mapped);
                else
                    safeFileName.Append(c);
            }
            return safeFileName.ToString();
        }

        public string GetOriginalSceneName(string name)
        {
            var originalFileName = new StringBuilder(name.Length);
            foreach (char c in name)
            {
                if (DecodeMap.TryGetValue(c, out char original))
                    originalFileName.Append(original);
                else
                    originalFileName.Append(c);
            }
            return originalFileName.ToString();
        }

        public async UniTask SaveScene(string name, SerializedScene serializedScene, bool isNewScene = false) {
            serializedScene.name = name;
            var fileName = GetSafeSceneName(name);
            var path = $"Scenes/{fileName}.json";
            if (Context.PersistentDataManager.HasFile(path)) {
                // Backup the old scene by copying the old file
                var fullPath = Context.PersistentDataManager.GetFullPath(path);
                File.Copy(fullPath, fullPath + ".autobackup", true);
            }
            await Context.PersistentDataManager.WriteFileAsync(path, JsonConvert.SerializeObject(serializedScene));
            // Delete the backup
            if (Context.PersistentDataManager.HasFile(path + ".autobackup")) {
                Context.PersistentDataManager.DeleteFile(path + ".autobackup");
            }
            Context.EventBus.Broadcast(new SceneSaveEvent(name, serializedScene, isNewScene));
            Context.Service?.Toast(ToastSeverity.Success, "SUCCESS", "SAVED_SCENE");
        }

        public void DeleteScene(string name) {
            var fileName = GetSafeSceneName(name);
            var path = $"Scenes/{fileName}.json";
            Context.PersistentDataManager.DeleteFile(path);
        }
        
        public bool HasScene(string name)
        {
            var fileName = GetSafeSceneName(name);
            var path = $"Scenes/{fileName}.json";
            return Context.PersistentDataManager.HasFile(path);
        }

        public async UniTask OpenScene(string name) {
            if (!HasScene(name)) {
                throw new Exception($"Scene {name} does not exist");
            }

            var fileName = GetSafeSceneName(name);
            var path = $"Scenes/{fileName}.json";

            var serializedScene = await Context.PersistentDataManager.ReadFileAsync<SerializedScene>(path);
            await Context.Instance.OpenScene(serializedScene);
        }

        public SerializedScene LoadDefaultSceneTemplate() {
            var serializedScene = JsonConvert.DeserializeObject<SerializedScene>(
                Resources.Load<TextAsset>("Templates/Scenes/DefaultScene").text)!;
            
            // Localize asset names
            foreach (var serializedAsset in serializedScene.assets) {
                var assetId = serializedAsset.typeId;
                var asset = Context.AssetTypeRegistry.GetTypeMeta(assetId);
                serializedAsset.name = asset.AssetType.title.Localized();
                
                if (serializedAsset.typeId is "726ab674-a550-474e-8b92-66526a5ad55e" or "6a05ecf3-1501-4cab-b9d7-84131b881a29") {
                    serializedAsset.name += " 1";
                }
            }

            return serializedScene;
        }
    }

    [Serializable]
    public class SceneEntry {
        public string name;
        public long lastModifiedTime;
    }
}
