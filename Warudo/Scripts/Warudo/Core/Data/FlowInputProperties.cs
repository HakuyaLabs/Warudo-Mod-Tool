using System;

namespace Warudo.Core.Data {
    [Serializable]
    public class FlowInputProperties : PortProperties {
        public FlowInputProperties Clone() {
            var ret = new FlowInputProperties();
            CopyTo(ret);
            return ret;
        }
    }
}