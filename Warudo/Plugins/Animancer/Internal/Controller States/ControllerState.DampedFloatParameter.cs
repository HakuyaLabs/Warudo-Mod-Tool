using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    partial class ControllerState
    {
        public class DampedFloatParameter
        {
            public ParameterID parameter;
            public float smoothTime;
            public float currentValue;
            public float targetValue;
            public float maxSpeed;
            public float velocity;
            public DampedFloatParameter(ParameterID parameter, float smoothTime, float defaultValue = 0, float maxSpeed = float.PositiveInfinity)
            {
                throw new NotImplementedException();
            }

            public void Apply(ControllerState controller) => throw new NotImplementedException();
            public void Apply(ControllerState controller, float deltaTime)
            {
                throw new NotImplementedException();
            }
        }
    }
}