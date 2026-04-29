using Warudo.Core.Scenes;

namespace Warudo.Core.Utils {
    public static class WarudoExtensions {
        public static bool IsNullOrInactive(this Asset asset) {
            return asset == null || !asset.Active;
        }
        public static bool IsNonNullAndActive(this Asset asset) {
            return asset != null && asset.Active;
        }
    }
}
