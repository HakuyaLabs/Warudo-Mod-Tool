using System;

namespace Warudo.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class LabelAttribute : Attribute {
        public string Label { get; set; }
        public LabelAttribute(string label) {
            Label = label;
        }
    }
}