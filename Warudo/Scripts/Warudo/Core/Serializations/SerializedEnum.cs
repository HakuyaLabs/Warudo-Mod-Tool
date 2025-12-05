using System;
using System.Linq;
using Warudo.Core.Localization;
using Warudo.Core.Utils;

namespace Warudo.Core.Serializations {
    [Serializable]
    public class SerializedEnum : ILocalizable {
        public string label;
        public long value;
        public string description;
        public string icon;

        public void Localize() {
            label = label.Localized();
            description = description.Localized();
        }
        
        public SerializedEnum Clone() {
            return new SerializedEnum {
                label = label,
                value = value,
                description = description,
                icon = icon
            };
        }
    }
    
    [Serializable]
    public class EnumType : ILocalizable {
        public SerializedEnum[] members;

        public void Localize() {
            members.ForEach(it => it.Localize());
        }
        
        public EnumType Clone() {
            return new EnumType {
                members = members.Select(it => it.Clone()).ToArray()
            };
        }
    }
}
