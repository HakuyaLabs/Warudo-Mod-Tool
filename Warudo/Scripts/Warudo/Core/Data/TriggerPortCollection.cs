using System.Collections.Generic;
using System.Linq;
using Warudo.Core.Graphs;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;

namespace Warudo.Core.Data {
    public class TriggerPortCollection : PortCollection<TriggerPort> {

        public Dictionary<string, SerializedTriggerPort> Serialize() {
            return GetPorts().ToDictionary(it => it.Key, it => it.Value.Serialize());
        }

        public override void Clear() {
            Ports.Values.ForEach(it => it.Dispose());
            base.Clear();
        }
        
    }
}
