using System;
using UnityEngine;
using Object = UnityEngine.Object;
using System;

namespace Animancer
{
    public class LinearMixerTransitionAsset : AnimancerTransitionAsset<LinearMixerTransition>
    {
        public new class UnShared : UnShared<LinearMixerTransitionAsset, LinearMixerTransition, LinearMixerState>, LinearMixerState.ITransition
        {
        }
    }

    public class LinearMixerTransition : MixerTransition<LinearMixerState, float>, LinearMixerState.ITransition, ICopyable<LinearMixerTransition>
    {
        public ref bool ExtrapolateSpeed => throw new NotImplementedException();
        public override bool IsValid
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override LinearMixerState CreateState()
        {
            throw new NotImplementedException();
        }

        public override void Apply(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        public void SortByThresholds()
        {
            throw new NotImplementedException();
        }

        public virtual void CopyFrom(LinearMixerTransition copyFrom)
        {
            throw new NotImplementedException();
        }
    }
}