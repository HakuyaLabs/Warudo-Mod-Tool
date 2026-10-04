using System.Collections.Generic;
using System.Linq;
using Warudo.Core.Graphs;
using Warudo.Core.Serializations;

namespace Warudo.Core.Data {
    public class FlowInputPortCollection : PortCollection<FlowInputPort> {
        
        public Dictionary<string, SerializedFlowInputPort> Serialize() {
            return GetPorts().ToDictionary(it => it.Key, it => it.Value.Serialize());
        }
        
    }
}
