using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Cinematography
{
    public partial class CameraAsset
    {
        public OutputMediaType BackgroundContentType = OutputMediaType.None;
        public string BackgroundImageSource;
        public string BackgroundVideoSource;
        public string BackgroundSpoutSource;
        public string BackgroundNdiSource;
        public Texture BackgroundTexture => throw new NotImplementedException();
        public RenderTexture ProcessedOutputTexture => throw new NotImplementedException();
    }
}