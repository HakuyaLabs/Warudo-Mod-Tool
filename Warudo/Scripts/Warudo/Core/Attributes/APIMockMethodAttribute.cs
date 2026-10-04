using System;

namespace Warudo.Core.Attributes {
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class APIMockMethodAttribute : Attribute {
        public string MethodName { get; }
        public APIMockMethodAttribute(string methodName)
        {
            MethodName = methodName;
        }
    }
}