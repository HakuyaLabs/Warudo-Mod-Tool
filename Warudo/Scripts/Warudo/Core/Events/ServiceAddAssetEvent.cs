using Warudo.Core.Scenes;

namespace Warudo.Core.Events {
    public class ServiceAddAssetEvent : Event {
        public Asset Asset { get; }
        public ServiceAddAssetEvent(Asset asset) {
            Asset = asset;
        }
    }
}
