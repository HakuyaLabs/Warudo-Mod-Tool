using System;
using System.Text;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class DirectionalMixerState : MixerState<Vector2>, ICopyable<DirectionalMixerState>
    {
        public float ParameterX { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public float ParameterY { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string GetParameterError(Vector2 value) => throw new NotImplementedException();
        public override void OnThresholdsChanged()
        {
            throw new NotImplementedException();
        }

        protected override void ForceRecalculateWeights()
        {
            throw new NotImplementedException();
        }

        public override AnimancerState Clone(AnimancerPlayable root)
        {
            throw new NotImplementedException();
        }

        void ICopyable<DirectionalMixerState>.CopyFrom(DirectionalMixerState copyFrom)
        {
            throw new NotImplementedException();
        }

        public override void AppendParameter(StringBuilder text, Vector2 parameter)
        {
            throw new NotImplementedException();
        }

        protected override int ParameterCount => throw new NotImplementedException();
        protected override string GetParameterName(int index)
        {
            throw new NotImplementedException();
        }

        protected override AnimatorControllerParameterType GetParameterType(int index) => throw new NotImplementedException();
        protected override object GetParameterValue(int index)
        {
            throw new NotImplementedException();
        }

        protected override void SetParameterValue(int index, object value)
        {
            throw new NotImplementedException();
        }
    }
}