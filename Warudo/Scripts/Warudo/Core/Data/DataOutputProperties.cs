using System;

namespace Warudo.Core.Data {
    [Serializable]
    public class DataOutputProperties : PortProperties {
        public DataOutputProperties Clone() {
            var ret = new DataOutputProperties();
            CopyTo(ret);
            return ret;
        }
    }
}