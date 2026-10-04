using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public abstract class RedirectRootMotion<T> : MonoBehaviour
    {
        public ref Animator Animator => throw new NotImplementedException();
        public ref T Target => throw new NotImplementedException();
        public bool ApplyRootMotion => throw new NotImplementedException();
        protected virtual void OnValidate()
        {
            throw new NotImplementedException();
        }

        protected abstract void OnAnimatorMove();
    }
}