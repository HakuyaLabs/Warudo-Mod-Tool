using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using RuntimeGizmos;
using UnityEngine;
using UnityEngine.Rendering;
using UniVRM10.FastSpringBones;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Events;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using Warudo.Core.Plugins;
using Warudo.Core.Rendering;
using Warudo.Core.Resource;
using Warudo.Core.Scenes;
using Warudo.Core.Serializations;
using Warudo.Core.Server;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Assets.Cinematography;
using Warudo.Plugins.Core.Assets.Environment;
using Warudo.Plugins.Core.Assets.MotionCapture;
using Warudo.Plugins.Core.Assets.Prop;
using Warudo.Plugins.Core.Events;
using Warudo.Plugins.Core.Utils;
using WebSocketSharp.Server;
using Debug = UnityEngine.Debug;
using File = System.IO.File;
using Object = UnityEngine.Object;
using ShadowResolution = UnityEngine.ShadowResolution;
using TransformGizmo = Warudo.Plugins.Core.Utils.TransformGizmo;
using System;

namespace Warudo.Plugins.Core
{
    public partial class CorePlugin : Plugin<SceneData>
    {
        public const int WebSocketMessageServicePort = 19190;
        public const string OutputName = "Warudo";
        class WindowSizeEntry
        {
            public string Name;
            public int Width;
            public int Height;
            public float RenderResolutionMultiply;
        }

        public string Language = "auto";
        public bool LaunchClientOnStart = true;
        public bool SpoutOutput = true;
        public string SpoutOutputMessage = "SENDING_OUTPUT_TO_SPOUT".Localized(OutputName);
        public bool NdiOutput;
        public string NdiOutputMessage = "SENDING_OUTPUT_TO_NDI".Localized(OutputName);
        public bool VirtualCamOutput;
        public bool MirrorVirtualCamOutput;
        public string VirtualCamOutputMessage = "";
        protected bool HideVirtualCamOutputOptions() => throw new NotImplementedException();
        public string WindowSizeSelection = "CUSTOM";
        public async UniTask<AutoCompleteList> GetWindowSizes()
        {
            throw new NotImplementedException();
        }

        public bool ShouldHideCustomWindowSize() => throw new NotImplementedException();
        public int WindowWidth = 1280;
        public int WindowHeight = 720;
        public bool FixedWindowSize = false;
        public float RenderResolutionMultiply = 1f;
        public bool PauseRender = false;
        public async void RequestStepRender()
        {
            throw new NotImplementedException();
        }

        public FPSLimitType FPSLimit = FPSLimitType._60Hz;
        public enum FPSLimitType
        {
            Off,
            _60Hz,
            _90Hz,
            _120Hz,
            _30Hz
        }

        public bool UseVSync = false;
        public AntiAliasingType AntiAliasing = AntiAliasingType.FXAA;
        public enum AntiAliasingType
        {
            Off,
            FXAA,
            SMAALow,
            SMAAMedium,
            SMAAHigh,
            MSAA2x,
            MSAA4x,
            MSAA8x
        }

        public bool DLSS = false;
        protected bool HideDLSS() => throw new NotImplementedException();
        public enum DLSSQualityType
        {
            Off = 0,
            NativeAA = 1,
        }

        public DLSSQualityType DLSSQuality = DLSSQualityType.NativeAA;
        protected bool HideDLSSOptions() => throw new NotImplementedException();
        public float DLSSAntiGhosting = 0.1f;
        public float DLSSSharpening = 0f;
        public ShadowResolution ShadowResolution = ShadowResolution.VeryHigh;
        public ShadowProjection ShadowProjection = ShadowProjection.CloseFit;
        public SkinWeights SkinWeights = SkinWeights.FourBones;
        public ProcessPriorityClass ProcessPriority = ProcessPriorityClass.Normal;
        public bool IncreasedGPUPriority = true;
        public bool SSAO = false;
        public bool Decal = false;
        public bool GrabPass = false;
        protected partial bool HideIncreasedGPUPriority();
        public TransformGizmo TransformGizmo { get; }

        public TransformType GizmoTransformType { get; set; }

        public TransformSpace GizmoTransformSpace { get; set; }

        public bool GizmoEnabled { get; set; }

        public SharedImageResources SharedImageResources { get; }

        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        protected override void OnDestroy()
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(SerializedPlugin serialized)
        {
            throw new NotImplementedException();
        }

        public override void OneTimeSetup()
        {
            throw new NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        public override void OnLateUpdate()
        {
            throw new NotImplementedException();
        }

        public override void OnPostLateUpdate()
        {
            throw new NotImplementedException();
        }

        public override void OnApplicationQuit()
        {
            throw new NotImplementedException();
        }

        public async UniTask<AutoCompleteList> AutoCompleteLanguages()
        {
            throw new NotImplementedException();
        }

        public override void OnSceneLoaded(Scene scene, SerializedScene serializedScene)
        {
            throw new NotImplementedException();
        }

        public override void OnSceneUnloaded(Scene scene)
        {
            throw new NotImplementedException();
        }

        public override void OnMessageReceived(string action, string payload)
        {
            throw new NotImplementedException();
        }

        private enum WebViewState
        {
            Created,
            Killing,
            Killed
        }

        public async Task BeforeListenToPort()
        {
            throw new NotImplementedException();
        }

        protected float token;
        public async void AfterListenToPort()
        {
            throw new NotImplementedException();
        }

        public async Task ReadyToCreateWebView()
        {
            throw new NotImplementedException();
        }

        public void MarkWebViewAsKilled()
        {
            throw new NotImplementedException();
        }

        private delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);
        public static IntPtr GetWindowHandle()
        {
            throw new NotImplementedException();
        }
    }

    public class SceneData
    {
        public Guid mainCamera;
        public bool v0_12_1_addedPendulumPhysics;
    }
}