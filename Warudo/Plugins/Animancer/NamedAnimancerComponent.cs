using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Object = UnityEngine.Object;
using System;

namespace Animancer
{
    public class NamedAnimancerComponent : AnimancerComponent
    {
        public ref bool PlayAutomatically => throw new NotImplementedException();
        public AnimationClip[] Animations
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public AnimationClip DefaultAnimation
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        protected virtual void Awake()
        {
            throw new NotImplementedException();
        }

        protected override void OnEnable()
        {
            throw new NotImplementedException();
        }

        public override object GetKey(AnimationClip clip) => throw new NotImplementedException();
        public override void GatherAnimationClips(ICollection<AnimationClip> clips)
        {
            throw new NotImplementedException();
        }
    }
}