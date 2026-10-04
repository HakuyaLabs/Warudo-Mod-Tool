using UnityEngine;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public abstract partial class AnimancerTransitionAssetBase : ScriptableObject, ITransition, IWrapper, IAnimationClipSource
    {
        public abstract ITransition GetTransition();
        object IWrapper.WrappedObject => throw new NotImplementedException();
        public virtual bool IsValid => throw new NotImplementedException();
        public virtual float FadeDuration => throw new NotImplementedException();
        public virtual object Key => throw new NotImplementedException();
        public virtual FadeMode FadeMode => throw new NotImplementedException();
        public virtual AnimancerState CreateState() => throw new NotImplementedException();
        public virtual void Apply(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        public virtual void GetAnimationClips(List<AnimationClip> clips) => throw new NotImplementedException();
    }
}