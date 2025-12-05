using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class IKMappingLimb : IKMapping
    {
        public enum BoneMapType
        {
            Parent,
            Bone1,
            Bone2,
            Bone3
        }

        public Transform parentBone;
        public Transform bone1;
        public Transform bone2;
        public Transform bone3;
        public float maintainRotationWeight;
        public float weight = 1f;
        public bool updatePlaneRotations = true;
        public override bool IsValid(IKSolver solver, ref string message)
        {
            throw new NotImplementedException();
        }

        public BoneMap GetBoneMap(BoneMapType boneMap)
        {
            throw new NotImplementedException();
        }

        public void SetLimbOrientation(Vector3 upper, Vector3 lower)
        {
            throw new NotImplementedException();
        }

        public IKMappingLimb()
        {
            throw new NotImplementedException();
        }

        public IKMappingLimb(Transform bone1, Transform bone2, Transform bone3, Transform parentBone = null)
        {
            throw new NotImplementedException();
        }

        public void SetBones(Transform bone1, Transform bone2, Transform bone3, Transform parentBone = null)
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

        public void WritePose(IKSolverFullBody solver, bool fullBody)
        {
            throw new NotImplementedException();
        }
    }
}