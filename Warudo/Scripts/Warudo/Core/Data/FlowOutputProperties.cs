using System;

namespace Warudo.Core.Data {
    [Serializable]
    public class FlowOutputProperties : PortProperties {
        public FlowOutputProperties Clone() {
            var ret = new FlowOutputProperties();
            CopyTo(ret);
            return ret;
        }
    }
}