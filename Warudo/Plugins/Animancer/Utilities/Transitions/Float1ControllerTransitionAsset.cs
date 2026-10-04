using System;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class Float1ControllerTransitionAsset : AnimancerTransitionAsset<Float1ControllerTransition>
    {
        public new class UnShared : UnShared<Float1ControllerTransitionAsset, Float1ControllerTransition, Float1ControllerState>, Float1ControllerState.ITransition
        {
        }
    }

    public class Float1ControllerTransition : ControllerTransition<Float1ControllerState>, Float1ControllerState.ITransition, ICopyable<Float1ControllerTransition>
    {
        public ref string ParameterName => throw new NotImplementedException();
        public Float1ControllerTransition()
        {
            throw new NotImplementedException();
        }

        public Float1ControllerTransition(RuntimeAnimatorController controller, string parameterName)
        {
            throw new NotImplementedException();
        }

        public override Float1ControllerState CreateState() => throw new NotImplementedException();
        public virtual void CopyFrom(Float1ControllerTransition copyFrom)
        {
            throw new NotImplementedException();
        }
    }
}