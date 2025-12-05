using System;
using System.Collections.Generic;
using UnityEngine.Serialization;
using Warudo.Core.Localization;

namespace Warudo.Core.Serializations {
    [Serializable]
    public class SerializedScene : ILocalizable {
        public string name;
        public string appVersion;
        public Guid selectedAssetId;
        public Guid selectedGraphId;
        public List<SerializedAsset> assets;
        public HierarchyNode assetHierarchy;
        public List<SerializedGraph> graphs;
        public HierarchyNode graphHierarchy;
        public Dictionary<string, PluginSceneData> plugins;

        public void Localize() {
            assets.ForEach(it => it.Localize());
            graphs.ForEach(it => it.Localize());
        }
    }

    [Serializable]
    public class PluginSceneData {
        public string version;
        public string data;
    }

    [Serializable]
    public class HierarchyNode {
        public bool collapsed;
        public string key;
        public List<HierarchyNode> children;
        
        public int GetOrder(string key) {
            var order = 0;
            if (children == null) {
                return -1;
            }
            // Depth-first search
            foreach (var child in children) {
                order++;
                if (child.key == key) {
                    return order;
                }
                var childOrder = child.GetOrder(key);
                if (childOrder != -1) {
                    return order + childOrder;
                }
            }
            return -1;
        }
        
        public bool Exists(string key) {
            if (children == null) {
                return false;
            }
            // Depth-first search
            foreach (var child in children) {
                if (child.key == key) {
                    return true;
                }
                if (child.Exists(key)) {
                    return true;
                }
            }
            return false;
        }
        
        public void AssignAtFirstLevel(string key, string parent) {
            if (children == null) throw new Exception("Leaf node cannot have children");
            
            // Remove existing nodes with the same key
            void RemoveRecursively(HierarchyNode node) {
                if (node.children == null) return;
                for (var i = 0; i < node.children.Count; i++) {
                    if (node.children[i].key == key) {
                        node.children.RemoveAt(i);
                        return;
                    }
                    RemoveRecursively(node.children[i]);
                }
            }
            RemoveRecursively(this);
            
            if (parent == string.Empty) {
                children.Add(new HierarchyNode {
                    key = key
                });
                return;
            }
            foreach (var child in children) {
                if (child.key == parent) {
                    child.children.Add(new HierarchyNode {
                        key = key
                    });
                    return;
                }
            }
            // If parent is not found, create parent
            children.Add(new HierarchyNode {
                key = parent,
                children = new List<HierarchyNode> {
                    new HierarchyNode {
                        key = key
                    }
                }
            });
        }
    }
}
