using System;
using System.IO;
#if MAGICA_CLOTH
using MagicaCloth;
#endif
using UMod.BuildEngine;
using UMod.ModTools.Export;
using UMod.Shared;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
#if URP_INSTALLED
using UnityEngine.Rendering.Universal;
#endif
using VRM;
using Warudo.Plugins.Core.Assets.Character;

namespace Warudo.Editor
{
    [UModToolsWindow]
    public class SetupURPWindow : EditorWindow
    {

        private ExportSettings settings;


        private void OnEnable()
        {
            settings = ModScriptableAsset<ExportSettings>.Active.Load();
        }

        private void OnInspectorUpdate()
        {
            Repaint();
        }

        private void SetURPRenderAsset()
        {
            QualitySettings.renderPipeline = AssetDatabase.LoadAssetAtPath<UniversalRenderPipelineAsset>("Assets/UniversalRenderPipelineAsset.asset");
        }

        private static void CreateURPAssets(string urpRenderDataPath, string urpPipelineAssetPath)
        {
            var urpRenderData = AssetDatabase.LoadAssetAtPath<UniversalRendererData>(urpRenderDataPath);
            if (urpRenderData == null)
            {
                urpRenderData = ScriptableObject.CreateInstance<UniversalRendererData>();
                AssetDatabase.CreateAsset(urpRenderData, urpRenderDataPath);
            }

            var urpPipelineAsset = AssetDatabase.LoadAssetAtPath<UniversalRenderPipelineAsset>(urpPipelineAssetPath);
            if (urpPipelineAsset == null)
            {
                urpPipelineAsset = ScriptableObject.CreateInstance<UniversalRenderPipelineAsset>();
                AssetDatabase.CreateAsset(urpPipelineAsset, urpPipelineAssetPath);
            }

            var serializedPipelineAsset = new SerializedObject(urpPipelineAsset);
            var rendererDataProperty = serializedPipelineAsset.FindProperty("m_RendererData");
            var rendererDataListProperty = serializedPipelineAsset.FindProperty("m_RendererDataList");
            var defaultRendererIndexProperty = serializedPipelineAsset.FindProperty("m_DefaultRendererIndex");

            if (rendererDataProperty != null)
            {
                rendererDataProperty.objectReferenceValue = urpRenderData;
            }

            if (rendererDataListProperty != null)
            {
                rendererDataListProperty.arraySize = 1;
                rendererDataListProperty.GetArrayElementAtIndex(0).objectReferenceValue = urpRenderData;
            }

            if (defaultRendererIndexProperty != null)
            {
                defaultRendererIndexProperty.intValue = 0;
            }

            serializedPipelineAsset.ApplyModifiedPropertiesWithoutUndo();

            EditorUtility.SetDirty(urpRenderData);
            EditorUtility.SetDirty(urpPipelineAsset);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        private void OnGUI()
        {
            titleContent.text = "Setup URP";
            if (settings == null)
            {
                EditorGUILayout.LabelField("No export settings found. Please reopen this window.");
                return;
            }

            EditorGUILayout.LabelField("Active mod: " + settings.ActiveExportProfile.ModName);
#if URP_INSTALLED
            var baseAbsolutePath = Application.dataPath;
            var basePath = FileUtil.GetProjectRelativePath(FileSystemUtil.NormalizeDirectory(new DirectoryInfo(baseAbsolutePath)).ToString());
            var urpRenderDataPath = basePath + "/URPRenderData.asset";
            var urpPipelineAssetPath = basePath + "/UniversalRenderPipelineAsset.asset";
            var urpRenderData = AssetDatabase.LoadAssetAtPath<UniversalRendererData>(urpRenderDataPath);
            var urpPipelineAsset = AssetDatabase.LoadAssetAtPath<UniversalRenderPipelineAsset>(urpPipelineAssetPath);

            if (urpRenderData != null && urpPipelineAsset != null)
            {
                EditorGUILayout.LabelField("URP assets already exist.");
                if (QualitySettings.renderPipeline == null || QualitySettings.renderPipeline != urpPipelineAsset)
                {
                    if (GUILayout.Button("Set URP Render Pipeline"))
                    {
                        SetURPRenderAsset();
                        EditorUtility.DisplayDialog("Warudo", "URP Render Pipeline have been set.", "OK");
                        return;
                    }
                }
            }
            else
            {
                EditorGUILayout.LabelField("URP assets not found in the asset.");
                if (GUILayout.Button("Create URP assets"))
                {
                    CreateURPAssets(urpRenderDataPath, urpPipelineAssetPath);
                    EditorUtility.DisplayDialog("Warudo", "URP Asset have been added.", "OK");
                    SetURPRenderAsset();
                    return;
                }
            }
#else
            EditorGUILayout.LabelField("URP is not installed. Please install URP via Package Manager.");   
#endif
            GUI.enabled = true;
        }

    }
}
