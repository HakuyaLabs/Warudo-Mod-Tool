using System;
using System.Collections.Generic;
using System.IO;
using Cysharp.Text;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Utils;

namespace Warudo.Core.Localization {
    public class LocalizationManager {
        
        private LocalizationMonitor localizationMonitor;

        private string activeLanguage = "en";
        private readonly Dictionary<string, Dictionary<string, string>> localizedStrings = new();
        private readonly Dictionary<string, string> supportLanguages = new() {};

        public async UniTask LoadAndMonitorLocalizations() {
            localizationMonitor = new LocalizationMonitor(Application.streamingAssetsPath + "/Localizations");
            await localizationMonitor.Start();
        }
        
        public string Localize(string key, params object[] args) {
            try {
                return string.Format(GetLocalizedString(key, activeLanguage), args);
            } catch {
                return GetLocalizedString(key, activeLanguage);
            }
        }

        public string GetActiveLanguage() {
            return activeLanguage;
        }

        public void SetActiveLanguage(string language) {
            activeLanguage = language;
            LocalizationExtensions.CachedLocalizedEnums.Clear();
        }
        
        public void LoadLocalizedStrings(JObject jObject) {
            foreach (var (languageKey, value) in jObject) {
                if (value?.Type == JTokenType.Object) {
                    foreach (var (stringKey, stringValue) in (JObject) value) {
                        if (stringValue?.Type == JTokenType.String) {
                            SetLocalizedString(stringKey, languageKey, (string)stringValue);
                        }
                    }
                }
                supportLanguages[languageKey] = GetLocalizedString("LANGUAGE_NAME", languageKey);
            }
        }
        
        public void SetLocalizedString(string key, string language, string localizedString) {
            if (!localizedStrings.ContainsKey(key)) {
                localizedStrings[key] = new();
            }
            // Debug.Log($"Added {key} for language {language}: {localizedString}");
            localizedStrings[key][language] = localizedString;
        }

        public string GetLocalizedString(string key, string language) {
            if (!localizedStrings.ContainsKey(key)) {
                return key;
            }
            return localizedStrings[key].ContainsKey(language) ? localizedStrings[key][language] : 
                (localizedStrings[key].ContainsKey("en") ? localizedStrings[key]["en"] : key);
        }

        public string GetTranslator()
        {
            if (!localizedStrings.ContainsKey("TRANSLATOR"))
            {
                return "";
            }
            return localizedStrings["TRANSLATOR"].ContainsKey(activeLanguage) ? localizedStrings["TRANSLATOR"][activeLanguage].Trim() : "";
        }

        public void RemoveLocalizedString(string key, string language) {
            if (!localizedStrings.ContainsKey(key)) {
                return;
            }
            localizedStrings.Remove(key);
        }

        public void ClearLocalizedStrings() {
            localizedStrings.Clear();
        }

        public void Dispose() {
            localizedStrings.Clear();
            localizationMonitor?.Dispose();
        }

        private static readonly Dictionary<Type, Type> BuiltInEnumLocalizedTypes = new();

        static LocalizationManager() {
            BuiltInEnumLocalizedTypes[typeof(HumanBodyBones)] = typeof(LocalizedHumanBodyBones);
        }

        public static Type GetLocalizedEnumType(Type enumType) {
            return BuiltInEnumLocalizedTypes.GetValueOrDefault(enumType);
        }

        public Dictionary<string, string> GetAllSupportLanguages() {
            return supportLanguages;
        }
    }

    public static class LocalizationExtensions {
        
        public static readonly Dictionary<Type, Dictionary<Enum, string>> CachedLocalizedEnums = new();

        public static string Localized(this string str, params object[] args) {
            if (str == null) return null;
            return Context.LocalizationManager.Localize(str, args);
        }

        public static string Localized(this Enum e) {
            if (e == null) return null;
            if (CachedLocalizedEnums.ContainsKey(e.GetType()) && CachedLocalizedEnums[e.GetType()].ContainsKey(e)) {
                return CachedLocalizedEnums[e.GetType()][e];
            }
            
            var type = LocalizationManager.GetLocalizedEnumType(e.GetType()) ?? e.GetType();
            var mappedValue = (Enum) Enum.Parse(type, e.ToString());
            var label = mappedValue.GetAttributeOfType<LabelAttribute>()?.Label ?? e.ToString();
            if (mappedValue.GetAttributeOfType<HideLabelAttribute>() != null) label = "";

            if (!CachedLocalizedEnums.ContainsKey(e.GetType())) {
                CachedLocalizedEnums[e.GetType()] = new();
            }
            
            return CachedLocalizedEnums[e.GetType()][e] = label.Localized();
        }
        
    }
}
