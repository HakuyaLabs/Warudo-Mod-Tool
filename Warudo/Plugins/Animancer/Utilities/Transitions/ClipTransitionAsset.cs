using Animancer.Units;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using System;

namespace Animancer
{
    public class ClipTransitionAsset : AnimancerTransitionAsset<ClipTransition>
    {
        public new class UnShared : UnShared<ClipTransitionAsset, ClipTransition, ClipState>, ClipState.ITransition
        {
        }
    }

    public class ClipTransition : AnimancerTransition<ClipState>, ClipState.ITransition, IMotion, IAnimationClipCollection, ICopyable<ClipTransition>
    {
        public const string ClipFieldName = "_Clip";
        public AnimationClip Clip
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public override Object MainObject => throw new NotImplementedException();
        public override object Key => throw new NotImplementedException();
        public override float Speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override float NormalizedStartTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override FadeMode FadeMode => throw new NotImplementedException();
        public virtual float Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool IsValid => throw new NotImplementedException();
        public override bool IsLooping => throw new NotImplementedException();
        public override float MaximumDuration => throw new NotImplementedException();
        public virtual float AverageAngularSpeed => throw new NotImplementedException();
        public virtual Vector3 AverageVelocity => throw new NotImplementedException();
        public override ClipState CreateState()
        {
            throw new NotImplementedException();
        }

        public override void Apply(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        public virtual void GatherAnimationClips(ICollection<AnimationClip> clips) => throw new NotImplementedException();
        public virtual void CopyFrom(ClipTransition copyFrom)
        {
            throw new NotImplementedException();
        }
    }
}