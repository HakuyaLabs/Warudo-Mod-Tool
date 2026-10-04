using System;
using System.Collections.Generic;
using System.Linq;

namespace Warudo.Core.Serializations {
    [Serializable]
    public class SerializedStructuredData : SerializedEntity {
        public string header;
        public bool collapsed;
    }
    
    [Serializable]
    public class ReducedSerializedStructuredData {
        public Guid id;
        public Dictionary<string, ReducedSerializedDataInputPort> dataInputs;
        
        public ReducedSerializedStructuredData(SerializedStructuredData sd) {
            id = sd.id;
            dataInputs = sd.dataInputs.ToDictionary(it => it.Key, it => new ReducedSerializedDataInputPort(it.Value));
        }
    }
}
