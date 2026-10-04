using System;

namespace Warudo.Core.Attributes {
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class APIHideAttribute : Attribute {
        public APIHideAttribute() {
        }
    }
}