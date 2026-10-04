using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Warudo.Core.Resource;
using Warudo.Core.Utils;
using Warudo.Plugins.Core;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Utils
{
    public static class ResourceListMemoryCache
    {
        private sealed class CachedName
        {
            public long ticks;
            public long length;
            public string label;
        }

        public static void StartLocal(string root)
        {
            throw new NotImplementedException();
        }

        public static void StartWorkshop(string root)
        {
            throw new NotImplementedException();
        }

        public static bool TryGetLocal(string query, out List<Resource> resources) => throw new NotImplementedException();
        public static bool TryGetWorkshop(string query, out List<Resource> resources) => throw new NotImplementedException();
        public static void Shutdown()
        {
            throw new NotImplementedException();
        }
    }
}