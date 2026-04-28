using System;

namespace Warudo.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class AutoCompleteResourceAttribute : Attribute {
        public string ResourceType { get; }
        
        public string DefaultLabel { get; }
        
        public AutoCompleteResourceAttribute(string resourceType, string defaultLabel = null) {
            ResourceType = resourceType;
            DefaultLabel = defaultLabel;
        }
    }
}