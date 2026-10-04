using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class IKConstraintBend
    {
        public Transform bone1;
        public Transform bone2;
        public Transform bone3;
        public Transform bendGoal;
        public Vector3 direction = Vector3.right;
        public Quaternion rotationOffset;
        public float weight = 0f;
        public bool IsValid(IKSolverFullBody solver, Warning.Logger logger)
        {
            throw new NotImplementedException();
        }

        public Vector3 defaultLocalDirection, defaultChildDirection;
        public float clampF = 0.505f;
        public bool initiated { get; private set; }

        public IKConstraintBend()
        {
            throw new NotImplementedException();
        }

        public IKConstraintBend(Transform bone1, Transform bone2, Transform bone3)
        {
            throw new NotImplementedException();
        }

        public void SetBones(Transform bone1, Transform bone2, Transform bone3)
        {
            throw new NotImplementedException();
        }

        public void Initiate(IKSolverFullBody solver)
        {
            throw new NotImplementedException();
        }

        public void SetLimbOrientation(Vector3 upper, Vector3 lower, Vector3 last)
        {
            throw new NotImplementedException();
        }

        public void LimitBend(float solverWeight, float positionWeight)
        {
            throw new NotImplementedException();
        }

        public Vector3 GetDir(IKSolverFullBody solver)
        {
            throw new NotImplementedException();
        }
    }
}