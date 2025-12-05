using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warudo.Core.Resource;
using Warudo.Core.Server;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core
{
    public partial class CorePlugin
    {
        public class GenericResourceUriMetaResolver : IResourceUriMetaResolver
        {
            public GenericResourceUriMetaResolver(string scheme, string authority)
            {
                throw new NotImplementedException();
            }

            public async Task<Dictionary<string, object>> Resolve(Uri uri)
            {
                throw new NotImplementedException();
            }
        }

        public class BuiltInResourceUriMetaResolver : IResourceUriMetaResolver
        {
            public BuiltInResourceUriMetaResolver(string scheme)
            {
                throw new NotImplementedException();
            }

            public async Task<Dictionary<string, object>> Resolve(Uri uri)
            {
                throw new NotImplementedException();
            }
        }
    }
}