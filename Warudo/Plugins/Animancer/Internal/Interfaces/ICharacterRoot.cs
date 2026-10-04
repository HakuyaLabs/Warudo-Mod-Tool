using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public interface ICharacterRoot
    {
        Transform transform { get; }
    }
}