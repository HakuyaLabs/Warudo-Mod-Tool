using System;
using Warudo.Core.Localization;

namespace Warudo.Core.Plugins {
    [Serializable]
    public class PluginType : ILocalizable {
        public string id;
        public string name;
        public string description;
        public string version;
        public string author;
        public string icon;
        public string supportUrl;

        public void Localize() {
            name = name.Localized();
            description = description.Localized();
        }
        
        public PluginType Clone() {
            return new PluginType{
                id = id,
                name = name,
                description = description,
                version = version,
                author = author,
                icon = icon,
                supportUrl = supportUrl
            };
        }
    }
}
