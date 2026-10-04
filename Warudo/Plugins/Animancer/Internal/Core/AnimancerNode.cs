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
    public abstract class AnimancerNode : Key, IUpdatable, IEnumerable<AnimancerState>, IEnumerator, IPlayableWrapper, ICopyable<AnimancerNode>
    {
        protected internal Playable _Playable;
        public Playable Playable => throw new NotImplementedException();
        public bool IsValid => throw new NotImplementedException();
        public virtual void CreatePlayable()
        {
            throw new NotImplementedException();
        }

        protected abstract void CreatePlayable(out Playable playable);
        public void DestroyPlayable()
        {
            throw new NotImplementedException();
        }

        public virtual void RecreatePlayable()
        {
            throw new NotImplementedException();
        }

        public void RecreatePlayableRecursive()
        {
            throw new NotImplementedException();
        }

        void ICopyable<AnimancerNode>.CopyFrom(AnimancerNode copyFrom)
        {
            throw new NotImplementedException();
        }

        public AnimancerPlayable Root
        {
            get => throw new NotImplementedException();
            internal set
            {
                throw new NotImplementedException();
            }
        }

        public abstract AnimancerLayer Layer { get; }

        public abstract IPlayableWrapper Parent { get; }

        public int Index { get; internal set; }

        protected AnimancerNode()
        {
            throw new NotImplementedException();
        }

        internal void ConnectToGraph()
        {
            throw new NotImplementedException();
        }

        internal void DisconnectFromGraph()
        {
            throw new NotImplementedException();
        }

        protected void RequireUpdate()
        {
            throw new NotImplementedException();
        }

        void IUpdatable.Update()
        {
            throw new NotImplementedException();
        }

        protected internal virtual void Update(out bool needsMoreUpdates)
        {
            throw new NotImplementedException();
        }

        public abstract bool IsPlayingAndNotEnding();
        bool IEnumerator.MoveNext() => throw new NotImplementedException();
        object IEnumerator.Current => throw new NotImplementedException();
        void IEnumerator.Reset()
        {
            throw new NotImplementedException();
        }

        public virtual int ChildCount => throw new NotImplementedException();
        AnimancerNode IPlayableWrapper.GetChild(int index) => throw new NotImplementedException();
        public virtual AnimancerState GetChild(int index) => throw new NotImplementedException();
        protected internal virtual void OnAddChild(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        protected internal virtual void OnRemoveChild(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        protected void OnAddChild(IList<AnimancerState> states, AnimancerState state)
        {
            throw new NotImplementedException();
        }

        public virtual bool KeepChildrenConnected => throw new NotImplementedException();
        internal void ConnectAllChildrenToGraph()
        {
            throw new NotImplementedException();
        }

        internal void DisconnectWeightlessChildrenFromGraph()
        {
            throw new NotImplementedException();
        }

        public virtual FastEnumerator<AnimancerState> GetEnumerator() => throw new NotImplementedException();
        IEnumerator<AnimancerState> IEnumerable<AnimancerState>.GetEnumerator() => throw new NotImplementedException();
        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
        public float Weight
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public void SetWeight(float value)
        {
            throw new NotImplementedException();
        }

        protected internal void SetWeightDirty()
        {
            throw new NotImplementedException();
        }

        public void ApplyWeight()
        {
            throw new NotImplementedException();
        }

        public float EffectiveWeight
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public float TargetWeight { get; set; }

        public float FadeSpeed { get; set; }

        public void StartFade(float targetWeight) => throw new NotImplementedException();
        public void StartFade(float targetWeight, float fadeDuration)
        {
            throw new NotImplementedException();
        }

        protected internal abstract void OnStartFade();
        public virtual void Stop()
        {
            throw new NotImplementedException();
        }

        public float Speed
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public float EffectiveSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public static bool ApplyParentAnimatorIK { get; set; }

        public static bool ApplyParentFootIK { get; set; }

        public virtual void CopyIKFlags(AnimancerNode copyFrom)
        {
            throw new NotImplementedException();
        }

        public virtual bool ApplyAnimatorIK
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

        public virtual bool ApplyFootIK
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

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public void SetDebugName(string name)
        {
            throw new NotImplementedException();
        }

        public string GetDescription(string separator = "\n")
        {
            throw new NotImplementedException();
        }

        public void AppendDescription(StringBuilder text, string separator = "\n")
        {
            throw new NotImplementedException();
        }

        protected virtual void AppendDetails(StringBuilder text, string separator)
        {
            throw new NotImplementedException();
        }

        public static void AppendIKDetails(StringBuilder text, string separator, IPlayableWrapper node)
        {
            throw new NotImplementedException();
        }
    }
}