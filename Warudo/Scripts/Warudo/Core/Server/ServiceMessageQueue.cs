using System;
using System.Collections.Generic;
using UnityEngine;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Scenes;
using Warudo.Core.Serializations;

namespace Warudo.Core.Server {
    public class ServiceMessageQueue {
        public TimeSpan UpdateInterval { get; set; } = TimeSpan.FromSeconds(1 / 60.0);

        private float lastUpdateTime;
        private readonly FrameUpdate frameUpdate = new();

        private readonly HashSet<ISerializableEntity> queuedEntities = new();
        private readonly List<(Entity, string)> queuedEntityData = new();
        private readonly List<(Entity, string)> queuedEntityDataInputProperties = new();
        private readonly List<(IFlowEntity, string)> queuedEntityDataOutputProperties = new();
        private readonly List<(Entity, string)> queuedEntityTriggerProperties = new();
        private readonly List<ICollapsibleStructuredData> queuedStructuredDataHeaders = new();
        private readonly List<Asset> queuedAssetActiveStates = new();
        private readonly Dictionary<string, string> queuedMessages = new();
        private bool queuedAssetHierarchy;
        private bool queuedGraphHierarchy;

        public void QueueEntity(ISerializableEntity entity) {
            queuedEntities.Add(entity);
        }

        public void QueueEntityDataInput(Entity entity, string dataPort) {
            queuedEntityData.Add((entity, dataPort));
        }
        
        public void QueueEntityDataInputProperties(Entity entity, string dataPort) {
            queuedEntityDataInputProperties.Add((entity, dataPort));
        }
        
        public void QueueEntityDataOutputProperties(IFlowEntity entity, string dataPort) {
            queuedEntityDataOutputProperties.Add((entity, dataPort));
        }
        
        public void QueueEntityTriggerProperties(Entity entity, string triggerPort) {
            queuedEntityTriggerProperties.Add((entity, triggerPort));
        }
        
        public void QueueEntityHeader(ICollapsibleStructuredData structuredData) {
            queuedStructuredDataHeaders.Add(structuredData);
        }
        
        public void QueueAssetActiveState(Asset asset) {
            queuedAssetActiveStates.Add(asset);
        }
        
        public void QueueMessage(string message, string data) {
            queuedMessages[message] = data;
        }

        public void QueueAssetHierarchy() {
            queuedAssetHierarchy = true;
        }
        
        public void QueueGraphHierarchy() {
            queuedGraphHierarchy = true;
        }
        
        public void Clear() {
            queuedEntities.Clear();
            queuedEntityData.Clear();
            queuedEntityDataInputProperties.Clear();
            queuedStructuredDataHeaders.Clear();
            queuedAssetActiveStates.Clear();
            queuedMessages.Clear();
            queuedAssetHierarchy = false;
            queuedGraphHierarchy = false;
        }

        public void Update() {
            if (Time.realtimeSinceStartup - lastUpdateTime < UpdateInterval.TotalSeconds) {
                return;
            }
            lastUpdateTime = Time.realtimeSinceStartup;

            if (Context.Service == null) return;
            
            if (queuedAssetHierarchy) {
                Context.Service.BroadcastAssetHierarchy();
                queuedAssetHierarchy = false;
            }
            if (queuedGraphHierarchy) {
                Context.Service.BroadcastGraphHierarchy();
                queuedGraphHierarchy = false;
            }
            
            foreach (var e in queuedEntities) {
                var serializedEntity = e.Serialize();
                serializedEntity.Localize();
                frameUpdate.entities.Add(new { entity = serializedEntity, entityType = serializedEntity switch {
                    SerializedAsset => "Asset",
                    SerializedNode => "Node",
                    SerializedPlugin => "Plugin",
                    SerializedStructuredData => "StructuredData",
                    _ => throw new Exception("Unknown entity type")
                }});
            }
            queuedEntities.Clear();
            
            foreach (var (entity, portKey) in queuedEntityData) {
                var port = entity.GetDataInputPort(portKey);
                if (port == null) continue;
                
                if (!frameUpdate.entityData.TryGetValue(entity.Id, out var portValues)) {
                    portValues = new Dictionary<string, string>();
                    frameUpdate.entityData.Add(entity.Id, portValues);
                }
                portValues[portKey] = port.SerializeValue();
            }
            queuedEntityData.Clear();
            
            foreach (var (entity, portKey) in queuedEntityDataInputProperties) {
                var port = entity.GetDataInputPort(portKey);
                if (port == null) continue;
                
                if (!frameUpdate.entityDataInputProperties.TryGetValue(entity.Id, out var portValues)) {
                    portValues = new Dictionary<string, DataInputProperties>();
                    frameUpdate.entityDataInputProperties.Add(entity.Id, portValues);
                }
                portValues[portKey] = port.Properties.Clone();
            }
            queuedEntityDataInputProperties.Clear();
            
            foreach (var (entity, portKey) in queuedEntityDataOutputProperties) {
                var port = entity.GetDataOutputPort(portKey);
                if (port == null) continue;
                
                if (!frameUpdate.entityDataOutputProperties.TryGetValue(entity.Id, out var portValues)) {
                    portValues = new Dictionary<string, DataOutputProperties>();
                    frameUpdate.entityDataOutputProperties.Add(entity.Id, portValues);
                }
                portValues[portKey] = port.Properties.Clone();
            }
            queuedEntityDataOutputProperties.Clear();
            
            foreach (var (entity, portKey) in queuedEntityTriggerProperties) {
                var port = entity.GetTriggerPort(portKey);
                if (port == null) continue;
                
                if (!frameUpdate.entityTriggerProperties.TryGetValue(entity.Id, out var portValues)) {
                    portValues = new Dictionary<string, TriggerProperties>();
                    frameUpdate.entityTriggerProperties.Add(entity.Id, portValues);
                }
                portValues[portKey] = port.Properties.Clone();
            }
            queuedEntityTriggerProperties.Clear();
            
            foreach (var entity in queuedStructuredDataHeaders) {
                frameUpdate.structuredDataHeaders[entity.Id] = entity.GetHeader();
            }
            queuedStructuredDataHeaders.Clear();
            
            foreach (var asset in queuedAssetActiveStates) {
                frameUpdate.assetActiveStates[asset.Id] = asset.Active;
            }
            queuedAssetActiveStates.Clear();
            
            foreach (var (message, data) in queuedMessages) {
                frameUpdate.messages[message] = data;
            }
            queuedMessages.Clear();
            
            if (frameUpdate.entities.Count == 0
                && frameUpdate.entityData.Count == 0
                && frameUpdate.entityDataInputProperties.Count == 0
                && frameUpdate.entityDataOutputProperties.Count == 0
                && frameUpdate.entityTriggerProperties.Count == 0
                && frameUpdate.structuredDataHeaders.Count == 0
                && frameUpdate.assetActiveStates.Count == 0
                && frameUpdate.messages.Count == 0) {
                return;
            }
            
            Context.Service.BroadcastFrameUpdate(frameUpdate);
            
            frameUpdate.entities.Clear();
            frameUpdate.entityData.Clear();
            frameUpdate.entityDataInputProperties.Clear();
            frameUpdate.entityDataOutputProperties.Clear();
            frameUpdate.entityTriggerProperties.Clear();
            frameUpdate.structuredDataHeaders.Clear();
            frameUpdate.assetActiveStates.Clear();
            frameUpdate.messages.Clear();
        }
    }

    [Serializable]
    public class FrameUpdate {
        public readonly List<object> entities = new();
        public readonly Dictionary<Guid, Dictionary<string, string>> entityData = new();
        public readonly Dictionary<Guid, Dictionary<string, DataInputProperties>> entityDataInputProperties = new();
        public readonly Dictionary<Guid, Dictionary<string, DataOutputProperties>> entityDataOutputProperties = new();
        public readonly Dictionary<Guid, Dictionary<string, TriggerProperties>> entityTriggerProperties = new();
        public readonly Dictionary<Guid, string> structuredDataHeaders = new();
        public readonly Dictionary<Guid, bool> assetActiveStates = new();
        public readonly Dictionary<string, string> messages = new();
    }
}
