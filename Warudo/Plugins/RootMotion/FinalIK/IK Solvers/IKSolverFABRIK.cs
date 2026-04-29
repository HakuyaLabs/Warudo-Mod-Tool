using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class IKSolverFABRIK : IKSolverHeuristic
    {
        public void SolveForward(Vector3 position)
        {
            throw new NotImplementedException();
        }

        public void SolveBackward(Vector3 position)
        {
            throw new NotImplementedException();
        }

        public override Vector3 GetIKPosition()
        {
            throw new NotImplementedException();
        }

        public IterationDelegate OnPreIteration;
        protected override void OnInitiate()
        {
            throw new NotImplementedException();
        }

        protected override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        protected override bool boneLengthCanBeZero
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}