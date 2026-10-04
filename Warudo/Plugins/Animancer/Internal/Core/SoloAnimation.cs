using Animancer.Units;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class SoloAnimation : MonoBehaviour, IAnimationClipSource
    {
        public const int DefaultExecutionOrder = -5000;
        public Animator Animator
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public AnimationClip Clip
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool StopOnDisable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsPlaying
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public float Speed
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool FootIK
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public float Time
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public float NormalizedTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsInitialized => throw new NotImplementedException();
        public void Play() => throw new NotImplementedException();
        public void Play(AnimationClip clip)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnEnable()
        {
            throw new NotImplementedException();
        }

        protected virtual void Update()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnDisable()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnDestroy()
        {
            throw new NotImplementedException();
        }

        public void GetAnimationClips(List<AnimationClip> clips)
        {
            throw new NotImplementedException();
        }
    }
}