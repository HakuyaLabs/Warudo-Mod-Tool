using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Warudo.Core.Localization;

namespace Warudo.Core.Data {
    [Serializable]
    public class AutoCompleteList : ILocalizable {
        public List<AutoCompleteCategory> categories;

        public void Localize() {
            categories?.ForEach(it => it.Localize());
        }

        public AutoCompleteList With(AutoCompleteList list, bool checkEmpty = true) {
            list ??= new AutoCompleteList();
            var ret = new AutoCompleteList {
                categories = categories == null ? new List<AutoCompleteCategory>() : new List<AutoCompleteCategory>(categories)
            };
            if (list.categories != null) {
                if (checkEmpty && list.categories.All(it => it.entries.Count == 0)) {
                    return ret;
                }
                ret.categories.AddRange(list.categories);
            }
            return ret;
        }

        public static AutoCompleteList Message(string message) {
            return new AutoCompleteList {
                categories = new() {
                    new() {
                        title = message
                    }
                }
            };
        }
        
        public static AutoCompleteList Single(IEnumerable<AutoCompleteEntry> entries) {
            return new AutoCompleteList {
                categories = new() {
                    new() {
                        entries = entries.ToList()
                    }
                }
            };
        }
    }

    [Serializable]
    public class AutoCompleteCategory : ILocalizable {
        public string title;
        public List<AutoCompleteEntry> entries;

        [JsonIgnore]
        public string LocalizedTitle {
            get {
                string localizedTitle;
                if (title != null && title.Contains("-->")) {
                    var parts = title.Split("-->");
                    // localizedTitle = parts.Select(it => it.Localized()).Aggregate((a, b) => $"{a} - {b}");
                    localizedTitle = parts.Last().Localized();
                } else {
                    localizedTitle = title.Localized();
                }
                return localizedTitle;
            }
        }
        
        public void Localize() {
            title = LocalizedTitle;
            entries?.ForEach(it => it.Localize());
        }
    }

    [Serializable]
    public class AutoCompleteEntry : ILocalizable {
        public string label;
        public string value;

        public void Localize() {
            label = label.Localized();
        }
    }

    public static class AutoCompleteExtensions {
        
        public static AutoCompleteList ToAutoCompleteList(this IEnumerable<AutoCompleteEntry> entries) {
            return new AutoCompleteList {
                categories = new() {
                    new() {
                        entries = entries.ToList()
                    }
                }
            };
        }
        
    }
}
