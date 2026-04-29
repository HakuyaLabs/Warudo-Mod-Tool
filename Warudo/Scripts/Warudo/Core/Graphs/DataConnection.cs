using Warudo.Core.Serializations;

namespace Warudo.Core.Graphs {
	public sealed record DataConnection(Node OutputNode, Node InputNode, DataOutputPort OutputPort, DataInputPort InputPort) {
		private SerializedDataConnection serialized;
		public SerializedDataConnection Serialize() {
			if (serialized == null) {
				serialized = new SerializedDataConnection {
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
