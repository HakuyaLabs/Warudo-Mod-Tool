using System;
using System.Runtime.CompilerServices;

namespace Warudo.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class SectionAttribute : Attribute {

        public int Order { get; set; }
        
        public string Title { get; set; }
        
        public SectionAttribute(string title, [CallerLineNumber] int order = 0) {
            Title = title;
            Order = order;
        }
        
    }
}