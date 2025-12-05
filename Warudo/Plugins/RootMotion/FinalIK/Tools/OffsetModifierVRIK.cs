using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public abstract class OffsetModifierVRIK : MonoBehaviour
    {
        public float weight = 1f;
        public VRIK ik;
        protected float deltaTime
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected abstract void OnModifyOffset();
        protected virtual void Start()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnDestroy()
        {
            throw new NotImplementedException();
        }
    }
}