using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Warudo.Core.Data;
using Warudo.Core.Localization;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;

namespace Warudo.Core.Scenes {
    public static class AssetSelectionProvider {
        
        public static Func<UniTask<AutoCompleteList>> For(Type type, Predicate<Asset> filter = default) {
            // TODO: Cache and reuse provider for the same type
            return async () =>
            {
                var assets = Context.OpenedScene.GetAssets()
                    .Where(it => it.Value.GetType().InheritsFrom(type))
                    .ToList();
                
                if (filter != default) {
                    assets = assets.Where(it => filter(it.Value)).ToList();
                }

                if (assets.Count == 0) {
                    return AutoCompleteList.Message("NO_COMPATIBLE_ASSETS_FOUND_IN_SCENE");
                }
                
                var section = new AutoCompleteCategory {
                    title = null,
                    entries = new()
                };
                
                foreach (var (id, asset) in assets) {
                    section.entries.Add(new AutoCompleteEntry {
                        label = asset.Name + (asset.Active ? "" : "INACTIVE_SUFFIX".Localized()),
                        value = JsonConvert.SerializeObject(new AssetIdentifier {
                            name = asset.Name,
                            id = id
                        })
                    });
                }

                section.entries.Sort((a, b) => string.Compare(a.label, b.label, StringComparison.Ordinal));

                return new AutoCompleteList {
                    categories = new() {
                        section
                    }
                };
            };
        }

        /// <summary>
        /// Creates an autocomplete provider that filters assets by their TypeId.
        /// This is used with TypeIdFilterAttribute to filter assets by their AssetType.Id.
        /// </summary>
        /// <param name="type">The base type of the asset (e.g., Asset, GameObjectAsset)</param>
        /// <param name="typeId">The TypeId to filter by (matches AssetType.Id attribute)</param>
        /// <param name="filter">Optional additional filter predicate</param>
        public static Func<UniTask<AutoCompleteList>> ForTypeId(Type type, string typeId, Predicate<Asset> filter = default) {
            return async () =>
            {
                var assets = Context.OpenedScene.GetAssets()
                    .Where(it => {
                        var assetType = it.Value.GetType();
                        if (!assetType.InheritsFrom(type)) return false;
                        
                        // Check if the asset's TypeId matches
                        var assetTypeMeta = Context.AssetTypeRegistry.GetTypeMeta(assetType);
                        if (assetTypeMeta == null) return false;
                        
                        return assetTypeMeta.AssetType.id == typeId;
                    })
                    .ToList();
                
                if (filter != default) {
                    assets = assets.Where(it => filter(it.Value)).ToList();
                }

                if (assets.Count == 0) {
                    return AutoCompleteList.Message("NO_COMPATIBLE_ASSETS_FOUND_IN_SCENE");
                }
                
                var section = new AutoCompleteCategory {
                    title = null,
                    entries = new()
                };
                
                foreach (var (id, asset) in assets) {
                    section.entries.Add(new AutoCompleteEntry {
                        label = asset.Name + (asset.Active ? "" : "INACTIVE_SUFFIX".Localized()),
                        value = JsonConvert.SerializeObject(new AssetIdentifier {
                            name = asset.Name,
                            id = id
                        })
                    });
                }

                section.entries.Sort((a, b) => string.Compare(a.label, b.label, StringComparison.Ordinal));

                return new AutoCompleteList {
                    categories = new() {
                        section
                    }
                };
            };
        }

    }
}
