using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class IKSolverTrigonometric : IKSolver
    {
        public Transform target;
        public float IKRotationWeight = 1f;
        public Quaternion IKRotation = Quaternion.identity;
        public Vector3 bendNormal = Vector3.right;
        public TrigonometricBone bone1 = new TrigonometricBone();
        public TrigonometricBone bone2 = new TrigonometricBone();
        public TrigonometricBone bone3 = new TrigonometricBone();
        public void SetBendGoalPosition(Vector3 goalPosition, float weight)
        {
            throw new NotImplementedException();
        }

        public void SetBendPlaneToCurrent()
        {
            throw new NotImplementedException();
        }

        public void SetIKRotation(Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        public void SetIKRotationWeight(float weight)
        {
            throw new NotImplementedException();
        }

        public Quaternion GetIKRotation()
        {
            throw new NotImplementedException();
        }

        public float GetIKRotationWeight()
        {
            throw new NotImplementedException();
        }

        public override IKSolver.Point[] GetPoints()
        {
            throw new NotImplementedException();
        }

        public override IKSolver.Point GetPoint(Transform transform)
        {
            throw new NotImplementedException();
        }

        public override void StoreDefaultLocalState()
        {
            throw new NotImplementedException();
        }

        public override void FixTransforms()
        {
            throw new NotImplementedException();
        }

        public override bool IsValid(ref string message)
        {
            throw new NotImplementedException();
        }

        public class TrigonometricBone : IKSolver.Bone
        {
            public void Initiate(Vector3 childPosition, Vector3 bendNormal)
            {
                throw new NotImplementedException();
            }

            public Quaternion GetRotation(Vector3 direction, Vector3 bendNormal)
            {
                throw new NotImplementedException();
            }

            public Vector3 GetBendNormalFromCurrentRotation()
            {
                throw new NotImplementedException();
            }
        }

        public bool SetChain(Transform bone1, Transform bone2, Transform bone3, Transform root)
        {
            throw new NotImplementedException();
        }

        public static void Solve(Transform bone1, Transform bone2, Transform bone3, Vector3 targetPosition, Vector3 bendNormal, float weight)
        {
            throw new NotImplementedException();
        }

        protected override void OnInitiate()
        {
            throw new NotImplementedException();
        }

        public void InitiateBones()
        {
            throw new NotImplementedException();
        }

        protected override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        protected Vector3 weightIKPosition;
        protected virtual void OnInitiateVirtual()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnUpdateVirtual()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnPostSolveVirtual()
        {
            throw new NotImplementedException();
        }

        protected bool directHierarchy = true;
        protected Vector3 GetBendDirection(Vector3 IKPosition, Vector3 bendNormal)
        {
            throw new NotImplementedException();
        }
    }
}