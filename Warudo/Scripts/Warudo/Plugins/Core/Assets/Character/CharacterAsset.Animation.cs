using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Animancer;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Newtonsoft.Json;
using RootMotion.FinalIK;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using UniVRM10;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Localization;
using Warudo.Core.Resource;
using Warudo.Core.Server;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Nodes;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
using System;

namespace Warudo.Plugins.Core.Assets.Character
{
    public partial class CharacterAsset
    {
        public const int IdleAnimationLayer = 0;
        public GameObject AvatarClone;
        public GameObject AvatarCloneParent;
        public AnimancerComponent CloneAnimancer;
        public Animator CloneAnimator;
        public void OverrideOverlappingAnimationTransitionTime(float overrideTransitionTime, float duration = -1f)
        {
            throw new NotImplementedException();
        }

        public void ResetRootMotion()
        {
            throw new NotImplementedException();
        }

        public void PlayOneShotAnimation(AnimationClip animationClip, IEnumerable<AnimationMaskedBodyPart> maskedBodyParts = null, float weight = 1f, float speed = 1f, bool additive = false, Action onEnd = default)
        {
            throw new NotImplementedException();
        }

        public Action PlayAnimation(AnimationClip animationClip, IEnumerable<AnimationMaskedBodyPart> maskedBodyParts = null, float weight = 1f, float speed = 1f, bool additive = false, Action onEnd = default)
        {
            throw new NotImplementedException();
        }

        public void AddTransientAnimation(TransientAnimationData data)
        {
            throw new NotImplementedException();
        }

        public void RemoveTransientAnimation(TransientAnimationData data)
        {
            throw new NotImplementedException();
        }

        public void ClearTransientAnimations()
        {
            throw new NotImplementedException();
        }

        public void UpdateLookAtIK()
        {
            throw new NotImplementedException();
        }

        public void UpdateSpineIK(IKEffector effector, SpineIKData data)
        {
            throw new NotImplementedException();
        }

        public void UpdateLimbIK(IKMappingLimb mapping, bool updateMapping, IKEffector effector, FBIKChain chain, LimbIKData data)
        {
            throw new NotImplementedException();
        }

        public void SetupOverlappingAnimations(float fadeDuration = -1f, Easing.Function baseEasing = Easing.Function.CubicOut)
        {
            throw new NotImplementedException();
        }

        public async UniTask SaveAnimationProfile(string profileName)
        {
            throw new NotImplementedException();
        }

        public static async UniTask<Dictionary<string, string>> LoadSerializedAnimationProfile(string profileName)
        {
            throw new NotImplementedException();
        }

        public async UniTask LoadAnimationProfile(string profileName)
        {
            throw new NotImplementedException();
        }

        public class OverrideHandPosesData : StructuredData<CharacterAsset>
        {
            public LeftHandPoseData LeftHand;
            public RightHandPoseData RightHand;
            public class LeftHandPoseData : HandPoseData, ICollapsibleStructuredData
            {
                public override IEnumerable<AnimationMaskedBodyPart> GetMaskedBodyParts() => throw new NotImplementedException();
                public string GetHeader() => throw new NotImplementedException();
            }

            public class RightHandPoseData : HandPoseData, ICollapsibleStructuredData
            {
                public override IEnumerable<AnimationMaskedBodyPart> GetMaskedBodyParts() => throw new NotImplementedException();
                public string GetHeader() => throw new NotImplementedException();
            }

            public abstract class HandPoseData : StructuredData<OverrideHandPosesData>, IOverlappingAnimationData
            {
                public bool Enabled;
                public string Pose = "character-animation://resources/Animations/Handy Poses/Basic";
                public float Weight = 1f;
                public bool HighPriority = false;
                public AnimationClip GetAnimationClip()
                {
                    throw new NotImplementedException();
                }

                public float GetWeight() => throw new NotImplementedException();
                public float GetSpeed() => throw new NotImplementedException();
                public bool IsMasked() => throw new NotImplementedException();
                public abstract IEnumerable<AnimationMaskedBodyPart> GetMaskedBodyParts();
                public bool IsAdditive() => throw new NotImplementedException();
                public bool IsLooping() => throw new NotImplementedException();
            }
        }

        public interface IOverlappingAnimationData
        {
            AnimationClip GetAnimationClip();
            float GetWeight();
            float GetSpeed();
            bool IsMasked();
            IEnumerable<AnimationMaskedBodyPart> GetMaskedBodyParts();
            bool IsAdditive();
            bool IsLooping();
            void OnAnimationEnd(AnimancerState state)
            {
                throw new NotImplementedException();
            }
        }

        public class BreatheAnimationData : IOverlappingAnimationData
        {
            public BreatheAnimationData(CharacterAsset character)
            {
                throw new NotImplementedException();
            }

            public AnimationClip GetAnimationClip() => throw new NotImplementedException();
            public float GetWeight() => throw new NotImplementedException();
            public float GetSpeed() => throw new NotImplementedException();
            public bool IsMasked() => throw new NotImplementedException();
            public IEnumerable<AnimationMaskedBodyPart> GetMaskedBodyParts() => throw new NotImplementedException();
            public bool IsAdditive() => throw new NotImplementedException();
            public bool IsLooping() => throw new NotImplementedException();
            public bool IsBonesOnly() => throw new NotImplementedException();
        }

        public class SwayAnimationData : IOverlappingAnimationData
        {
            public SwayAnimationData(CharacterAsset character)
            {
                throw new NotImplementedException();
            }

            public AnimationClip GetAnimationClip() => throw new NotImplementedException();
            public float GetWeight() => throw new NotImplementedException();
            public float GetSpeed() => throw new NotImplementedException();
            public bool IsMasked() => throw new NotImplementedException();
            public IEnumerable<AnimationMaskedBodyPart> GetMaskedBodyParts() => throw new NotImplementedException();
            public bool IsAdditive() => throw new NotImplementedException();
            public bool IsLooping() => throw new NotImplementedException();
            public bool IsBonesOnly() => throw new NotImplementedException();
        }

        public class TransientAnimationData : IOverlappingAnimationData
        {
            public readonly AnimationClip AnimationClip;
            public float Weight = 1f;
            public float Speed = 1f;
            public bool Additive;
            public bool Looping;
            public bool BonesOnly;
            public int Layer;
            public Action<AnimancerState> OnEnd;
            public TransientAnimationData(AnimationClip animationClip)
            {
                throw new NotImplementedException();
            }

            public AnimationClip GetAnimationClip() => throw new NotImplementedException();
            public float GetWeight() => throw new NotImplementedException();
            public float GetSpeed() => throw new NotImplementedException();
            public bool IsMasked() => throw new NotImplementedException();
            public IEnumerable<AnimationMaskedBodyPart> GetMaskedBodyParts() => throw new NotImplementedException();
            public void SetMaskedBodyParts(IEnumerable<AnimationMaskedBodyPart> bodyParts)
            {
                throw new NotImplementedException();
            }

            public bool IsAdditive() => throw new NotImplementedException();
            public bool IsLooping() => throw new NotImplementedException();
            public void OnAnimationEnd(AnimancerState state)
            {
                throw new NotImplementedException();
            }
        }

        public class OverlappingAnimationData : StructuredData<CharacterAsset>, IOverlappingAnimationData, ICollapsibleStructuredData
        {
            public bool Enabled = true;
            public string Animation;
            public float Weight = 1f;
            public float Speed = 1f;
            public bool Masked = true;
            public AnimationMaskedBodyPart[] MaskedBodyParts;
            public void MaskUpperBody()
            {
                throw new NotImplementedException();
            }

            public void MaskLowerBody()
            {
                throw new NotImplementedException();
            }

            public bool Additive;
            public bool Looping = true;
            public string CustomLayerID = "";
            public AnimationClip GetAnimationClip()
            {
                throw new NotImplementedException();
            }

            public float GetWeight() => throw new NotImplementedException();
            public float GetSpeed() => throw new NotImplementedException();
            public bool IsMasked() => throw new NotImplementedException();
            public IEnumerable<AnimationMaskedBodyPart> GetMaskedBodyParts() => throw new NotImplementedException();
            public bool IsAdditive() => throw new NotImplementedException();
            public bool IsLooping() => throw new NotImplementedException();
            public string GetHeader()
            {
                throw new NotImplementedException();
            }
        }

        public enum AnimationMaskedBodyPart
        {
            Root,
            Body,
            Head,
            LeftLeg,
            RightLeg,
            LeftArm,
            RightArm,
            LeftFingers,
            RightFingers,
            LeftFoot,
            RightFoot
        }

        public static AvatarMask CreateAvatarMask(IEnumerable<AvatarMaskBodyPart> bodyParts)
        {
            throw new NotImplementedException();
        }

        public class SaveAnimationProfileData : StructuredData
        {
            public string ProfileName;
        }

        public class LoadAnimationProfileData : StructuredData
        {
            public string ProfileName;
        }
    }
}