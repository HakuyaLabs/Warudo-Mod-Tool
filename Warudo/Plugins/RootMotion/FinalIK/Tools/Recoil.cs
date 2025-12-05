using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class Recoil : OffsetModifier
    {
        public class RecoilOffset
        {
            public Vector3 offset;
            public float additivity = 1f;
            public float maxAdditiveOffsetMag = 0.2f;
            public class EffectorLink
            {
                public FullBodyBipedEffector effector;
                public float weight;
            }

            public EffectorLink[] effectorLinks;
            public void Start()
            {
                throw new NotImplementedException();
            }

            public void Apply(IKSolverFullBodyBiped solver, Quaternion rotation, float masterWeight, float length, float timeLeft)
            {
                throw new NotImplementedException();
            }
        }

        public enum Handedness
        {
            Right,
            Left
        }

        public AimIK aimIK;
        public AimIK headIK;
        public bool aimIKSolvedLast;
        public Handedness handedness;
        public bool twoHanded = true;
        public AnimationCurve recoilWeight;
        public float magnitudeRandom = 0.1f;
        public Vector3 rotationRandom;
        public Vector3 handRotationOffset;
        public float blendTime;
        public RecoilOffset[] offsets;
        public Quaternion rotationOffset = Quaternion.identity;
        public bool isFinished
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void SetHandRotations(Quaternion leftHandRotation, Quaternion rightHandRotation)
        {
            throw new NotImplementedException();
        }

        public void Fire(float magnitude)
        {
            throw new NotImplementedException();
        }

        protected override void OnModifyOffset()
        {
            throw new NotImplementedException();
        }

        protected override void OnDestroy()
        {
            throw new NotImplementedException();
        }
    }
}