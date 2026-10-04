using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class RotationLimitSpline : RotationLimit
    {
        void SupportGroup()
        {
            throw new NotImplementedException();
        }

        void ASThread()
        {
            throw new NotImplementedException();
        }

        public float twistLimit = 180;
        public void SetSpline(Keyframe[] keyframes)
        {
            throw new NotImplementedException();
        }

        public AnimationCurve spline;
        protected override Quaternion LimitRotation(Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        public Quaternion LimitSwing(Quaternion rotation)
        {
            throw new NotImplementedException();
        }
    }
}