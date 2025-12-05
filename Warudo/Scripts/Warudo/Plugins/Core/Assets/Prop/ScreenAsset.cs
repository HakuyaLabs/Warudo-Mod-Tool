using Cysharp.Threading.Tasks;
using System;
using System.Linq;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Rendering;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Cinematography;
using Warudo.Plugins.Core.Assets.Mixins;
using Warudo.Plugins.Core.Events;
using Warudo.Plugins.Core.Mixins;
using Warudo.Plugins.Core.Utils;
using Object = UnityEngine.Object;
using System;

namespace Warudo.Plugins.Core.Assets.Prop
{
    public class ScreenAsset : GameObjectAsset
    {
        public Attachable Attachable;
        public Vector2 ScreenSize = new(1920, 1080);
        public bool IsShowScreenSizeOutline = false;
        public void HideScreenSizeOutline()
        {
            throw new NotImplementedException();
        }

        public void ShowScreenSizeOutline()
        {
            throw new NotImplementedException();
        }

        public ScreenContentType ContentType = ScreenContentType.Display;
        public enum ScreenContentType
        {
            Display,
            Window,
            Browser,
            Image,
            Video,
            Spout,
            Ndi
        }

        public string DisplayName;
        protected async UniTask<AutoCompleteList> AutoCompleteDisplayName()
        {
            throw new NotImplementedException();
        }

        protected bool HideDisplaySection() => throw new NotImplementedException();
        public string WindowTitle;
        protected async UniTask<AutoCompleteList> AutoCompleteWindowTitle()
        {
            throw new NotImplementedException();
        }

        protected bool HideWindowSection() => throw new NotImplementedException();
        public string ImageSource;
        public void OpenImagesFolder()
        {
            throw new NotImplementedException();
        }

        protected bool HideImageSection() => throw new NotImplementedException();
        public string VideoSource;
        public void OpenVideosFolder()
        {
            throw new NotImplementedException();
        }

        public PlaybackMixin VideoPlayback;
        public bool VideoAutoPlay = true;
        protected bool HideVideoSection() => throw new NotImplementedException();
        public bool BrowserUseHtml = false;
        protected bool HideBrowserUrlSection() => throw new NotImplementedException();
        protected bool HideBrowserHTMLSection() => throw new NotImplementedException();
        public string BrowserUrl;
        public string BrowserHTML = "<html>\n<head></head>\n<body>\n</body>\n</html>";
        public void BrowserReloadPage()
        {
            throw new NotImplementedException();
        }

        public bool BrowserAllowTransparentBackground = true;
        public string BrowserCustomCss;
        protected bool HideBrowserSection() => throw new NotImplementedException();
        public string SpoutSource;
        protected async UniTask<AutoCompleteList> AutoCompleteSpoutSource() => throw new NotImplementedException();
        public TextureFormat SpoutTextureFormat = TextureFormat.RGBA4444;
        public bool SpoutMipChain = false;
        public bool SpoutLinear = true;
        protected bool HideSpoutSection() => throw new NotImplementedException();
        public string NdiSource;
        protected async UniTask<AutoCompleteList> AutoCompleteNdiSource() => throw new NotImplementedException();
        protected bool HideNdiSection() => throw new NotImplementedException();
        public bool Bend = true;
        public float BendRadius = 5.0f;
        public float Thickness = 0f;
        public Vector4 Crop = Vector4.zero;
        public Vector4 CornerRadius = Vector4.zero;
        public Color Tint = Color.white;
        public bool UseChromaKey;
        public Color ChromaKeyColor = Color.green;
        protected bool HideChromaKeySection() => throw new NotImplementedException();
        public bool AlwaysFaceCamera;
        public CameraAsset FaceCamera;
        protected bool HideFaceCameraSection() => throw new NotImplementedException();
        public bool FaceCameraLockXAxis = true;
        public bool ReceiveLighting;
        protected bool HideReceiveLighting() => throw new NotImplementedException();
        protected bool HideLightingSection() => throw new NotImplementedException();
        public float Smoothness = 0.5f;
        public float Metallic = 0f;
        public float Emissive = 0f;
        public enum AutoRotateType
        {
            None,
            CCW,
            CW
        }

        public AutoRotateType AutoRotate = AutoRotateType.None;
        public bool IsAutoRotated()
        {
            throw new NotImplementedException();
        }

        public bool UseMask = false;
        public string MaskSource;
        public void OpenMaskImageFolder()
        {
            throw new NotImplementedException();
        }

        protected bool HideMask() => throw new NotImplementedException();
        public Vector2 BrowserSize = new(1920, 1080);
        public float GetContentFillPercent() => throw new NotImplementedException();
        public float GetRadiusConvert() => throw new NotImplementedException();
        public Texture DisplayTexture => throw new NotImplementedException();
        public ImageResource Image => throw new NotImplementedException();
        public RenderTexture VideoTexture => throw new NotImplementedException();
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        protected override void OnDestroy()
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(SerializedAsset serialized)
        {
            throw new NotImplementedException();
        }

        public void UpdateSize()
        {
            throw new NotImplementedException();
        }

        protected override GameObject CreateGameObject()
        {
            throw new NotImplementedException();
        }

        public void ForceRecreateWebView()
        {
            throw new NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }
    }
}