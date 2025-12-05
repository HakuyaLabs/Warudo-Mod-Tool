using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Warudo.Core.Localization;

namespace Warudo.Core.Utils {
    public static class LanguageExtensions {

        private static readonly Dictionary<Type, Array> EmptyArrays = new();

        public static Array GetEmptyArray(this Type type) {
            if (EmptyArrays.TryGetValue(type, out var array)) {
                return array;
            }
            EmptyArrays[type] = array = Array.CreateInstance(type, 0);
            return array;
        }
        
        public static string GenerateNextName<T>(this T self, IEnumerable<T> items, Func<T, string> getName, bool addSpace = true) {
            var usedNumbers = new HashSet<int>();
            var name = getName(self);
            foreach (var it in items) {
                if (it.Equals(self)) continue;
                var itName = getName(it);
                if (!itName.StartsWith(name)) continue;
                if (int.TryParse(itName[name.Length..].Trim(), out var num)) {
                    usedNumbers.Add(num);
                } else if (itName.Trim() == name) {
                    usedNumbers.Add(1);
                }
            }
            if (usedNumbers.Count == 0) {
                return name;
            }
            return name + (addSpace ? " " : "") + (usedNumbers.Max() + 1);
        }
        
        public static string GenerateUniqueName<T>(this T self, IEnumerable<T> items, Func<T, string> getName, bool addSpace = true) {
            var list = items.ToList();
            if (list.Where(it => !it.Equals(self)).Any(it => getName(it) == getName(self))) {
                return self.GenerateNextName(list, getName, addSpace);
            }
            return getName(self);
        }
        
        public static MethodInfo GetProvidingMethod<T>(this Type type, string methodName, params Type[] parameterTypes) {
            return GetProvidingMethod(type, typeof(T), methodName, parameterTypes);
        }
        
        public static MethodInfo GetProvidingMethod(this Type type, Type returnType, string methodName, params Type[] parameterTypes) {
            if (methodName == null) {
                throw new ArgumentNullException(nameof(methodName));
            }
            var methodInfo = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            if (methodInfo == null) {
                throw new Exception($"Method {type.Name}::{methodName} does not exist");
            }
            if (methodInfo.ReturnType != returnType) {
                throw new Exception($"Method {type.Name}::{methodName} does not return {returnType.Name}");
            }
            if (methodInfo.GetParameters().Length != parameterTypes.Length || !methodInfo.GetParameters().Select(it => it.ParameterType).SequenceEqual(parameterTypes)) {
                throw new Exception($"Method {type.Name}::{methodName} does not match expected parameters: {string.Join(", ", parameterTypes.Select(t => t.Name))}");
            }
            return methodInfo;
        }
        
        public static string PrettyPrint(this Exception exception) {
            if (exception is UserException userException) {
                return userException.Message + "\n\nStack trace:\n\n" + exception.StackTrace;
            }
            return "AN_ERROR_HAS_OCCURRED_WITH_EXCEPTION".Localized() + "\n"
                + (exception.GetType().FullName ?? "<unknown>") + ": " + exception.Message + "\n"
                + exception.StackTrace;
        }
        
        public static bool IsNullOrWhiteSpace(this string str) {
            return string.IsNullOrWhiteSpace(str);
        }
        
        public static bool IsValueTypeOrString(this Type type) {
            return type.IsValueType || type == typeof(string);
        }

        private static readonly Dictionary<Type, string> TypeNamesCache = new();
        private static readonly Dictionary<(string, string), bool> TypeInheritsFromCache = new();

        private static string GetTypeAssemblyQualifiedNameCached(this Type type) {
            if (TypeNamesCache.TryGetValue(type, out var name)) {
                return name;
            }
            TypeNamesCache[type] = name = type.AssemblyQualifiedName;
            return name;
        }
        
        public static bool InheritsFrom(this Type type, Type baseType) {
            var tuple = (type.GetTypeAssemblyQualifiedNameCached(), baseType.GetTypeAssemblyQualifiedNameCached());
            if (TypeInheritsFromCache.TryGetValue(tuple, out var from)) {
                return from;
            }
            if (baseType.IsAssignableFrom(type)) {
                TypeInheritsFromCache[tuple] = true;
                return true;
            }
            if (type.IsInterface && !baseType.IsInterface) {
                TypeInheritsFromCache[tuple] = false;
                return false;
            }
            if (baseType.IsInterface) {
                var inheritsFrom = type.GetInterfaces().Contains(baseType);
                TypeInheritsFromCache[tuple] = inheritsFrom;
                return inheritsFrom;
            }
            for (var anotherType = type; anotherType != null; anotherType = anotherType.BaseType) {
                if (anotherType == baseType || baseType.IsGenericTypeDefinition && anotherType.IsGenericType && anotherType.GetGenericTypeDefinition() == baseType) {
                    TypeInheritsFromCache[tuple] = true;
                    return true;
                }
            }
            TypeInheritsFromCache[tuple] = false;
            return false;
        }

        public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0 ? (T)attributes[0] : null;
        }

        public static bool HasCustomAttribute<T>(this MemberInfo memberInfo) {
            return memberInfo.GetCustomAttributes(typeof(T), true).Length > 0;
        }

        public static R Let<T, R>(this T self, Func<T, R> block) {
            return block(self);
        }

        public static T Also<T>(this T self, Action<T> block) {
            block(self);
            return self;
        }
        
        public static void Update<T>(this T self, Action<T> block) {
            block(self);
        }

        public static void ForEach<T>(this IEnumerable<T> self, Action<T> block) {
            foreach (var o in self) {
                block(o);
            }
        }
        
        public static void CopyFrom<TK, TV>(this Dictionary<TK, TV> self, Dictionary<TK, TV> other) {
            foreach (var kvp in other) {
                self[kvp.Key] = kvp.Value;
            }
        }

        public static string ToSpacedPascalCase(this string str) {
            return Regex.Replace(str, "(\\B[A-Z])", " $1");
        }

        public static readonly Dictionary<Type, string> KeywordTypes = new() {
            {
                typeof(bool), "bool"
            }, {
                typeof(byte), "byte"
            }, {
                typeof(sbyte), "sbyte"
            }, {
                typeof(char), "char"
            }, {
                typeof(decimal), "decimal"
            }, {
                typeof(double), "double"
            }, {
                typeof(float), "float"
            }, {
                typeof(int), "int"
            }, {
                typeof(uint), "uint"
            }, {
                typeof(long), "long"
            }, {
                typeof(ulong), "ulong"
            }, {
                typeof(object), "object"
            }, {
                typeof(short), "short"
            }, {
                typeof(ushort), "ushort"
            }, {
                typeof(string), "string"
            }, {
                typeof(void), "void"
            }
        };

        /// MIT License
        /// https://github.com/zspitz/ZSpitz.Util
        public static string FriendlyFullName(this Type type) {
            if (type is null) return null;

            if (type.IsClosureClass()) {
                return "<closure>";
            }

            if (type.IsAnonymous()) {
                return "{ " + string.Join(", ", type.GetProperties().Select(p =>
                {
                    var name = p.Name;
                    var typename = p.PropertyType.FriendlyFullName();
                    return $"{typename} {name}";
                })) + " }";
            }

            if (type.IsArray) {
                var (left, right) = ("[", "]");
                var nestedArrayTypes = type.NestedArrayTypes().ToList();
                var arraySpecifiers = nestedArrayTypes.JoinedT("",
                    (current, _, _) => left + Enumerable.Repeat("", current.GetArrayRank()).Joined() + right
                    );
                return nestedArrayTypes.Last().root!.FriendlyFullName() + arraySpecifiers;
            }

            if (!type.IsGenericType) {
                return KeywordTypes.TryGetValue(type, out var ret) ? ret : type.FullName;
            }

            if (type.GetGenericTypeDefinition() == typeof(Nullable<>)) {
                return (Nullable.GetUnderlyingType(type) ?? type).FriendlyFullName() + "?";
            }

            if (type.IsGenericParameter) {
                return type.FullName;
            }

            var parts = type.GetGenericArguments().Joined(", ", t => t.FriendlyFullName()!);
            var nonGenericName = type.NonGenericName();
            return $"{nonGenericName}<{parts}>";
        }

        private static string NonGenericName(this Type t) {
            var backtickIndex = t.FullName!.IndexOf('`');
            var nonGenericName = t.FullName[..backtickIndex];
            return nonGenericName;
        }

        private static bool IsClosureClass(this Type type) =>
            type != null && type.HasCustomAttribute<CompilerGeneratedAttribute>() && type.Name.Contains("DisplayClass");

        private static bool IsAnonymous(this Type type) =>
            type.HasCustomAttribute<CompilerGeneratedAttribute>() && type.Name.Contains("Anonymous") && type.Name.Contains("<>") && !type.InheritsFrom(typeof(Delegate));

        private static IEnumerable<(Type current, Type root)> NestedArrayTypes(this Type type) {
            var currentType = type;
            while (currentType.IsArray) {
                var nextType = currentType.GetElementType()!;
                if (nextType.IsArray) {
                    yield return (currentType, null);
                } else {
                    yield return (currentType, nextType);
                    break;
                }
                currentType = nextType;
            }
        }

        public static string Joined<T>(this IEnumerable<T> source, string delimiter = ",", Func<T, string>? selector = null) =>
            source is null ? "" :
            selector is null ? string.Join(delimiter, source) :
            string.Join(delimiter, source.Select(selector));

        public static string Joined<T>(this IEnumerable<T> source, string delimiter, Func<T, int, string> selector) =>
            source is null ? "" :
            selector is null ? string.Join(delimiter, source) :
            string.Join(delimiter, source.Select(selector));

        public static string JoinedT<T1, T2>(this IEnumerable<(T1, T2)> src, string delimiter, Func<T1, T2, string> selector) =>
            src.Joined(delimiter, x => selector(x.Item1, x.Item2));

        public static string JoinedT<T1, T2>(this IEnumerable<(T1, T2)> src, string delimiter, Func<T1, T2, int, string> selector) =>
            src.Joined(delimiter, (x, index) => selector(x.Item1, x.Item2, index));

        public static string GetReadableFileSize(this ulong i) {
            // Determine the suffix and readable value
            string suffix;
            double readable;
            if (i >= 0x1000000000000000) // Exabyte
            {
                suffix = "EB";
                readable = i >> 50;
            } else if (i >= 0x4000000000000) // Petabyte
            {
                suffix = "PB";
                readable = i >> 40;
            } else if (i >= 0x10000000000) // Terabyte
            {
                suffix = "TB";
                readable = i >> 30;
            } else if (i >= 0x40000000) // Gigabyte
            {
                suffix = "GB";
                readable = i >> 20;
            } else if (i >= 0x100000) // Megabyte
            {
                suffix = "MB";
                readable = i >> 10;
            } else if (i >= 0x400) // Kilobyte
            {
                suffix = "KB";
                readable = i;
            } else {
                return i.ToString("0 B"); // Byte
            }
            // Divide by 1024 to get fractional value
            readable = readable / 1024;
            // Return formatted number with suffix
            return readable.ToString("0.### ") + suffix;
        }

        public static IEnumerable<T> AppendWith<T>(this IEnumerable<T> source, IEnumerable<T> append) {
            foreach (var obj in source)
                yield return obj;
            foreach (var obj in append)
                yield return obj;
        }
        
    }
}
