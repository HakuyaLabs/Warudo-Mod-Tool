using System;

namespace Warudo.Core.Attributes {
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class SectionHiddenIfAttribute : PredicateAttribute {
        public SectionHiddenIfAttribute(string methodName) : base(methodName) {
        }
        public SectionHiddenIfAttribute(string dataInputPortName, If @if, object value) : base(dataInputPortName, @if, value) {
        }
        public SectionHiddenIfAttribute(string dataInputPortName, Is @is) : base(dataInputPortName, @is) {
        }
    }
}
