using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class AnimancerComponent : MonoBehaviour, IAnimancerComponent, IEnumerator, IAnimationClipSource, IAnimationClipCollection
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

        public AnimancerPlayable Playable
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsPlayableInitialized => throw new NotImplementedException();
        public AnimancerPlayable.StateDictionary States => throw new NotImplementedException();
        public AnimancerPlayable.LayerList Layers => throw new NotImplementedException();
        public static implicit operator AnimancerPlayable(AnimancerComponent animancer)
        {
            throw new NotImplementedException();
        }

        public static implicit operator AnimancerLayer(AnimancerComponent animancer)
        {
            throw new NotImplementedException();
        }

        public ref DisableAction ActionOnDisable => throw new NotImplementedException();
        bool IAnimancerComponent.ResetOnDisable => throw new NotImplementedException();
        public enum DisableAction
        {
            Stop,
            Pause,
            Continue,
            Reset,
            Destroy,
        }

        public AnimatorUpdateMode UpdateMode
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        protected virtual void OnEnable()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnDisable()
        {
            throw new NotImplementedException();
        }

        public void InitializePlayable()
        {
            throw new NotImplementedException();
        }

        public void InitializePlayable(AnimancerPlayable playable)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnInitializePlayable()
        {
            throw new NotImplementedException();
        }

        public bool TryGetAnimator() => throw new NotImplementedException();
        protected virtual void OnDestroy()
        {
            throw new NotImplementedException();
        }

        public virtual object GetKey(AnimationClip clip) => throw new NotImplementedException();
        public AnimancerState Play(AnimationClip clip) => throw new NotImplementedException();
        public AnimancerState Play(AnimancerState state) => throw new NotImplementedException();
        public AnimancerState Play(AnimationClip clip, float fadeDuration, FadeMode mode = default) => throw new NotImplementedException();
        public AnimancerState Play(AnimancerState state, float fadeDuration, FadeMode mode = default) => throw new NotImplementedException();
        public AnimancerState Play(ITransition transition) => throw new NotImplementedException();
        public AnimancerState Play(ITransition transition, float fadeDuration, FadeMode mode = default) => throw new NotImplementedException();
        public AnimancerState TryPlay(object key) => throw new NotImplementedException();
        public AnimancerState TryPlay(object key, float fadeDuration, FadeMode mode = default) => throw new NotImplementedException();
        public AnimancerState Stop(AnimationClip clip) => throw new NotImplementedException();
        public AnimancerState Stop(IHasKey hasKey) => throw new NotImplementedException();
        public AnimancerState Stop(object key) => throw new NotImplementedException();
        public void Stop()
        {
            throw new NotImplementedException();
        }

        public bool IsPlaying(AnimationClip clip) => throw new NotImplementedException();
        public bool IsPlaying(IHasKey hasKey) => throw new NotImplementedException();
        public bool IsPlaying(object key) => throw new NotImplementedException();
        public bool IsPlaying() => throw new NotImplementedException();
        public bool IsPlayingClip(AnimationClip clip) => throw new NotImplementedException();
        public void Evaluate() => throw new NotImplementedException();
        public void Evaluate(float deltaTime) => throw new NotImplementedException();
        bool IEnumerator.MoveNext()
        {
            throw new NotImplementedException();
        }

        object IEnumerator.Current => throw new NotImplementedException();
        void IEnumerator.Reset()
        {
            throw new NotImplementedException();
        }

        public void GetAnimationClips(List<AnimationClip> clips)
        {
            throw new NotImplementedException();
        }

        public virtual void GatherAnimationClips(ICollection<AnimationClip> clips)
        {
            throw new NotImplementedException();
        }
    }
}