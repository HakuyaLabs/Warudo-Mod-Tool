using UnityEngine;
using System.Collections;
using System;
using RootMotion;
using UnityEngine.Serialization;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public partial class IKSolverVR : IKSolver
    {
        public class Spine : BodyPart
        {
            public Transform headTarget;
            public float positionWeight = 1f;
            public float rotationWeight = 1f;
            public float headClampWeight = 0.6f;
            public float minHeadHeight = 0.8f;
            public float useAnimatedHeadHeightWeight;
            public float useAnimatedHeadHeightRange = 0.1f;
            public float animatedHeadHeightBlend = 0.3f;
            public Transform pelvisTarget;
            public float pelvisPositionWeight;
            public float pelvisRotationWeight;
            public float maintainPelvisPosition = 0.2f;
            public Transform chestGoal;
            public float chestGoalWeight;
            public float chestClampWeight = 0.5f;
            public float rotateChestByHands = 1f;
            public float bodyPosStiffness = 0.55f;
            public float bodyRotStiffness = 0.1f;
            public float neckStiffness = 0.2f;
            public float moveBodyBackWhenCrouching = 0.5f;
            public float maxRootAngle = 25f;
            public float rootHeadingOffset;
            public Vector3 IKPositionHead;
            public Quaternion IKRotationHead = Quaternion.identity;
            public Vector3 IKPositionPelvis;
            public Quaternion IKRotationPelvis = Quaternion.identity;
            public Vector3 goalPositionChest;
            public Vector3 pelvisPositionOffset;
            public Vector3 chestPositionOffset;
            public Vector3 headPositionOffset;
            public Quaternion pelvisRotationOffset = Quaternion.identity;
            public Quaternion chestRotationOffset = Quaternion.identity;
            public Quaternion headRotationOffset = Quaternion.identity;
            internal VirtualBone pelvis
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            internal VirtualBone firstSpineBone
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            internal VirtualBone chest
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            internal VirtualBone head
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public Vector3 faceDirection;
            internal Vector3 headPosition;
            internal Quaternion anchorRotation { get; private set; }

            internal Quaternion anchorRelativeToHead { get; private set; }

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

            public void Solve(Animator animator, VirtualBone rootBone, Leg[] legs, Arm[] arms, float scale)
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

            public void InverseTranslateToHead(Leg[] legs, bool limited, bool useCurrentLegMag, Vector3 offset, float w)
            {
                throw new NotImplementedException();
            }
        }
    }
}