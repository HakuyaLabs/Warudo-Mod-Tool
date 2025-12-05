using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Warudo.Core.Rendering;
using Warudo.Core.Scenes;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Utils;
using Context = Warudo.Core.Context;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core
{
    public partial class CorePlugin
    {
        public Dictionary<Asset, (Camera camera, RenderTexture renderTexture)> ManagedCameraAssets { get; }

        public UnityEvent<Asset> OnMainCameraAssetChanged { get; }

        public Asset MainCameraAsset
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public Asset TransitionFromCameraAsset { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Camera MainCamera => throw new NotImplementedException();
        public CameraTransition MainCameraTransition { get; private set; }

        public Vector2 WindowSize => throw new NotImplementedException();
        public void RequestCameraTransparency()
        {
            throw new NotImplementedException();
        }

        public Camera RenderTextureCamera => throw new NotImplementedException();
        public void RegisterCamera(Asset asset, Camera camera)
        {
            throw new NotImplementedException();
        }

        public void UnregisterCamera(Asset asset)
        {
            throw new NotImplementedException();
        }

        public void RefreshCameraRenderTextures()
        {
            throw new NotImplementedException();
        }

        public void SetMainCamera(Asset asset)
        {
            throw new NotImplementedException();
        }

        public void NextCamera()
        {
            throw new NotImplementedException();
        }

        public void PreviousCamera()
        {
            throw new NotImplementedException();
        }

        public void StartCameraTransition(Asset fromCameraAsset, Asset toCameraAsset, CameraTransition transition)
        {
            throw new NotImplementedException();
        }

        public void EndCameraTransition()
        {
            throw new NotImplementedException();
        }

        public class CameraTransition
        {
            public string Shader = "Warudo/TextureFade";
            public Ease Easing = Ease.Linear;
            public float Duration = 2f;
            public float Progress;
        }
    }
}