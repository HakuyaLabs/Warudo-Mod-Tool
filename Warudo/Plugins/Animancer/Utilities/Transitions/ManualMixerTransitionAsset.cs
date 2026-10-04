using Animancer.Units;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using System;

namespace Animancer
{
    public class ManualMixerTransitionAsset : AnimancerTransitionAsset<ManualMixerTransition>
    {
        public new class UnShared : UnShared<ManualMixerTransitionAsset, ManualMixerTransition, ManualMixerState>, ManualMixerState.ITransition
        {
        }
    }

    public abstract class ManualMixerTransition<TMixer> : AnimancerTransition<TMixer>, IMotion, IAnimationClipCollection, ICopyable<ManualMixerTransition<TMixer>> where TMixer : ManualMixerState
    {
        public override float Speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ref Object[] Animations => throw new NotImplementedException();
        public const string AnimationsField = "_Animations";
        public ref float[] Speeds => throw new NotImplementedException();
        public const string SpeedsField = "_Speeds";
        public bool HasSpeeds => throw new NotImplementedException();
        public ref bool[] SynchronizeChildren => throw new NotImplementedException();
        public const string SynchronizeChildrenField = "_SynchronizeChildren";
        public override bool IsLooping
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override float MaximumDuration
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual float AverageAngularSpeed
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual Vector3 AverageVelocity
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool IsValid
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual void InitializeState()
        {
            throw new NotImplementedException();
        }

        public override void Apply(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        void IAnimationClipCollection.GatherAnimationClips(ICollection<AnimationClip> clips) => throw new NotImplementedException();
        public virtual void CopyFrom(ManualMixerTransition<TMixer> copyFrom)
        {
            throw new NotImplementedException();
        }
    }
}