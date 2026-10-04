using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public interface IHasKey
    {
        object Key { get; }
    }
}