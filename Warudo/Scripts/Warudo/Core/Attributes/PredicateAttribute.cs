using System;

namespace Warudo.Core.Attributes {
    public abstract class PredicateAttribute : Attribute {
        public AttributePredicateType Predicate { get; }
        
        public string MethodName { get; }      
        
        public string DataInputPortName { get; }
        
        public If If { get; }
        
        public object Value { get; }
        
        public Is Is { get; }
        
        public PredicateAttribute(string methodName) {
            Predicate = AttributePredicateType.Method;
            MethodName = methodName;
        }

        public PredicateAttribute(string dataInputPortName, If @if, object value) {
            Predicate = AttributePredicateType.PortIf;
            DataInputPortName = dataInputPortName;
            If = @if;
            Value = value;
        }
        
        public PredicateAttribute(string dataInputPortName, Is @is) {
            Predicate = AttributePredicateType.PortIs;
            DataInputPortName = dataInputPortName;
            Is = @is;
        }
    }
}
