using System;

namespace Warudo.Core.Attributes {
    public class ProviderAttribute : Attribute {
        public string MethodName { get; }

        protected ProviderAttribute(string methodName) {
            MethodName = methodName;
        }
    }
}
