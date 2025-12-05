using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class IKSolverFABRIKRoot : IKSolver
    {
        public int iterations = 4;
        public float rootPin = 0f;
        public FABRIKChain[] chains = new FABRIKChain[0];
        public override bool IsValid(ref string message)
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

        public override IKSolver.Point[] GetPoints()
        {
            throw new NotImplementedException();
        }

        public override IKSolver.Point GetPoint(Transform transform)
        {
            throw new NotImplementedException();
        }
    }
}