using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class RedirectRootMotionToCharacterController : RedirectRootMotion<CharacterController>
    {
        protected override void OnAnimatorMove()
        {
            throw new NotImplementedException();
        }
    }
}