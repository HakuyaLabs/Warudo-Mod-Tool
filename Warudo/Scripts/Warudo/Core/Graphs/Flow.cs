using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;

namespace Warudo.Core.Graphs {
	public sealed class Flow {
		private readonly Graph graph;

		private readonly Dictionary<Guid, object> cachedPortData = new();
		private readonly StringBuilder serializedActiveConnections = new();
		
		public Flow(Graph graph) {
			this.graph = graph;
		}

		public void EnsureCapacity(int capacity) {
			cachedPortData.EnsureCapacity(capacity);
		}

		public void Clear() {
			cachedPortData.Clear();
			serializedActiveConnections.Clear();
		}

		public void Invoke(Node startNode, Continuation firstContinuation) {
			Clear();

			var node = startNode;
			var isFirst = true;
			Continuation cont = null;
			try {
				do {
					// WarudoLogger.Print($"Getting data for {node.GetType()}");
					foreach (var (_, dataInputPort) in node.DataInputPortCollection.GetPorts()) {
						RecursivelySetData(node, dataInputPort);
					}

					if (isFirst) {
						isFirst = false;
						cont = firstContinuation;
					} else {
						cont = cont.Connection.InputPort.GetContinuation();
					}

					if (cont != null) {
						node = cont.Connection.InputNode;
						var connection = cont.Connection;
						if (connection.OutputNode != null && connection.InputNode != null) {
							serializedActiveConnections
								.Append(connection.OutputNode.IdString)
								.Append("::")
								.Append(connection.OutputPort.Key)
								.Append("->")
								.Append(connection.InputNode.IdString)
								.Append("::")
								.Append(connection.InputPort.Key)
								.Append("\\n");
						}
					} else {
						node = null;
					}
				} while (node != null);
			} catch (Exception e) {
				// TODO: More details; propagate error to client? e.g. highlight error node
				Log.Error($"An error occurred whole invoking flow at {node?.GetType().Name}, which originated at {startNode.GetType().Name}", e);
			}
		}

		private string switchGuid = "77aad728-2021-4571-a8cf-20e6479bdf86";
		private string delayGuid = "006cb78d-295d-4c58-bca3-bfa1ee6cf1b3";

		public void RecursivelySetData(Node inputNode, DataInputPort inputPort) {
			// var log = inputNode.Type.Id == switchGuid || inputNode.Type.Id == delayGuid;
			if (cachedPortData.TryGetValue(inputPort.Id, out var cachedValue)) {
				if (cachedValue != null) {
					// if (log) Debug.Log($"Setting cached {cachedValue} into {inputNode.Name}::{inputPort.Key}");
					inputPort.SetValue(cachedValue);
				} else {
					if (inputPort.Type.GetKind().AllowNullData()) {
						// if (log) Debug.Log($"Cache is null, setting null into {inputNode.Name}::{inputPort.Key}");
						inputPort.SetValue(null);
					} else if (inputPort.Type.GetKind().IsArray()) {
						// if (log) Debug.Log($"Cache is null, setting empty {inputPort.Type.Name} into {inputNode.Name}::{inputPort.Key}");
						inputPort.SetValue(inputPort.Type.GetElementType()!.GetEmptyArray());
					}
				}
				return;
			}

			var dataConnections = graph.GetInputDataConnections(inputNode);

			if (dataConnections != null && dataConnections.ContainsKey(inputPort.Key)) {
				var connections = dataConnections[inputPort.Key];

				object GetComputedValue(DataConnection connection) {
					var connectedOutputPort = connection.OutputPort;
					var connectedOutputNode = connection.OutputNode;
				
					if (cachedPortData.TryGetValue(connectedOutputPort.Id, out var value)) {
						// if (log) Debug.Log($"Cached {connection.OutputNode.Name}::{connection.OutputPort.Key}, return {cachedPortData[inputPort.Id]}");
						return value;
					}

					if (connectedOutputNode.Type.Id == delayGuid) {
						// if (log) Debug.Log($"Magic! DelayData node {connectedOutputNode.Id} is dead: " + !connectedOutputNode.Created);
					}
					foreach (var (_, connectedOutputNodeDataInputPort) in connectedOutputNode.DataInputPortCollection.GetPorts()) {
						// if (log) Debug.Log($"Recursively setting data for {connectedOutputNode.Name}::{connectedOutputNodeDataInputPort.Key}");
						RecursivelySetData(connectedOutputNode, connectedOutputNodeDataInputPort);
					}

					var computedValue = connectedOutputPort.ComputedValue();
					// if (log) Debug.Log($"Caching {computedValue} into {connection.OutputNode.Name}::{connection.OutputPort.Key}");
					cachedPortData[connectedOutputPort.Id] = computedValue;

					return computedValue;
				}
				
				var connection = connections[0];
				var outputPort = connection.OutputPort;
				var computedValue = GetComputedValue(connection);
				var computedValueNonNull = computedValue != null;
				
				// Type check
				if (computedValueNonNull && !computedValue.GetType().InheritsFrom(inputPort.Type) && inputPort.Type != typeof(object)) {
					if (!DataConverters.CanConvert(outputPort.Type, inputPort.Type) && !DataConverters.CanConvert(computedValue.GetType(), inputPort.Type)) {
						if (outputPort.Type != typeof(object)) {
							throw new UserException($"Type mismatch: {inputPort.Type} is not assignable from {computedValue.GetType()}");
						}
						if (Application.isEditor) Debug.LogWarning("Type mismatch: " + inputPort.Type + " is not assignable from " + computedValue.GetType());
						return;
					}
					computedValue = DataConverters.Convert(computedValue, outputPort.Type, inputPort.Type);
				}
				
				cachedPortData[inputPort.Id] = computedValue;

				if (computedValueNonNull) {
					// if (log) Debug.Log($"Setting {computedValue} into {inputNode.Name}::{inputPort.Key}");
					
					inputPort.SetValue(computedValue);
					if (connection.OutputNode != null && connection.InputNode != null) {
						serializedActiveConnections
							.Append(connection.OutputNode.IdString)
							.Append("::")
							.Append(connection.OutputPort.Key)
							.Append("->")
							.Append(connection.InputNode.IdString)
							.Append("::")
							.Append(connection.InputPort.Key)
							.Append("\\n");
					}
				} else {
					if (inputPort.Type.GetKind().AllowNullData()) {
						// if (log) Debug.Log($"Setting null into {inputNode.Name}::{inputPort.Key}");
						inputPort.SetValue(null);
					} else if (inputPort.Type.GetKind().IsArray()) {
						// if (log) Debug.Log($"Setting empty {inputPort.Type.Name} into {inputNode.Name}::{inputPort.Key}");
						inputPort.SetValue(inputPort.Type.GetElementType()!.GetEmptyArray());
					}
				}
			}

			// var currentValue = port.Getter();
			// // WarudoLogger.Print($"Caching {currentValue} into {port}");
			// cachedPortData[port.Id] = currentValue;
			// port.Setter(currentValue);
		}

		public string GetSerializedActiveConnections() {
			return serializedActiveConnections.ToString();
		}
	}
}
