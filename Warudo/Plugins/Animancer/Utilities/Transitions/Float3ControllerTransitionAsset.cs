using System;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class Float3ControllerTransitionAsset : AnimancerTransitionAsset<Float3ControllerTransition>
    {
        public new class UnShared : UnShared<Float3ControllerTransitionAsset, Float3ControllerTransition, Float3ControllerState>, Float3ControllerState.ITransition
        {
        }
    }

    public class Float3ControllerTransition : ControllerTransition<Float3ControllerState>, Float3ControllerState.ITransition, ICopyable<Float3ControllerTransition>
    {
        public ref string ParameterNameX => throw new NotImplementedException();
        public ref string ParameterNameY => throw new NotImplementedException();
        public ref string ParameterNameZ => throw new NotImplementedException();
        public Float3ControllerTransition()
        {
            throw new NotImplementedException();
        }

        public Float3ControllerTransition(RuntimeAnimatorController controller, string parameterNameX, string parameterNameY, string parameterNameZ)
        {
            throw new NotImplementedException();
        }

        public override Float3ControllerState CreateState() => throw new NotImplementedException();
        public virtual void CopyFrom(Float3ControllerTransition copyFrom)
        {
            throw new NotImplementedException();
        }
    }
}