#define VERBATIM
using UnityEngine;
using UnityEngine.Rendering;

#if UNITY_EDITOR
using UnityEditor;
#endif
namespace Warudo.Plugins.Core.Assets.Environment
{
    public class EnvironmentSettings : MonoBehaviour
    {
        public Material skyboxMaterial;
        public Light sunSource;
        public Color realtimeShadowColor;
        public AmbientMode environmentLightingScene;
        public Color environmentLightingAmbientColor;
        public float environmentLightingIntensityMultiplier = 1f;
        public DefaultReflectionMode environmentReflectionsSource;
        public int environmentReflectionsResolution;
        public float environmentReflectionsIntensityMultiplier;
        public int environmentReflectionsBounces;
        public bool fog;
        public Color fogColor;
        public FogMode fogMode;
        public float fogDensity;
        public float fogStartDistance = 0f;
        public float fogEndDistance = 300f;
        public float haloStrength;
        public float flareFadeSpeed;
        public float flareStrength;
        public void CopyFromCurrentSettings()
        {
            skyboxMaterial = RenderSettings.skybox;
            sunSource = RenderSettings.sun;
            realtimeShadowColor = RenderSettings.subtractiveShadowColor;
            environmentLightingScene = RenderSettings.ambientMode;
            environmentLightingAmbientColor = RenderSettings.ambientLight;
            environmentLightingIntensityMultiplier = RenderSettings.ambientIntensity;
            environmentReflectionsSource = RenderSettings.defaultReflectionMode;
            environmentReflectionsResolution = RenderSettings.defaultReflectionResolution;
            environmentReflectionsIntensityMultiplier = RenderSettings.reflectionIntensity;
            environmentReflectionsBounces = RenderSettings.reflectionBounces;
            fog = RenderSettings.fog;
            fogColor = RenderSettings.fogColor;
            fogMode = RenderSettings.fogMode;
            fogDensity = RenderSettings.fogDensity;
            fogStartDistance = RenderSettings.fogStartDistance;
            fogEndDistance = RenderSettings.fogEndDistance;
            haloStrength = RenderSettings.haloStrength;
            flareFadeSpeed = RenderSettings.flareFadeSpeed;
            flareStrength = RenderSettings.flareStrength;
        }

        public void Apply()
        {
            RenderSettings.skybox = skyboxMaterial;
            RenderSettings.sun = sunSource;
            RenderSettings.subtractiveShadowColor = realtimeShadowColor;
            RenderSettings.ambientMode = environmentLightingScene;
            RenderSettings.ambientLight = environmentLightingAmbientColor;
            RenderSettings.ambientIntensity = environmentLightingIntensityMultiplier;
            RenderSettings.defaultReflectionMode = environmentReflectionsSource;
            RenderSettings.defaultReflectionResolution = environmentReflectionsResolution;
            RenderSettings.reflectionIntensity = environmentReflectionsIntensityMultiplier;
            RenderSettings.reflectionBounces = environmentReflectionsBounces;
            RenderSettings.fog = fog;
            RenderSettings.fogColor = fogColor;
            RenderSettings.fogMode = fogMode;
            RenderSettings.fogDensity = fogDensity;
            RenderSettings.fogStartDistance = fogStartDistance;
            RenderSettings.fogEndDistance = fogEndDistance;
            RenderSettings.haloStrength = haloStrength;
            RenderSettings.flareFadeSpeed = flareFadeSpeed;
            RenderSettings.flareStrength = flareStrength;
            DynamicGI.UpdateEnvironment();
            // Unity fix
            if (RenderSettings.ambientMode == AmbientMode.Skybox)
            {
                RenderSettings.ambientMode = AmbientMode.Custom;
                RenderSettings.ambientMode = AmbientMode.Skybox;
            }
        }
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(EnvironmentSettings))]
    public class EnvironmentSettingsEditor : Editor {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            if (GUILayout.Button("Copy from current environment settings")) {
                var settings = (EnvironmentSettings)target;
                settings.CopyFromCurrentSettings();
            }
            if (GUILayout.Button("Apply")) {
                var settings = (EnvironmentSettings)target;
                settings.Apply();
            }
        }
    }
#endif
}