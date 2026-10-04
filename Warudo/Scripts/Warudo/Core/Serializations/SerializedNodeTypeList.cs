using System;
using System.Collections.Generic;
using System.Linq;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using Warudo.Core.Utils;

namespace Warudo.Core.Serializations {
    [Serializable]
    public class SerializedNodeTypeList : ILocalizable {
        public List<Category> categories;

        [Serializable]
        public class Category : ILocalizable {
            public string name;
            public List<NodeType> nodeTypes;

            public void Localize() {
                name = name.Localized();
                nodeTypes = nodeTypes.Select(it => it.Clone().Also(type => type.Localize())).ToList();
            }
        }

        public void Localize() {
            categories.ForEach(it => it.Localize());
        }
    }
}
