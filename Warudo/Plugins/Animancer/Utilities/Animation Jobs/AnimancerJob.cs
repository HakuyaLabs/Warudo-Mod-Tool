using UnityEngine.Animations;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public abstract class AnimancerJob<T>
        where T : struct, IAnimationJob
    {
        protected T _Job;
        protected AnimationScriptPlayable _Playable;
        protected void CreatePlayable(AnimancerPlayable animancer)
        {
            throw new NotImplementedException();
        }

        public virtual void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}