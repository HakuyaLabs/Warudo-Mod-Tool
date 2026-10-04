using System;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;
using System;

namespace Animancer
{
    public partial struct AnimancerEvent : IEquatable<AnimancerEvent>
    {
        public float normalizedTime;
        public Action callback;
        public const float AlmostOne = 0.99999994f;
        public static readonly Action DummyCallback;
        public static bool IsNullOrDummy(Action callback) => throw new NotImplementedException();
        public AnimancerEvent(float normalizedTime, Action callback)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public void AppendDetails(StringBuilder text)
        {
            throw new NotImplementedException();
        }

        public static AnimancerState CurrentState => throw new NotImplementedException();
        public static ref readonly AnimancerEvent CurrentEvent => throw new NotImplementedException();
        public void Invoke(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        public static float GetFadeOutDuration() => throw new NotImplementedException();
        public static float GetFadeOutDuration(float minDuration) => throw new NotImplementedException();
        public static float GetFadeOutDuration(AnimancerState state, float minDuration)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(AnimancerEvent a, AnimancerEvent b)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(AnimancerEvent a, AnimancerEvent b)
        {
            throw new NotImplementedException();
        }

        public bool Equals(AnimancerEvent other) => throw new NotImplementedException();
        public override bool Equals(object obj) => throw new NotImplementedException();
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}