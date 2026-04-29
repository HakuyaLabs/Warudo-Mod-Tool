using System.Collections.Generic;
using System.Linq;
using Warudo.Core.Graphs;
using Warudo.Core.Serializations;

namespace Warudo.Core.Data {
    public class DataOutputPortCollection : PortCollection<DataOutputPort> {

        public Dictionary<string, SerializedDataOutputPort> Serialize() {
            return GetPorts().ToDictionary(it => it.Key, it => it.Value.Serialize());
        }

    }
}
