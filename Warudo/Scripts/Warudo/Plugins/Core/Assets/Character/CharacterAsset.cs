using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Animancer;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using RootMotion;
using RootMotion.Dynamics;
using RootMotion.FinalIK;
using UnityEngine;
using UniVRM10;
using UniVRM10.FastSpringBones;
using Vexe.Fast.Reflection;
using VRM;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Localization;
using Warudo.Core.Resource;
using Warudo.Core.Serializations;
using Warudo.Core.Server;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Utility;
using Warudo.Plugins.Core.Nodes;
using Warudo.Plugins.Core.Utils;
using Context = Warudo.Core.Context;
using Object = UnityEngine.Object;
using System;

namespace Warudo.Plugins.Core.Assets.Character
{
    public sealed partial class CharacterAsset : FromSourceGameObjectAsset, IMeshDataParent
    {
        public const string DefaultIdleAnimationUri = "character-animation://resources/Animations/AGIA/01_Idles/AGIA_Idle_generic_01";
        protected override bool UsePreviewGallery => throw new NotImplementedException();
        public bool TrackingEnabled;
        public QuickCalibrationData QuickCalibration;
        public BlueprintNavigationData BlueprintNavigation;
        public partial void SetupTracking();
        public partial void RemoveTracking();
        public void OpenExpressionProfilesFolder()
        {
            throw new NotImplementedException();
        }

        public string DebugExpressionState;
        public ExpressionData[] Expressions;
        public void TriggerImportVRMExpressions()
        {
            throw new NotImplementedException();
        }

        public partial void TriggerGenerateKeyBindingGraph();
        public partial void TriggerRemoveKeyBindingGraph();
        public BlendShapeEntry[] DefaultBlendShapes;
        public MaterialPropertyEntry[] DefaultMaterialProperties;
        public class BlendShapeEntry : BlendShapeEntryDataBase<CharacterAsset>
        {
            protected override Dictionary<string, SkinnedMeshRenderer> ParentSkinnedMeshRenderers => throw new NotImplementedException();
            protected override bool ParentActive => throw new NotImplementedException();
            protected override CharacterAsset ParentCharacter => throw new NotImplementedException();
        }

        public class MaterialPropertyEntry : MaterialPropertyEntryBase<CharacterAsset>
        {
            protected override bool ParentActive => throw new NotImplementedException();
            protected override Dictionary<string, List<Material>> ParentMaterials => throw new NotImplementedException();
            protected override Dictionary<string, List<ShaderProperty>> ParentMaterialProperties => throw new NotImplementedException();
            protected override CharacterAsset ParentCharacter => throw new NotImplementedException();
            protected override bool HideTransitionDataInputs() => throw new NotImplementedException();
        }

        public void OpenAnimationProfilesFolder()
        {
            throw new NotImplementedException();
        }

        public string DefaultIdleAnimation;
        public void OpenCharacterAnimationsFolder()
        {
            throw new NotImplementedException();
        }

        public OverlappingAnimationData[] OverlappingAnimations;
        public OverrideHandPosesData OverrideHandPoses;
        public bool BreathingEnabled = false;
        public float BreathingExertion = 0.1f;
        public float BreathingRate = 0.25f;
        public bool SwayingEnabled = false;
        public float SwayingIntensity = 0.25f;
        public float OverlappingAnimationTransitionTime = 1f;
        public AdditionalBoneOffset[] AdditionalBoneOffsets;
        public class AdditionalBoneOffset : StructuredData, ICollapsibleStructuredData
        {
            public HumanBodyBones Bone = HumanBodyBones.Head;
            public Vector3 RotationOffset = Vector3.zero;
            public bool ApplyWhileTracked = true;
            public string GetHeader() => throw new NotImplementedException();
        }

        public bool ApplyFootIK = false;
        public bool DisableUnityRetargeting = true;
        public bool LookAtEnabled = false;
        public GameObjectAsset LookAtTarget;
        public float LookAtWeight = 0.5f;
        public float LookAtEyesWeight = 1f;
        public float LookAtHeadWeight = 1f;
        public float LookAtBodyWeight = 1f;
        public float LookAtClampEyesWeight = 0.8f;
        public float LookAtClampHeadWeight = 0.7f;
        public float LookAtClampBodyWeight = 0.6f;
        public SpineIKData SpineIK;
        public LimbIKData LeftHandIK;
        public LimbIKData RightHandIK;
        public LimbIKData LeftFootIK;
        public LimbIKData RightFootIK;
        public class SpineIKData : StructuredData<CharacterAsset>, ICollapsibleStructuredData
        {
            public void ToggleIKTargetAnchor()
            {
                throw new NotImplementedException();
            }

            public GameObjectAsset IkTarget;
            public HumanBodyBones GetTargetBone()
            {
                throw new NotImplementedException();
            }

            public void SetupIKTargetAnchorAtCurrentPosition()
            {
                throw new NotImplementedException();
            }

            protected bool DisableSetupIKTargetAnchorAtCurrentPosition() => throw new NotImplementedException();
            public bool HasSetUpIKTargetAnchor() => throw new NotImplementedException();
            public async void RemoveCurrentIKTargetAnchor()
            {
                throw new NotImplementedException();
            }

            protected bool HasNotSetUpIKTargetAnchor() => throw new NotImplementedException();
            public bool Enabled = false;
            public float PositionWeight = 1;
            public float RotationWeight = 0;
            public Guid SetupIkTargetAnchorAssetId;
            protected override void OnUpdate()
            {
                throw new NotImplementedException();
            }

            public HumanBodyBones GetBendGoalTargetBone()
            {
                throw new NotImplementedException();
            }

            public string GetHeader() => throw new NotImplementedException();
        }

        public class LimbIKData : SpineIKData
        {
            public GameObjectAsset BendGoalTarget;
            public float BendGoalWeight = 1;
        }

        public bool RagdollEnabled = false;
        public bool AngularLimits = false;
        public bool InternalCollisions = false;
        public float MuscleSpring = 100f;
        public float MuscleDamper = 50f;
        public bool RagdollHighQuality = false;
        public float RagdollSmoothTime = 0.2f;
        public RagdollMuscleData[] RagdollMuscles;
        public MeshData<CharacterAsset>[] Meshes;
        public bool UseMeshBounds = false;
        public void ResetMagicaCloth()
        {
            throw new NotImplementedException();
        }

        protected bool HideMagicaCloth() => throw new NotImplementedException();
        public void ResetMagicaCloth2()
        {
            throw new NotImplementedException();
        }

        protected bool HideMagicaCloth2() => throw new NotImplementedException();
        public string[] TrackingAssetIds;
        public string[] TrackingGraphIds;
        public string ExpressionKeyBindingGraphId;
        public bool BypassIK { get; set; }

        public Transform MainTransform { get; private set; }

        public Transform ParentTransform { get; private set; }

        public Transform RootTransform { get; private set; }

        public Dictionary<string, SkinnedMeshRenderer> SkinnedMeshRenderers { get; private set; }

        public Dictionary<string, MeshRenderer> MeshRenderers { get; private set; }

        public Dictionary<string, List<Material>> Materials { get; private set; }

        public Dictionary<string, List<ShaderProperty>> MaterialProperties { get; private set; }

        public Dictionary<string, List<string>> BlendShapes { get; private set; }

        public Animator Animator { get; private set; }

        public FullBodyBipedIK FullBodyBipedIK { get; private set; }

        public LookAtIK LookAtIK { get; private set; }

        public ShoulderRotator ShoulderRotator { get; private set; }

        public FBBIKHeadEffector HeadEffector { get; private set; }

        public PuppetMaster PuppetMaster { get; private set; }

        public AnimancerComponent Animancer { get; private set; }

        public ICharacterAnimationJob InternalAnimationJob { get; set; }

        public ICharacterAnimationJob AnimationJob { get; set; }

        public Vector3[] InitialBoneLocalPositions { get; private set; }

        public Vector3[] InitialBoneWorldPositions { get; }

        public MeshUpdater MeshUpdater { get; private set; }

        public VRMBlendShapeProxy VRMBlendShapeProxy { get; private set; }

        public List<VRMSpringBone> VRMSpringBones { get; }

        public bool UpdateVRMSpringBones { get; set; }

        public Vrm10Instance Vrm10Instance { get; private set; }

        public Vector3[] EndOfLateUpdateBonePositions { get; }

        public Quaternion[] EndOfLateUpdateBoneRotations { get; }

        public Vector3[] EndOfLateUpdateBoneWorldPositions { get; }

        public Quaternion[] EndOfLateUpdateBoneWorldRotations { get; }

        public Vector3[] EndOfPostLateUpdateBonePositions { get; }

        public Quaternion[] EndOfPostLateUpdateBoneRotations { get; }

        public Vector3[] EndOfPostLateUpdateBoneWorldPositions { get; }

        public Quaternion[] EndOfPostLateUpdateBoneWorldRotations { get; }

        public Vector3[] EndOfFrameBonePositions { get; }

        public Quaternion[] EndOfFrameBoneRotations { get; }

        public Vector3[] EndOfFrameBoneWorldPositions { get; }

        public Quaternion[] EndOfFrameBoneWorldRotations { get; }

        public Vector3 AnimationRootPosition { get; private set; }

        public Quaternion AnimationRootRotation { get; private set; }

        public Dictionary<string, float> LastVRMBlendShapeProxyWeights { get; private set; }

        public Dictionary<string, VRMBlendShapeClipData> VRMBlendShapeClips { get; }

        public List<string> VRMBlendShapeClipNames { get; }

        public Dictionary<HumanBodyBones, Transform> HumanBodyBoneToBodyTransforms { get; }

        public Dictionary<Transform, HumanBodyBones> BoneTransformToHumanBodyBones { get; }

        public Vector3[] PendulumPhysicsEulerAngles { get; }

        public float DisableTemporaryRagdollTime { get; set; }

        public void RevertBoneToAnimationNextFrame(HumanBodyBones bone, float amount = 1f)
        {
            throw new NotImplementedException();
        }

        public void RevertBonesToAnimationNextFrame(IEnumerable<HumanBodyBones> bones, float amount = 1f)
        {
            throw new NotImplementedException();
        }

        public void RevertBonesToAnimationNextFrame(AnimationMaskedBodyPart bodyPart, float amount = 1f)
        {
            throw new NotImplementedException();
        }

        public Transform FindChildTransform(string path)
        {
            throw new NotImplementedException();
        }

        protected override async UniTask<AutoCompleteList> GetSources()
        {
            throw new NotImplementedException();
        }

        protected override void OnDestroyGameObject()
        {
            throw new NotImplementedException();
        }

        protected override GameObject CreateGameObject()
        {
            throw new NotImplementedException();
        }

        protected override void OnGameObjectCreated()
        {
            throw new NotImplementedException();
        }

        public override async void Deserialize(SerializedAsset serialized)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public override void OnPreUpdate()
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

        public override void OnEndOfFrame()
        {
            throw new NotImplementedException();
        }

        protected override void OnDestroy()
        {
            throw new NotImplementedException();
        }

        public async void DisableAnimatorNextFrame()
        {
            throw new NotImplementedException();
        }

        public void ResetRagdollState()
        {
            throw new NotImplementedException();
        }

        public Guid StartOverrideRagdollOptions(bool? enabled = null, bool? internalCollisions = null, bool? angularLimits = null, float? muscleSpring = null, float? muscleDamper = null)
        {
            throw new NotImplementedException();
        }

        public void StopOverrideRagdollOptions(Guid handle)
        {
            throw new NotImplementedException();
        }
    }
}