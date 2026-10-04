using Animancer.Units;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Object = UnityEngine.Object;
using System;

namespace Animancer
{
    public class PlayableAssetTransitionAsset : AnimancerTransitionAsset<PlayableAssetTransition>
    {
        public new class UnShared : UnShared<PlayableAssetTransitionAsset, PlayableAssetTransition, PlayableAssetState>, PlayableAssetState.ITransition
        {
        }
    }

    public class PlayableAssetTransition : AnimancerTransition<PlayableAssetState>, PlayableAssetState.ITransition, IAnimationClipCollection, ICopyable<PlayableAssetTransition>
    {
        public ref PlayableAsset Asset => throw new NotImplementedException();
        public override Object MainObject => throw new NotImplementedException();
        public override object Key => throw new NotImplementedException();
        public override float Speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override float NormalizedStartTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ref Object[] Bindings => throw new NotImplementedException();
        public override float MaximumDuration => throw new NotImplementedException();
        public override bool IsValid => throw new NotImplementedException();
        public override PlayableAssetState CreateState()
        {
            throw new NotImplementedException();
        }

        public override void Apply(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        void IAnimationClipCollection.GatherAnimationClips(ICollection<AnimationClip> clips) => throw new NotImplementedException();
        public virtual void CopyFrom(PlayableAssetTransition copyFrom)
        {
            throw new NotImplementedException();
        }
    }
}