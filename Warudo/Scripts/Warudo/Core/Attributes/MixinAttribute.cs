using System;
using System.Runtime.CompilerServices;

namespace Warudo.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class MixinAttribute : Attribute {

        public int Order { get; }
        
        public MixinAttribute([CallerLineNumber] int order = 0) {
            Order = order;
        }
        
    }
}