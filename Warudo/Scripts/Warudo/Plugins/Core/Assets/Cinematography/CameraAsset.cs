using Cinemachine;
using DG.Tweening;
using JetBrains.Annotations;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Localization;
using Warudo.Core.Rendering;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Events;
using Warudo.Scripts.Warudo.Core.Events;
using static Warudo.Plugins.Core.CorePlugin;
using Icon = Warudo.Core.Attributes.IconAttribute;
using Object = UnityEngine.Object;
using System;

namespace Warudo.Plugins.Core.Assets.Cinematography
{
    public partial class CameraAsset : GameObjectAsset
    {
        public CameraControlMode ControlMode = CameraControlMode.FreeLook;
        public float ControlSensitivity = 1f;
        public bool ControllerInputEnabled = false;
        public ControllerIndex ControllerIndex = ControllerIndex.One;
        public float ControllerSensitivity = 1f;
        public bool ControllerInvertXAxis = false;
        public bool ControllerInvertYAxis = false;
        public CharacterAsset FocusCharacter;
        public bool FollowCharacter = true;
        public float FollowCharacterSpeed = 0.9f;
        protected bool HideFollowCharacterSpeed() => throw new NotImplementedException();
        public void ResetCameraTransform()
        {
            throw new NotImplementedException();
        }

        public float FieldOfView = 35f;
        public string PostprocessingDisabledHint = "POST_PROCESSING_EFFECTS_DISABLED_FOR_NON_OPAQUE_BACKGROUND".Localized();
        protected bool HidePostprocessingDisabledHint() => throw new NotImplementedException();
        public bool TransparentBackground = false;
        public bool UseChromaKey;
        public Color ChromaKeyColor = Color.green;
        protected bool HideChromaKeyColor() => throw new NotImplementedException();
        public bool RenderCharacters = true;
        public bool RenderProps = true;
        public bool RenderEnvironment = true;
        public bool RenderScreen = true;
        public float NearClipPlane = 0.01f;
        public float FarClipPlane = 5000f;
        public bool OrthographicProjection = false;
        public string OutputHint = "CAMERA_OUTPUT_HINT".Localized();
        public bool SpoutOutput;
        public string SpoutOutputMessage = "";
        public string SpoutOutputName => throw new NotImplementedException();
        public string DuplicateSpoutOutputNameWarning = "DUPLICATE_SPOUT_NAME_WARNING".Localized();
        protected bool HideDuplicateSpoutOutputNameWarning()
        {
            throw new NotImplementedException();
        }

        public bool NdiOutput;
        public string NdiOutputMessage = "";
        public string NdiOutputName => throw new NotImplementedException();
        public string DuplicateNdiOutputNameWarning = "DUPLICATE_NDI_NAME_WARNING".Localized();
        protected bool HideDuplicateNdiOutputNameWarning()
        {
            throw new NotImplementedException();
        }

        public bool VirtualCamOutput;
        public bool MirrorVirtualCamOutput;
        public string VirtualCamOutputMessage = "";
        protected bool HideVirtualCamOutputOptions() => throw new NotImplementedException();
        public partial void TakeScreenshot();
        public bool NoiseEnabled;
        public float NoiseAmplitude = 0.5f;
        public float NoiseFrequency = 1f;
        protected bool HideBiRPPostprocessingOptions() => throw new NotImplementedException();
        public string LUTTexture;
        public void LUTOpenImagesFolder()
        {
            throw new NotImplementedException();
        }

        public float LUTIntensity = 1f;
        public bool ACESTonemapping = false;
        public float Vibrance = 1f;
        public float Contrast = 1.02f;
        public float Brightness = 1.05f;
        public Color Tint = Color.clear;
        public bool EnableBloom = false;
        public float BloomIntensity = 0.1f;
        public float BloomThreshold = 0.75f;
        public Color BloomTint = Color.clear;
        public float BloomDepthAttenuation = 0f;
        public float BloomNearAttenuationDistance = 0f;
        public bool BloomHighQuality = true;
        public bool EnableHBAO = false;
        public string HBAOHint = "HBAO_EFFECT_HINT".Localized();
        public float HBAORadius = 1f;
        public int HBAOMaxRadiusPixels = 128;
        public float HBAOIntensity = 1f;
        public Color HBAOColor = Color.black;
        public bool HBAOHighQuality = true;
        public bool EnableAnamorphicFlares = false;
        public float AnamorphicFlaresIntensity = 0.1f;
        public float AnamorphicFlaresThreshold = 0.75f;
        public Color AnamorphicFlaresTint = Color.clear;
        public float AnamorphicFlaresSpread = 1f;
        public bool AnamorphicFlaresVertical = false;
        public bool AnamorphicFlaresHighQuality = true;
        public bool EnableDepthOfField = false;
        public bool DepthOfFieldEnableFocusCharacter = true;
        public float DepthOfFieldFocusDistance = 1f;
        protected bool HideDepthOfFieldFocusDistance() => throw new NotImplementedException();
        public float DepthOfFieldFocusSpeed = 1f;
        public float DepthOfFieldFocalLength = 0.25f;
        public float DepthOfFieldAperture = 2.8f;
        public bool DepthOfFieldBokeh = true;
        public float DepthOfFieldBokehThreshold = 1f;
        public float DepthOfFieldBokehIntensity = 2f;
        protected bool HideDepthOfFieldBokehInputs() => throw new NotImplementedException();
        public bool DepthOfFieldHighQuality = true;
        public bool EnableChromaticAberration = false;
        public float ChromaticAberrationIntensity = 0.5f;
        public float ChromaticAberrationSmoothing = 0f;
        public string LensDirtTexture;
        public void LensDirtOpenImagesFolder()
        {
            throw new NotImplementedException();
        }

        public float LensDirtIntensity = 0.9f;
        public float LensDirtThreshold = 0.5f;
        public bool EnableVignetting = false;
        public Color VignettingColor = new Color(76f / 255f, 76f / 255f, 76f / 255f, 13f / 255f);
        public float VignettingFadeOut = 0f;
        public float VignettingBlink = 0f;
        public bool EnableNightVision = false;
        public Color NightVisionColor = new Color(128f / 255f, 255f / 255f, 128f / 255f, 128f / 255f);
        public bool EnableBlur = false;
        public float BlurIntensity = 1f;
        public bool EnablePixelate = false;
        public int PixelateIntensity = 16;
        public Vector2 OrbitRotation = new Vector2(180f, 0.5f);
        public Vector3 OrbitOffset;
        public Camera Camera { get; private set; }

        public bool ShouldUpdateFreeLook { get; set; }

        public CinemachineBrain CinemachineBrain { get; set; }

        public CinemachineFreeLook CinemachineFreeLook { get; set; }

        public CinemachineComposer CinemachineFreeLookCenterRigComposer { get; set; }

        public CinemachineBasicMultiChannelPerlin CinemachineFreeLookNoise { get; set; }

        public CinemachineVirtualCamera CinemachineVirtualCamera { get; set; }

        public CinemachineBasicMultiChannelPerlin CinemachineVirtualCameraNoise { get; set; }

        public CinemachineCameraOffset CinemachineCameraOffset { get; set; }

        public CinemachineImpulseSource CinemachineImpulseSource { get; set; }

        public PostProcessLayer BiRPPostProcessLayer { get; private set; }

        protected bool ShouldRender()
        {
            throw new NotImplementedException();
        }

        protected override GameObject CreateGameObject()
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(SerializedAsset serialized)
        {
            throw new NotImplementedException();
        }

        public override void EnableTransformGizmo()
        {
            throw new NotImplementedException();
        }

        public override void DisableTransformGizmo()
        {
            throw new NotImplementedException();
        }

        public void InitializeCameraTransform()
        {
            throw new NotImplementedException();
        }

        public void TeleportTo(Vector3 position, Quaternion rotation, bool broadcast = true)
        {
            throw new NotImplementedException();
        }

        public Action OnUpdateDelegate;
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

        protected override void OnDestroy()
        {
            throw new NotImplementedException();
        }

        public enum CameraControlMode
        {
            None,
            FreeLook,
            Orbit
        }

        public void UpdateLUTTexture()
        {
            throw new NotImplementedException();
        }

        public void UpdateLensDirtTexture()
        {
            throw new NotImplementedException();
        }

        public override void Store(Guid newId)
        {
            throw new NotImplementedException();
        }

        protected CorePlugin CorePlugin => throw new NotImplementedException();
    }
}