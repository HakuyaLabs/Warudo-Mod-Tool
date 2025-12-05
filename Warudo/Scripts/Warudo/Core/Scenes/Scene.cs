using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using TagLib.Riff;
using UnityEngine;
using Vexe.Fast.Reflection;
using Warudo.Core.Events;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using Warudo.Core.Plugins;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;

namespace Warudo.Core.Scenes {
    public class Scene {
        public string Name { get; set; }
        
        public float LoadedTime { get; set; }

        public int ActiveFrames { get; set; } = 0;

        public HierarchyNode AssetHierarchy { get; set; } = null;
        public HierarchyNode GraphHierarchy { get; set; } = null;
        
        private readonly List<Asset> assetList = new();
        private readonly Dictionary<Guid, Asset> assetMap = new();
        private Guid selectedAssetId = Guid.Empty;

        private readonly List<Graph> graphList = new();
        private readonly Dictionary<Guid, Graph> graphMap = new();
        private Guid selectedGraphId = Guid.Empty;

        private Dictionary<string, object> pluginData = new();
        
        public IReadOnlyDictionary<Guid, Asset> GetAssets() => assetMap;
        
        public IReadOnlyList<Asset> GetAssetList() => assetList;

        public IReadOnlyList<T> GetAssets<T>() => assetMap.Values.OfType<T>().ToList();
        
        public IReadOnlyList<Asset> GetAssetsOfType(Type type) => assetMap.Values.Where(it => it.GetType() == type).ToList();

        public IReadOnlyList<T> GetOtherAssetsOfSameType<T>(T self) => assetMap.Values.OfType<T>().Where(it => !it.Equals(self)).ToList();
        
        public void FixedUpdate() {
            foreach (var asset in assetList) asset.FixedUpdate();
            foreach (var graph in graphList) graph.FixedUpdate();
        }
        
        public void PreUpdate() {
            foreach (var asset in assetList) asset.PreUpdate();
            foreach (var graph in graphList) graph.PreUpdate();
        }

        public void Update() {
            foreach (var asset in assetList) asset.Update();
            foreach (var graph in graphList) graph.Update();
        }
        
        public void PostUpdate() {
            foreach (var asset in assetList) asset.PostUpdate();
            foreach (var graph in graphList) graph.PostUpdate();
        }

        public void LateUpdate() {
            foreach (var asset in assetList) asset.LateUpdate();
            foreach (var graph in graphList) graph.LateUpdate();
        }
        
        public void PostLateUpdate() {
            foreach (var asset in assetList) asset.PostLateUpdate();
            foreach (var graph in graphList) graph.PostLateUpdate();
        }
        
        public void EndOfFrame() {
            foreach (var asset in assetList) asset.EndOfFrame();
            foreach (var graph in graphList) graph.EndOfFrame();
        }
        
        public void OnDrawGizmos() {
            foreach (var asset in assetList) asset.OnDrawGizmos();
            foreach (var graph in graphList) graph.OnDrawGizmos();
        }
        
        public Asset AddAsset(string typeId) {
            return AddAssetToGroup(typeId, null);
        }
        
        public Asset AddAssetToGroup(string typeId, string group) {
            var typeMeta = Context.AssetTypeRegistry.GetTypeMeta(typeId);
            if (typeMeta.AssetType.singleton && assetList.Any(it => it.Type.AssetType.id == typeId)) {
                throw new Exception($"{typeMeta.Type.Name} is singleton, and an asset already exists");
            }
            var asset = Context.AssetTypeRegistry.CreateEntity(typeId);
            AddAssetToGroup(asset, group);
            UpdateNewAssetName(asset);
            return asset;
        }
        
        public T GetOrAddAsset<T>() where T : Asset {
            return (T) assetList.FirstOrDefault(it => it.GetType() == typeof(T)) ?? AddAsset<T>();
        }
        
        public T AddAsset<T>() where T : Asset {
            return AddAssetToGroup<T>(null);
        }

        public T AddAssetToGroup<T>(string group) where T : Asset {
            var typeMeta = Context.AssetTypeRegistry.GetTypeMeta(typeof(T));
            if (typeMeta.AssetType.singleton && assetList.Any(it => it.Type.AssetType.id == typeMeta.AssetType.id)) {
                throw new Exception($"{typeMeta.Type.Name} is singleton, and an asset already exists");
            }
            var asset = Context.AssetTypeRegistry.CreateEntity(typeof(T));
            AddAsset(asset);
            if (group != null && AssetHierarchy != null) {
                AssetHierarchy.AssignAtFirstLevel(asset.IdString, group);
            }
            EnsureAssetHierarchyIntegrity();
            UpdateNewAssetName(asset);
            return (T) asset;
        }
            

        public void AddAsset(Asset asset) {
            AddAssetToGroup(asset, null);
        }
        
        public void AddAssetToGroup(Asset asset, string group) {
            if (assetMap.ContainsKey(asset.Id)) {
                throw new Exception($"An asset with ID {asset.Id} already exists");
            }
            if (!asset.Created) {
                throw new ArgumentException($"Asset {asset.Id} has not been created yet");
            }
            if (Context.AssetTypeRegistry.GetTypeMeta(asset.GetType()).AssetType.singleton && assetList.Any(it => it.GetType() == asset.GetType())) {
                throw new Exception($"Asset type {asset.GetType().Name} is singleton, and an asset already exists");
            }
            
            asset.Scene = this;

            assetMap[asset.Id] = asset;
            assetList.Add(asset);

            if (group != null && AssetHierarchy != null) {
                AssetHierarchy.AssignAtFirstLevel(asset.IdString, group);
            }
            EnsureAssetHierarchyIntegrity();

            Debug.Log($"Added {asset.GetType().Name} asset {asset.Name} ({asset.Id})");
            Context.EventBus.Broadcast(new AssetAddEvent(asset));
        }

        public void UpdateNewAssetName(Asset asset) {
            asset.Name = asset.GenerateNextName(assetList, it => it.Name);
        }
        
        public Asset GetSelectedAsset() {
            if (!assetMap.ContainsKey(selectedAssetId)) {
                selectedAssetId = Guid.Empty;
                return null;
            }
            return assetMap[selectedAssetId];
        }

        public void SetSelectedAsset(Guid assetId) {
            if (!assetMap.ContainsKey(assetId) && assetId != Guid.Empty) {
                throw new Exception($"Asset {assetId} does not exist");
            }
            var previousSelectedAssetId = selectedAssetId;
            selectedAssetId = assetId;
            if (assetMap.ContainsKey(previousSelectedAssetId)) {
                assetMap[previousSelectedAssetId].OnSelectedStateChange.Invoke(false);
            }
            if (assetId != Guid.Empty) {
                assetMap[assetId].OnSelectedStateChange.Invoke(true);
            }
        }

        public Asset GetAsset(Guid id) {
            return assetMap.GetValueOrDefault(id);
        }

        public void RemoveAsset(Guid id) {
            var asset = assetMap.GetValueOrDefault(id);
            if (asset == null) throw new Exception($"Asset {id} does not exist");
            
            assetMap.Remove(id);
            assetList.Remove(asset);
            // Remove all references to it in scene and graph
            foreach (var otherAsset in assetList) {
                foreach (var (key, port) in otherAsset.DataInputPortCollection.GetPorts()) {
                    if (port.Type.GetKind() == TypeKind.Asset 
                        && asset.GetType().InheritsFrom(port.Type)
                        && ((Asset) port.Getter())?.Id == asset.Id) {
                        port.SetValue(null);
                        Context.Service?.BroadcastEntityDataInputPortValue(otherAsset.Id, key, port.SerializeValue());
                    }
                }
            }
            foreach (var (nodeId, node) in graphList.SelectMany(it => it.GetNodes())) {
                foreach (var (key, port) in node.DataInputPortCollection.GetPorts()) {
                    if (port.Type.GetKind() == TypeKind.Asset 
                        && asset.GetType().InheritsFrom(port.Type)
                        && ((Asset) port.Getter())?.Id == asset.Id) {
                        port.SetValue(null);
                        Context.Service?.BroadcastEntityDataInputPortValue(nodeId, key, port.SerializeValue());
                    }
                }
            }
            if (selectedAssetId == asset.Id) selectedAssetId = Guid.Empty;
            asset.Destroy();
            if (asset.Scene == this) asset.Scene = null;
            
            EnsureAssetHierarchyIntegrity();

            Context.Service?.BroadcastAssetRemoved(id);
            Debug.Log($"Removed asset {asset.Name} ({asset.GetType().Name})");
            
            Context.EventBus.Broadcast(new AssetRemoveEvent(asset));
        }

        public IReadOnlyDictionary<Guid, Graph> GetGraphs() => graphMap;
        
        public IReadOnlyList<Graph> GetGraphList() => graphList;

        public void AddGraph(Graph graph) {
            AddGraphToGroup(graph, "CUSTOM".Localized());
        }

        public void AddGraphToGroup(Graph graph, string group) {
            if (graphMap.ContainsKey(graph.Id)) {
                throw new Exception($"An graph with ID {graph.Id} already exists");
            }
            graphMap[graph.Id] = graph;
            graphList.Add(graph);
            graph.Scene = this;
            
            if (group != null && GraphHierarchy != null) {
                GraphHierarchy.AssignAtFirstLevel(graph.Id.ToString(), group);
            }
            EnsureGraphHierarchyIntegrity();
            Debug.Log($"Added graph {graph.Name} ({graph.Id})");
        }

        public Graph GetSelectedGraph() {
            if (!graphMap.ContainsKey(selectedGraphId)) {
                selectedGraphId = Guid.Empty;
                return null;
            }
            return graphMap[selectedGraphId];
        }

        public void SetSelectedGraph(Guid graphId) {
            if (!graphMap.ContainsKey(graphId) && graphId != Guid.Empty) {
                throw new Exception($"Graph {graphId} does not exist");
            }
            selectedGraphId = graphId;
        }

        public Graph GetGraph(Guid id) {
            return graphMap.GetValueOrDefault(id);
        }

        public void RemoveGraph(Guid id) {
            var graph = graphMap.GetValueOrDefault(id);
            if (graph == null) throw new Exception($"Graph {id} does not exist");

            graph.IsBeingRemoved = true;
            graph.Enabled = false;
            
            graphMap.Remove(id);
            graphList.Remove(graph);
            if (selectedGraphId == graph.Id) selectedGraphId = Guid.Empty;
            graph.Destroy();
            if (graph.Scene == this) graph.Scene = null;
            
            EnsureGraphHierarchyIntegrity();
            
            Debug.Log($"Removed graph {graph.Name} ({graph.GetType().Name})");
        }

        public void Destroy() {
            foreach (var it in assetList) {
                try {
                    it.Destroy();
                } catch (Exception e) {
                    Log.Error("Error while destroying asset " + it.Id, e);
                }
            }
            assetList.Clear();
            assetMap.Clear();
            foreach (var it in graphList) {
                try {
                    it.Destroy();
                } catch (Exception e) {
                    Log.Error("Error while destroying graph " + it.Id, e);
                }
            }
            graphList.Clear();
            graphMap.Clear();
        }

        public SerializedScene Serialize(bool includeTransientData = true) {
            return new SerializedScene {
                name = Name,
                appVersion = Application.version,
                assets = assetList.Select(it => it.Serialize()).Select(it => {
                    if (!includeTransientData) {
                        it.dataInputs = it.dataInputs
                            .Where(d => !d.Value.properties.transient)
                            .ToDictionary(kv => kv.Key, kv => kv.Value);
                    }
                    return it;
                }).ToList(),
                graphs = graphList.Select(it => it.Serialize()).Select(it => {
                    if (!includeTransientData) {
                        it.nodes = it.nodes
                            .Select(n => {
                                n.Value.dataInputs = n.Value.dataInputs
                                    .Where(d => !d.Value.properties.transient)
                                    .ToDictionary(kv => kv.Key, kv => kv.Value);
                                return n;
                            })
                            .ToDictionary(kv => kv.Key, kv => kv.Value);
                    }
                    return it;
                }).ToList(),
                plugins = Context.PluginManager.GetPlugins().ToDictionary(it => it.PluginId, it => new PluginSceneData {
                    version = it.GetTypeMeta().PluginType.version,
                    data = JsonConvert.SerializeObject(pluginData.GetValueOrDefault(it.PluginId))
                }),
                selectedAssetId = selectedAssetId,
                selectedGraphId = selectedGraphId,
                assetHierarchy = AssetHierarchy,
                graphHierarchy = GraphHierarchy
            };
        }

        public async UniTask Save() {
            await Context.SceneManager.SaveScene(Name, Serialize(false));
        }

        public async UniTask SaveAs(string newName) {
            await Context.SceneManager.SaveScene(newName, Serialize(false));
            Name = newName;
            Context.Service?.BroadcastOpenedScene();
        }
        
        public async UniTask Reload() {
            await Context.SceneManager.OpenScene(Name);
        }

        public async UniTask Restart() {
            var serializedScene = Serialize(false);
            await Context.Instance.OpenScene(serializedScene);
        }

        public Asset DeserializeAsset(SerializedAsset asset) {
            DeserializeAssets(new List<SerializedAsset> {asset});
            return GetAsset(asset.id);
        }

        public void DeserializeAssets(List<SerializedAsset> assets) {
            // Prevent circular references by serializing without data first
            foreach (var serializedAsset in assets) {
                try {
                    var asset = Context.AssetTypeRegistry.CreateEntity(serializedAsset.typeId);
                    asset.Scene = this;
                    asset.Store(serializedAsset.id);
                    AddAsset(asset);
                } catch (Exception e) {
                    Log.UserError($"Could not create asset {serializedAsset.name} ({serializedAsset.id}). Skipping", e);
                }
            }
            foreach (var serializedAsset in assets) {
                var asset = GetAsset(serializedAsset.id);
                if (GetAsset(serializedAsset.id) == null) continue;
                try {
                    asset.Deserialize(serializedAsset);
                } catch (Exception e) {
                    Log.UserError($"Could not deserialize data for asset {serializedAsset.name} ({serializedAsset.id})", e);
                }
            }
        }
        
        public Graph DeserializeGraph(SerializedGraph graph) {
            DeserializeGraphs(new List<SerializedGraph> {graph});
            return GetGraph(graph.id);
        }
        
        public void DeserializeGraphs(List<SerializedGraph> graphs) {
            foreach (var serializedGraph in graphs) {
                try {
                    var graph = new Graph();
                    graph.Scene = this;
                    graph.DeserializeNodes(serializedGraph);
                    AddGraph(graph);
                } catch (Exception e) {
                    Log.UserError($"Could not deserialize graph {serializedGraph.name} ({serializedGraph.id}). Skipping", e);
                }
            }
            foreach (var serializedGraph in graphs) {
                var graph = GetGraph(serializedGraph.id);
                if (graph == null) continue;
                foreach (var (id, serializedNode) in serializedGraph.nodes) {
                    var node = graph.GetNode(id);
                    if (node == null) continue;
                    try {
                        node.OnAllNodesDeserialized(serializedNode);
                    } catch (Exception e) {
                        Log.UserError($"An error occurred while calling OnAllNodesDeserialized for node {node.Name} ({node.Id})", e);
                    }
                }
                graph.DeserializeConnections(serializedGraph);
            }
        }

        public void Deserialize(SerializedScene serializedScene) {
            Name = serializedScene.name;
            serializedScene.plugins ??= new();
            pluginData = Context.PluginManager.GetPlugins().ToDictionary(it => it.PluginId, it => {
                // Have scene data type?
                if (it is not IUseSceneData useSceneData) return null;
                var sceneDataType = useSceneData.SceneDataType;

                if (!serializedScene.plugins.ContainsKey(it.PluginId)) {
                    return sceneDataType.DelegateForCtor().Invoke(Array.Empty<object>());
                }
                try {
                    return JsonConvert.DeserializeObject(serializedScene.plugins[it.PluginId].data, sceneDataType);
                } catch (Exception e) {
                    Log.UserError($"Could not deserialize scene data for plugin {it.PluginId}", e);
                    return sceneDataType.DelegateForCtor().Invoke(Array.Empty<object>());
                }
            });
            
            DeserializeAssets(serializedScene.assets);
            DeserializeGraphs(serializedScene.graphs);
            
            AssetHierarchy = serializedScene.assetHierarchy;
            GraphHierarchy = serializedScene.graphHierarchy;
            EnsureAssetHierarchyIntegrity();
            EnsureGraphHierarchyIntegrity();
            
            selectedAssetId = serializedScene.selectedAssetId;
            selectedGraphId = serializedScene.selectedGraphId;
        }

        public T GetPluginData<T>(string pluginId) {
            return (T) pluginData.GetValueOrDefault(pluginId);
        }
        
        public object GetPluginData(string pluginId) {
            return pluginData.GetValueOrDefault(pluginId);
        }

        internal void UpdateAssetsOrder() {
            assetList.Sort((a, b) => a.Order.CompareTo(b.Order));   
        }
        
        internal void UpdateGraphsOrder() {
            graphList.Sort((a, b) => a.Order.CompareTo(b.Order));
        }

        internal void EnsureAssetHierarchyIntegrity() {
            try {
                if (AssetHierarchy == null) {
                    AssetHierarchy = new HierarchyNode {
                        key = string.Empty,
                        children = new List<HierarchyNode>()
                    };
                    foreach (var asset in assetList) {
                        var key = asset.IdString;
                        var parent = asset.Type.AssetType.categoryId is null or "MISCELLANEOUS"
                            ? (asset.Type.AssetType.id == "778ab65f-8e11-44f1-ad85-28b7a12429f1" ? string.Empty : "MISCELLANEOUS".Localized())
                            : asset.Type.AssetType.categoryId.Localized();
                        AssetHierarchy.AssignAtFirstLevel(key, parent);
                    }
                    AssetHierarchy.children = AssetHierarchy.children
                        .OrderBy(it => AssetTypeRegistry.GetCategoryOrder(it.key))
                        .ThenBy(it => {
                            if (Guid.TryParse(it.key, out var id) && GetAsset(id) is {} asset) {
                                return asset.Order - 1000;
                            }
                            return 9999; // Categories always come last
                        }).ToList();
                    foreach (var node in AssetHierarchy.children) {
                        if (node.children == null) continue;
                        node.children = node.children.OrderBy(it => GetAsset(Guid.Parse(it.key)).Order).ToList();
                    }
                    return;
                }

                // Remove all children that no longer exist
                void RemoveRecursively(HierarchyNode node) {
                    if (node.children == null) return;
                    node.children.RemoveAll(it => it.children == null && assetList.All(asset => asset.IdString != it.key));
                    foreach (var child in node.children) {
                        RemoveRecursively(child);
                    }
                }

                RemoveRecursively(AssetHierarchy);
                // Add all children that are missing
                foreach (var asset in assetList) {
                    var parent = asset.Type.AssetType.categoryId is null or "MISCELLANEOUS"
                        ? "MISCELLANEOUS".Localized()
                        : asset.Type.AssetType.categoryId.Localized();
                    if (!AssetHierarchy.Exists(asset.Id.ToString())) {
                        AssetHierarchy.AssignAtFirstLevel(asset.Id.ToString(), parent);
                    }
                }
                // Ensure nodes with no children are at the start
                AssetHierarchy.children = AssetHierarchy.children.OrderBy(it => it.children == null ? 0 : 1).ToList();
                UpdateAssetsOrder();
                Context.ServiceMessageQueue.QueueAssetHierarchy();
            } catch (Exception e) {
                Log.Error("Asset hierarchy is corrupt, rebuilding", e);
                AssetHierarchy = null;
                EnsureAssetHierarchyIntegrity();
            }
        }
        
        internal void EnsureGraphHierarchyIntegrity() {
            try {
                if (GraphHierarchy == null) {
                    GraphHierarchy = new HierarchyNode {
                        key = string.Empty,
                        children = new List<HierarchyNode>()
                    };
                    var mocapCategory = new HierarchyNode {
                        key = "CATEGORY_MOTION_CAPTURE".Localized(),
                        children = new List<HierarchyNode>()
                    };
                    var inputCategory = new HierarchyNode {
                        key = "CATEGORY_INPUT".Localized(),
                        children = new List<HierarchyNode>()
                    };
                    var customCategory = new HierarchyNode {
                        key = "CUSTOM".Localized(),
                        children = new List<HierarchyNode>()
                    };

                    var characterAssets = assetList
                        .Where(it => it.Type.Id == "726ab674-a550-474e-8b92-66526a5ad55e").ToList();
                    Debug.Log("There are " + characterAssets.Count + " character assets");
                    foreach (var graph in graphList) {
                        if (characterAssets.Any(it => it.GetDataInput<string[]>("TrackingGraphIds").Contains(graph.Id.ToString()))) {
                            mocapCategory.children.Add(new HierarchyNode {
                                key = graph.Id.ToString(),
                            });
                        } else if (characterAssets.Any(it => it.GetDataInput<string>("ExpressionKeyBindingGraphId") == graph.Id.ToString())) {
                            inputCategory.children.Add(new HierarchyNode {
                                key = graph.Id.ToString(),
                            });
                        } else {
                            customCategory.children.Add(new HierarchyNode {
                                key = graph.Id.ToString(),
                            });
                        }
                    }
                    if (mocapCategory.children.Count > 0) {
                        GraphHierarchy.children.Add(mocapCategory);
                    }
                    if (inputCategory.children.Count > 0) {
                        GraphHierarchy.children.Add(inputCategory);
                    }
                    if (customCategory.children.Count > 0) {
                        GraphHierarchy.children.Add(customCategory);
                    }
                    return;
                }

                // Remove all children that no longer exist
                void RemoveRecursively(HierarchyNode node) {
                    if (node.children == null) return;
                    node.children.RemoveAll(it => it.children == null && graphList.All(graph => graph.Id.ToString() != it.key));
                    foreach (var child in node.children) {
                        RemoveRecursively(child);
                    }
                }

                RemoveRecursively(GraphHierarchy);
                // Add all children that are missing
                foreach (var graph in graphList) {
                    if (!GraphHierarchy.Exists(graph.Id.ToString())) {
                        GraphHierarchy.AssignAtFirstLevel(graph.Id.ToString(), "CUSTOM".Localized());
                    }
                }
                // Ensure nodes with no children are at the start
                GraphHierarchy.children = GraphHierarchy.children.OrderBy(it => it.children == null ? 0 : 1).ToList();
                UpdateGraphsOrder();
                Context.ServiceMessageQueue.QueueGraphHierarchy();
            } catch (Exception e) {
                Log.Error("Graph hierarchy is corrupt, rebuilding", e);
                GraphHierarchy = null;
                EnsureGraphHierarchyIntegrity();
            }
        }
    }
}
