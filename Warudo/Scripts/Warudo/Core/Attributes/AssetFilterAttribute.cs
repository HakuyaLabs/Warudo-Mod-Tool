using System;

namespace Warudo.Core.Attributes {
    [AttributeUsage(AttributeTargets.Field)]
    public class AssetFilterAttribute : ProviderAttribute {
        public AssetFilterAttribute(string methodName) : base(methodName) {
        }
    }
}