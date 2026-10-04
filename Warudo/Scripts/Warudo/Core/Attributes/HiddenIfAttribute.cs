using System;

namespace Warudo.Core.Attributes {
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class HiddenIfAttribute : PredicateAttribute {
        public HiddenIfAttribute(string methodName) : base(methodName) {
        }
        public HiddenIfAttribute(string dataInputPortName, If @if, object value) : base(dataInputPortName, @if, value) {
        }
        public HiddenIfAttribute(string dataInputPortName, Is @is) : base(dataInputPortName, @is) {
        }
    }
}
