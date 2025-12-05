using System;
using System.Collections.Generic;
using Warudo.Core.Localization;
using Warudo.Core.Utils;

namespace Warudo.Core.Serializations {
    [Serializable]
    public class SerializedPluginList : ILocalizable {
        public Dictionary<string, SerializedPlugin> plugins;

        public void Localize() {
            plugins.Values.ForEach(it => it.Localize());
        }
    }
}
