using System;
using System.Collections.Generic;
using System.IO;
using Animancer;
using Cysharp.Threading.Tasks;
using RootMotion.Dynamics;
using RuntimeAnimationClip;
using RuntimeGizmos;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Localization;
using Warudo.Core.Server;
using Warudo.Core.Utils;
using TemporaryControlPoints = Warudo.Core.Utils.TemporaryControlPointManager;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.Character
{
    public partial class CharacterAsset
    {
        public class CreateKeyMotionData : StructuredData
        {
            public string Name;
            public Color SkeletonColor;
        }

        private struct KeyMotionBonePose
        {
            public Transform Transform;
            public Vector3 LocalPosition;
            public Quaternion LocalRotation;
        }

        private sealed class KeyMotionEditState
        {
            public int Generation;
            public bool Restored;
            public CreateKeyMotionData InputData;
            public TemporaryControlPoints.Session Session;
            public TemporaryControlPoints.TransformOperation Operation;
            public readonly Dictionary<HumanBodyBones, KeyMotionBonePose> OriginalBonePoses = new();
            public readonly Dictionary<HumanBodyBones, KeyMotionBonePose> TransformStartBonePoses = new();
            public readonly Dictionary<Guid, bool> TrackingGraphStates = new();
            public AnimancerComponent MainAnimancer;
            public bool MainAnimancerGraphStateCaptured;
            public bool MainAnimancerGraphWasPlaying;
            public Animator MainAnimator;
            public bool MainAnimatorEnabled;
            public AnimancerComponent CloneAnimancer;
            public bool CloneAnimancerGraphStateCaptured;
            public bool CloneAnimancerGraphWasPlaying;
            public Animator CloneAnimator;
            public bool CloneAnimatorEnabled;
            public bool UpdateVRMSpringBones;
            public Behaviour Vrm10Instance;
            public bool Vrm10InstanceEnabled;
            public bool EditingRagdoll;
            public PuppetMaster PuppetMaster;
            public bool PuppetMasterEnabled;
            public bool PuppetMasterModeCaptured;
            public PuppetMaster.Mode PuppetMasterMode;
            public CorePlugin CorePlugin;
            public TransformType GizmoTransformType;
            public bool GizmoEnabled;
        }

        internal bool IsEditingKeyMotion => throw new NotImplementedException();
    }
}