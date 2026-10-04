using System;
using System.Runtime.CompilerServices;

namespace Warudo.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class MarkdownAttribute : Attribute {
        
        public int Order { get; }
        
        public bool Persist { get; }
        
        public bool Primary { get; set; }
        
        public MarkdownAttribute([CallerLineNumber] int order = 0, bool persist = false, bool primary = false) {
            Order = order;
            Persist = persist;
            Primary = primary;
        }
        
    }
}