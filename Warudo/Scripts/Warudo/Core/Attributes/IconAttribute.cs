using System;

namespace Warudo.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class IconAttribute : Attribute {
        public string Icon { get; set; }
        public IconAttribute(string icon) {
            Icon = icon;
        }
    }
}