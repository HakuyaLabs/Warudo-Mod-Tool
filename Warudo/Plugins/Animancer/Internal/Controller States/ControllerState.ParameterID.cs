using System;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    partial class ControllerState
    {
        public readonly struct ParameterID
        {
            public readonly string Name;
            public readonly int Hash;
            public ParameterID(string name)
            {
                throw new NotImplementedException();
            }

            public ParameterID(int hash)
            {
                throw new NotImplementedException();
            }

            public ParameterID(string name, int hash)
            {
                throw new NotImplementedException();
            }

            public static implicit operator ParameterID(string name)
            {
                throw new NotImplementedException();
            }

            public static implicit operator ParameterID(int hash)
            {
                throw new NotImplementedException();
            }

            public static implicit operator int (ParameterID parameter)
            {
                throw new NotImplementedException();
            }

            public void ValidateHasParameter(RuntimeAnimatorController controller, AnimatorControllerParameterType type)
            {
                throw new NotImplementedException();
            }

            public override string ToString()
            {
                throw new NotImplementedException();
            }
        }
    }
}