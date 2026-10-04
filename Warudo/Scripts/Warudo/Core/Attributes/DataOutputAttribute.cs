using System;
using System.Runtime.CompilerServices;

namespace Warudo.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class DataOutputAttribute : Attribute {
        
        public int Order { get; }

        public DataOutputAttribute([CallerLineNumber] int order = 0) {
            Order = order;
        }
        
    }
}