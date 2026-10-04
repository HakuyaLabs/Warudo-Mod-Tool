using System;
using System.Runtime.CompilerServices;

namespace Warudo.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FlowOutputAttribute : Attribute {
        
        public int Order { get; }

        public FlowOutputAttribute([CallerLineNumber] int order = 0) {
            Order = order;
        }
        
    }
}