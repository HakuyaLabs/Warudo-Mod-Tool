using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;
using Warudo.Core;
using Warudo.Core.Utils;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Utils {
    public static class ObjectPools {
        
        private static readonly List<IDisposable> GameObjectPools = new();
        private static readonly Dictionary<string, IDisposable> ResourcePools = new();
        private static List<GameObject> parents = new();

        public static ObjectPool<GameObject> CreateGameObjectPool(Func<GameObject> createFunc) {
            GameObject parent = null;
            var pool = new ObjectPool<GameObject>(
                () => {
                    if (parent == null) {
                        parent = new GameObject("GameObjectPool");
                        
                        parents.Add(parent);
                    }
                    var obj = createFunc();
                    obj.transform.SetParent(parent.transform);
                    return obj;
                },
                obj => {
                    if (obj == null) return;
                    obj.SetActive(true);
                },
                obj => {
                    if (obj == null) return;
                    obj.SetActive(false);
                },
                Object.Destroy);
            GameObjectPools.Add(pool);
            return pool;
        }
        
        public static ObjectPool<GameObject> CreateOrGetResourceGameObjectPool(string resourceUri) {
            if (ResourcePools.ContainsKey(resourceUri)) {
                return (ObjectPool<GameObject>) ResourcePools[resourceUri];
            }
            var gameObject = Context.ResourceManager.ResolveResourceUri<GameObject>(resourceUri);
            if (gameObject == null) {
                throw new Exception("Failed to load resource: " + resourceUri);
            }
            GameObject parent = null;
            gameObject.SetActive(false);
            var pool = new ObjectPool<GameObject>(
                () => {
                    if (parent == null) {
                        parent = new GameObject("ResourceGameObjectPool-" + resourceUri.Split("/").Last());
                        parents.Add(parent);
                    }
                    var obj = Object.Instantiate(gameObject, parent.transform, false);
                    gameObject.transform.SetParent(parent.transform);
                    obj.SetActive(true);
                    return obj;
                },
                obj => {
                    if (obj == null) return;
                    obj.SetActive(true);
                },
                obj => {
                    if (obj == null) return;
                    obj.SetActive(false);
                },
                Object.Destroy);
            ResourcePools[resourceUri] = pool;
            return pool;
        }

        public static void Dispose() {
            GameObjectPools.ForEach(pool => pool.Dispose());
            GameObjectPools.Clear();
            ResourcePools.Values.ForEach(pool => pool.Dispose());
            ResourcePools.Clear();
            parents.ForEach(Object.Destroy);
            parents.Clear();
        }
        
    }
}
