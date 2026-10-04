using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public partial class ManualMixerState : AnimancerState, ICopyable<ManualMixerState>
    {
        public interface ITransition : ITransition<ManualMixerState>
        {
        }

        public interface ITransition2D : ITransition<MixerState<Vector2>>
        {
        }

        public override bool KeepChildrenConnected => throw new NotImplementedException();
        public override AnimationClip Clip => throw new NotImplementedException();
        protected AnimancerState[] ChildStates { get; private set; }

        public sealed override int ChildCount => throw new NotImplementedException();
        public int ChildCapacity
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        protected virtual void OnChildCapacityChanged()
        {
            throw new NotImplementedException();
        }

        public static int DefaultChildCapacity { get; set; }

        public void EnsureRemainingChildCapacity(int minimumCapacity)
        {
            throw new NotImplementedException();
        }

        public sealed override AnimancerState GetChild(int index) => throw new NotImplementedException();
        public sealed override FastEnumerator<AnimancerState> GetEnumerator() => throw new NotImplementedException();
        protected override void OnSetIsPlaying()
        {
            throw new NotImplementedException();
        }

        public override bool IsLooping
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override double RawTime
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

        public override void MoveTime(double time, bool normalized)
        {
            throw new NotImplementedException();
        }

        public override float Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override void CreatePlayable(out Playable playable)
        {
            throw new NotImplementedException();
        }

        protected internal override void OnAddChild(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        protected internal override void OnRemoveChild(AnimancerState state)
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

        void ICopyable<ManualMixerState>.CopyFrom(ManualMixerState copyFrom)
        {
            throw new NotImplementedException();
        }

        public void Add(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        public ClipState Add(AnimationClip clip)
        {
            throw new NotImplementedException();
        }

        public AnimancerState Add(Animancer.ITransition transition)
        {
            throw new NotImplementedException();
        }

        public AnimancerState Add(object child)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IList<AnimationClip> clips)
        {
            throw new NotImplementedException();
        }

        public void AddRange(params AnimationClip[] clips) => throw new NotImplementedException();
        public void AddRange(IList<Animancer.ITransition> transitions)
        {
            throw new NotImplementedException();
        }

        public void AddRange(params Animancer.ITransition[] clips) => throw new NotImplementedException();
        public void AddRange(IList<object> children)
        {
            throw new NotImplementedException();
        }

        public void AddRange(params object[] clips) => throw new NotImplementedException();
        public void Remove(int index, bool destroy) => throw new NotImplementedException();
        public void Remove(AnimancerState child, bool destroy)
        {
            throw new NotImplementedException();
        }

        public void Set(int index, AnimancerState child, bool destroyPrevious)
        {
            throw new NotImplementedException();
        }

        public ClipState Set(int index, AnimationClip clip, bool destroyPrevious)
        {
            throw new NotImplementedException();
        }

        public AnimancerState Set(int index, Animancer.ITransition transition, bool destroyPrevious)
        {
            throw new NotImplementedException();
        }

        public AnimancerState Set(int index, object child, bool destroyPrevious)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(AnimancerState child) => throw new NotImplementedException();
        public void DestroyChildren()
        {
            throw new NotImplementedException();
        }

        public AnimationScriptPlayable CreatePlayable<T>(AnimancerPlayable root, T job, bool processInputs = false)
            where T : struct, IAnimationJob
        {
            throw new NotImplementedException();
        }

        protected void CreatePlayable<T>(out Playable playable, T job, bool processInputs = false)
            where T : struct, IAnimationJob
        {
            throw new NotImplementedException();
        }

        public T GetJobData<T>()
            where T : struct, IAnimationJob => throw new NotImplementedException();
        public void SetJobData<T>(T value)
            where T : struct, IAnimationJob => throw new NotImplementedException();
        protected internal override void Update(out bool needsMoreUpdates)
        {
            throw new NotImplementedException();
        }

        public bool WeightsAreDirty { get; set; }

        public bool RecalculateWeights()
        {
            throw new NotImplementedException();
        }

        protected virtual void ForceRecalculateWeights()
        {
            throw new NotImplementedException();
        }

        public static bool SynchronizeNewChildren { get; set; }

        public static float MinimumSynchronizeChildrenWeight { get; set; }

        public AnimancerState[] SynchronizedChildren
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public int SynchronizedChildCount => throw new NotImplementedException();
        public bool IsSynchronized(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        public void Synchronize(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        public void DontSynchronize(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        public void DontSynchronizeChildren()
        {
            throw new NotImplementedException();
        }

        public void InitializeSynchronizedChildren(params bool[] synchronizeChildren)
        {
            throw new NotImplementedException();
        }

        public ManualMixerState GetParentMixer()
        {
            throw new NotImplementedException();
        }

        public static ManualMixerState GetParentMixer(IPlayableWrapper node)
        {
            throw new NotImplementedException();
        }

        public static bool IsChildOf(IPlayableWrapper child, IPlayableWrapper parent)
        {
            throw new NotImplementedException();
        }

        protected void ApplySynchronizeChildren(ref bool needsMoreUpdates)
        {
            throw new NotImplementedException();
        }

        public float CalculateRealEffectiveSpeed()
        {
            throw new NotImplementedException();
        }

        public override bool ApplyAnimatorIK { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool ApplyFootIK { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public static float CalculateTotalWeight(AnimancerState[] states, int count)
        {
            throw new NotImplementedException();
        }

        public void SetChildrenTime(float value, bool normalized = false)
        {
            throw new NotImplementedException();
        }

        protected void DisableRemainingStates(int previousIndex)
        {
            throw new NotImplementedException();
        }

        public void NormalizeWeights(float totalWeight)
        {
            throw new NotImplementedException();
        }

        public virtual string GetDisplayKey(AnimancerState state) => throw new NotImplementedException();
        public override Vector3 AverageVelocity
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void NormalizeDurations()
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

        public override void GatherAnimationClips(ICollection<AnimationClip> clips) => throw new NotImplementedException();
    }
}