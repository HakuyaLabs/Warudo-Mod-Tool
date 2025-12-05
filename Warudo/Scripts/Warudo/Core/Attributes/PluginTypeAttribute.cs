using System;

namespace Warudo.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class PluginTypeAttribute : Attribute {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public string Icon { get; set; }
        public string SupportUrl { get; set; }
        public Type[] AssetTypes { get; set; }
        public Type[] NodeTypes { get; set; }
    }
}