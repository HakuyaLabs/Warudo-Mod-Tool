using System;
using Warudo.Core.Events;

namespace Warudo.Plugins.Core.Events {
    public class AssetTypeRegisteredEvent : Event {
        public Type AssetType { get; }
        public AssetTypeRegisteredEvent(Type assetType) {
            AssetType = assetType;
        }
    }
}
