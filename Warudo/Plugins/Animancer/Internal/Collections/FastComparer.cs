using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public sealed class FastComparer : IEqualityComparer<object>
    {
        public static readonly FastComparer Instance = new FastComparer();
        bool IEqualityComparer<object>.Equals(object x, object y) => throw new NotImplementedException();
        int IEqualityComparer<object>.GetHashCode(object obj) => throw new NotImplementedException();
    }

    public sealed class FastReferenceComparer : IEqualityComparer<object>
    {
        public static readonly FastReferenceComparer Instance = new FastReferenceComparer();
        bool IEqualityComparer<object>.Equals(object x, object y) => throw new NotImplementedException();
        int IEqualityComparer<object>.GetHashCode(object obj) => throw new NotImplementedException();
    }
}