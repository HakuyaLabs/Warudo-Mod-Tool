using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using UMod;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Data.Models;
using Warudo.Core.Localization;
using Warudo.Core.Server;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Events;
using Warudo.Plugins.Core.Utils;
using Object = UnityEngine.Object;
using Scene = UnityEngine.SceneManagement.Scene;
using SceneManager = UnityEngine.SceneManagement.SceneManager;
using System;

namespace Warudo.Plugins.Core.Assets.Environment
{
    public sealed class EnvironmentAsset : GameObjectAsset
    {
        public string Source;
        public string SourceMeta;
        public void ApplyEnvironmentLighting()
        {
            throw new NotImplementedException();
        }

        protected bool DisableApplyEnvironmentLighting()
        {
            throw new NotImplementedException();
        }

        public static float CalculateIdealDirectionalLightIntensity()
        {
            throw new NotImplementedException();
        }

        public bool EnableLights = true;
        public bool AllowLightsToAffectCharacters = false;
        public bool AllowLightsToAffectProps = false;
        public bool EnableAudioSources = true;
        public bool EnablePostProcessingVolumes = true;
        public string OverrideEnvironmentSettingsInfo = "OVERRIDE_ENVIRONMENT_SETTINGS_INFO".Localized();
        public bool EnvironmentLightingSourceOverride = false;
        public enum EnvironmentLightingSourceType
        {
            Skybox,
            Color
        }

        public EnvironmentLightingSourceType EnvironmentLightingSource = EnvironmentLightingSourceType.Skybox;
        public float SkyboxLightingIntensity = 1;
        public Color EnvironmentLightingColor = new(54 / 255f, 58 / 255f, 66 / 255f);
        public bool EnvironmentReflectionsIntensityOverride = false;
        public float EnvironmentReflectionsIntensity = 1f;
        public bool FogEnabledOverride = false;
        public bool FogEnabled = true;
        public bool FogColorOverride = false;
        public Color FogColor = new(54 / 255f, 58 / 255f, 66 / 255f);
        public bool FogDensityOverride = false;
        public float FogDensity = 0.01f;
        public bool DoNotChangeGameObjectLayers = false;
        public bool AutoDeactivatedCameraInEnvironment = false;
        public Scene LoadedScene => throw new NotImplementedException();
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        protected override async void OnDestroy()
        {
            throw new NotImplementedException();
        }

        protected override GameObject CreateGameObject()
        {
            throw new NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        public class UpdateSky : MonoBehaviour
        {
            ReflectionProbe baker;
            void Start()
            {
                throw new NotImplementedException();
            }

            IEnumerator UpdateEnvironment()
            {
                throw new NotImplementedException();
            }
        }

        public Transform GetSceneTransform(string path)
        {
            throw new NotImplementedException();
        }

        public AutoCompleteList AutoCompleteGameObjectPath(Func<Transform, bool> predicate = null)
        {
            throw new NotImplementedException();
        }
    }
}