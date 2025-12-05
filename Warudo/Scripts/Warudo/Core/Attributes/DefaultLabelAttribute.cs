using System;

namespace Warudo.Core.Attributes {
    [AttributeUsage(AttributeTargets.Field)]
    public class DefaultLabelAttribute : Attribute {
        public string DefaultLabel { get; set; }
        public DefaultLabelAttribute(string defaultLabel) {
            DefaultLabel = defaultLabel;
        }
    }
}