using System;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class Float2ControllerTransitionAsset : AnimancerTransitionAsset<Float2ControllerTransition>
    {
        public new class UnShared : UnShared<Float2ControllerTransitionAsset, Float2ControllerTransition, Float2ControllerState>, Float2ControllerState.ITransition
        {
        }
    }

    public class Float2ControllerTransition : ControllerTransition<Float2ControllerState>, Float2ControllerState.ITransition, ICopyable<Float2ControllerTransition>
    {
        public ref string ParameterNameX => throw new NotImplementedException();
        public ref string ParameterNameY => throw new NotImplementedException();
        public Float2ControllerTransition()
        {
            throw new NotImplementedException();
        }

        public Float2ControllerTransition(RuntimeAnimatorController controller, string parameterNameX, string parameterNameY)
        {
            throw new NotImplementedException();
        }

        public override Float2ControllerState CreateState() => throw new NotImplementedException();
        public virtual void CopyFrom(Float2ControllerTransition copyFrom)
        {
            throw new NotImplementedException();
        }
    }
}