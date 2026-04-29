using System;
using Newtonsoft.Json;
using Warudo.Core.Localization;

namespace Warudo.Core.Data {
    [Serializable]
    public class PortProperties : ILocalizable {
        public float order;
        public bool hidden;
        public bool disabled;
        public string label;
        public string description;
        public string sectionTitle;
        public bool sectionHidden;

        [JsonIgnore] public bool alwaysHidden;
        [JsonIgnore] public bool alwaysDisabled;

        public virtual void Localize() {
            label = label.Localized();
            description = description.Localized();
            sectionTitle = sectionTitle.Localized();
        }

        protected void CopyTo(PortProperties other) {
            other.order = order;
            other.hidden = hidden;
            other.disabled = disabled;
            other.label = label;
            other.description = description;
            other.sectionTitle = sectionTitle;
            other.sectionHidden = sectionHidden;
            other.alwaysHidden = alwaysHidden;
            other.alwaysDisabled = alwaysDisabled;
        }
    }
}
