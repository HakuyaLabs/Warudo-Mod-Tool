using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Plugins;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Events;

namespace Warudo.Core.Scenes {
    public sealed class AssetTypeRegistry : EntityTypeRegistry<Asset, AssetTypeMeta, AssetTypeCheckpoint> {
        protected override AssetTypeMeta CreateMeta(string id, Type type) {
            var meta = base.CreateMeta(id, type);
            
            meta.AssetType = new AssetType {
                userModifiable = true,
                singleton = false
            };
            var assetTypeAttribute = type.GetCustomAttribute<AssetTypeAttribute>();
            if (assetTypeAttribute != null) {
                meta.AssetType.id = assetTypeAttribute.Id;
                meta.AssetType.title = assetTypeAttribute.Title;
                meta.AssetType.category = assetTypeAttribute.Category;
                meta.AssetType.categoryId = assetTypeAttribute.Category;
                meta.AssetType.categoryOrder = assetTypeAttribute.CategoryOrder;
                meta.AssetType.userModifiable = assetTypeAttribute.UserModifiable;
                meta.AssetType.singleton = assetTypeAttribute.Singleton;
                meta.AssetType.supportedRenderingPipelines = assetTypeAttribute.SupportedRenderingPipelines;
            }
            if (meta.AssetType.id == null) {
                throw new Exception($"Asset type {type.FriendlyFullName()} does not have an ID");
            }
            meta.AssetType.title ??= type.Name.ToSpacedPascalCase();
            
            return meta;
        }
        
        public AssetTypeMeta RegisterType(Type type) {
            var attribute = type.GetCustomAttribute<AssetTypeAttribute>();
            if (attribute == null) {
                throw new Exception($"Asset type {type.FriendlyFullName()} does not have an ID");
            }
            var meta = base.RegisterType(attribute.Id, type);
            DataConverters.RegisterGenericConverter(type, typeof(Asset), new IdentityConverter());
            Context.EventBus.Broadcast(new AssetTypeRegisteredEvent(type));
            return meta;
        }

        public override void UnregisterType(string id) {
            if (Context.OpenedScene != null) {
                var currentAssets = Context.OpenedScene.GetAssets()
                    .Values
                    .Where(it => it.Type.AssetType.id == id).ToList();
                foreach (var currentAsset in currentAssets) {
                    Context.OpenedScene.RemoveAsset(currentAsset.Id);
                }
            }
            base.UnregisterType(id);
        }

        public override AssetTypeCheckpoint CreateTypeCheckpoint(string id) {
            var checkpoint = new AssetTypeCheckpoint {Id = id};
            
            if (Context.OpenedScene != null) {
                var existingAssets = Context.OpenedScene.GetAssets()
                    .Values
                    .Where(it => it.Type.AssetType.id == id)
                    .ToList();

                foreach (var existingAsset in existingAssets) {
                    foreach (var (assetId, asset) in Context.OpenedScene.GetAssets()) {
                        foreach (var (_, port) in asset.DataInputPortCollection.GetPorts()) {
                            if (port.Type.GetKind() == TypeKind.Asset 
                                && existingAsset.GetType().InheritsFrom(port.Type)
                                && ((Asset) port.Getter())?.Id == asset.Id) {
                                checkpoint.AssetReferrers.Add((assetId, port.Key, existingAsset.Id));
                            }
                        }
                    }
                    foreach (var (graphId, graph) in Context.OpenedScene.GetGraphs()) {
                        foreach (var (nodeId, node) in graph.GetNodes()) {
                            foreach (var (_, port) in node.DataInputPortCollection.GetPorts()) {
                                if (port.Type.GetKind() == TypeKind.Asset 
                                    && existingAsset.GetType().InheritsFrom(port.Type)
                                    && ((Asset) port.Getter())?.Id == existingAsset.Id) {
                                    checkpoint.NodeReferrers.Add((graphId, nodeId, port.Key, existingAsset.Id));
                                }
                            }
                        }
                    }
                    checkpoint.SerializedAssets.Add(existingAsset.Serialize());
                }
            }

            return checkpoint;
        }
        
        public override void RestoreTypeCheckpoint(AssetTypeCheckpoint checkpoint) {
            // Restore assets and references
            if (Context.OpenedScene == null) return;
            Context.OpenedScene.DeserializeAssets(checkpoint.SerializedAssets);
            foreach (var (refererId, port, referenceId) in checkpoint.AssetReferrers) {
                var referer = Context.OpenedScene.GetAsset(refererId);
                var reference = Context.OpenedScene.GetAsset(referenceId);
                referer.DataInputPortCollection.SetPortValue(port, reference);
            }
            foreach (var (refererGraphId, refererNodeId, port, referenceId) in checkpoint.NodeReferrers) {
                var refererGraph = Context.OpenedScene.GetGraph(refererGraphId);
                var refererNode = refererGraph.GetNode(refererNodeId);
                var reference = Context.OpenedScene.GetAsset(referenceId);
                refererNode.DataInputPortCollection.SetPortValue(port, reference);
            }
        }

        public override Asset CreateEntity(string id, Action<Asset> initializer = null) {
            var asset = base.CreateEntity(id, initializer);
            asset.Type = GetTypeMeta(id);
            asset.Scene = Context.OpenedScene;
            return asset;
        }

        public SerializedAssetTypeList Serialize() {
            return new SerializedAssetTypeList {
                categories = RegisteredTypes.Values
                    .Select(it => it.AssetType)
                    .Where(it => it.supportedRenderingPipelines == null || it.supportedRenderingPipelines.Contains(Context.RenderingPipelineManager.CurrentPipeline))
                    .GroupBy(it => it.category)
                    .Select(it => new SerializedAssetTypeList.Category {
                        name = it.Key,
                        assetTypes = it.Select(assetType => assetType.Clone()).OrderBy(x => x.categoryOrder).ToList()
                        })
                    .OrderBy(category => GetCategoryOrder(category.name))
                    .ToList()
            };
        }
        
        public static int GetCategoryOrder(string categoryId) {
            return categoryId switch {
                "CATEGORY_INPUT" => -1,
                "CATEGORY_CHARACTERS" => 0,
                "CATEGORY_PROP" => 1,
                "CATEGORY_ACCESSORIES" => 2,
                "CATEGORY_ENVIRONMENTS" => 3,
                "CATEGORY_CINEMATOGRAPHY" => 4,
                "CATEGORY_EXTERNAL_INTEGRATION" => 5,
                "CATEGORY_MOTION_CAPTURE" => 6,
                "MISCELLANEOUS" or null or "" => 9999,
                _ => 9998,
            };
        }
    }
    
    public class AssetTypeMeta : EntityTypeMeta {
        public Plugin OwnerPlugin;
        public AssetType AssetType;
    }
    
    public class AssetTypeCheckpoint : TypeCheckpoint {
        public readonly List<SerializedAsset> SerializedAssets = new();
            
        // References to the asset type in scene and graph
        public readonly List<(Guid refererId, string port, Guid referenceId)> AssetReferrers = new();
        public readonly List<(Guid refererGraphId, Guid refererNodeId, string port, Guid referenceId)> NodeReferrers = new();
    }
}
