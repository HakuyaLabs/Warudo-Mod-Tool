using UnityEngine;
using System.Collections;
using System;
using RootMotion;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public partial class IKSolverVR : IKSolver
    {
        public class Arm : BodyPart
        {
            public enum ShoulderRotationMode
            {
                YawPitch,
                FromTo
            }

            public Transform target;
            public float positionWeight = 1f;
            public float rotationWeight = 1f;
            public float shoulderRotationWeight = 1f;
            public ShoulderRotationMode shoulderRotationMode = ShoulderRotationMode.YawPitch;
            public float shoulderTwistWeight = 1f;
            public float shoulderYawOffset = 45f;
            public float shoulderPitchOffset = -30f;
            public Transform bendGoal;
            public float bendGoalWeight;
            public float swivelOffset;
            public Vector3 wristToPalmAxis = Vector3.zero;
            public Vector3 palmToThumbAxis = Vector3.zero;
            public float armLengthMlp = 1f;
            public AnimationCurve stretchCurve = new AnimationCurve();
            public Vector3 IKPosition;
            public Quaternion IKRotation = Quaternion.identity;
            public Vector3 bendDirection = Vector3.back;
            public Vector3 handPositionOffset;
            public Vector3 position { get; private set; }

            public Quaternion rotation { get; private set; }

            protected override void OnRead(Vector3[] positions, Quaternion[] rotations, bool hasChest, bool hasNeck, bool hasShoulders, bool hasToes, bool hasLegs, int rootIndex, int index)
            {
                throw new NotImplementedException();
            }

            public override void PreSolve(float scale)
            {
                throw new NotImplementedException();
            }

            public override void ApplyOffsets(float scale)
            {
                throw new NotImplementedException();
            }

            public void Solve(bool isLeft)
            {
                throw new NotImplementedException();
            }

            public override void ResetOffsets()
            {
                throw new NotImplementedException();
            }

            public override void Write(ref Vector3[] solvedPositions, ref Quaternion[] solvedRotations)
            {
                throw new NotImplementedException();
            }
        }
    }
}