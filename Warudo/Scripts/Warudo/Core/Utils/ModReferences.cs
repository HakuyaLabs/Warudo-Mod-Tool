using System;
using System.Collections.Generic;
using UMod;
using UnityEngine;

namespace Warudo.Core.Utils {
    public static class ModReferences {
        
        private static readonly Dictionary<Uri, int> References = new();
        private static readonly Dictionary<string, Uri> UriMapping = new();

        public static void Initialize() {
            References.Clear();
            UriMapping.Clear();
        }

        public static void Dispose() {
            References.Clear();
            UriMapping.Clear();
        }

        public static void Add(Uri resourceUri, Uri localPath, GameObject go) {
            UriMapping[resourceUri.OriginalString] = localPath;
            References[localPath] = References.TryGetValue(localPath, out var reference) ? reference + 1 : 1;
            go.AddComponent<RemoveModReferenceBehavior>().OnRemoveModReference = () => {
                if (!References.ContainsKey(localPath)) {
                    return;
                }
                References[localPath] -= 1;
                if (References[localPath] == 0) {
                    UnloadModHost(localPath);
                    References.Remove(localPath);
                }
            };
        }
        
        public static ModHost GetModHost(Uri resourceUri) {
            if (!UriMapping.ContainsKey(resourceUri.OriginalString)) {
                return null;
            }
            var localPath = UriMapping[resourceUri.OriginalString];
            return Mod.GetLoadedMod(localPath);
        }

        private static void UnloadModHost(Uri localPath) {
            var modHost = Mod.GetLoadedMod(localPath);
            if (modHost != null) {
                Debug.Log("Unloaded " + modHost.name + " at " + localPath);
                modHost.DestroyModObjects();
                modHost.UnloadMod(false);
            }
        }

    }

    public class RemoveModReferenceBehavior : MonoBehaviour {
        
        public Action OnRemoveModReference;

        private void OnDestroy() {
            OnRemoveModReference?.Invoke();
        }

    }
}
