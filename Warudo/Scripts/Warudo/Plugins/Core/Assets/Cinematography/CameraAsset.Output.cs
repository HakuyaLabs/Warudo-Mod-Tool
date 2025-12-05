using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Localization;
using Warudo.Core.Server;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Utils;
using Warudo.Scripts.Warudo.Core.Events;
using Object = UnityEngine.Object;
using System;

namespace Warudo.Plugins.Core.Assets.Cinematography
{
    public partial class CameraAsset
    {
        public async partial void TakeScreenshot()
        {
            throw new NotImplementedException();
        }

        public async UniTask<Texture2D> CreateTexture()
        {
            throw new NotImplementedException();
        }
    }
}