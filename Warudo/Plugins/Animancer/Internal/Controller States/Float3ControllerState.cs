using System;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class Float3ControllerState : ControllerState
    {
        public new interface ITransition : ITransition<Float3ControllerState>
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

        public ParameterID ParameterZID
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public float ParameterZ
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public Vector3 Parameter
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public Float3ControllerState(RuntimeAnimatorController controller, ParameterID parameterX, ParameterID parameterY, ParameterID parameterZ, params ActionOnStop[] actionsOnStop) : base(controller, actionsOnStop)
        {
            throw new NotImplementedException();
        }

        public Float3ControllerState(RuntimeAnimatorController controller, ParameterID parameterX, ParameterID parameterY, ParameterID parameterZ) : this(controller, parameterX, parameterY, parameterZ, null)
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