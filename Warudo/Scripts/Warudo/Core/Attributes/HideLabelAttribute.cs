using System;

namespace Warudo.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class HideLabelAttribute : Attribute {
        public HideLabelAttribute() {
        }
    }
}