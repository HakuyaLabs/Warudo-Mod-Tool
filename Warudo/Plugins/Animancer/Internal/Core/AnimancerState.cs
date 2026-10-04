using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Playables;
using Object = UnityEngine.Object;
using System;

namespace Animancer
{
    public abstract partial class AnimancerState : AnimancerNode, IAnimationClipCollection, ICopyable<AnimancerState>
    {
        public void SetRoot(AnimancerPlayable root)
        {
            throw new NotImplementedException();
        }

        public sealed override IPlayableWrapper Parent => throw new NotImplementedException();
        public void SetParent(AnimancerNode parent, int index)
        {
            throw new NotImplementedException();
        }

        internal void SetParentInternal(AnimancerNode parent, int index = -1)
        {
            throw new NotImplementedException();
        }

        public override AnimancerLayer Layer => throw new NotImplementedException();
        public int LayerIndex
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        internal object _Key;
        public object Key
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual AnimationClip Clip { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public virtual Object MainObject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        protected void ChangeMainObject<T>(ref T currentObject, T newObject)
            where T : Object
        {
            throw new NotImplementedException();
        }

        public virtual Vector3 AverageVelocity => throw new NotImplementedException();
        public bool IsPlaying
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        protected virtual void OnSetIsPlaying()
        {
            throw new NotImplementedException();
        }

        public sealed override void CreatePlayable()
        {
            throw new NotImplementedException();
        }

        public bool IsActive => throw new NotImplementedException();
        public bool IsStopped => throw new NotImplementedException();
        public void Play()
        {
            throw new NotImplementedException();
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }

        protected internal override void OnStartFade()
        {
            throw new NotImplementedException();
        }

        public float Time { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double TimeD
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual double RawTime
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public float NormalizedTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double NormalizedTimeD
        {
            get
            {
                throw new NotImplementedException();
            }

            set => throw new NotImplementedException();
        }

        public void MoveTime(float time, bool normalized) => throw new NotImplementedException();
        public virtual void MoveTime(double time, bool normalized)
        {
            throw new NotImplementedException();
        }

        protected void CancelSetTime() => throw new NotImplementedException();
        public float NormalizedEndTime
        {
            get
            {
                throw new NotImplementedException();
            }

            set => throw new NotImplementedException();
        }

        public float Duration
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public float RemainingDuration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public abstract float Length { get; }

        public virtual bool IsLooping => throw new NotImplementedException();
        protected internal override void Update(out bool needsMoreUpdates)
        {
            throw new NotImplementedException();
        }

        public virtual void Destroy()
        {
            throw new NotImplementedException();
        }

        public AnimancerState Clone() => throw new NotImplementedException();
        public abstract AnimancerState Clone(AnimancerPlayable root);
        protected void SetNewCloneRoot(AnimancerPlayable root)
        {
            throw new NotImplementedException();
        }

        void ICopyable<AnimancerState>.CopyFrom(AnimancerState copyFrom)
        {
            throw new NotImplementedException();
        }

        public virtual void GatherAnimationClips(ICollection<AnimationClip> clips)
        {
            throw new NotImplementedException();
        }

        public override bool IsPlayingAndNotEnding()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        protected override void AppendDetails(StringBuilder text, string separator)
        {
            throw new NotImplementedException();
        }

        public string GetPath()
        {
            throw new NotImplementedException();
        }
    }
}