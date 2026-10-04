using System;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public partial class CustomFade
    {
        public static void Apply(AnimancerComponent animancer, Func<float, float> calculateWeight) => throw new NotImplementedException();
        public static void Apply(AnimancerPlayable animancer, Func<float, float> calculateWeight) => throw new NotImplementedException();
        public static void Apply(AnimancerState state, Func<float, float> calculateWeight) => throw new NotImplementedException();
        public static void Apply(AnimancerNode node, Func<float, float> calculateWeight) => throw new NotImplementedException();
        public static void Apply(AnimancerComponent animancer, Easing.Function function) => throw new NotImplementedException();
        public static void Apply(AnimancerPlayable animancer, Easing.Function function) => throw new NotImplementedException();
        public static void Apply(AnimancerState state, Easing.Function function) => throw new NotImplementedException();
        public static void Apply(AnimancerNode node, Easing.Function function) => throw new NotImplementedException();
        private class Delegate : CustomFade
        {
            public static Delegate Acquire(Func<float, float> calculateWeight)
            {
                throw new NotImplementedException();
            }

            protected override float CalculateWeight(float progress) => throw new NotImplementedException();
            protected override void Release() => throw new NotImplementedException();
        }
    }
}