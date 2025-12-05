using Warudo.Core.Serializations;

namespace Warudo.Core.Graphs {
	public sealed record FlowConnection(Node OutputNode, Node InputNode, FlowOutputPort OutputPort, FlowInputPort InputPort) {
		private SerializedFlowConnection serialized;
		public SerializedFlowConnection Serialize() {
			if (serialized == null) {
				serialized = new SerializedFlowConnection {
					outputNode = OutputNode.Id,
					inputNode = InputNode.Id,
					outputPort = OutputPort.Key,
					inputPort = InputPort.Key
				};
			}
			return serialized;
		}
	}
}
