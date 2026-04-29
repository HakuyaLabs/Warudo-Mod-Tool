using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class IKMappingSpine : IKMapping
    {
        public Transform[] spineBones;
        public Transform leftUpperArmBone;
        public Transform rightUpperArmBone;
        public Transform leftThighBone;
        public Transform rightThighBone;
        public int iterations = 3;
        public float twistWeight = 1f;
        public override bool IsValid(IKSolver solver, ref string message)
        {
            throw new NotImplementedException();
        }

        public IKMappingSpine()
        {
            throw new NotImplementedException();
        }

        public IKMappingSpine(Transform[] spineBones, Transform leftUpperArmBone, Transform rightUpperArmBone, Transform leftThighBone, Transform rightThighBone)
        {
            throw new NotImplementedException();
        }

        public void SetBones(Transform[] spineBones, Transform leftUpperArmBone, Transform rightUpperArmBone, Transform leftThighBone, Transform rightThighBone)
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

        public void WritePose(IKSolverFullBody solver)
        {
            throw new NotImplementedException();
        }

        public void ForwardReach(Vector3 position)
        {
            throw new NotImplementedException();
        }
    }
}