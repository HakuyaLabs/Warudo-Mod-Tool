using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class BipedIK : SolverManager
    {
        void SupportGroup()
        {
            throw new NotImplementedException();
        }

        void ASThread()
        {
            throw new NotImplementedException();
        }

        public BipedReferences references = new BipedReferences();
        public BipedIKSolvers solvers = new BipedIKSolvers();
        public float GetIKPositionWeight(AvatarIKGoal goal)
        {
            throw new NotImplementedException();
        }

        public float GetIKRotationWeight(AvatarIKGoal goal)
        {
            throw new NotImplementedException();
        }

        public void SetIKPositionWeight(AvatarIKGoal goal, float weight)
        {
            throw new NotImplementedException();
        }

        public void SetIKRotationWeight(AvatarIKGoal goal, float weight)
        {
            throw new NotImplementedException();
        }

        public void SetIKPosition(AvatarIKGoal goal, Vector3 IKPosition)
        {
            throw new NotImplementedException();
        }

        public void SetIKRotation(AvatarIKGoal goal, Quaternion IKRotation)
        {
            throw new NotImplementedException();
        }

        public Vector3 GetIKPosition(AvatarIKGoal goal)
        {
            throw new NotImplementedException();
        }

        public Quaternion GetIKRotation(AvatarIKGoal goal)
        {
            throw new NotImplementedException();
        }

        public void SetLookAtWeight(float weight, float bodyWeight, float headWeight, float eyesWeight, float clampWeight, float clampWeightHead, float clampWeightEyes)
        {
            throw new NotImplementedException();
        }

        public void SetLookAtPosition(Vector3 lookAtPosition)
        {
            throw new NotImplementedException();
        }

        public void SetSpinePosition(Vector3 spinePosition)
        {
            throw new NotImplementedException();
        }

        public void SetSpineWeight(float weight)
        {
            throw new NotImplementedException();
        }

        public IKSolverLimb GetGoalIK(AvatarIKGoal goal)
        {
            throw new NotImplementedException();
        }

        public void InitiateBipedIK()
        {
            throw new NotImplementedException();
        }

        public void UpdateBipedIK()
        {
            throw new NotImplementedException();
        }

        public void SetToDefaults()
        {
            throw new NotImplementedException();
        }

        protected override void FixTransforms()
        {
            throw new NotImplementedException();
        }

        protected override void InitiateSolver()
        {
            throw new NotImplementedException();
        }

        protected override void UpdateSolver()
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string message)
        {
            throw new NotImplementedException();
        }
    }
}