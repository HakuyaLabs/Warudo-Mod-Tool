using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using Warudo.Core.Plugins;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;

namespace Warudo.Core.Data {
	public sealed class NodeTypeRegistry : EntityTypeRegistry<Node, NodeTypeMeta, NodeTypeCheckpoint> {
		private bool restorationQueued;

		public override NodeTypeMeta RegisterType(string id, Type type) {
			var meta = base.RegisterType(id, type);
			if (Context.OpenedScene != null && !restorationQueued) {
				restorationQueued = true;
				// OwnerPlugin and the remaining types are assigned by the caller
				// before the next player-loop turn.
				UniTask.Post(() => { restorationQueued = false; RestoreAvailableTypes(); });
			}
			return meta;
		}

		public void RestoreAvailableTypes() {
			if (Context.OpenedScene == null) return;
			foreach (var graph in Context.OpenedScene.GetGraphs().Values.ToList()) {
				foreach (var placeholder in graph.GetNodes().Values.OfType<PlaceholderNode>().ToList()) {
					if (!IsTypeRegistered(placeholder.OriginalTypeId)) continue;
					try { graph.ReplaceNode(placeholder, placeholder.GetSnapshot()); }
					catch (Exception e) { Log.UserError("Could not restore placeholder node " + placeholder.Id, e); }
				}
			}
		}

		protected override NodeTypeMeta CreateMeta(string id, Type type) {
			var meta = base.CreateMeta(id, type);
			
			meta.NodeType = new NodeType();
			var nodeTypeAttribute = type.GetCustomAttribute<NodeTypeAttribute>();
			if (nodeTypeAttribute != null) {
				meta.NodeType.id = nodeTypeAttribute.Id;
				meta.NodeType.title = nodeTypeAttribute.Title;
				meta.NodeType.category = nodeTypeAttribute.Category;
				meta.NodeType.categoryId = nodeTypeAttribute.Category;
			}
			if (meta.NodeType.id == null) {
				throw new Exception($"Node type {type.FriendlyFullName()} does not have an ID");
			}
			meta.NodeType.title ??= type.Name.ToSpacedPascalCase();
			meta.NodeType.searchHint ??= meta.NodeType.category + ";" + type.Name + ";" + meta.NodeType.title + ";" + Context.LocalizationManager.GetLocalizedString(meta.NodeType.title, "en");
			meta.NodeType.width = nodeTypeAttribute?.Width ?? 1f;
			
			foreach (var fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)) {
				var flowOutputPortTypeMeta = FlowOutputPort.GetReflectionMeta(fieldInfo);
				if (flowOutputPortTypeMeta != null) {
					meta.FlowOutputs.Add(flowOutputPortTypeMeta);
				}
			}
			foreach (var methodInfo in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)) {
				var dataOutputPortTypeMeta = DataOutputPort.GetReflectionMeta(methodInfo);
				if (dataOutputPortTypeMeta != null) {
					meta.DataOutputs.Add(dataOutputPortTypeMeta);
				}
				
				var flowInputPortTypeMeta = FlowInputPort.GetReflectionMeta(methodInfo);
				if (flowInputPortTypeMeta != null) {
					meta.FlowInputs.Add(flowInputPortTypeMeta);
				}
			}
			
			return meta;
		}

		public NodeTypeMeta RegisterType(Type type) {
			var attribute = type.GetCustomAttribute<NodeTypeAttribute>();
			if (attribute == null) {
				throw new Exception($"Node type {type.FriendlyFullName()} does not have an ID");
			}
			var meta = RegisterType(attribute.Id, type);
			return meta;
		}

		public override void UnregisterType(string id) {
			if (Context.OpenedScene != null) {
				foreach (var (_, graph) in Context.OpenedScene.GetGraphs()) {
					var currentNodes = graph.GetNodes().Values.Where(it => it.Type.NodeType.id == id
						|| it is PlaceholderNode placeholder && placeholder.OriginalTypeId == id).ToList();
					foreach (var currentNode in currentNodes) {
						var snapshot = currentNode.Serialize();
						SerializedEntitySnapshot.StripTransient(snapshot);
						graph.ReplaceNode(currentNode, snapshot, true);
					}
				}
			}
			base.UnregisterType(id);
		}

		public override NodeTypeCheckpoint CreateTypeCheckpoint(string id) {
			var checkpoint = new NodeTypeCheckpoint {Id = id, EntitiesRetained = true};
            
			if (Context.OpenedScene != null) {
				foreach (var (graphId, graph) in Context.OpenedScene.GetGraphs()) {
					var existingNodes = graph.GetNodes()
						.Values
						.Where(it => it.Type.NodeType.id == id)
						.ToList();
					var inputDataConnections = graph.GetInputDataConnections();
					var outputFlowConnections = graph.GetOutputFlowConnections();
						
					foreach (var existingNode in existingNodes) {
						var dataConnections = inputDataConnections
							.SelectMany(it => it.Value.SelectMany(k => k.Value))
							.Where(it => it.InputNode == existingNode || it.OutputNode == existingNode)
							.Select(it => it.Serialize())
							.ToList();
						var flowConnections = outputFlowConnections
							.SelectMany(it => it.Value.Values)
							.Where(it => it.InputNode == existingNode || it.OutputNode == existingNode)
							.Select(it => it.Serialize())
							.ToList();
							
						checkpoint.SerializedNodes.Add((graphId, existingNode.Serialize(), flowConnections, dataConnections));
					}
				}
			}

			return checkpoint;
		}

		public override void RestoreTypeCheckpoint(NodeTypeCheckpoint checkpoint) {
			if (Context.OpenedScene == null) return;
			var recreated = new HashSet<(Guid graphId, Guid nodeId)>();
			// Restore nodes and connections
			foreach (var (graphId, serializedNode, _, _) in checkpoint.SerializedNodes) {
				var graph = Context.OpenedScene.GetGraph(graphId);
				if (graph == null) continue;
				try {
					// The live placeholder is authoritative: it may have been moved,
					// rewired or deleted since the checkpoint was captured.
					var existing = graph.GetNode(serializedNode.id);
					if (existing is PlaceholderNode placeholder && IsTypeRegistered(placeholder.OriginalTypeId)) {
						graph.ReplaceNode(placeholder, placeholder.GetSnapshot());
					} else if (existing == null && !checkpoint.EntitiesRetained) {
						graph.DeserializeNode(serializedNode);
						recreated.Add((graphId, serializedNode.id));
					}
				} catch (Exception e) {
					Log.UserError($"Could not deserialize node {serializedNode.id}. Skipping", e);
				}
			}
			foreach (var (graphId, serializedNode, _, _) in checkpoint.SerializedNodes) {
				if (!recreated.Contains((graphId, serializedNode.id))) continue;
				var graph = Context.OpenedScene.GetGraph(graphId);
				if (graph == null) continue;
				try {
					var node = graph.GetNode(serializedNode.id);
					if (node == null) continue;
					node.OnAllNodesDeserialized(serializedNode);
				} catch (Exception e) {
					Log.UserError($"An error occurred while calling OnAllNodesDeserialized for node {serializedNode.name} ({serializedNode.id})", e);
				}
			}
			foreach (var (graphId, _, flowConnections, dataConnections) in checkpoint.SerializedNodes) {
				var graph = Context.OpenedScene.GetGraph(graphId);
				if (graph == null) continue;
				foreach (var flowConnection in flowConnections) {
					if (!recreated.Contains((graphId, flowConnection.inputNode)) && !recreated.Contains((graphId, flowConnection.outputNode))) continue;
					try {
						graph.DeserializeFlowConnection(flowConnection);
					} catch (Exception e) {
						Log.UserError($"Could not deserialize flow connection from node {flowConnection.outputNode} to node {flowConnection.inputNode}. Skipping", e);
					}
				}
				foreach (var dataConnection in dataConnections) {
					if (!recreated.Contains((graphId, dataConnection.inputNode)) && !recreated.Contains((graphId, dataConnection.outputNode))) continue;
					try {
						graph.DeserializeDataConnection(dataConnection);
					} catch (Exception e) {
						Log.UserError($"Could not deserialize data connection from node {dataConnection.outputNode} to node {dataConnection.inputNode}. Skipping", e);
					}
				}
			}
		}

		public override Node CreateEntity(string id, Action<Node> initializer = null) {
			var node = base.CreateEntity(id, initializer);
			node.Type = GetTypeMeta(id);
			return node;
		}

		public SerializedNodeTypeList Serialize() {
			return new SerializedNodeTypeList {
				categories = RegisteredTypes.Values.Select(it => it.NodeType).GroupBy(it => it.category).Select(it => new SerializedNodeTypeList.Category {
					name = it.Key,
					nodeTypes = it.Select(nodeType => nodeType.Clone()).ToList()
				}).ToList()
			};
		}
	}
	
	public class NodeTypeMeta : EntityTypeMeta {
		public Plugin OwnerPlugin;
		public NodeType NodeType;
		public readonly List<ReflectedDataOutputPortMeta> DataOutputs = new();
		public readonly List<ReflectedFlowInputPortMeta> FlowInputs = new();
		public readonly List<ReflectedFlowOutputPortMeta> FlowOutputs = new();
	}
	
	public class NodeTypeCheckpoint : TypeCheckpoint {
		public bool EntitiesRetained;
		public List<(Guid graphId, SerializedNode serializedNode, List<SerializedFlowConnection> flowConnections, List<SerializedDataConnection> dataConnections)> SerializedNodes = new();
	}
}
