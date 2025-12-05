using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class IKEffector
    {
        public IKSolver.Node GetNode(IKSolverFullBody solver)
        {
            throw new NotImplementedException();
        }

        public Transform bone;
        public Transform target;
        public float positionWeight;
        public float rotationWeight;
        public Vector3 position = Vector3.zero;
        public Quaternion rotation = Quaternion.identity;
        public Vector3 positionOffset;
        public bool isEndEffector { get; private set; }

        public bool effectChildNodes = true;
        public float maintainRelativePositionWeight;
        public void PinToBone(float positionWeight, float rotationWeight)
        {
            throw new NotImplementedException();
        }

        public Transform[] childBones = new Transform[0];
        public Transform planeBone1;
        public Transform planeBone2;
        public Transform planeBone3;
        public Quaternion planeRotationOffset = Quaternion.identity;
        public IKEffector()
        {
            throw new NotImplementedException();
        }

        public IKEffector(Transform bone, Transform[] childBones)
        {
            throw new NotImplementedException();
        }

        public bool IsValid(IKSolver solver, ref string message)
        {
            throw new NotImplementedException();
        }

        public void Initiate(IKSolverFullBody solver)
        {
            throw new NotImplementedException();
        }

        public void ResetOffset(IKSolverFullBody solver)
        {
            throw new NotImplementedException();
        }

        public void SetToTarget()
        {
            throw new NotImplementedException();
        }

        public void OnPreSolve(IKSolverFullBody solver)
        {
            throw new NotImplementedException();
        }

        public void OnPostWrite()
        {
            throw new NotImplementedException();
        }

        public void Update(IKSolverFullBody solver)
        {
            throw new NotImplementedException();
        }
    }
}