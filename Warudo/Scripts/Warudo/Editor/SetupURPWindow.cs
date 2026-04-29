using System;
using System.IO;
using System.Linq;
using System.Reflection;
#if MAGICA_CLOTH
using MagicaCloth;
#endif
using UMod.BuildEngine;
using UMod.ModTools.Export;
using UMod.Shared;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
#if UNITY_URP
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

        private void OnGUI()
        {
            titleContent.text = "Setup URP";
            if (settings == null)
            {
                EditorGUILayout.LabelField("No export settings found. Please reopen this window.");
                return;
            }

            EditorGUILayout.LabelField("Active mod: " + settings.ActiveExportProfile.ModName);
#if UNITY_URP
            // Check if URPRenderData.asset exists in the mod folder
            var baseAbsolutePath = settings.ActiveExportProfile.ModAssetsPath;
            var basePath = FileUtil.GetProjectRelativePath(FileSystemUtil.NormalizeDirectory(new DirectoryInfo(baseAbsolutePath)).ToString());
            var urpRenderDataPath = Path.Combine(baseAbsolutePath, "URPRenderData.asset");
            if (File.Exists(urpRenderDataPath))
            {
                EditorGUILayout.LabelField("URPRenderData already exists in the mod folder.");
            } else
            {
                EditorGUILayout.LabelField("URPRenderData not found in the mod folder.");
                if (GUILayout.Button("Create URPRenderData.asset"))
                {
                    // Create URPRenderData.asset in the mod folder
                    var urpRenderData = ScriptableObject.CreateInstance<UniversalRendererData>();
                    AssetDatabase.CreateAsset(urpRenderData, urpRenderDataPath);
                    EditorUtility.DisplayDialog("Warudo", "URP Asset have been added.", "OK");
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
