using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class FullBodyBipedIK : IK
    {
        protected override void OpenUserManual()
        {
            throw new NotImplementedException();
        }

        protected override void OpenScriptReference()
        {
            throw new NotImplementedException();
        }

        void OpenSetupTutorial()
        {
            throw new NotImplementedException();
        }

        void OpenInspectorTutorial()
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

        public BipedReferences references = new BipedReferences();
        public IKSolverFullBodyBiped solver = new IKSolverFullBodyBiped();
        public void SetReferences(BipedReferences references, Transform rootNode)
        {
            throw new NotImplementedException();
        }

        public override IKSolver GetIKSolver()
        {
            throw new NotImplementedException();
        }

        public bool ReferencesError(ref string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool ReferencesWarning(ref string warningMessage)
        {
            throw new NotImplementedException();
        }

        void Reinitiate()
        {
            throw new NotImplementedException();
        }

        void AutoDetectReferences()
        {
            throw new NotImplementedException();
        }
    }
}