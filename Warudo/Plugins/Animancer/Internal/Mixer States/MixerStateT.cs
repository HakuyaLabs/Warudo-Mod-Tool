using System;
using System.Text;
using UnityEngine;
using UnityEngine.Animations;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public abstract class MixerState<TParameter> : ManualMixerState, ICopyable<MixerState<TParameter>>
    {
        public TParameter Parameter
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public abstract string GetParameterError(TParameter parameter);
        public bool HasThresholds => throw new NotImplementedException();
        public TParameter GetThreshold(int index) => throw new NotImplementedException();
        public void SetThreshold(int index, TParameter threshold)
        {
            throw new NotImplementedException();
        }

        public void SetThresholds(params TParameter[] thresholds)
        {
            throw new NotImplementedException();
        }

        public bool ValidateThresholdCount()
        {
            throw new NotImplementedException();
        }

        public virtual void OnThresholdsChanged()
        {
            throw new NotImplementedException();
        }

        public void CalculateThresholds(Func<AnimancerState, TParameter> calculate)
        {
            throw new NotImplementedException();
        }

        public override void RecreatePlayable()
        {
            throw new NotImplementedException();
        }

        protected override void OnChildCapacityChanged()
        {
            throw new NotImplementedException();
        }

        public void Add(AnimancerState state, TParameter threshold)
        {
            throw new NotImplementedException();
        }

        public ClipState Add(AnimationClip clip, TParameter threshold)
        {
            throw new NotImplementedException();
        }

        public AnimancerState Add(Animancer.ITransition transition, TParameter threshold)
        {
            throw new NotImplementedException();
        }

        public AnimancerState Add(object child, TParameter threshold)
        {
            throw new NotImplementedException();
        }

        void ICopyable<MixerState<TParameter>>.CopyFrom(MixerState<TParameter> copyFrom)
        {
            throw new NotImplementedException();
        }

        public override string GetDisplayKey(AnimancerState state) => throw new NotImplementedException();
        protected override void AppendDetails(StringBuilder text, string separator)
        {
            throw new NotImplementedException();
        }

        public virtual void AppendParameter(StringBuilder description, TParameter parameter)
        {
            throw new NotImplementedException();
        }
    }
}