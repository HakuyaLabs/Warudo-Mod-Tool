using System;

namespace Warudo.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class IntegerSliderAttribute : Attribute {
        public int Min { get; }
        public int Max { get; }
        public int Step { get; }

        public IntegerSliderAttribute(int min, int max, int step = 1) {
            Min = min;
            Max = max;
            Step = step;
        }
    }
}