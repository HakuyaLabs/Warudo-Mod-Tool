using Warudo.Core.Scenes;

namespace Warudo.Core.Events {
    public class AssetAddEvent : Event {
        public Asset Asset { get; }
        public AssetAddEvent(Asset asset) {
            Asset = asset;
        }
    }
}
