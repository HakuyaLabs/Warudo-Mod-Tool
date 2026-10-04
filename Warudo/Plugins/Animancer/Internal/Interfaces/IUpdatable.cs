using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public interface IUpdatable : Key.IListItem
    {
        void Update();
    }
}