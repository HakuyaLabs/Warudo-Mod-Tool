using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public interface IMotion
    {
        float AverageAngularSpeed { get; }

        Vector3 AverageVelocity { get; }
    }

    public static partial class AnimancerUtilities
    {
        public static bool TryGetAverageAngularSpeed(object motion, out float averageAngularSpeed)
        {
            throw new NotImplementedException();
        }

        public static bool TryGetAverageVelocity(object motion, out Vector3 averageVelocity)
        {
            throw new NotImplementedException();
        }
    }
}