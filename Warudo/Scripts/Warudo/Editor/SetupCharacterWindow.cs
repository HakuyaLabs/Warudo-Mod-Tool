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
using VRM;
using UniVRM10;
using Warudo.Plugins.Core.Assets.Character;

namespace Warudo.Editor {
    [UModToolsWindow]
    public class SetupCharacterWindow : EditorWindow {

        private ExportSettings settings;
        private GameObject selectedCharacter;

        private bool hasAnimator;
        private bool normalizedBones;
        
        private void OnEnable() {
            settings = ModScriptableAsset<ExportSettings>.Active.Load();
            Selection.selectionChanged += UpdateSelectedCharacter;
            UpdateSelectedCharacter();
        }
        
        private void UpdateSelectedCharacter() {
            hasAnimator = false;
            normalizedBones = false;
            
            selectedCharacter = Selection.activeGameObject;
            if (selectedCharacter == null) {
                return;
            }
            
            var animator = selectedCharacter.GetComponent<Animator>();
            hasAnimator = animator != null;
            if (!hasAnimator) {
                return;
            }

            normalizedBones = true;
            for (var i = 0; i < (int) HumanBodyBones.LastBone; i++) {
                var bone = animator.GetBoneTransform((HumanBodyBones) i);
                if (bone == null) continue;
                if (bone.localRotation != Quaternion.identity) {
                    normalizedBones = false;
                    break;
                }
            }
        }

        private void OnInspectorUpdate() {
            Repaint();
        }

        private void OnGUI() {
            titleContent.text = "Setup Character";
            if (settings == null) {
                EditorGUILayout.LabelField("No export settings found. Please reopen this window.");
                return;
            }
            
            EditorGUILayout.LabelField("Active mod: " + settings.ActiveExportProfile.ModName);
            GUI.enabled = selectedCharacter != null;
            if (!GUI.enabled) {
                EditorGUILayout.LabelField("Please select the character GameObject in scene.");
            } else {
                EditorGUILayout.LabelField("Has animator: " + hasAnimator);
                EditorGUILayout.LabelField("Normalized bones: " + normalizedBones);
            }
            if (GUILayout.Button("Setup selected GameObject as character mod")) {
                SetupCharacter();
            }
            GUI.enabled = true;
        }

        public void SetupCharacter() {
            if (selectedCharacter == null) {
                EditorUtility.DisplayDialog("Error", "Please select the character GameObject in scene.", "OK");
                return;
            }
            if (!hasAnimator) {
                EditorUtility.DisplayDialog("Error", "Selected GameObject has no Animator component.", "OK");
                return;
            }

            var baseAbsolutePath = settings.ActiveExportProfile.ModAssetsPath;
            var basePath = FileUtil.GetProjectRelativePath(FileSystemUtil.NormalizeDirectory(new DirectoryInfo(baseAbsolutePath)).ToString());
            var prefabAbsolutePath = Path.Combine(baseAbsolutePath, "Character.prefab");
            if (File.Exists(prefabAbsolutePath)) {
                if (!EditorUtility.DisplayDialog("Warning", $"Character mod already exists at {prefabAbsolutePath[..^".prefab".Length].Replace("\\", "/")}. Overwrite?", "OK", "Cancel")) {
                    return;
                }
            }
            var prefabPath = Path.Combine(basePath, "Character.prefab");
            
            selectedCharacter.transform.position = Vector3.zero;
            selectedCharacter.transform.rotation = Quaternion.identity;

            var colliderGroups = selectedCharacter.GetComponentsInChildren<VRMSpringBoneColliderGroup>();
            var colliderGroupCenters = colliderGroups.ToDictionary(it => it, it =>
                it.Colliders.Select(c => it.transform.TransformPoint(c.Offset)).ToArray());

            // Check if the model is VRM0 or VRM1, which already have normalized bones
            var isVRMModel = selectedCharacter.GetComponent<VRMMeta>() != null ||
                            selectedCharacter.GetComponent<Vrm10Instance>() != null;

            if (!normalizedBones && !isVRMModel) {
                var animator = selectedCharacter.GetComponent<Animator>();
                BoneNormalization.Apply(selectedCharacter.gameObject, animator);
                
                // Store the created avatars and meshes in the mod directory
                var avatar = animator.avatar;
                var avatarPath = Path.Combine(basePath, "Avatar.asset");
                AssetDatabase.CreateAsset(avatar, avatarPath);
                
                var skinnedMeshRenderers = selectedCharacter.GetComponentsInChildren<SkinnedMeshRenderer>();
                foreach (var smr in skinnedMeshRenderers) {
                    var mesh = smr.sharedMesh;
                    if (mesh.name.EndsWith(".normalized")) {
                        var meshPath = Path.Combine(basePath, mesh.name[..^".normalized".Length] + ".asset");
                        AssetDatabase.CreateAsset(mesh, meshPath);
                    }
                }
                
                var meshFilters = selectedCharacter.GetComponentsInChildren<MeshFilter>();
                foreach (var mf in meshFilters) {
                    var mesh = mf.sharedMesh;
                    if (mesh.name.EndsWith(".normalized")) {
                        var meshPath = Path.Combine(basePath, mesh.name[..^".normalized".Length] + ".asset");
                        AssetDatabase.CreateAsset(mesh, meshPath);
                    }
                }
            }
            
            selectedCharacter.name = "Character";
            selectedCharacter.transform.localScale = Vector3.one;

            if (PrefabUtility.IsAnyPrefabInstanceRoot(selectedCharacter)) {
                PrefabUtility.UnpackPrefabInstance(selectedCharacter, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            }
            PrefabUtility.SaveAsPrefabAssetAndConnect(selectedCharacter, prefabPath, InteractionMode.AutomatedAction);
            
            if (!normalizedBones) {
#if MAGICA_CLOTH
                var updatedMagicaCloth = false;
                
                // Since bones are changed, needed to recreate any MagicaCloth bone-based components
                var magicaBoneCloths = selectedCharacter.GetComponentsInChildren<MagicaBoneCloth>();
                updatedMagicaCloth |= magicaBoneCloths.Length > 0;
                foreach (var magicaBoneCloth in magicaBoneCloths) {
                    var editor = (MagicaBoneClothInspector) UnityEditor.Editor.CreateEditor(magicaBoneCloth);
                    editor.OnInspectorGUI();
                    if (magicaBoneCloth.ClothSelection == null) {
                        var initSelectorDataMethod =
                            typeof(ClothEditor).GetMethod(
                                "InitSelectorData",
                                BindingFlags.Instance | BindingFlags.NonPublic,
                                Type.DefaultBinder,
                                Type.EmptyTypes,
                                null);
                        initSelectorDataMethod!.Invoke(editor, null);
                    }
                    BuildManager.CreateComponent(magicaBoneCloth);
                }
                var magicaBoneSprings = selectedCharacter.GetComponentsInChildren<MagicaBoneSpring>();
                updatedMagicaCloth |= magicaBoneSprings.Length > 0;
                foreach (var magicaBoneSpring in magicaBoneSprings) {
                    var editor = (MagicaBoneSpringInspector) UnityEditor.Editor.CreateEditor(magicaBoneSpring);
                    editor.OnInspectorGUI();
                    BuildManager.CreateComponent(magicaBoneSpring);
                }
                
                if (updatedMagicaCloth) {
                    Debug.Log("Updated MagicaCloth components");
                    EditorUtility.DisplayDialog("Warning", "MagicaCloth bone-based components are recreated. Please check in Play Mode that the physics are working correctly.", "OK");
                }
#endif
                
                var updatedVRMSpringBoneColliders = false;
                
                foreach (var colliderGroup in colliderGroups) {
                    var centers = colliderGroupCenters[colliderGroup];
                    var colliders = colliderGroup.Colliders;
                    for (var i = 0; i < centers.Length; i++) {
                        var collider = colliders[i];
                        collider.Offset = colliderGroup.transform.InverseTransformPoint(centers[i]);
                    }
                }
                
                if (colliderGroups.Length > 0) {
                    updatedVRMSpringBoneColliders = true;
                }
                
                if (updatedVRMSpringBoneColliders) {
                    Debug.Log("Updated VRMSpringBoneColliderGroup components");
                    EditorUtility.DisplayDialog("Warning", "VRMSpringBoneColliderGroup components are updated. Please check in Play Mode that the physics are working correctly.", "OK");
                }
                
                PrefabUtility.SaveAsPrefabAssetAndConnect(selectedCharacter, prefabPath, InteractionMode.AutomatedAction);
            }
            
            EditorUtility.DisplayDialog("Success", $"Character mod created at {prefabAbsolutePath[..^".prefab".Length]}.", "OK");
        }

    }
}
