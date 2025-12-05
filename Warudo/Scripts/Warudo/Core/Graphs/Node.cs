using System;
using UnityEngine;
using Warudo.Core.Data;
using Warudo.Core.Plugins;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;

namespace Warudo.Core.Graphs {
    public abstract class Node : FlowEntity<NodeTypeMeta, SerializedNode> {
        public string Name { get; set; }
        
        public Graph Graph { get; set; }

        public Vector2 GraphPosition { get; set; }

        public Plugin Plugin => Type.OwnerPlugin;

        public void InvokeFlow(string key, bool invokeWhenDisabled = false) {
            Graph.InvokeFlow(this, key, invokeWhenDisabled);
        }
        
        public override bool CanReceiveEvents => Graph != null && Graph.Enabled;

        public override bool ShouldEvaluateClientFunctions => Context.OpenedScene != null && Context.OpenedScene.GetSelectedGraph() == Graph && base.ShouldEvaluateClientFunctions;

        public override NodeTypeMeta GetTypeMeta() => Context.NodeTypeRegistry.GetTypeMeta(GetType()) ?? throw new Exception($"{GetType()} is not registered as a node type");
        
        protected override void Define(NodeTypeMeta meta) {
            Define(meta.DataInputs, meta.Triggers, meta.Mixins, this);
            Define(meta.DataOutputs, meta.FlowInputs, meta.FlowOutputs); 
            Name ??= meta.NodeType.title;
        }
        
        public override SerializedNode Serialize() {
            return new SerializedNode {
                id = Id,
                typeId = Type.NodeType.id,
                name = Name,
                version = GetVersion(),
                dataInputs = DataInputPortCollection.Serialize(),
                dataOutputs = DataOutputPortCollection.Serialize(),
                flowInputs = FlowInputPortCollection.Serialize(),
                flowOutputs = FlowOutputPortCollection.Serialize(),
                triggers = TriggerPortCollection.Serialize(),
                x = GraphPosition.x,
                y = GraphPosition.y
            };
        }
       
        public override void Deserialize(SerializedNode serialized) {
            if (Graph == null) {
                throw new ArgumentNullException(nameof(Graph));
            }
            
            Store(serialized.id);

            if (serialized.version != GetVersion()) {
                Debug.Log($"Node {GetType().Name} was serialized with version {serialized.version} but current version is {GetVersion()}. There may be compatibility issues.");
            }

            // Name = serialized.name; // TODO: Make a "custom name" instead, since names are localized
            GraphPosition = new Vector2(serialized.x, serialized.y);

            if (serialized.dataInputs != null) {
                foreach (var (key, serializedPort) in serialized.dataInputs) {
                    var port = DataInputPortCollection.GetPort(key);
                    if (port == null) {
                        // Debug.LogWarning($"{GetType().Name}::{key} was serialized but this port no longer exists. Skipping deserialization.");
                        continue;
                    }
                    if (port.Properties.transient) {
                        continue;
                    }

                    try {
                        // TODO: Remove? e.g. enums / structured data can be deserialized even if type changed
                        
                        // var dataType = Context.TypeRegistry.GetType(serializedPort.type);
                        // if (dataType == null) {
                        //     throw new Exception($"Cannot find data type {serializedPort.type} for {GetType().Name}::{key}. Does it belong to a plugin that is not currently loaded?");
                        // }
                        //
                        // if (dataType != port.Type && ) {
                        //     throw new Exception($"Serialized data type {serializedPort.type} does not match actual data type {port.Type.FriendlyFullName()}");
                        // }

                        port.SetSerializedValue(serializedPort.value, Graph.Scene, this);
                    } catch (Exception e) {
                        Log.UserError($"Failed to set data input port value for node {GetType().Name}::{port.Key} = {serializedPort.value}", e);
                    }
                }
            }
        }
        
        public virtual void OnAllNodesDeserialized(SerializedNode serialized) {
        }
        
        public override void Broadcast() {
            // Do not broadcast if this node is not added to a graph/scene
            if (Graph == null) {
                return;
            }
            base.Broadcast();
        }

        public override FlowOutputPort AddFlowOutputPort(string key, FlowOutputProperties properties = null) {
            var port = base.AddFlowOutputPort(key, properties);
            if (port == null) return null;

            if (Graph != null) {
                var outputFlowConnections = Graph.GetOutputFlowConnections(this);
                if (outputFlowConnections != null && outputFlowConnections.TryGetValue(key, out var flowConnection)) {
                    // Re-add flow connection to set continuation
                    Graph.RemoveFlowConnection(flowConnection);
                    Graph.AddFlowConnection(new FlowConnection(flowConnection.OutputNode, flowConnection.InputNode, port, flowConnection.InputPort));
                }
            }

            return port;
        }
        
        public virtual void OnUserAddToScene() {
        }
    }
}
