using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public sealed class AnimancerLayer : AnimancerNode, IAnimationClipCollection
    {
        internal AnimancerLayer(AnimancerPlayable root, int index)
        {
            throw new NotImplementedException();
        }

        protected override void CreatePlayable(out Playable playable) => throw new NotImplementedException();
        public override AnimancerLayer Layer => throw new NotImplementedException();
        public override IPlayableWrapper Parent => throw new NotImplementedException();
        public override bool KeepChildrenConnected => throw new NotImplementedException();
        public AnimancerState CurrentState
        {
            get => throw new NotImplementedException();
            private set
            {
                throw new NotImplementedException();
            }
        }

        public int CommandCount { get; private set; }

        public bool IsAdditive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void SetMask(AvatarMask mask)
        {
            throw new NotImplementedException();
        }

        public Vector3 AverageVelocity
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int ChildCount => throw new NotImplementedException();
        public override AnimancerState GetChild(int index) => throw new NotImplementedException();
        public AnimancerState this[int index] => throw new NotImplementedException();
        public void AddChild(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        protected internal override void OnAddChild(AnimancerState state) => throw new NotImplementedException();
        protected internal override void OnRemoveChild(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        public override FastEnumerator<AnimancerState> GetEnumerator() => throw new NotImplementedException();
        public ClipState CreateState(AnimationClip clip) => throw new NotImplementedException();
        public ClipState CreateState(object key, AnimationClip clip)
        {
            throw new NotImplementedException();
        }

        public AnimancerState GetState(ref object key)
        {
            throw new NotImplementedException();
        }

        public void CreateIfNew(AnimationClip clip0, AnimationClip clip1)
        {
            throw new NotImplementedException();
        }

        public void CreateIfNew(AnimationClip clip0, AnimationClip clip1, AnimationClip clip2)
        {
            throw new NotImplementedException();
        }

        public void CreateIfNew(AnimationClip clip0, AnimationClip clip1, AnimationClip clip2, AnimationClip clip3)
        {
            throw new NotImplementedException();
        }

        public void CreateIfNew(params AnimationClip[] clips)
        {
            throw new NotImplementedException();
        }

        public AnimancerState GetOrCreateState(AnimationClip clip, bool allowSetClip = false)
        {
            throw new NotImplementedException();
        }

        public AnimancerState GetOrCreateState(ITransition transition)
        {
            throw new NotImplementedException();
        }

        public AnimancerState GetOrCreateState(object key, AnimationClip clip, bool allowSetClip = false)
        {
            throw new NotImplementedException();
        }

        public AnimancerState GetOrCreateState(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        public static float WeightlessThreshold { get; set; }

        public static int MaxCloneCount { get; private set; }

        public AnimancerState GetOrCreateWeightlessState(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        public void DestroyStates()
        {
            throw new NotImplementedException();
        }

        protected internal override void OnStartFade()
        {
            throw new NotImplementedException();
        }

        public AnimancerState Play(AnimationClip clip) => throw new NotImplementedException();
        public AnimancerState Play(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        public AnimancerState Play(AnimationClip clip, float fadeDuration, FadeMode mode = default) => throw new NotImplementedException();
        public AnimancerState Play(AnimancerState state, float fadeDuration, FadeMode mode = default)
        {
            throw new NotImplementedException();
        }

        public AnimancerState Play(ITransition transition) => throw new NotImplementedException();
        public AnimancerState Play(ITransition transition, float fadeDuration, FadeMode mode = default)
        {
            throw new NotImplementedException();
        }

        public AnimancerState TryPlay(object key) => throw new NotImplementedException();
        public AnimancerState TryPlay(object key, float fadeDuration, FadeMode mode = default) => throw new NotImplementedException();
        public override void Stop()
        {
            throw new NotImplementedException();
        }

        public bool IsPlayingClip(AnimationClip clip)
        {
            throw new NotImplementedException();
        }

        public bool IsAnyStatePlaying()
        {
            throw new NotImplementedException();
        }

        public override bool IsPlayingAndNotEnding() => throw new NotImplementedException();
        public float GetTotalWeight()
        {
            throw new NotImplementedException();
        }

        public override bool ApplyAnimatorIK { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool ApplyFootIK { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void GatherAnimationClips(ICollection<AnimationClip> clips) => throw new NotImplementedException();
        public override string ToString()
        {
            throw new NotImplementedException();
        }

        protected override void AppendDetails(StringBuilder text, string separator)
        {
            throw new NotImplementedException();
        }
    }
}