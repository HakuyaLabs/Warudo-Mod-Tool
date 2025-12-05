using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Utils
{
    public interface ITransformConstraint
    {
        public void Initialize();
        public void OnUpdate();
    }
}