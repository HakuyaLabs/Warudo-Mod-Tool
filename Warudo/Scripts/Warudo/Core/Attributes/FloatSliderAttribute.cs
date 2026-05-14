using System;

namespace Warudo.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FloatSliderAttribute : Attribute {
        public float Min { get; }
        public float Max { get; }
        public float Step { get; }

        public FloatSliderAttribute(float min, float max, float step = 0.01f) {
            Min = min;
            Max = max;
            Step = step;
        }
    }
}