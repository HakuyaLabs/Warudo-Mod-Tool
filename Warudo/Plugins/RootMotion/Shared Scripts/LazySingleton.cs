using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public abstract class LazySingleton<T> : MonoBehaviour where T : LazySingleton<T>
    {
        public static bool hasInstance
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public static T instance
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected virtual void Awake()
        {
            throw new NotImplementedException();
        }
    }
}