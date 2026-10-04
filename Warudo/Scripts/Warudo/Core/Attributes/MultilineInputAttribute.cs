using System;
using System.Runtime.CompilerServices;

namespace Warudo.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class MultilineInputAttribute : Attribute {
        
        public int Order { get; }

        public MultilineInputAttribute([CallerLineNumber] int order = 0) {
            Order = order;
        }
        
    }
}