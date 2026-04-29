using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using UMod;
using UnityEngine;
using Vexe.Fast.Reflection;
using Warudo.Core;
using Warudo.Core.Resource;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core
{
    public partial class CorePlugin
    {
        public abstract class LocalGenericResourceUriThumbnailResolver : IResourceUriThumbnailResolver
        {
            public abstract string ResolveFilePath(Uri uri);
            public async Task<byte[]> Resolve(Uri uri)
            {
                throw new NotImplementedException();
            }
        }

        public class PersistentDataDirectoryGenericResourceUriThumbnailResolver : LocalGenericResourceUriThumbnailResolver
        {
            public override string ResolveFilePath(Uri uri)
            {
                throw new NotImplementedException();
            }
        }
    }
}