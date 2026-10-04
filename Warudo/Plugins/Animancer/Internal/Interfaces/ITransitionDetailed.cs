using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public interface ITransitionDetailed : ITransition
    {
        bool IsValid { get; }

        bool IsLooping { get; }

        float NormalizedStartTime { get; set; }

        float MaximumDuration { get; }

        float Speed { get; set; }
    }

    public static partial class AnimancerUtilities
    {
        public static bool IsValid(this ITransition transition)
        {
            throw new NotImplementedException();
        }

        public static bool TryGetIsLooping(object motionOrTransition, out bool isLooping)
        {
            throw new NotImplementedException();
        }

        public static bool TryGetLength(object motionOrTransition, out float length)
        {
            throw new NotImplementedException();
        }
    }
}