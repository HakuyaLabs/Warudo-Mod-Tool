using System;

namespace Warudo.Core.Attributes {
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class DisabledIfAttribute : PredicateAttribute {
        public DisabledIfAttribute(string methodName) : base(methodName) {
        }
        public DisabledIfAttribute(string dataInputPortName, If @if, object value) : base(dataInputPortName, @if, value) {
        }
        public DisabledIfAttribute(string dataInputPortName, Is @is) : base(dataInputPortName, @is) {
        }
    }
}
