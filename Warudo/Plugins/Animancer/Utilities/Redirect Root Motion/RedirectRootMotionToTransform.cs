using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class RedirectRootMotionToTransform : RedirectRootMotion<Transform>
    {
        protected override void OnAnimatorMove()
        {
            throw new NotImplementedException();
        }
    }
}