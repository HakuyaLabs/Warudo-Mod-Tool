using System;

namespace Warudo.Core.Attributes {
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class APIVoidReturnAttribute : Attribute {
        public APIVoidReturnAttribute() {
        }
    }
}