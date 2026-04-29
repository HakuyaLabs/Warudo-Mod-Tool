using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class RotationLimitAngle : RotationLimit
    {
        void SupportGroup()
        {
            throw new NotImplementedException();
        }

        void ASThread()
        {
            throw new NotImplementedException();
        }

        public float limit = 45;
        public float twistLimit = 180;
        protected override Quaternion LimitRotation(Quaternion rotation)
        {
            throw new NotImplementedException();
        }
    }
}