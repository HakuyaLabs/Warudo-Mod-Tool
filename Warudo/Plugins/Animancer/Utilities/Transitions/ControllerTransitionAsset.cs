using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Object = UnityEngine.Object;
using Animancer.Units;
using System;

namespace Animancer
{
    public class ControllerTransitionAsset : AnimancerTransitionAsset<ControllerTransition>
    {
        public new class UnShared : UnShared<ControllerTransitionAsset, ControllerTransition, ControllerState>, ControllerState.ITransition
        {
        }
    }

    public abstract class ControllerTransition<TState> : AnimancerTransition<TState>, IAnimationClipCollection, ICopyable<ControllerTransition<TState>> where TState : ControllerState
    {
        public ref RuntimeAnimatorController Controller => throw new NotImplementedException();
        public override Object MainObject => throw new NotImplementedException();
        public ref ControllerState.ActionOnStop[] ActionsOnStop => throw new NotImplementedException();
        public override float MaximumDuration
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool IsValid => throw new NotImplementedException();
        public static implicit operator RuntimeAnimatorController(ControllerTransition<TState> transition)
        {
            throw new NotImplementedException();
        }

        public override void Apply(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        void IAnimationClipCollection.GatherAnimationClips(ICollection<AnimationClip> clips)
        {
            throw new NotImplementedException();
        }

        public virtual void CopyFrom(ControllerTransition<TState> copyFrom)
        {
            throw new NotImplementedException();
        }
    }

    public class ControllerTransition : ControllerTransition<ControllerState>, ControllerState.ITransition, ICopyable<ControllerTransition>
    {
        public override ControllerState CreateState()
        {
            throw new NotImplementedException();
        }

        public ControllerTransition()
        {
            throw new NotImplementedException();
        }

        public ControllerTransition(RuntimeAnimatorController controller)
        {
            throw new NotImplementedException();
        }

        public static implicit operator ControllerTransition(RuntimeAnimatorController controller)
        {
            throw new NotImplementedException();
        }

        public virtual void CopyFrom(ControllerTransition copyFrom)
        {
            throw new NotImplementedException();
        }
    }
}