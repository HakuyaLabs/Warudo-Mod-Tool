using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public partial class IKSolverVR : IKSolver
    {
        public partial class Locomotion
        {
            public float footDistance = 0.3f;
            public float stepThreshold = 0.4f;
            public float angleThreshold = 60f;
            public float comAngleMlp = 1f;
            public float maxVelocity = 0.4f;
            public float velocityFactor = 0.4f;
            public float maxLegStretch = 1f;
            public float rootSpeed = 20f;
            public float stepSpeed = 3f;
            public AnimationCurve stepHeight;
            public float maxBodyYOffset = 0.05f;
            public AnimationCurve heelHeight;
            public float relaxLegTwistMinAngle = 20f;
            public float relaxLegTwistSpeed = 400f;
            public InterpolationMode stepInterpolation = InterpolationMode.InOutSine;
            public Vector3 offset;
            public bool blockingEnabled;
            public LayerMask blockingLayers;
            public float raycastRadius = 0.2f;
            public float raycastHeight = 0.2f;
            public UnityEvent onLeftFootstep = new UnityEvent();
            public UnityEvent onRightFootstep = new UnityEvent();
            public Vector3 centerOfMass { get; private set; }

            public void Solve_Procedural(VirtualBone rootBone, Spine spine, Leg leftLeg, Leg rightLeg, Arm leftArm, Arm rightArm, int supportLegIndex, out Vector3 leftFootPosition, out Vector3 rightFootPosition, out Quaternion leftFootRotation, out Quaternion rightFootRotation, out float leftFootOffset, out float rightFootOffset, out float leftHeelOffset, out float rightHeelOffset, float scale, float deltaTime)
            {
                throw new NotImplementedException();
            }

            public Vector3 leftFootstepPosition
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public Vector3 rightFootstepPosition
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public Quaternion leftFootstepRotation
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public Quaternion rightFootstepRotation
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}