using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using Object = UnityEngine.Object;
using System;

namespace Animancer
{
    public class ClipState : AnimancerState
    {
        public interface ITransition : ITransition<ClipState>
        {
        }

        public override AnimationClip Clip
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public override Object MainObject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override float Length => throw new NotImplementedException();
        public override bool IsLooping => throw new NotImplementedException();
        public override Vector3 AverageVelocity => throw new NotImplementedException();
        public override bool ApplyAnimatorIK
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ApplyFootIK
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public ClipState(AnimationClip clip)
        {
            throw new NotImplementedException();
        }

        protected override void CreatePlayable(out Playable playable)
        {
            throw new NotImplementedException();
        }

        public override void Destroy()
        {
            throw new NotImplementedException();
        }

        public override AnimancerState Clone(AnimancerPlayable root)
        {
            throw new NotImplementedException();
        }
    }
}