using System;
using Warudo.Core.Scenes;

namespace Warudo.Core.Attributes {
    public enum If {
        Equal,
        NotEqual,
        Greater,
        GreaterOrEqual,
        Less,
        LessOrEqual,
        InstanceOf,
        NotInstanceOf
    }

    public static class IfExtensions {
        
        public static bool Evaluate(this If @if, object value, object other) {
            return @if switch {
                If.Equal => Equals(value, other),
                If.NotEqual => !Equals(value, other),
                If.Greater => Comparer(value, other) > 0,
                If.GreaterOrEqual => Comparer(value, other) >= 0,
                If.Less => Comparer(value, other) < 0,
                If.LessOrEqual => Comparer(value, other) <= 0,
                If.InstanceOf => other is Type otherType && otherType.IsInstanceOfType(value),
                If.NotInstanceOf => !(other is Type otherType && otherType.IsInstanceOfType(value)),
                _ => throw new ArgumentOutOfRangeException(nameof(@if), @if, null)
            };
        }
        
        private static int Comparer(object value, object other) {
            if (value is IComparable comparable) {
                return comparable.CompareTo(other);
            }
            throw new ArgumentException($"Cannot compare {value} and {other}");
        }
        
    }
    
    public enum Is {
        True,
        False,
        Null,
        NonNull,
        NullOrInactive,
        NonNullAndActive
    }

    public static class IsExtensions {
        
        public static bool Evaluate(this Is @is, object value) {
            return @is switch {
                Is.True => value is true,
                Is.False => value is false,
                Is.Null => value == null,
                Is.NonNull => value != null,
                Is.NullOrInactive => value is not Asset { Active: true },
                Is.NonNullAndActive => value is Asset { Active: true },
                _ => throw new ArgumentOutOfRangeException(nameof(@is), @is, null)
            };
        }
        
    }
}
