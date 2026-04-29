using System;
using System.Runtime.CompilerServices;

namespace Warudo.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class StructuredDataInitializerAttribute : Attribute {

        public string MethodName { get; }      
        
        public StructuredDataInitializerAttribute(string methodName) {
            MethodName = methodName;
        }
        
    }
}