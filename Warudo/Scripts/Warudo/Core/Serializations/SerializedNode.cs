using System;
using System.Collections.Generic;
using System.Linq;
using Warudo.Core.Localization;
using Warudo.Core.Utils;

namespace Warudo.Core.Serializations {
    [Serializable]
    public class SerializedNode : SerializedEntity {
        public string typeId;
        public string name;
        
        public Dictionary<string, SerializedDataOutputPort> dataOutputs;
        public Dictionary<string, SerializedFlowInputPort> flowInputs;
        public Dictionary<string, SerializedFlowOutputPort> flowOutputs;

        public float x;
        public float y;

        public override void Localize() {
            base.Localize();
            name = name.Localized();
            dataOutputs.ForEach(it => it.Value.Localize());
            flowInputs.ForEach(it => it.Value.Localize());
            flowOutputs.ForEach(it => it.Value.Localize());
        }
    }
    
    [Serializable]
    public class ReducedSerializedNode {
        public Guid id;
        public Dictionary<string, ReducedSerializedDataInputPort> dataInputs;
        
        public string typeId;
        public string name;

        public float x;
        public float y;
        
        public ReducedSerializedNode(SerializedNode node) {
            id = node.id;
            dataInputs = node.dataInputs.ToDictionary(it => it.Key, it => new ReducedSerializedDataInputPort(it.Value));
            
            typeId = node.typeId;
            name = node.name;
            
            x = node.x;
            y = node.y;
        }
    }
}
