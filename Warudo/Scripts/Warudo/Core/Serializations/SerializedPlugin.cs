using System;
using Warudo.Core.Plugins;
using Warudo.Core.Utils;

namespace Warudo.Core.Serializations {
    [Serializable]
    public class SerializedPlugin : SerializedEntity {
        public PluginType type;
        
        public override void Localize() {
            base.Localize();
            type = type.Clone().Also(it => it.Localize());
        }
    }
}
