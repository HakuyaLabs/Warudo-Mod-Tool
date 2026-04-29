using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class FABRIKRoot : IK
    {
        protected override void OpenUserManual()
        {
            throw new NotImplementedException();
        }

        protected override void OpenScriptReference()
        {
            throw new NotImplementedException();
        }

        void SupportGroup()
        {
            throw new NotImplementedException();
        }

        void ASThread()
        {
            throw new NotImplementedException();
        }

        public IKSolverFABRIKRoot solver = new IKSolverFABRIKRoot();
        public override IKSolver GetIKSolver()
        {
            throw new NotImplementedException();
        }
    }
}