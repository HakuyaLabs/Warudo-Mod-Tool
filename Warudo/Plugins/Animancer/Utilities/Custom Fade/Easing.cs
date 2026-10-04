using System;
using static UnityEngine.Mathf;
using NormalizedDelegate = System.Func<float, float>;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public static class Easing
    {
        public const float Ln2 = 0.693147180559945f;
        public delegate float RangedDelegate(float start, float end, float value);
        public enum Function
        {
            Linear,
            QuadraticIn,
            QuadraticOut,
            QuadraticInOut,
            CubicIn,
            CubicOut,
            CubicInOut,
            QuarticIn,
            QuarticOut,
            QuarticInOut,
            QuinticIn,
            QuinticOut,
            QuinticInOut,
            SineIn,
            SineOut,
            SineInOut,
            ExponentialIn,
            ExponentialOut,
            ExponentialInOut,
            CircularIn,
            CircularOut,
            CircularInOut,
            BackIn,
            BackOut,
            BackInOut,
            BounceIn,
            BounceOut,
            BounceInOut,
            ElasticIn,
            ElasticOut,
            ElasticInOut,
        }

        public const int FunctionCount = (int)Function.ElasticInOut + 1;
        public static NormalizedDelegate GetDelegate(this Function function)
        {
            throw new NotImplementedException();
        }

        public static NormalizedDelegate GetDerivativeDelegate(this Function function)
        {
            throw new NotImplementedException();
        }

        public static RangedDelegate GetRangedDelegate(this Function function)
        {
            throw new NotImplementedException();
        }

        public static RangedDelegate GetRangedDerivativeDelegate(this Function function)
        {
            throw new NotImplementedException();
        }

        public static float Lerp(float start, float end, float value) => throw new NotImplementedException();
        public static float UnLerp(float start, float end, float value) => throw new NotImplementedException();
        public static float ReScale(float start, float end, float value, NormalizedDelegate function) => throw new NotImplementedException();
        public static float Linear(float value) => throw new NotImplementedException();
        public static float LinearDerivative(float value) => throw new NotImplementedException();
        public static float Linear(float start, float end, float value) => throw new NotImplementedException();
        public static float LinearDerivative(float start, float end, float value) => throw new NotImplementedException();
        public static class Quadratic
        {
            public static float In(float value) => throw new NotImplementedException();
            public static float Out(float value)
            {
                throw new NotImplementedException();
            }

            public static float InOut(float value)
            {
                throw new NotImplementedException();
            }

            public static float InDerivative(float value) => throw new NotImplementedException();
            public static float OutDerivative(float value) => throw new NotImplementedException();
            public static float InOutDerivative(float value)
            {
                throw new NotImplementedException();
            }

            public static float In(float start, float end, float value) => throw new NotImplementedException();
            public static float Out(float start, float end, float value) => throw new NotImplementedException();
            public static float InOut(float start, float end, float value) => throw new NotImplementedException();
            public static float InDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float OutDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float InOutDerivative(float start, float end, float value) => throw new NotImplementedException();
        }

        public static class Cubic
        {
            public static float In(float value) => throw new NotImplementedException();
            public static float Out(float value)
            {
                throw new NotImplementedException();
            }

            public static float InOut(float value)
            {
                throw new NotImplementedException();
            }

            public static float InDerivative(float value) => throw new NotImplementedException();
            public static float OutDerivative(float value)
            {
                throw new NotImplementedException();
            }

            public static float InOutDerivative(float value)
            {
                throw new NotImplementedException();
            }

            public static float In(float start, float end, float value) => throw new NotImplementedException();
            public static float Out(float start, float end, float value) => throw new NotImplementedException();
            public static float InOut(float start, float end, float value) => throw new NotImplementedException();
            public static float InDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float OutDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float InOutDerivative(float start, float end, float value) => throw new NotImplementedException();
        }

        public static class Quartic
        {
            public static float In(float value) => throw new NotImplementedException();
            public static float Out(float value)
            {
                throw new NotImplementedException();
            }

            public static float InOut(float value)
            {
                throw new NotImplementedException();
            }

            public static float InDerivative(float value) => throw new NotImplementedException();
            public static float OutDerivative(float value)
            {
                throw new NotImplementedException();
            }

            public static float InOutDerivative(float value)
            {
                throw new NotImplementedException();
            }

            public static float In(float start, float end, float value) => throw new NotImplementedException();
            public static float Out(float start, float end, float value) => throw new NotImplementedException();
            public static float InOut(float start, float end, float value) => throw new NotImplementedException();
            public static float InDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float OutDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float InOutDerivative(float start, float end, float value) => throw new NotImplementedException();
        }

        public static class Quintic
        {
            public static float In(float value) => throw new NotImplementedException();
            public static float Out(float value)
            {
                throw new NotImplementedException();
            }

            public static float InOut(float value)
            {
                throw new NotImplementedException();
            }

            public static float InDerivative(float value) => throw new NotImplementedException();
            public static float OutDerivative(float value)
            {
                throw new NotImplementedException();
            }

            public static float InOutDerivative(float value)
            {
                throw new NotImplementedException();
            }

            public static float In(float start, float end, float value) => throw new NotImplementedException();
            public static float Out(float start, float end, float value) => throw new NotImplementedException();
            public static float InOut(float start, float end, float value) => throw new NotImplementedException();
            public static float InDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float OutDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float InOutDerivative(float start, float end, float value) => throw new NotImplementedException();
        }

        public static class Sine
        {
            public static float In(float value) => throw new NotImplementedException();
            public static float Out(float value) => throw new NotImplementedException();
            public static float InOut(float value) => throw new NotImplementedException();
            public static float InDerivative(float value) => throw new NotImplementedException();
            public static float OutDerivative(float value) => throw new NotImplementedException();
            public static float InOutDerivative(float value) => throw new NotImplementedException();
            public static float In(float start, float end, float value) => throw new NotImplementedException();
            public static float Out(float start, float end, float value) => throw new NotImplementedException();
            public static float InOut(float start, float end, float value) => throw new NotImplementedException();
            public static float InDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float OutDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float InOutDerivative(float start, float end, float value) => throw new NotImplementedException();
        }

        public static class Exponential
        {
            public static float In(float value) => throw new NotImplementedException();
            public static float Out(float value) => throw new NotImplementedException();
            public static float InOut(float value)
            {
                throw new NotImplementedException();
            }

            public static float InDerivative(float value) => throw new NotImplementedException();
            public static float OutDerivative(float value) => throw new NotImplementedException();
            public static float InOutDerivative(float value)
            {
                throw new NotImplementedException();
            }

            public static float In(float start, float end, float value) => throw new NotImplementedException();
            public static float Out(float start, float end, float value) => throw new NotImplementedException();
            public static float InOut(float start, float end, float value) => throw new NotImplementedException();
            public static float InDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float OutDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float InOutDerivative(float start, float end, float value) => throw new NotImplementedException();
        }

        public static class Circular
        {
            public static float In(float value) => throw new NotImplementedException();
            public static float Out(float value)
            {
                throw new NotImplementedException();
            }

            public static float InOut(float value)
            {
                throw new NotImplementedException();
            }

            public static float InDerivative(float value) => throw new NotImplementedException();
            public static float OutDerivative(float value)
            {
                throw new NotImplementedException();
            }

            public static float InOutDerivative(float value)
            {
                throw new NotImplementedException();
            }

            public static float In(float start, float end, float value) => throw new NotImplementedException();
            public static float Out(float start, float end, float value) => throw new NotImplementedException();
            public static float InOut(float start, float end, float value) => throw new NotImplementedException();
            public static float InDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float OutDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float InOutDerivative(float start, float end, float value) => throw new NotImplementedException();
        }

        public static class Back
        {
            public static float In(float value) => throw new NotImplementedException();
            public static float Out(float value)
            {
                throw new NotImplementedException();
            }

            public static float InOut(float value)
            {
                throw new NotImplementedException();
            }

            public static float InDerivative(float value) => throw new NotImplementedException();
            public static float OutDerivative(float value)
            {
                throw new NotImplementedException();
            }

            public static float InOutDerivative(float value)
            {
                throw new NotImplementedException();
            }

            public static float In(float start, float end, float value) => throw new NotImplementedException();
            public static float Out(float start, float end, float value) => throw new NotImplementedException();
            public static float InOut(float start, float end, float value) => throw new NotImplementedException();
            public static float InDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float OutDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float InOutDerivative(float start, float end, float value) => throw new NotImplementedException();
        }

        public static class Bounce
        {
            public static float In(float value)
            {
                throw new NotImplementedException();
            }

            public static float Out(float value)
            {
                throw new NotImplementedException();
            }

            public static float InOut(float value)
            {
                throw new NotImplementedException();
            }

            public static float InDerivative(float value) => throw new NotImplementedException();
            public static float OutDerivative(float value)
            {
                throw new NotImplementedException();
            }

            public static float InOutDerivative(float value)
            {
                throw new NotImplementedException();
            }

            public static float In(float start, float end, float value) => throw new NotImplementedException();
            public static float Out(float start, float end, float value) => throw new NotImplementedException();
            public static float InOut(float start, float end, float value) => throw new NotImplementedException();
            public static float InDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float OutDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float InOutDerivative(float start, float end, float value) => throw new NotImplementedException();
        }

        public static class Elastic
        {
            public const float TwoThirdsPi = 2f / 3f * PI;
            public static float In(float value)
            {
                throw new NotImplementedException();
            }

            public static float Out(float value)
            {
                throw new NotImplementedException();
            }

            public static float InOut(float value)
            {
                throw new NotImplementedException();
            }

            public static float InDerivative(float value)
            {
                throw new NotImplementedException();
            }

            public static float OutDerivative(float value)
            {
                throw new NotImplementedException();
            }

            public static float InOutDerivative(float value)
            {
                throw new NotImplementedException();
            }

            public static float In(float start, float end, float value) => throw new NotImplementedException();
            public static float Out(float start, float end, float value) => throw new NotImplementedException();
            public static float InOut(float start, float end, float value) => throw new NotImplementedException();
            public static float InDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float OutDerivative(float start, float end, float value) => throw new NotImplementedException();
            public static float InOutDerivative(float start, float end, float value) => throw new NotImplementedException();
        }
    }
}