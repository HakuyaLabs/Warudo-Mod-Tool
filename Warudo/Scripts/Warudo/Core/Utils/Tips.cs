using UnityEngine;
using Warudo.Core.Localization;

namespace Warudo.Core.Utils {
    public class Tips {

        public static void Once(string messageKey, string key = null) {
            if (key == null) key = messageKey;
            if (PlayerPrefs.HasKey(key)) return;
            PlayerPrefs.SetInt(key, 1);
            PlayerPrefs.Save();
            Context.Service.PromptMessage("TIPS", messageKey.Localized());
        }
        
        public static void Always(string messageKey) {
            Context.Service.PromptMessage("TIPS", messageKey.Localized());
        }

    }
}
