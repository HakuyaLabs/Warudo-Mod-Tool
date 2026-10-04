using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Warudo.Core.Localization;
using Warudo.Core.Utils;

namespace Warudo.Core.Serializations {
    public abstract class SerializedEntity : ILocalizable {
        public Guid id;

        /// <summary>
        /// The version of the entity when it was serialized.
        /// Used for version migration during deserialization.
        /// </summary>
        public long version;
        
        public Dictionary<string, SerializedDataInputPort> dataInputs;
        public Dictionary<string, SerializedTriggerPort> triggers;

        // Editor-only diagnostics. Persistence removes these fields.
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] public string placeholderKind;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] public string placeholderTypeId;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] public string[] errorPorts;
        
        public virtual void Localize() {
            dataInputs?.ForEach(it => it.Value?.Localize());
            triggers?.ForEach(it => it.Value?.Localize());
        }
    }
}
