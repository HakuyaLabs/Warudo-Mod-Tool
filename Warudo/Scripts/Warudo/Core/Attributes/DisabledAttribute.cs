using System;

namespace Warudo.Core.Attributes {
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class DisabledAttribute : Attribute {
    }
}
