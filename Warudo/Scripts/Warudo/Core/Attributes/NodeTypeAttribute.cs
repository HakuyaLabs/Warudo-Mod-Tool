using System;

namespace Warudo.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class NodeTypeAttribute : Attribute {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public float Width { get; set; } = 1f;
    }
}