using System;
using System.Collections.Generic;
using System.Linq;
using Warudo.Core.Localization;

namespace Warudo.Core.Serializations {
    [Serializable]
    public class AssetIdentifier {
        public Guid id;
        public string name;
    }

    [Serializable]
    public class SerializedAsset : SerializedEntity {
        public string typeId;
        public string name;
        public bool active;
        
        public override void Localize() {
            base.Localize();
            name = name.Localized();
        }
    }
    
    [Serializable]
    public class ReducedSerializedAsset {
        public Guid id;
        public Dictionary<string, ReducedSerializedDataInputPort> dataInputs;
        
        public string typeId;
        public string name;
        public bool active;
        public int order;
        public string group;
        
        public ReducedSerializedAsset(SerializedAsset serializedAsset) {
            id = serializedAsset.id;
            dataInputs = serializedAsset.dataInputs.ToDictionary(it => it.Key, it => new ReducedSerializedDataInputPort(it.Value));
            
            typeId = serializedAsset.typeId;
            name = serializedAsset.name;
            active = serializedAsset.active;
        }
    }
}
