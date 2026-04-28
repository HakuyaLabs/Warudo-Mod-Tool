using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Plugins;
using Warudo.Core.Scenes;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;

namespace Warudo.Core.Data {
    public sealed class PluginTypeRegistry : EntityTypeRegistry<Plugin, PluginTypeMeta, PluginTypeCheckpoint> {

        protected override PluginTypeMeta CreateMeta(string id, Type type) {
            var meta = base.CreateMeta(id, type);
            meta.Type = type;
            
            meta.PluginType = new PluginType();
            var pluginTypeAttribute = type.GetCustomAttribute<PluginTypeAttribute>();
            if (pluginTypeAttribute != null) {
                meta.PluginType.id = pluginTypeAttribute.Id;
                meta.PluginType.name = pluginTypeAttribute.Name;
                meta.PluginType.description = pluginTypeAttribute.Description;
                meta.PluginType.author = pluginTypeAttribute.Author;
                meta.PluginType.version = pluginTypeAttribute.Version == "WARUDO_VERSION" ? Application.version : pluginTypeAttribute.Version;
                meta.PluginType.icon = pluginTypeAttribute.Icon;
                meta.PluginType.supportUrl = pluginTypeAttribute.SupportUrl;
                if (pluginTypeAttribute.AssetTypes != null) meta.AssetTypes.AddRange(pluginTypeAttribute.AssetTypes);
                if (pluginTypeAttribute.NodeTypes != null) meta.NodeTypes.AddRange(pluginTypeAttribute.NodeTypes);
            }
            if (meta.PluginType.id == null) {
                throw new Exception($"Plugin type {type.FriendlyFullName()} does not have an ID");
            }
            meta.PluginType.name ??= type.Name.ToSpacedPascalCase();
            
            return meta;
        }

        public override void UnregisterType(string id) {
            var plugin = Context.PluginManager.GetPlugin(id);
            if (plugin != null) {
                Context.PluginManager.DisablePlugin(plugin);
            }
            base.UnregisterType(id);
        }
        
        public override PluginTypeCheckpoint CreateTypeCheckpoint(string id) {
            var checkpoint = new PluginTypeCheckpoint {Id = id};

            var meta = GetTypeMeta(id);
            var plugin = Context.PluginManager.GetPlugin(id);
            if (plugin != null) {
                checkpoint.SerializedPlugin = plugin.Serialize();
                
                // Checkpoint node types first - important, because nodes may reference assets, but not vice versa
                checkpoint.NodeTypeCheckpoints = meta.NodeTypes
                    .Select(it => Context.NodeTypeRegistry.GetTypeMeta(it) == null ? null : Context.NodeTypeRegistry.CreateTypeCheckpoint(Context.NodeTypeRegistry.GetTypeMeta(it).NodeType.id))
                    .Where(it => it != null)
                    .ToList();
                checkpoint.AssetTypeCheckpoints = meta.AssetTypes
                    .Select(it => Context.AssetTypeRegistry.GetTypeMeta(it) == null ? null : Context.AssetTypeRegistry.CreateTypeCheckpoint(Context.AssetTypeRegistry.GetTypeMeta(it).AssetType.id))
                    .Where(it => it != null)
                    .ToList();
            }

            return checkpoint;
        }

        public override void RestoreTypeCheckpoint(PluginTypeCheckpoint checkpoint) {
            // Restore assets and nodes
            var plugin = Context.PluginManager.GetPlugin(checkpoint.Id);
            if (plugin != null && checkpoint.SerializedPlugin != null) {
                plugin.Deserialize(checkpoint.SerializedPlugin);
                // Aggregate asset type checkpoints into one single checkpoint, then restore, because assets may refer to each other
                var aggregateAssetTypeCheckpoint = new AssetTypeCheckpoint();
                foreach (var assetTypeCheckpoint in checkpoint.AssetTypeCheckpoints) {
                    aggregateAssetTypeCheckpoint.SerializedAssets.AddRange(assetTypeCheckpoint.SerializedAssets);
                    aggregateAssetTypeCheckpoint.AssetReferrers.AddRange(assetTypeCheckpoint.AssetReferrers);
                }
                Context.AssetTypeRegistry.RestoreTypeCheckpoint(aggregateAssetTypeCheckpoint);
               
                // Similarly, aggregate node type checkpoints into one single checkpoint, then restore
                var aggregateNodeTypeCheckpoint = new NodeTypeCheckpoint();
                foreach (var nodeTypeCheckpoint in checkpoint.NodeTypeCheckpoints) {
                    aggregateNodeTypeCheckpoint.SerializedNodes.AddRange(nodeTypeCheckpoint.SerializedNodes);
                }

                Context.NodeTypeRegistry.RestoreTypeCheckpoint(aggregateNodeTypeCheckpoint);
                
                // Restore node referrers that depend on replaced asset types last
                aggregateAssetTypeCheckpoint = new AssetTypeCheckpoint();
                foreach (var assetTypeCheckpoint in checkpoint.AssetTypeCheckpoints) {
                    aggregateAssetTypeCheckpoint.NodeReferrers.AddRange(assetTypeCheckpoint.NodeReferrers);
                }

                Context.AssetTypeRegistry.RestoreTypeCheckpoint(aggregateAssetTypeCheckpoint);
            }
        }

        public override Plugin CreateEntity(string id, Action<Plugin> initializer = null) {
            var plugin = base.CreateEntity(id, initializer);
            plugin.Type = GetTypeMeta(id);
            return plugin;
        }
    }
    
    public class PluginTypeMeta : EntityTypeMeta {
        public PluginType PluginType;
        public List<Type> AssetTypes = new();
        public List<Type> NodeTypes = new();
    }

    public class PluginTypeCheckpoint : TypeCheckpoint {
        public SerializedPlugin SerializedPlugin;
        public List<AssetTypeCheckpoint> AssetTypeCheckpoints = new();
        public List<NodeTypeCheckpoint> NodeTypeCheckpoints = new();
    }
}
