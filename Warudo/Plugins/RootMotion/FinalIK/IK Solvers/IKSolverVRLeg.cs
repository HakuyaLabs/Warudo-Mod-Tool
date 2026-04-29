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
        public class Leg : BodyPart
        {
            public Transform target;
            public float positionWeight;
            public float rotationWeight;
            public Transform bendGoal;
            public float bendGoalWeight;
            public float swivelOffset;
            public float bendToTargetWeight = 0.5f;
            public float legLengthMlp = 1f;
            public AnimationCurve stretchCurve = new AnimationCurve();
            public Vector3 IKPosition;
            public Quaternion IKRotation = Quaternion.identity;
            public Vector3 footPositionOffset;
            public Vector3 heelPositionOffset;
            public Quaternion footRotationOffset = Quaternion.identity;
            public float currentMag;
            public bool useAnimatedBendNormal;
            public Vector3 position { get; private set; }

            public Quaternion rotation { get; private set; }

            public bool hasToes { get; private set; }

            public VirtualBone thigh
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public VirtualBone lastBone
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public Vector3 thighRelativeToPelvis { get; private set; }

            public Vector3 bendNormalRelToPelvis { get; set; }

            public Vector3 bendNormalRelToTarget { get; set; }

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

            public void Solve(bool stretch)
            {
                throw new NotImplementedException();
            }

            public override void Write(ref Vector3[] solvedPositions, ref Quaternion[] solvedRotations)
            {
                throw new NotImplementedException();
            }

            public override void ResetOffsets()
            {
                throw new NotImplementedException();
            }
        }
    }
}