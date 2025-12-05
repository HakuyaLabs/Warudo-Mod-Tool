using System;
using System.Runtime.CompilerServices;

namespace Warudo.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TriggerAttribute : Attribute {
        
        public int Order { get; }

        public TriggerAttribute([CallerLineNumber] int order = 0) {
            Order = order;
        }
        
    }
}