using System;
using System.Text;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using Object = UnityEngine.Object;
using System;

namespace Animancer
{
    public class LinearMixerState : MixerState<float>, ICopyable<LinearMixerState>
    {
        public new interface ITransition : ITransition<LinearMixerState>
        {
        }

        public bool ExtrapolateSpeed
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public override string GetParameterError(float value) => throw new NotImplementedException();
        public override AnimancerState Clone(AnimancerPlayable root)
        {
            throw new NotImplementedException();
        }

        void ICopyable<LinearMixerState>.CopyFrom(LinearMixerState copyFrom)
        {
            throw new NotImplementedException();
        }

        public void AssertThresholdsSorted()
        {
            throw new NotImplementedException();
        }

        protected override void ForceRecalculateWeights()
        {
            throw new NotImplementedException();
        }

        public LinearMixerState AssignLinearThresholds(float min = 0, float max = 1)
        {
            throw new NotImplementedException();
        }

        protected override void AppendDetails(StringBuilder text, string separator)
        {
            throw new NotImplementedException();
        }

        protected override int ParameterCount => throw new NotImplementedException();
        protected override string GetParameterName(int index) => throw new NotImplementedException();
        protected override AnimatorControllerParameterType GetParameterType(int index) => throw new NotImplementedException();
        protected override object GetParameterValue(int index) => throw new NotImplementedException();
        protected override void SetParameterValue(int index, object value) => throw new NotImplementedException();
    }
}