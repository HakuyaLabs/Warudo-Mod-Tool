using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class IKSolverLimb : IKSolverTrigonometric
    {
        public AvatarIKGoal goal;
        public BendModifier bendModifier;
        public float maintainRotationWeight;
        public float bendModifierWeight = 1f;
        public Transform bendGoal;
        public void MaintainRotation()
        {
            throw new NotImplementedException();
        }

        public void MaintainBend()
        {
            throw new NotImplementedException();
        }

        public enum BendModifier
        {
            Animation,
            Target,
            Parent,
            Arm,
            Goal
        }

        protected override void OnInitiateVirtual()
        {
            throw new NotImplementedException();
        }

        protected override void OnUpdateVirtual()
        {
            throw new NotImplementedException();
        }

        protected override void OnPostSolveVirtual()
        {
            throw new NotImplementedException();
        }

        public struct AxisDirection
        {
            public Vector3 direction;
            public Vector3 axis;
            public float dot;
            public AxisDirection(Vector3 direction, Vector3 axis)
            {
                throw new NotImplementedException();
            }
        }

        public IKSolverLimb()
        {
            throw new NotImplementedException();
        }

        public IKSolverLimb(AvatarIKGoal goal)
        {
            throw new NotImplementedException();
        }
    }
}