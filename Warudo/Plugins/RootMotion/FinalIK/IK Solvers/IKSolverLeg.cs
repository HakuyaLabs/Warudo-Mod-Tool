using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class IKSolverLeg : IKSolver
    {
        public float IKRotationWeight = 1f;
        public Quaternion IKRotation = Quaternion.identity;
        public IKSolver.Point pelvis = new IKSolver.Point();
        public IKSolver.Point thigh = new IKSolver.Point();
        public IKSolver.Point calf = new IKSolver.Point();
        public IKSolver.Point foot = new IKSolver.Point();
        public IKSolver.Point toe = new IKSolver.Point();
        public IKSolverVR.Leg leg = new IKSolverVR.Leg();
        public Vector3 heelOffset;
        public override bool IsValid(ref string message)
        {
            throw new NotImplementedException();
        }

        public void SetRotationWeight(float weight)
        {
            throw new NotImplementedException();
        }

        public bool SetChain(Transform pelvis, Transform thigh, Transform calf, Transform foot, Transform toe, Transform root)
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