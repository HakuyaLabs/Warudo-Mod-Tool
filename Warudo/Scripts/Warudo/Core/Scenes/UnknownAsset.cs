using Warudo.Core.Attributes;
using Warudo.Core.Serializations;

namespace Warudo.Core.Scenes {
    [AssetType(Id = TypeId, Title = "UNKNOWN_ASSET", UserModifiable = false)]
    public sealed class UnknownAsset : Asset {
        public const string TypeId = "9f5c3e3d-cae0-4b93-b459-189c1e41c546";
        public string OriginalTypeId { get; private set; }
        private SerializedAsset raw;

        public override bool CanReceiveEvents => false;

        public override void Deserialize(SerializedAsset serialized) {
            Store(serialized.id);
            OriginalTypeId = serialized.typeId;
            raw = SerializedEntitySnapshot.Clone(serialized);
            Name = serialized.name;
            SetActive(serialized.active);
        }

        public override SerializedAsset Serialize() {
            var serialized = SerializedEntitySnapshot.Clone(raw);
            serialized.id = Id;
            serialized.name = Name;
            serialized.active = Active;
            serialized.placeholderKind = "unknown";
            serialized.placeholderTypeId = TypeId;
            return serialized;
        }
    }
}
