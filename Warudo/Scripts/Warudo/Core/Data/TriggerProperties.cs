using System;

namespace Warudo.Core.Data {
    [Serializable]
    public class TriggerProperties : PortProperties {
        public TriggerProperties Clone() {
            var ret = new TriggerProperties();
            CopyTo(ret);
            return ret;
        }
    }
}