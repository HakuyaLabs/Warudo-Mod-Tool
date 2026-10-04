using UnityEngine;
using Warudo.Core.Data;
using Warudo.Core.Serializations;

namespace Warudo.Core.Graphs {
    public abstract class PlaceholderNode : Node {
        public string OriginalTypeId { get; private set; }
        protected SerializedNode Raw { get; private set; }

        public override bool CanReceiveEvents => false;

        public override void Deserialize(SerializedNode serialized) {
            Store(serialized.id);
            OriginalTypeId = serialized.typeId;
            Raw = SerializedEntitySnapshot.Clone(serialized);
            Name = serialized.name;
            GraphPosition = new Vector2(serialized.x, serialized.y);
            DataInputPortCollection.Clear();
            DataOutputPortCollection.Clear();
            FlowInputPortCollection.Clear();
            FlowOutputPortCollection.Clear();
            if (Raw.dataInputs != null) foreach (var (key, port) in Raw.dataInputs) {
                var properties = port?.properties?.Clone() ?? new DataInputProperties();
                properties.disabled = properties.alwaysDisabled = true;
                AddDataInputPort(key, typeof(object), null, properties);
            }
            if (Raw.dataOutputs != null) foreach (var (key, port) in Raw.dataOutputs)
                AddDataOutputPort(key, typeof(object), () => null, port?.properties?.Clone() ?? new DataOutputProperties());
            if (Raw.flowInputs != null) foreach (var (key, port) in Raw.flowInputs)
                FlowInputPortCollection.AddPort(new FlowInputPort(key, () => null, port?.properties?.Clone() ?? new FlowInputProperties()));
            if (Raw.flowOutputs != null) foreach (var (key, port) in Raw.flowOutputs)
                base.AddFlowOutputPort(key, port?.properties?.Clone() ?? new FlowOutputProperties());
        }

        public override SerializedNode Serialize() {
            var serialized = GetSnapshot();
            serialized.placeholderKind = this is ErrorNode ? "error" : "unknown";
            serialized.placeholderTypeId = Type.NodeType.id;
            return serialized;
        }

        internal SerializedNode GetSnapshot() {
            // Rebuilding must use the retained data, without recovery UI added
            // by ErrorNode.Serialize(), even when another restore attempt fails.
            var serialized = SerializedEntitySnapshot.Clone(Raw);
            serialized.id = Id;
            serialized.name = Name;
            serialized.x = GraphPosition.x;
            serialized.y = GraphPosition.y;
            return serialized;
        }
    }
}
