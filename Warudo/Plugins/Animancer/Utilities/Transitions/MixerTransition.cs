using System;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public abstract class MixerTransition<TMixer, TParameter> : ManualMixerTransition<TMixer>, ICopyable<MixerTransition<TMixer, TParameter>> where TMixer : MixerState<TParameter>
    {
        public ref TParameter[] Thresholds => throw new NotImplementedException();
        public const string ThresholdsField = "_Thresholds";
        public ref TParameter DefaultParameter => throw new NotImplementedException();
        public const string DefaultParameterField = "_DefaultParameter";
        public override void InitializeState()
        {
            throw new NotImplementedException();
        }

        public virtual void CopyFrom(MixerTransition<TMixer, TParameter> copyFrom)
        {
            throw new NotImplementedException();
        }
    }
}