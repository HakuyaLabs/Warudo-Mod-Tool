using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Warudo.Core.Data;
using Warudo.Core.Events;
using Warudo.Core.Scenes;
using Warudo.Core.Localization;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;

namespace Warudo.Core.Graphs {
	public class Graph {
		public Scene Scene { get; set; }
		public Guid Id { get; set; }
		public bool Enabled {
			get => enabled;
			set {
				if (enabled == value) return;
				enabled = value;
				if (value) {
					Context.EventBus.Broadcast(new GraphEnableEvent(this));
				} else {
					Context.EventBus.Broadcast(new GraphDisableEvent(this));
				}
				Context.Service?.BroadcastGraphEnabled(Id, value);
			}
		}
		public string Name { get; set; } = "NEW_GRAPH".Localized();
		public int Order {
			get {
				var hierarchy = Scene.GraphHierarchy;
				if (hierarchy == null) {
					return -1;
				}
				return hierarchy.GetOrder(Id.ToString());
			}
		}
		public float? PanningX { get; set; }
		public float? PanningY { get; set; }
		public float? Scaling { get; set; }
		public bool IsBeingRemoved { get; set; } = false;
		
		public GraphProperties Properties { get; }
		
		private readonly Dictionary<Guid, Node> nodes = new();
		private readonly Dictionary<Guid, Dictionary<string, List<DataConnection>>> inputDataConnections = new();
		private readonly Dictionary<Guid, Dictionary<string, FlowConnection>> outputFlowConnections = new();

		private readonly Flow invokedFlow;
		private readonly Flow eventHandlerFlow;
		private const float FlowBroadcastInterval = 0.4f;
		private readonly Dictionary<(Guid, string), float> lastInvokeFlowBroadcastTimestamps = new();
		private bool enabled;

		public Graph() {
			Id = Guid.NewGuid();
			Properties = StructuredData.Create<GraphProperties>();
			Properties.Graph = this;
			invokedFlow = new Flow(this);
			eventHandlerFlow = new Flow(this);
		}
		
		public void FixedUpdate() {
			foreach (var node in nodes.Values) node.FixedUpdate();
		}
        
		public void PreUpdate() {
			foreach (var node in nodes.Values) node.PreUpdate();
		}

		public void Update() {
			foreach (var node in nodes.Values) node.Update();
		}
        
		public void PostUpdate() {
			foreach (var node in nodes.Values) node.PostUpdate();
		}

		public void LateUpdate() {
			foreach (var node in nodes.Values) node.LateUpdate();
		}
		
		public void PostLateUpdate() {
			foreach (var node in nodes.Values) node.PostLateUpdate();
		}
		
		public void EndOfFrame() {
			foreach (var node in nodes.Values) node.EndOfFrame();
		}
		
		public void OnDrawGizmos() {
			foreach (var node in nodes.Values) node.OnDrawGizmos();
		}
		
		public Dictionary<Guid, Node> GetNodes() => nodes;

		public Node GetNode(Guid id) => nodes.GetValueOrDefault(id);

		public IReadOnlyDictionary<string, List<DataConnection>> GetInputDataConnections(Node node) {
			return inputDataConnections.GetValueOrDefault(node.Id);
		}
		
		public IReadOnlyDictionary<string, FlowConnection> GetOutputFlowConnections(Node node) {
			return outputFlowConnections.GetValueOrDefault(node.Id);
		}
		
		public IReadOnlyDictionary<Guid, Dictionary<string, List<DataConnection>>> GetInputDataConnections() {
			return inputDataConnections;
		}
		
		public IReadOnlyDictionary<Guid, Dictionary<string,FlowConnection>> GetOutputFlowConnections() {
			return outputFlowConnections;
		}

		public void Destroy() {
			foreach (var it in nodes.Values) {
				try {
					it.Destroy();
				} catch (Exception e) {
					Log.Error("Error while destroying node " + it.Id, e);
				}
			}
			nodes.Clear();
			inputDataConnections.Clear();
			outputFlowConnections.Clear();
			try {
				Properties.Destroy();
			} catch (Exception e) {
				Log.Error("Error while destroying graph properties", e);
			}
		}

		public T AddNode<T>() where T : Node {
			var node = Context.NodeTypeRegistry.CreateEntity(typeof(T));
			AddNode(node);
			return (T) node;
		}
		
		public Node AddNode(string typeId) {
			var node = Context.NodeTypeRegistry.CreateEntity(typeId);
			AddNode(node);
			return node;
		}
		
		public Node DeserializeNode(SerializedNode serializedNode) {
			if (nodes.ContainsKey(serializedNode.id)) {
				throw new ArgumentException($"Node {serializedNode.id} already exists", nameof(serializedNode));
			}
			var node = Context.NodeTypeRegistry.CreateEntity(serializedNode.typeId);
			node.Graph = this;
			node.Store(serializedNode.id);
			try {
				node.Deserialize(serializedNode);
			} catch {
				// Unstore node
				node.Destroy();
				throw;
			}
			AddNode(node);
			return node;
		}
		
		public void AddNode(Node node) {
			if (nodes.ContainsKey(node.Id)) {
				throw new ArgumentException($"Node {node.Id} already exists", nameof(node));
			}
			if (!node.Created) {
				throw new ArgumentException($"Node {node.Id} has not been created yet");
			}
			nodes.Add(node.Id, node);
			node.Graph = this;
			// Debug.Log("Added node " + node.Id);
		}

		public void RemoveNode(Guid nodeId) {
			var node = nodes.GetValueOrDefault(nodeId);
			if (node == null) {
				throw new Exception($"Node {nodeId} does not exist");
			}
			
			var dataConnectionsToRemove = inputDataConnections
				.SelectMany(it => it.Value.SelectMany(k => k.Value))
				.Where(it => it.InputNode == node || it.OutputNode == node)
				.ToList();
			dataConnectionsToRemove.ForEach(it => RemoveDataConnection(it, false));
			
			var flowConnectionsToRemove = outputFlowConnections
				.SelectMany(it => it.Value.Values)
				.Where(it => it.InputNode == node || it.OutputNode == node)
				.ToList();
			flowConnectionsToRemove.ForEach(RemoveFlowConnection);

			nodes.Remove(node.Id);
			node.Destroy();
		}

		public bool AddDataConnection(DataConnection connection) {
			if (!nodes.ContainsKey(connection.InputNode.Id)) {
				throw new ArgumentException($"Input node {connection.InputNode.Id} does not exist", nameof(connection));
			}
			if (!nodes.ContainsKey(connection.OutputNode.Id)) {
				throw new ArgumentException($"Output node {connection.OutputNode.Id} does not exist", nameof(connection));
			}
			if (connection.InputPort == null) {
				throw new ArgumentException("Input port is null");
			}
			if (connection.OutputPort == null) {
				throw new ArgumentException("Output port is null");
			}

			if (WillCreateCycle(connection)) {
				return false;
			}

			if (!connection.OutputPort.Type.InheritsFrom(connection.InputPort.Type) && connection.InputPort.Type != typeof(object) && connection.OutputPort.Type != typeof(object)
			    && !DataConverters.CanConvert(connection.OutputPort.Type, connection.InputPort.Type)) {
				throw new ArgumentException($"{connection.OutputNode.GetType()}::{connection.OutputPort.Key} is not compatible with {connection.InputNode.GetType()}::{connection.InputPort.Key}", nameof(connection));
			}

			if (!inputDataConnections.ContainsKey(connection.InputNode.Id)) {
				inputDataConnections[connection.InputNode.Id] = new Dictionary<string, List<DataConnection>>();
			}
			if (!inputDataConnections[connection.InputNode.Id].ContainsKey(connection.InputPort.Key)) {
				inputDataConnections[connection.InputNode.Id][connection.InputPort.Key] = new List<DataConnection>();
			}
			
			var connections = inputDataConnections[connection.InputNode.Id][connection.InputPort.Key];
			connections.Clear(); // TODO: Multiple data connections - Feasible? Necessary?
			connections.Add(connection);

			eventHandlerFlow.EnsureCapacity(inputDataConnections.Values.Select(it => it.Values.Count).Sum());

			return true;
		}

		public bool AddDataConnection(Node from, string fromData, Node to, string toData) 
			=> AddDataConnection(new DataConnection(from, to, from.DataOutputPortCollection.GetPort(fromData), to.DataInputPortCollection.GetPort(toData)));

		public void RemoveDataConnection(DataConnection connection, bool broadcastInputPortValue = true) {
			if (!nodes.ContainsKey(connection.InputNode.Id)) {
				throw new ArgumentException($"Input node {connection.InputNode.Id} does not exist", nameof(connection));
			}
			if (!nodes.ContainsKey(connection.OutputNode.Id)) {
				throw new ArgumentException($"Output node {connection.OutputNode.Id} does not exist", nameof(connection));
			}
			if (connection.InputPort == null) {
				throw new ArgumentException("Input port is null");
			}
			if (connection.OutputPort == null) {
				throw new ArgumentException("Output port is null");
			}
			
			if (inputDataConnections.ContainsKey(connection.InputNode.Id)) {
				var connections = inputDataConnections[connection.InputNode.Id][connection.InputPort.Key];
				var connectionToRemove = connections.FirstOrDefault(it => it.OutputPort == connection.OutputPort && it.OutputNode == connection.OutputNode);
				if (connectionToRemove != null) connections.Remove(connectionToRemove);
				if (connections.Count == 0) {
					inputDataConnections[connection.InputNode.Id].Remove(connection.InputPort.Key);
				}
			}
			
			var type = connection.InputPort.Type;
				
			// If reference type, clear value
			if (type.GetKind().AllowNullData()) {
				connection.InputPort.SetValue(null);
			}
				
			// If array type, set to empty array
			if (type.GetKind().IsArray()) {
				connection.InputPort.SetValue(type.GetElementType().GetEmptyArray());
			}
			
			if (broadcastInputPortValue) Context.Service?.BroadcastEntityDataInputPortValue(connection.InputNode.Id, connection.InputPort.Key, connection.InputPort.SerializeValue());
		}
		
		public void RemoveDataConnection(Node from, string fromData, Node to, string toData)
			=> RemoveDataConnection(new DataConnection(from, to, from.DataOutputPortCollection.GetPort(fromData), to.DataInputPortCollection.GetPort(toData)));

		public bool AddFlowConnection(FlowConnection connection) {
			// Debug.Log($"Adding {connection}");
			if (!nodes.ContainsKey(connection.InputNode.Id)) {
				throw new ArgumentException($"Input node {connection.InputNode.Id} does not exist", nameof(connection));
			}
			if (!nodes.ContainsKey(connection.OutputNode.Id)) {
				throw new ArgumentException($"Output node {connection.OutputNode.Id} does not exist", nameof(connection));
			}
			if (connection.InputPort == null) {
				throw new ArgumentException("Input port is null");
			}
			if (connection.OutputPort == null) {
				throw new ArgumentException("Output port is null");
			}

			if (WillCreateCycle(connection)) {
				return false;
			}
			
			connection.OutputPort.SetContinuation(new Continuation(connection));
			
			if (!outputFlowConnections.ContainsKey(connection.OutputNode.Id)) {
				outputFlowConnections[connection.OutputNode.Id] = new Dictionary<string, FlowConnection>();
			}
			outputFlowConnections[connection.OutputNode.Id][connection.OutputPort.Key] = connection;

			return true;
		}
		
		public bool AddFlowConnection(Node from, string fromFlow, Node to, string toFlow) =>
			AddFlowConnection(new FlowConnection(from, to, from.FlowOutputPortCollection.GetPort(fromFlow), to.FlowInputPortCollection.GetPort(toFlow)));

		public void RemoveFlowConnection(FlowConnection connection) {
			if (!nodes.ContainsKey(connection.InputNode.Id)) {
				throw new ArgumentException($"Input node {connection.InputNode.Id} does not exist", nameof(connection));
			}
			if (!nodes.ContainsKey(connection.OutputNode.Id)) {
				throw new ArgumentException($"Output node {connection.OutputNode.Id} does not exist", nameof(connection));
			}
			if (connection.InputPort == null) {
				throw new ArgumentException("Input port is null");
			}
			if (connection.OutputPort == null) {
				throw new ArgumentException("Output port is null");
			}
			if (outputFlowConnections.ContainsKey(connection.OutputNode.Id)) {
				outputFlowConnections[connection.OutputNode.Id].Remove(connection.OutputPort.Key);
				if (outputFlowConnections[connection.OutputNode.Id].Count == 0) {
					outputFlowConnections.Remove(connection.OutputNode.Id);
				}
			}

			connection.OutputNode.FlowOutputPortCollection.GetPort(connection.OutputPort.Key).SetContinuation(null);
		}
		
		public void RemoveFlowConnection(Node from, string fromFlow, Node to, string toFlow) => 
			RemoveFlowConnection(new FlowConnection(from, to, from.FlowOutputPortCollection.GetPort(fromFlow), to.FlowInputPortCollection.GetPort(toFlow)));

		public void DeserializeDataConnection(SerializedDataConnection serializedDataConnection) {
			var outputNode = GetNode(serializedDataConnection.outputNode);
			if (outputNode == null) {
				throw new Exception($"Output node {serializedDataConnection.outputNode} does not exist for data connection");
			}
			var inputNode = GetNode(serializedDataConnection.inputNode);
			if (inputNode == null) {
				throw new Exception($"Input node {serializedDataConnection.inputNode} does not exist for data connection");
			}
			AddDataConnection(new DataConnection(outputNode, inputNode,
				outputNode.DataOutputPortCollection.GetPort(serializedDataConnection.outputPort),
				inputNode.DataInputPortCollection.GetPort(serializedDataConnection.inputPort)));
		}

		public void DeserializeFlowConnection(SerializedFlowConnection serializedFlowConnection) {
			var outputNode = GetNode(serializedFlowConnection.outputNode);
			if (outputNode == null) {
				throw new Exception($"Output node {serializedFlowConnection.outputNode} does not exist for flow connection");
			}
			var inputNode = GetNode(serializedFlowConnection.inputNode);
			if (inputNode == null) {
				throw new Exception($"Input node {serializedFlowConnection.inputNode} does not exist for flow connection");
			}
			AddFlowConnection(new FlowConnection(outputNode, inputNode,
				outputNode.FlowOutputPortCollection.GetPort(serializedFlowConnection.outputPort),
				inputNode.FlowInputPortCollection.GetPort(serializedFlowConnection.inputPort)));
		}
		
		public bool WillCreateCycle(DataConnection connection) {
			var graph = new DirectedGraph(nodes.Select(it => it.Value.Id));
			inputDataConnections.SelectMany(it => it.Value.Values.SelectMany(k => k)).ToList().ForEach(it => graph.AddDirectedEdge(it.OutputNode.Id, it.InputNode.Id));
			return graph.WillCreateCycle(connection.OutputNode.Id, connection.InputNode.Id);
		}
		
		public bool WillCreateCycle(FlowConnection connection) {
			var graph = new DirectedGraph(nodes.Select(it => it.Value.Id));
			outputFlowConnections.SelectMany(it => it.Value.Values).ToList().ForEach(it => graph.AddDirectedEdge(it.OutputNode.Id, it.InputNode.Id));
			return graph.WillCreateCycle(connection.OutputNode.Id, connection.InputNode.Id);
		}

		public DirectedGraph GetDependencyGraph() {
			var graph = new DirectedGraph(nodes.Select(it => it.Value.Id));
			inputDataConnections.SelectMany(it => it.Value.Values.SelectMany(k => k)).ToList().ForEach(it => graph.AddDirectedEdge(it.OutputNode.Id, it.InputNode.Id));
			outputFlowConnections.SelectMany(it => it.Value.Values).ToList().ForEach(it => graph.AddDirectedEdge(it.OutputNode.Id, it.InputNode.Id));
			return graph;
		}

		public void InvokeFlow(Node from, string outputPortKey, bool invokeWhenDisabled = false) {
			if (!Enabled && !invokeWhenDisabled) return;

			if (outputPortKey == null) {
				// Equivalent to update dependencies for this node
				invokedFlow.Invoke(from, null);
			} else {
				var port = from.FlowOutputPortCollection.GetPort(outputPortKey);
				if (port == null) {
					throw new Exception($"Flow output port {outputPortKey} does not exist on {from.GetType().Name} node {from.Id}");
				}

				invokedFlow.Invoke(from, port.GetContinuation());

				if (!lastInvokeFlowBroadcastTimestamps.ContainsKey((from.Id, outputPortKey))
				    || Time.realtimeSinceStartup - lastInvokeFlowBroadcastTimestamps[(from.Id, outputPortKey)] >= FlowBroadcastInterval) {
					if (Scene?.GetSelectedGraph() == this) {
						Context.Service?.BroadcastActiveConnections(Id, invokedFlow.GetSerializedActiveConnections());
					}
					lastInvokeFlowBroadcastTimestamps[(from.Id, outputPortKey)] = Time.realtimeSinceStartup;
				}
			}
		}

		public void InvokeFlowAtInput(Node start, string inputPortKey, bool invokeWhenDisabled = false) {
			if (!Enabled && !invokeWhenDisabled) return;
			
			if (inputPortKey == null) {
				throw new Exception("Input port key cannot be null");
			}
			var port = start.FlowInputPortCollection.GetPort(inputPortKey);
			if (port == null) {
				throw new Exception($"Flow input port {inputPortKey} does not exist on {start.GetType().Name} node {start.Id}");
			}
			
			invokedFlow.Clear();
			foreach (var (_, dataInputPort) in start.DataInputPortCollection.GetPorts()) {
				invokedFlow.RecursivelySetData(start, dataInputPort);
			}

			Continuation cont;
			try {
				cont = port.GetContinuation();
				if (cont == null) {
					return;
				}
			} catch (Exception e) {
				Debug.LogError($"Error invoking port {inputPortKey} on {start.GetType().Name} node {start.Id}: {e}");
				return;
			}
			if (cont.Connection.InputPort == null) {
				return;
			}

			InvokeFlow(cont.Connection.OutputNode, cont.Connection.OutputPort.Key, invokeWhenDisabled);
		}

		public SerializedGraph Serialize() {
			return new SerializedGraph {
				id = Id,
				enabled = Enabled,
				name = Name,
				panningX = PanningX,
				panningY = PanningY,
				scaling = Scaling,
				nodes = nodes.ToDictionary(it => it.Key, it => it.Value.Serialize()),
				dataConnections = inputDataConnections.SelectMany(it => it.Value.Values.SelectMany(k => k)).Select(it => it.Serialize()).ToList(),
				flowConnections = outputFlowConnections.SelectMany(it => it.Value.Values).Select(it => it.Serialize()).ToList(),
				properties = Properties.Serialize()
			};
		}

		public void DeserializeNodes(SerializedGraph serializedGraph) {
			if (Scene == null) {
				throw new ArgumentNullException(nameof(Scene));
			}
			
			Id = serializedGraph.id;
			Name = serializedGraph.name;
			if (serializedGraph.panningX.HasValue) {
				PanningX = serializedGraph.panningX.Value;
			}
			if (serializedGraph.panningY.HasValue) {
				PanningY = serializedGraph.panningY.Value;
			}
			if (serializedGraph.scaling.HasValue) {
				Scaling = serializedGraph.scaling.Value;
			}
			foreach (var (id, serializedNode) in serializedGraph.nodes) {
				try {
					DeserializeNode(serializedNode);
				} catch (Exception e) {
					Log.UserError($"Could not deserialize node {id}. Skipping", e);
				}
			}
			
			if (serializedGraph.properties != null) {
				Properties.Deserialize(serializedGraph.properties);
			}
		}

		public void DeserializeConnections(SerializedGraph serializedGraph) {
			foreach (var it in serializedGraph.dataConnections) {
				try {
					DeserializeDataConnection(it);
				} catch (Exception e) {
					Log.UserError($"Could not deserialize data connection {it}. Skipping", e);
				}
			}
			foreach (var it in serializedGraph.flowConnections) {
				try {
					DeserializeFlowConnection(it);
				} catch (Exception e) {
					Log.UserError($"Could not deserialize flow connection {it}. Skipping", e);
				}
			}
			
			if (serializedGraph.enabled) {
				Enabled = true; // Trigger graph enable event
			}
		}
	}
}
