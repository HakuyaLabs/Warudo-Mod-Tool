using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class IKMappingBone : IKMapping
    {
        public Transform bone;
        public float maintainRotationWeight = 1f;
        public override bool IsValid(IKSolver solver, ref string message)
        {
            throw new NotImplementedException();
        }

        public IKMappingBone()
        {
            throw new NotImplementedException();
        }

        public IKMappingBone(Transform bone)
        {
            throw new NotImplementedException();
        }

        public void StoreDefaultLocalState()
        {
            throw new NotImplementedException();
        }

        public void FixTransforms()
        {
            throw new NotImplementedException();
        }

        public override void Initiate(IKSolverFullBody solver)
        {
            throw new NotImplementedException();
        }

        public void ReadPose()
        {
            throw new NotImplementedException();
        }

        public void WritePose(float solverWeight)
        {
            throw new NotImplementedException();
        }
    }
}