using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class RotationLimitHinge : RotationLimit
    {
        void SupportGroup()
        {
            throw new NotImplementedException();
        }

        void ASThread()
        {
            throw new NotImplementedException();
        }

        public bool useLimits = true;
        public float min = -45;
        public float max = 90;
        protected override Quaternion LimitRotation(Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        public float zeroAxisDisplayOffset;
    }
}