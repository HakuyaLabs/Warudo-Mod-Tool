using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AnimatedImages;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Utils
{
    public class InMemoryImageCache
    {
        public async UniTask<ImageResource> GetImageResource(string url)
        {
            throw new NotImplementedException();
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}