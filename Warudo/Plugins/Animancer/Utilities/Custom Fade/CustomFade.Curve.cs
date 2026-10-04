using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public partial class CustomFade
    {
        public static void Apply(AnimancerComponent animancer, AnimationCurve curve) => throw new NotImplementedException();
        public static void Apply(AnimancerPlayable animancer, AnimationCurve curve) => throw new NotImplementedException();
        public static void Apply(AnimancerState state, AnimationCurve curve) => throw new NotImplementedException();
        public static void Apply(AnimancerNode node, AnimationCurve curve) => throw new NotImplementedException();
        private class Curve : CustomFade
        {
            public static Curve Acquire(AnimationCurve curve)
            {
                throw new NotImplementedException();
            }

            protected override float CalculateWeight(float progress) => throw new NotImplementedException();
            protected override void Release() => throw new NotImplementedException();
        }
    }
}