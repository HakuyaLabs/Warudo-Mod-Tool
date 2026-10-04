using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using System;

namespace Animancer
{
    public class ManualMixerTransition : ManualMixerTransition<ManualMixerState>, ManualMixerState.ITransition, ICopyable<ManualMixerTransition>
    {
        public override ManualMixerState CreateState()
        {
            throw new NotImplementedException();
        }

        public virtual void CopyFrom(ManualMixerTransition copyFrom)
        {
            throw new NotImplementedException();
        }
    }
}