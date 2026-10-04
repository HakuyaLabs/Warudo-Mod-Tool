using Warudo.Core.Scenes;

namespace Warudo.Core.Events {
    public class AssetRemoveEvent : Event {
        public Asset Asset { get; }
        public AssetRemoveEvent(Asset asset) {
            Asset = asset;
        }
    }
}
