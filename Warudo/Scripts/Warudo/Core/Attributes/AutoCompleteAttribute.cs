using System;

namespace Warudo.Core.Attributes {
    [AttributeUsage(AttributeTargets.Field)]
    public class AutoCompleteAttribute : ProviderAttribute {
        
        public bool ForceSelection { get; set; } 
        
        public string DefaultLabel { get; set; }
        
        public AutoCompleteAttribute(string methodName, bool forceSelection = false, string defaultLabel = "") : base(methodName) {
            ForceSelection = forceSelection;
            DefaultLabel = defaultLabel;
        }
        
    }
}