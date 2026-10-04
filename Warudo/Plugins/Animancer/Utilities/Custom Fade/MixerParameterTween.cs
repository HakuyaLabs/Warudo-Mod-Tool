using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class MixerParameterTweenFloat : MixerParameterTween<float>
    {
        public MixerParameterTweenFloat()
        {
            throw new NotImplementedException();
        }

        public MixerParameterTweenFloat(MixerState<float> mixer) : base(mixer)
        {
            throw new NotImplementedException();
        }

        protected override float CalculateCurrentValue() => throw new NotImplementedException();
    }

    public class MixerParameterTweenVector2 : MixerParameterTween<Vector2>
    {
        public MixerParameterTweenVector2()
        {
            throw new NotImplementedException();
        }

        public MixerParameterTweenVector2(MixerState<Vector2> mixer) : base(mixer)
        {
            throw new NotImplementedException();
        }

        protected override Vector2 CalculateCurrentValue() => throw new NotImplementedException();
    }

    public abstract class MixerParameterTween<TParameter> : Key, IUpdatable
    {
        public MixerState<TParameter> Mixer { get; set; }

        public TParameter StartValue { get; set; }

        public TParameter EndValue { get; set; }

        public float Duration { get; set; }

        public float Time { get; set; }

        public float Progress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MixerParameterTween()
        {
            throw new NotImplementedException();
        }

        public MixerParameterTween(MixerState<TParameter> mixer)
        {
            throw new NotImplementedException();
        }

        public void Start(TParameter endValue, float duration)
        {
            throw new NotImplementedException();
        }

        public void Stop() => throw new NotImplementedException();
        public bool IsActive => throw new NotImplementedException();
        protected abstract TParameter CalculateCurrentValue();
        void IUpdatable.Update()
        {
            throw new NotImplementedException();
        }
    }
}