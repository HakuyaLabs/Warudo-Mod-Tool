using System;
using System.Runtime.CompilerServices;

namespace Warudo.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DataInputAttribute : Attribute {

        public int Order { get; }
        
        public DataInputAttribute([CallerLineNumber] int order = 0) {
            Order = order;
        }
        
    }
}