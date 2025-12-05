using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class IKSolverArm : IKSolver
    {
        public float IKRotationWeight = 1f;
        public Quaternion IKRotation = Quaternion.identity;
        public IKSolver.Point chest = new IKSolver.Point();
        public IKSolver.Point shoulder = new IKSolver.Point();
        public IKSolver.Point upperArm = new IKSolver.Point();
        public IKSolver.Point forearm = new IKSolver.Point();
        public IKSolver.Point hand = new IKSolver.Point();
        public bool isLeft;
        public IKSolverVR.Arm arm = new IKSolverVR.Arm();
        public override bool IsValid(ref string message)
        {
            throw new NotImplementedException();
        }

        public void SetRotationWeight(float weight)
        {
            throw new NotImplementedException();
        }

        public bool SetChain(Transform chest, Transform shoulder, Transform upperArm, Transform forearm, Transform hand, Transform root)
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

        protected override void OnInitiate()
        {
            throw new NotImplementedException();
        }

        protected override void OnUpdate()
        {
            throw new NotImplementedException();
        }
    }
}