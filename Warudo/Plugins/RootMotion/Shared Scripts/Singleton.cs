using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T instance
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public static void Clear()
        {
            throw new NotImplementedException();
        }

        protected virtual void Awake()
        {
            throw new NotImplementedException();
        }
    }
}