using System;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class Float2ControllerState : ControllerState
    {
        public new interface ITransition : ITransition<Float2ControllerState>
        {
        }

        public ParameterID ParameterXID
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public float ParameterX
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public ParameterID ParameterYID
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public float ParameterY
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public Vector2 Parameter
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public Float2ControllerState(RuntimeAnimatorController controller, ParameterID parameterX, ParameterID parameterY, params ActionOnStop[] actionsOnStop) : base(controller, actionsOnStop)
        {
            throw new NotImplementedException();
        }

        public Float2ControllerState(RuntimeAnimatorController controller, ParameterID parameterX, ParameterID parameterY) : this(controller, parameterX, parameterY, null)
        {
            throw new NotImplementedException();
        }

        public override int ParameterCount => throw new NotImplementedException();
        public override int GetParameterHash(int index)
        {
            throw new NotImplementedException();
        }

        public override AnimancerState Clone(AnimancerPlayable root)
        {
            throw new NotImplementedException();
        }
    }
}