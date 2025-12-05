using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Cysharp.Threading.Tasks;
using Warudo.Core.Scenes;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Localization;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;

namespace Warudo.Core {
    public class TypeRegistry {
        private Dictionary<string, Type> knownTypes = new();
        
        public async UniTask Initialize() {
            await UniTask.RunOnThreadPool(() => {
                var benchmarkTimer = new BenchmarkTimer("TypeRegistry");
                foreach (var (type, friendlyName) in LanguageExtensions.KeywordTypes) {
                    knownTypes[friendlyName] = type;
                }

                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                    try {
                        foreach (var type in assembly.GetTypes()) {
                            if (type.FullName == null) continue;
                            knownTypes[type.FullName] = type;
                        }
                    } catch {
                        // ignored
                    }
                }

                benchmarkTimer.Time("Initialization");
            });
        }

        public void AddType(Type type) {
            if (type.FullName == null) throw new Exception("Type has no name");
            knownTypes[type.FullName] = type;
        }

        public Type GetType(string fullName) {
            if (fullName == null) return null;
            var builtInType = Type.GetType(fullName);
            if (builtInType != null) return builtInType;
            
            return ParseType(fullName);
        }
        
        private static readonly Regex MultiDimensionalArrayTypeRegex = new(@"[^\]]\[([\,]+)]");
        private static readonly Regex GenericTypeRegex = new(@"<(.*)>$");

        private Type ParseType(string friendlyFullName) {
            // Generics
            var genericInnerType = GenericTypeRegex.Match(friendlyFullName).Groups[1].Value;
            if (genericInnerType != "") {
                var baseTypeName = friendlyFullName[..friendlyFullName.IndexOf('<')];

                var innerTypeNames = new List<string>();
                var bracketCounter = 0;
                var lastIndex = 0;
                for (var index = 0; index < genericInnerType.Length; index++) {
                    var s = genericInnerType[index];
                    switch (s) {
                        case '<':
                        case '[':
                            bracketCounter++;
                            break;
                        case '>':
                        case ']':
                            bracketCounter--;
                            break;
                        case ',' when bracketCounter == 0:
                            innerTypeNames.Add(genericInnerType[lastIndex..index]);
                            lastIndex = index + 2;
                            break;
                    }
                }
                innerTypeNames.Add(genericInnerType[lastIndex..]);
                var innerTypes = innerTypeNames.Select(ParseType).ToArray();

                var baseType = ParseType(baseTypeName + '`' + innerTypes.Length);
                if (baseType == null) return null;
                return baseType.MakeGenericType(innerTypes);
            }

            var multiDimCommas = MultiDimensionalArrayTypeRegex.Match(friendlyFullName).Groups[1].Value;
            // Multidimensional array, multiDimCommas is like , or ,,
            if (multiDimCommas != "") {
                // C# has a terrible, terrible design choice on array declaration order:
                // https://stackoverflow.com/questions/12532591/c-sharp-jagged-array-type-declaration-in-reverse
                var baseTypeName = friendlyFullName[..friendlyFullName.IndexOf('[')] + friendlyFullName[(friendlyFullName.IndexOf(']') + 1)..];
                var baseType = ParseType(baseTypeName);
                if (baseType == null) return null;

                var mDimType = baseType.MakeArrayType(multiDimCommas.Length + 1);
                return mDimType;
            }

            // Jagged array
            if (friendlyFullName.Contains("[]")) {
                var baseTypeName = friendlyFullName[..friendlyFullName.IndexOf('[')] + friendlyFullName[(friendlyFullName.IndexOf(']') + 1)..];
                var baseType = ParseType(baseTypeName);
                if (baseType == null) return null;

                var jaggedType = baseType.MakeArrayType();
                return jaggedType;
            }
            
            // Nullable type
            if (friendlyFullName.EndsWith("?")) {
                var baseTypeName = friendlyFullName[..^1];
                var baseType = ParseType(baseTypeName);
                if (baseType == null) return null;
                
                var nullableType = Nullable.GetUnderlyingType(baseType) ?? baseType;
                return nullableType.IsValueType ? typeof(Nullable<>).MakeGenericType(nullableType) : nullableType;
            }

            return knownTypes.GetValueOrDefault(friendlyFullName);
        }

        private readonly Dictionary<Type, EnumType> enumTypes = new();

        public EnumType GetSerializedEnumType(Type enumType) {
            if (!enumType.IsEnum) throw new Exception($"{enumType.FriendlyFullName()} is not an enum type");
            if (enumTypes.ContainsKey(enumType)) return enumTypes[enumType].Clone();
            var data = new EnumType();
            var values = Enum.GetValues(enumType);
            var mappedType = LocalizationManager.GetLocalizedEnumType(enumType);
            var mappedValues = mappedType != null ? Enum.GetValues(mappedType) : null;
            data.members = new SerializedEnum[values.Length];
            for (var i = 0; i < values.Length; i++) {
                var value = (Enum) values.GetValue(i);
                var mappedValue = (Enum)mappedValues?.GetValue(i);
                var mappedLabel = mappedValue?.GetAttributeOfType<LabelAttribute>()?.Label;
                if (mappedValue?.GetAttributeOfType<HideLabelAttribute>() != null) mappedLabel = "";
                data.members[i] = new SerializedEnum {
                    label = value.GetAttributeOfType<LabelAttribute>()?.Label ?? mappedLabel ?? Enum.GetName(enumType, value),
                    value = Convert.ToInt64(value),
                    description = value.GetAttributeOfType<DescriptionAttribute>()?.Description,
                    icon = value.GetAttributeOfType<IconAttribute>()?.Icon,
                };
            }
            enumTypes[enumType] = data;
            return data.Clone();
        }

        public void Dispose() {
            knownTypes?.Clear();
            knownTypes = null;
            enumTypes.Clear();
        }
    }

    public static class TypeExtensions {

        public static bool AllowNullData(this TypeKind kind) {
            return kind is TypeKind.Asset or TypeKind.Reference;
        }
        
        public static bool IsArray(this TypeKind kind) {
            return kind is TypeKind.ValueArray or TypeKind.EnumArray or TypeKind.AssetArray or TypeKind.StructuredDataArray;
        }

        private static readonly Dictionary<Type, TypeKind> TypeKindLookup = new();

        public static TypeKind GetKind(this Type type) {
            if (TypeKindLookup.ContainsKey(type)) return TypeKindLookup[type];
            var typeKind = TypeKind.Reference;
            if (type.IsEnum) {
                typeKind = TypeKind.Enum;
            } else if (type.InheritsFrom(typeof(Asset))) {
                typeKind = TypeKind.Asset;
            } else if (type.InheritsFrom(typeof(StructuredData))) {
                typeKind = TypeKind.StructuredData;
            } else if (type.IsValueTypeOrString()) {
                typeKind = TypeKind.Value;
            } else if (type.IsArray) {
                var elType = type.GetElementType()!;
                if (elType.IsEnum) {
                    typeKind = TypeKind.EnumArray;
                } else if (elType.InheritsFrom(typeof(Asset))) {
                    typeKind = TypeKind.AssetArray;
                } else if (elType.InheritsFrom(typeof(StructuredData))) {
                    typeKind = TypeKind.StructuredDataArray;
                } else if (elType.IsValueTypeOrString()) {
                    typeKind = TypeKind.ValueArray;
                }
            }
            TypeKindLookup[type] = typeKind;
            return typeKind;
        }
        
    }
    
    public enum TypeKind {
        Reference,
        Value, Enum, Asset, StructuredData,
        ValueArray, EnumArray, AssetArray, StructuredDataArray
    }
}
