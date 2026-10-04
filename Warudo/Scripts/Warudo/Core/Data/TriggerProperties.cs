using System;

using System.ComponentModel;
using Newtonsoft.Json;

namespace Warudo.Core.Data {
    [Serializable]
    public class TriggerProperties : PortProperties {
        [DefaultValue(false), JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool transient;
        public TriggerProperties Clone() {
            var ret = new TriggerProperties();
            CopyTo(ret);
            ret.transient = transient;
            return ret;
        }
    }
}
