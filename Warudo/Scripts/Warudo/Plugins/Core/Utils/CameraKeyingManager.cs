using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Warudo.Plugins.Core.Assets.Cinematography;
using Object = UnityEngine.Object;
using System;

namespace Warudo.Plugins.Core.Utils
{
    public enum KeyLayerSourceType
    {
        None = 0,
        Image = 1,
        Video = 2,
        Spout = 3,
        Ndi = 4,
        InternalImage = 5
    }

    public enum KeyPositionAnchor
    {
        BottomLeft,
        MiddleLeft,
        TopLeft,
        BottomCenter,
        Center,
        TopCenter,
        BottomRight,
        MiddleRight,
        TopRight
    }

    public sealed class KeyLayer
    {
        public KeyLayerSourceType SourceType;
        public string Source;
        public Texture2D InternalImage;
        public Vector2 Position = new(0.5f, 0.5f);
        public KeyPositionAnchor Anchor;
        public bool UseReferenceOutputSize;
        public Vector2Int ReferenceOutputSize = new(1920, 1080);
        public bool PreserveReferenceAspectRatio;
        public Vector2 Scale = Vector2.one;
        public float Rotation;
        public float Opacity = 1f;
        public string[] Tags = Array.Empty<string>();
    }

    public sealed class UpstreamKeyConfiguration
    {
        public string CameraId;
        public string VirtualCameraId;
        public List<KeyLayer> Layers = new();
    }

    public sealed class CameraKeyingManager : MonoBehaviour
    {
        private sealed class OutputState
        {
            public RenderTexture Output;
            public RenderTexture Scratch;
            public void EnsureSize(RenderTexture raw, bool alignForMedia)
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }

        private sealed class RuntimeLayer
        {
            public KeyLayer Settings;
            public OutputMediaSource Media;
            public RawImage Image;
            public Texture Texture => throw new NotImplementedException();
        }

        public const string AllCamerasId = "ALL_CAMERA";
        public const string OnlyDirectorId = "ONLY_DIRECTOR";
        public static CameraKeyingManager Current => throw new NotImplementedException();
        public static CameraKeyingManager Ensure()
        {
            throw new NotImplementedException();
        }

        public void RefreshFromInspector() => throw new NotImplementedException();
        public void RegisterCamera(CameraAsset asset, Camera camera)
        {
            throw new NotImplementedException();
        }

        public void UnregisterCamera(CameraAsset asset)
        {
            throw new NotImplementedException();
        }

        public RenderTexture GetCameraOutput(CameraAsset asset)
        {
            throw new NotImplementedException();
        }

        public void SetUpstreamLayers(Guid cameraId, Guid virtualCameraId, IReadOnlyList<KeyLayer> layers)
        {
            throw new NotImplementedException();
        }

        public void SetAllCameraUpstreamLayers(IReadOnlyList<KeyLayer> layers)
        {
            throw new NotImplementedException();
        }

        public void SetOnlyDirectorUpstreamLayers(IReadOnlyList<KeyLayer> layers)
        {
            throw new NotImplementedException();
        }

        public void SetActiveDirectorCamera(CameraAsset asset)
        {
            throw new NotImplementedException();
        }

        public void SetDownstreamLayers(IReadOnlyList<KeyLayer> layers)
        {
            throw new NotImplementedException();
        }

        public KeyLayer GetUSKLayerByTag(string tag)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<KeyLayer> GetUSKLayersByTag(string tag)
        {
            throw new NotImplementedException();
        }

        public KeyLayer GetDSKLayerByTag(string tag)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<KeyLayer> GetDSKLayersByTag(string tag)
        {
            throw new NotImplementedException();
        }

        public void RegisterDirectorCamera(CameraAsset asset, ICinemachineCamera virtualCamera, Guid id)
        {
            throw new NotImplementedException();
        }

        public void ClearDirectorCameras(CameraAsset asset)
        {
            throw new NotImplementedException();
        }

        public RenderTexture ComposePreview(CameraAsset asset, Camera previewCamera, Guid virtualCameraId)
        {
            throw new NotImplementedException();
        }

        public void ReleasePreview(Camera previewCamera)
        {
            throw new NotImplementedException();
        }

        public void ComposeCamera(Camera camera, RenderTexture source = null)
        {
            throw new NotImplementedException();
        }

        public void StopMediaSources()
        {
            throw new NotImplementedException();
        }
    }
}