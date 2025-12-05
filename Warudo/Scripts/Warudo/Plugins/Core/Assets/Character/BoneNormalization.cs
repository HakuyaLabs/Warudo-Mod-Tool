#define VERBATIM
using System;
using System.Collections.Generic;
using System.Linq;
using UniGLTF.MeshUtility;
using UniHumanoid;
using UnityEngine;
using VRM;
using Warudo.Core.Utils;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Character
{
    // Much of the code here is brought from UniVRM. Thanks!
    public static class BoneNormalization
    {
        public static void Apply(GameObject go, Animator animator)
        {
            var(normalized, boneMap) = NormalizeHierarchy(go, animator);
            foreach (var src in go.transform.Traverse())
            {
                Transform dst;
                if (!boneMap.TryGetValue(src, out dst))
                {
                    continue;
                }

                NormalizeSkinnedMesh(src, dst, boneMap);
                NormalizeNoneSkinnedMesh(src, dst);
            }

            foreach (var(fromBone, toBone)in boneMap)
            {
                fromBone.localRotation = toBone.localRotation;
                fromBone.localPosition = toBone.localPosition;
            }

            if (Application.isPlaying)
            {
                // Reset dynamic bones
                go.GetComponentsInChildren<DynamicBone>().ForEach(it => it.SetupParticles());
            }

            // Rebuild avatar, and reset bones again.
            // I don't know why this works.jpg
            var avatar = BuildAvatarDescription(go, animator, boneMap).CreateAvatarAndSetup(go.transform);
            avatar.name = go.name + ".normalized";
            animator.avatar = avatar;
            foreach (var(fromBone, toBone)in boneMap)
            {
                fromBone.localRotation = toBone.localRotation;
                fromBone.localPosition = toBone.localPosition;
            }

            if (Application.isEditor)
            {
                Object.DestroyImmediate(normalized);
            }
            else
            {
                Object.Destroy(normalized);
            }
        }

        private static (GameObject, Dictionary<Transform, Transform>) NormalizeHierarchy(GameObject go, Animator animator)
        {
            var boneMap = new Dictionary<Transform, Transform>();
            var normalized = new GameObject(go.name + "(normalized)");
            normalized.transform.position = go.transform.position;
            CopyAndBuild(go.transform, normalized.transform, boneMap);
            var avatarDescription = BuildAvatarDescription(go, animator, boneMap);
            var avatar = avatarDescription.CreateAvatarAndSetup(go.transform);
            avatar.name = go.name + ".normalized";
            return (normalized, boneMap);
        }

        private static AvatarDescription BuildAvatarDescription(GameObject go, Animator animator, Dictionary<Transform, Transform> boneMap)
        {
            var srcHumanBones = Enum.GetValues(typeof(HumanBodyBones)).Cast<HumanBodyBones>().Where(x => x != HumanBodyBones.LastBone).Select(x => new
            {
            Key = x, Value = animator.GetBoneTransform(x)}).Where(x => x.Value != null);
            var map = srcHumanBones.Where(x => boneMap.ContainsKey(x.Value)).ToDictionary(x => x.Key, x => boneMap[x.Value]);
            var vrmHuman = go.GetComponent<VRMHumanoidDescription>();
            var avatarDescription = AvatarDescription.Create();
            if (vrmHuman != null && vrmHuman.Description != null)
            {
                avatarDescription.armStretch = vrmHuman.Description.armStretch;
                avatarDescription.legStretch = vrmHuman.Description.legStretch;
                avatarDescription.upperArmTwist = vrmHuman.Description.upperArmTwist;
                avatarDescription.lowerArmTwist = vrmHuman.Description.lowerArmTwist;
                avatarDescription.upperLegTwist = vrmHuman.Description.upperLegTwist;
                avatarDescription.lowerLegTwist = vrmHuman.Description.lowerLegTwist;
                avatarDescription.feetSpacing = vrmHuman.Description.feetSpacing;
                avatarDescription.hasTranslationDoF = vrmHuman.Description.hasTranslationDoF;
            }

            avatarDescription.SetHumanBones(map);
            return avatarDescription;
        }

        private static void CopyAndBuild(Transform src, Transform dst, Dictionary<Transform, Transform> boneMap)
        {
            boneMap[src] = dst;
            foreach (Transform child in src)
            {
                if (child.gameObject.activeSelf)
                {
                    var dstChild = new GameObject(child.name);
                    dstChild.transform.SetParent(dst);
                    dstChild.transform.position = child.position; // copy position only
                    CopyAndBuild(child, dstChild.transform, boneMap);
                }
            }
        }

        private static void NormalizeSkinnedMesh(Transform src, Transform dst, Dictionary<Transform, Transform> boneMap)
        {
            var srcRenderer = src.GetComponent<SkinnedMeshRenderer>();
            if (srcRenderer == null || !srcRenderer.enabled || srcRenderer.sharedMesh == null || srcRenderer.sharedMesh.vertexCount == 0)
            {
                // 有効なSkinnedMeshRendererが無かった
                return;
            }

            var srcMesh = srcRenderer.sharedMesh;
            var originalSrcMesh = srcMesh;
            // 元の Transform[] bones から、無効なboneを取り除いて前に詰めた配列を作る
            var dstBones = srcRenderer.bones.Where(x => x != null && boneMap.ContainsKey(x)).Select(x => boneMap[x]).ToArray();
            var hasBoneWeight = srcRenderer.bones != null && srcRenderer.bones.Length > 0;
            if (!hasBoneWeight)
            {
                srcMesh = srcMesh.Copy(true);
                var bw = new BoneWeight{boneIndex0 = 0, boneIndex1 = 0, boneIndex2 = 0, boneIndex3 = 0, weight0 = 1.0f, weight1 = 0.0f, weight2 = 0.0f, weight3 = 0.0f, };
                srcMesh.boneWeights = Enumerable.Range(0, srcMesh.vertexCount).Select(x => bw).ToArray();
                srcMesh.bindposes = new[]{Matrix4x4.identity};
                var smrTransform = srcRenderer.transform;
                srcRenderer.rootBone = smrTransform;
                srcRenderer.bones = new[]{smrTransform};
                srcRenderer.sharedMesh = srcMesh;
            }

            var mesh = srcMesh.Copy(false);
            mesh.name = srcMesh.name + ".normalized";
            srcRenderer.BakeMesh(mesh);
            var blendShapeValues = new Dictionary<int, float>();
            for (var i = 0; i < srcMesh.blendShapeCount; i++)
            {
                var val = srcRenderer.GetBlendShapeWeight(i);
                if (val > 0)
                    blendShapeValues.Add(i, val);
            }

            // 新しい骨格のボーンウェイトを作成する
            mesh.boneWeights = MapBoneWeight(srcMesh.boneWeights, boneMap, srcRenderer.bones, dstBones);
            // recalc bindposes
            mesh.bindposes = dstBones.Select(x => x.worldToLocalMatrix * dst.transform.localToWorldMatrix).ToArray();
            //var m = src.localToWorldMatrix; // include scaling
            var m = default(Matrix4x4);
            m.SetTRS(Vector3.zero, src.rotation, Vector3.one); // rotation only
            mesh.ApplyMatrix(m);
            // clear blendShape always
            var backcup = new List<float>();
            for (int i = 0; i < srcMesh.blendShapeCount; ++i)
            {
                backcup.Add(srcRenderer.GetBlendShapeWeight(i));
                srcRenderer.SetBlendShapeWeight(i, 0);
            }

            var meshVertices = mesh.vertices;
            var meshNormals = mesh.normals;
#if VRM_NORMALIZE_BLENDSHAPE_TANGENT
            var meshTangents = mesh.tangents.Select(x => (Vector3)x).ToArray();
#endif
            var originalBlendShapePositions = new Vector3[meshVertices.Length];
            var originalBlendShapeNormals = new Vector3[meshVertices.Length];
            var originalBlendShapeTangents = new Vector3[meshVertices.Length];
            var blendShapeMesh = new Mesh();
            for (int i = 0; i < srcMesh.blendShapeCount; ++i)
            {
                // check blendShape
                srcRenderer.sharedMesh.GetBlendShapeFrameVertices(i, 0, originalBlendShapePositions, originalBlendShapeNormals, originalBlendShapeTangents);
                var hasVertices = originalBlendShapePositions.Count(x => x != Vector3.zero);
                var hasNormals = originalBlendShapeNormals.Count(x => x != Vector3.zero);
#if VRM_NORMALIZE_BLENDSHAPE_TANGENT
                var hasTangents = originalBlendShapeTangents.Count(x => x != Vector3.zero);
#else
                var hasTangents = 0;
#endif
                var name = srcMesh.GetBlendShapeName(i);
                if (string.IsNullOrEmpty(name))
                {
                    name = $"{i}";
                }

                srcRenderer.SetBlendShapeWeight(i, 100.0f);
                srcRenderer.BakeMesh(blendShapeMesh);
                if (blendShapeMesh.vertices.Length != mesh.vertices.Length)
                {
                    throw new Exception("different vertex count");
                }

                var value = blendShapeValues.ContainsKey(i) ? blendShapeValues[i] : 0;
                srcRenderer.SetBlendShapeWeight(i, value);
                Vector3[] vertices = blendShapeMesh.vertices;
                for (int j = 0; j < vertices.Length; ++j)
                {
                    if (originalBlendShapePositions[j] == Vector3.zero)
                    {
                        vertices[j] = Vector3.zero;
                    }
                    else
                    {
                        vertices[j] = m.MultiplyPoint(vertices[j]) - meshVertices[j];
                    }
                }

                Vector3[] normals = blendShapeMesh.normals;
                for (int j = 0; j < normals.Length; ++j)
                {
                    if (originalBlendShapeNormals[j] == Vector3.zero)
                    {
                        normals[j] = Vector3.zero;
                    }
                    else
                    {
                        normals[j] = m.MultiplyVector(normals[j].normalized) - meshNormals[j];
                    }
                }

                Vector3[] tangents = blendShapeMesh.tangents.Select(x => (Vector3)x).ToArray();
#if VRM_NORMALIZE_BLENDSHAPE_TANGENT
                for (int j = 0; j < tangents.Length; ++j)
                {
                    if (originalBlendShapeTangents[j] == Vector3.zero)
                    {
                        tangents[j] = Vector3.zero;
                    }
                    else
                    {
                        tangents[j] = m.MultiplyVector(tangents[j]) - meshTangents[j];
                    }
                }
#endif
                var frameCount = srcMesh.GetBlendShapeFrameCount(i);
                for (int f = 0; f < frameCount; f++)
                {
                    var weight = srcMesh.GetBlendShapeFrameWeight(i, f);
                    try
                    {
                        mesh.AddBlendShapeFrame(name, weight, vertices, hasNormals > 0 ? normals : null, hasTangents > 0 ? tangents : null);
                    }
                    catch (Exception)
                    {
                        Debug.LogErrorFormat("fail to mesh.AddBlendShapeFrame {0}.{1}", mesh.name, srcMesh.GetBlendShapeName(i));
                        throw;
                    }
                }
            }

            // End of BlendShapes
            //srcRenderer.bones = dstBones;
            srcRenderer.sharedMesh = mesh;
            if (!hasBoneWeight)
            {
                // restore bones
                srcRenderer.bones = new Transform[]{};
                srcRenderer.sharedMesh = originalSrcMesh;
            }
        }

        private static void NormalizeNoneSkinnedMesh(Transform src, Transform dst)
        {
            var srcFilter = src.GetComponent<MeshFilter>();
            if (srcFilter == null || srcFilter.sharedMesh == null || srcFilter.sharedMesh.vertexCount == 0)
            {
                return;
            }

            var srcRenderer = src.GetComponent<MeshRenderer>();
            if (srcRenderer == null || !srcRenderer.enabled)
            {
                return;
            }

            var mesh = srcFilter.sharedMesh.Copy(false);
            mesh.name = src.name + ".normalized";
            mesh.ApplyRotationAndScale(src.localToWorldMatrix);
            srcFilter.sharedMesh = mesh;
        }

        private static BoneWeight[] MapBoneWeight(BoneWeight[] src, Dictionary<Transform, Transform> boneMap, Transform[] srcBones, Transform[] dstBones)
        {
            // 処理前後の index の対応表を作成する
            var indexMap = new int[srcBones.Length];
            for (int i = 0; i < srcBones.Length; ++i)
            {
                var srcBone = srcBones[i];
                if (srcBone == null)
                {
                    // 元のボーンが無い
                    indexMap[i] = -1;
                    Debug.LogWarningFormat("bones[{0}] is null", i);
                }
                else
                {
                    if (boneMap.TryGetValue(srcBone, out Transform dstBone))
                    {
                        // 対応するボーンが存在する
                        var dstIndex = Array.IndexOf(dstBones, dstBone);
                        if (dstIndex == -1)
                        {
                            // ありえない。バグ
                            throw new Exception();
                        }

                        indexMap[i] = dstIndex;
                    }
                    else
                    {
                        // 先のボーンが無い
                        indexMap[i] = -1;
                        Debug.LogWarningFormat("{0} is removed", srcBone.name);
                    }
                }
            }

            // 新しいBoneWeightを作成する
            var newBoneWeights = new BoneWeight[src.Length];
            for (int i = 0; i < src.Length; ++i)
            {
                BoneWeight srcBoneWeight = src[i];
                // 0
                CopyOrDropWeight(indexMap, srcBoneWeight.boneIndex0, srcBoneWeight.weight0, (newIndex, newWeight) =>
                {
                    newBoneWeights[i].boneIndex0 = newIndex;
                    newBoneWeights[i].weight0 = newWeight;
                });
                // 1
                CopyOrDropWeight(indexMap, srcBoneWeight.boneIndex1, srcBoneWeight.weight1, (newIndex, newWeight) =>
                {
                    newBoneWeights[i].boneIndex1 = newIndex;
                    newBoneWeights[i].weight1 = newWeight;
                });
                // 2
                CopyOrDropWeight(indexMap, srcBoneWeight.boneIndex2, srcBoneWeight.weight2, (newIndex, newWeight) =>
                {
                    newBoneWeights[i].boneIndex2 = newIndex;
                    newBoneWeights[i].weight2 = newWeight;
                });
                // 3
                CopyOrDropWeight(indexMap, srcBoneWeight.boneIndex3, srcBoneWeight.weight3, (newIndex, newWeight) =>
                {
                    newBoneWeights[i].boneIndex3 = newIndex;
                    newBoneWeights[i].weight3 = newWeight;
                });
            }

            return newBoneWeights;
        }

        private static bool CopyOrDropWeight(int[] indexMap, int srcIndex, float weight, Action<int, float> setter)
        {
            if (srcIndex < 0 || srcIndex >= indexMap.Length)
            {
                // ありえるかどうかわからないが BoneWeight.boneIndexN に変な値が入っている. 
                setter(0, 0);
                return false;
            }

            var dstIndex = indexMap[srcIndex];
            if (dstIndex != -1)
            {
                // 有効なindex。weightをコピーする
                setter(dstIndex, weight);
                return true;
            }
            else
            {
                // 無効なindex。0でクリアする
                setter(0, 0);
                return false;
            }
        }
    }
}