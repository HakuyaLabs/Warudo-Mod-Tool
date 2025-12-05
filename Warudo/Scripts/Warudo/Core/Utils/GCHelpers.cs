using System;
using System.Collections.Concurrent;

namespace Warudo.Core.Utils {
    public static class OptimizedExtensions {

        private static readonly ConcurrentDictionary<string, string> ToLowerCache = new();

        public static string ToLowerOptimized(this string str) {
            if (str == null) return null;
            if (ToLowerCache.TryGetValue(str, out var cached)) return cached;
            var lower = str.ToLower();
            ToLowerCache[str] = lower;
            return lower;
        }

    }
}
