using System;
using System.Runtime.CompilerServices;

namespace Warudo.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class FlowInputAttribute : Attribute {
        
        public int Order { get; }

        public FlowInputAttribute([CallerLineNumber] int order = 0) {
            Order = order;
        }
        
    }
}