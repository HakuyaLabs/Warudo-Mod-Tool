using System;
using System.Collections.Generic;
using System.Linq;
using Warudo.Core.Localization;
using Warudo.Core.Utils;

namespace Warudo.Core.Serializations {
    [Serializable]
    public class SerializedGraph : ILocalizable {
        public Guid id;
        public bool enabled;
        public string name;
        public int order;
        public string group;
        
        public float? panningX;
        public float? panningY;
        public float? scaling;
        
        public Dictionary<Guid, SerializedNode> nodes;
        public List<SerializedDataConnection> dataConnections;
        public List<SerializedFlowConnection> flowConnections;
        public SerializedStructuredData properties;

        public void Localize() {
            group = group.Localized();
            nodes.Values.ForEach(it => it.Localize());
            properties.Localize();
        }
    }
    
    [Serializable]
    public class ReducedSerializedGraph {
        public Guid id;
        public bool enabled;
        public string name;
        public int order;
        public string group;
        
        public float? panningX;
        public float? panningY;
        public float? scaling;
        
        public Dictionary<Guid, ReducedSerializedNode> nodes;
        public List<SerializedDataConnection> dataConnections;
        public List<SerializedFlowConnection> flowConnections;
        public ReducedSerializedStructuredData properties;

        public ReducedSerializedGraph(SerializedGraph graph) {
            id = graph.id;
            enabled = graph.enabled;
            name = graph.name;
            order = graph.order;
            group = graph.group;
            panningX = graph.panningX;
            panningY = graph.panningY;
            scaling = graph.scaling;
            nodes = graph.nodes.ToDictionary(it => it.Key, it => new ReducedSerializedNode(it.Value));
            dataConnections = graph.dataConnections;
            flowConnections = graph.flowConnections;
            properties = new ReducedSerializedStructuredData(graph.properties);
        }
    }

    [Serializable]
    public class SerializedDataConnection {
        public Guid outputNode;
        public Guid inputNode;
        public string outputPort;
        public string inputPort;
        
        public SerializedDataConnection Clone() {
            return new SerializedDataConnection {
                outputNode = outputNode,
                inputNode = inputNode,
                outputPort = outputPort,
                inputPort = inputPort
            };
        }

        public override string ToString() {
            return $"{nameof(outputNode)}: {outputNode}, {nameof(inputNode)}: {inputNode}, {nameof(outputPort)}: {outputPort}, {nameof(inputPort)}: {inputPort}";
        }
    }
    
    [Serializable]
    public class SerializedFlowConnection {
        public Guid outputNode;
        public Guid inputNode;
        public string outputPort;
        public string inputPort;
        
        public SerializedFlowConnection Clone() {
            return new SerializedFlowConnection {
                outputNode = outputNode,
                inputNode = inputNode,
                outputPort = outputPort,
                inputPort = inputPort
            };
        }
        
        public override string ToString() {
            return $"{nameof(outputNode)}: {outputNode}, {nameof(inputNode)}: {inputNode}, {nameof(outputPort)}: {outputPort}, {nameof(inputPort)}: {inputPort}";
        }
    }
}
