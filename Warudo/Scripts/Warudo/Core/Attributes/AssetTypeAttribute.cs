using System;
using Warudo.Core.Rendering;

namespace Warudo.Core.Attributes {
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class AssetTypeAttribute : Attribute {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public int CategoryOrder { get; set; } = 9999;
        public bool UserModifiable { get; set; } = true;
        public bool Singleton { get; set; } = false;
        public RenderingPipeline[] SupportedRenderingPipelines { get; set; } = null;
    }
}