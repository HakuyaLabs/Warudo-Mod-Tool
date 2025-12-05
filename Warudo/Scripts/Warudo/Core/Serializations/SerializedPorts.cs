using System;
using System.Linq;
using Newtonsoft.Json;
using Warudo.Core.Data;
using Warudo.Core.Localization;

namespace Warudo.Core.Serializations {
    [Serializable]
    public abstract class SerializedPort : ILocalizable {
        public string key;
        
        public abstract void Localize();
    }
    
    [Serializable]
    public class SerializedDataInputPort : SerializedPort {
        public string type;
        public TypeKind typeKind;
        public string defaultValue;
        public string value;
        public DataInputProperties properties;

        public override void Localize() {
            properties.Localize();
        }
        
        public SerializedDataInputPort Clone() {
            return new SerializedDataInputPort {
                key = key,
                type = type,
                typeKind = typeKind,
                defaultValue = defaultValue,
                value = value,
                properties = properties.Clone()
            };
        }
    }
    
    [Serializable]
    public class ReducedSerializedDataInputPort {
        public string type;
        public string value;
        
        public ReducedSerializedDataInputPort(SerializedDataInputPort port) {
            type = port.type;
            value = port.value;
            if (port.typeKind == TypeKind.StructuredData) {
                value = JsonConvert.SerializeObject(new ReducedSerializedStructuredData(JsonConvert.DeserializeObject<SerializedStructuredData>(value)));
            } else if (port.typeKind == TypeKind.StructuredDataArray) {
                value = JsonConvert.SerializeObject(JsonConvert.DeserializeObject<SerializedStructuredData[]>(value)!.Select(it => new ReducedSerializedStructuredData(it)));
            }
        }
    }

    [Serializable]
    public class SerializedDataOutputPort : SerializedPort {
        public string type;
        public DataOutputProperties properties;
        
        public override void Localize() {
            properties.Localize();
        }
    }
    
    [Serializable]
    public class SerializedFlowInputPort : SerializedPort {
        public FlowInputProperties properties;
        
        public override void Localize() {
            properties.Localize();
        }
    }

    [Serializable]
    public class SerializedFlowOutputPort : SerializedPort {
        public FlowOutputProperties properties;
        
        public override void Localize() {
            properties.Localize();
        }
    }
    
    [Serializable]
    public class SerializedTriggerPort : SerializedPort {
        public TriggerProperties properties;
        
        public override void Localize() {
            properties.Localize();
        }
        
        public SerializedTriggerPort Clone() {
            return new SerializedTriggerPort {
                properties = properties.Clone()
            };
        }
    }
}
