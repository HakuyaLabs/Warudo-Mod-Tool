using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class IKMapping
    {
        public class BoneMap
        {
            public Transform transform;
            public int chainIndex = -1;
            public int nodeIndex = -1;
            public Vector3 defaultLocalPosition;
            public Quaternion defaultLocalRotation;
            public Vector3 localSwingAxis, localTwistAxis, planePosition, ikPosition;
            public Quaternion defaultLocalTargetRotation;
            public float length;
            public Quaternion animatedRotation;
            public void Initiate(Transform transform, IKSolverFullBody solver)
            {
                throw new NotImplementedException();
            }

            public Vector3 swingDirection
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public void StoreDefaultLocalState()
            {
                throw new NotImplementedException();
            }

            public void FixTransform(bool position)
            {
                throw new NotImplementedException();
            }

            public bool isNodeBone
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public void SetLength(BoneMap nextBone)
            {
                throw new NotImplementedException();
            }

            public void SetLocalSwingAxis(BoneMap swingTarget)
            {
                throw new NotImplementedException();
            }

            public void SetLocalSwingAxis(BoneMap bone1, BoneMap bone2)
            {
                throw new NotImplementedException();
            }

            public void SetLocalTwistAxis(Vector3 twistDirection, Vector3 normalDirection)
            {
                throw new NotImplementedException();
            }

            public void SetPlane(IKSolverFullBody solver, Transform planeBone1, Transform planeBone2, Transform planeBone3)
            {
                throw new NotImplementedException();
            }

            public void UpdatePlane(bool rotation, bool position)
            {
                throw new NotImplementedException();
            }

            public void SetIKPosition()
            {
                throw new NotImplementedException();
            }

            public void MaintainRotation()
            {
                throw new NotImplementedException();
            }

            public void SetToIKPosition()
            {
                throw new NotImplementedException();
            }

            public void FixToNode(IKSolverFullBody solver, float weight, IKSolver.Node fixNode = null)
            {
                throw new NotImplementedException();
            }

            public Vector3 GetPlanePosition(IKSolverFullBody solver)
            {
                throw new NotImplementedException();
            }

            public void PositionToPlane(IKSolverFullBody solver)
            {
                throw new NotImplementedException();
            }

            public void RotateToPlane(IKSolverFullBody solver, float weight)
            {
                throw new NotImplementedException();
            }

            public void Swing(Vector3 swingTarget, float weight)
            {
                throw new NotImplementedException();
            }

            public void Swing(Vector3 pos1, Vector3 pos2, float weight)
            {
                throw new NotImplementedException();
            }

            public void Twist(Vector3 twistDirection, Vector3 normalDirection, float weight)
            {
                throw new NotImplementedException();
            }

            public void RotateToMaintain(float weight)
            {
                throw new NotImplementedException();
            }

            public void RotateToEffector(IKSolverFullBody solver, float weight)
            {
                throw new NotImplementedException();
            }
        }

        public virtual bool IsValid(IKSolver solver, ref string message)
        {
            throw new NotImplementedException();
        }

        public virtual void Initiate(IKSolverFullBody solver)
        {
            throw new NotImplementedException();
        }

        protected bool BoneIsValid(Transform bone, IKSolver solver, ref string message, Warning.Logger logger = null)
        {
            throw new NotImplementedException();
        }

        protected Vector3 SolveFABRIKJoint(Vector3 pos1, Vector3 pos2, float length)
        {
            throw new NotImplementedException();
        }
    }
}