using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public abstract class OffsetModifier : MonoBehaviour
    {
        public class OffsetLimits
        {
            public FullBodyBipedEffector effector;
            public float spring = 0f;
            public bool x, y, z;
            public float minX, maxX, minY, maxY, minZ, maxZ;
            public void Apply(IKEffector e, Quaternion rootRotation)
            {
                throw new NotImplementedException();
            }
        }

        public float weight = 1f;
        public FullBodyBipedIK ik;
        protected float deltaTime
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected abstract void OnModifyOffset();
        protected float lastTime;
        protected virtual void Start()
        {
            throw new NotImplementedException();
        }

        protected void ApplyLimits(OffsetLimits[] limits)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnDestroy()
        {
            throw new NotImplementedException();
        }
    }
}