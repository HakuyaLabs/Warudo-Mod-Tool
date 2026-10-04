using Warudo.Core.Attributes;

namespace Warudo.Core.Graphs {
    [NodeType(Id = TypeId, Title = "UNKNOWN_NODE")]
    public sealed class UnknownNode : PlaceholderNode {
        public const string TypeId = "d65bff51-f056-449f-a9bb-95d4499e96b2";
    }
}
