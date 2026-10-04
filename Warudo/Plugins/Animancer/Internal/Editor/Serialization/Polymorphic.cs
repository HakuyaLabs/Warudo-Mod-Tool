using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public interface IPolymorphic
    {
    }

    public interface IPolymorphicReset : IPolymorphic
    {
        void Reset();
    }

    public sealed class PolymorphicAttribute : PropertyAttribute
    {
    }
}