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
        public enum PositionOffset
        {
            Pelvis,
            Chest,
            Head,
            LeftHand,
            RightHand,
            LeftFoot,
            RightFoot,
            LeftHeel,
            RightHeel
        }

        public enum RotationOffset
        {
            Pelvis,
            Chest,
            Head,
        }

        public class VirtualBone
        {
            public Vector3 readPosition;
            public Quaternion readRotation;
            public Vector3 solverPosition;
            public Quaternion solverRotation;
            public float length;
            public float sqrMag;
            public Vector3 axis;
            public VirtualBone(Vector3 position, Quaternion rotation)
            {
                throw new NotImplementedException();
            }

            public void Read(Vector3 position, Quaternion rotation)
            {
                throw new NotImplementedException();
            }

            public static void SwingRotation(VirtualBone[] bones, int index, Vector3 swingTarget, float weight = 1f)
            {
                throw new NotImplementedException();
            }

            public static float PreSolve(ref VirtualBone[] bones)
            {
                throw new NotImplementedException();
            }

            public static void RotateAroundPoint(VirtualBone[] bones, int index, Vector3 point, Quaternion rotation)
            {
                throw new NotImplementedException();
            }

            public static void RotateBy(VirtualBone[] bones, int index, Quaternion rotation)
            {
                throw new NotImplementedException();
            }

            public static void RotateBy(VirtualBone[] bones, Quaternion rotation)
            {
                throw new NotImplementedException();
            }

            public static void RotateTo(VirtualBone[] bones, int index, Quaternion rotation)
            {
                throw new NotImplementedException();
            }

            public static void SolveTrigonometric(VirtualBone[] bones, int first, int second, int third, Vector3 targetPosition, Vector3 bendNormal, float weight)
            {
                throw new NotImplementedException();
            }

            public static void SolveFABRIK(VirtualBone[] bones, Vector3 startPosition, Vector3 targetPosition, float weight, float minNormalizedTargetDistance, int iterations, float length, Vector3 startOffset)
            {
                throw new NotImplementedException();
            }

            public static void SolveCCD(VirtualBone[] bones, Vector3 targetPosition, float weight, int iterations)
            {
                throw new NotImplementedException();
            }
        }
    }
}