using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public static partial class Validate
    {
        public enum Value
        {
            Any,
            ZeroToOne,
            IsNotNegative,
            IsFinite,
            IsFiniteOrNaN,
        }

        public static void ValueRule(ref float value, Value rule)
        {
            throw new NotImplementedException();
        }
    }
}