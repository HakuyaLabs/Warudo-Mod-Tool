using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public abstract class IK : SolverManager
    {
        public abstract IKSolver GetIKSolver();
        protected override void UpdateSolver()
        {
            throw new NotImplementedException();
        }

        protected override void InitiateSolver()
        {
            throw new NotImplementedException();
        }

        protected override void FixTransforms()
        {
            throw new NotImplementedException();
        }

        protected abstract void OpenUserManual();
        protected abstract void OpenScriptReference();
    }
}