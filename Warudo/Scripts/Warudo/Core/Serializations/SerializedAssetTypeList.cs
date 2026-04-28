using System;
using System.Collections.Generic;
using System.Linq;
using Warudo.Core.Scenes;
using Warudo.Core.Localization;
using Warudo.Core.Utils;

namespace Warudo.Core.Serializations {
    [Serializable]
    public class SerializedAssetTypeList : ILocalizable {
        public List<Category> categories;

        [Serializable]
        public class Category : ILocalizable {
            public string name;
            public List<AssetType> assetTypes;
            
            public void Localize() {
                name = name.Localized();
                assetTypes = assetTypes.Select(it => it.Clone().Also(type => type.Localize())).ToList();
            }
        }
        
        public void Localize() {
            categories.ForEach(it => it.Localize());
        }
    }
}
