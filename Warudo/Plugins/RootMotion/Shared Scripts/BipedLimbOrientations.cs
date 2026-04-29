using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public class BipedLimbOrientations
    {
        public class LimbOrientation
        {
            public Vector3 upperBoneForwardAxis;
            public Vector3 lowerBoneForwardAxis;
            public Vector3 lastBoneLeftAxis;
            public LimbOrientation(Vector3 upperBoneForwardAxis, Vector3 lowerBoneForwardAxis, Vector3 lastBoneLeftAxis)
            {
                throw new NotImplementedException();
            }
        }

        public LimbOrientation leftArm, rightArm, leftLeg, rightLeg;
        public BipedLimbOrientations(LimbOrientation leftArm, LimbOrientation rightArm, LimbOrientation leftLeg, LimbOrientation rightLeg)
        {
            throw new NotImplementedException();
        }

        public static BipedLimbOrientations UMA
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public static BipedLimbOrientations MaxBiped
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}