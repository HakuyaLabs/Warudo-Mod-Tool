using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class RedirectRootMotionToRigidbody : RedirectRootMotion<Rigidbody>
    {
        protected override void OnAnimatorMove()
        {
            throw new NotImplementedException();
        }
    }
}