using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class IKSolverAim : IKSolverHeuristic
    {
        public Transform transform;
        public Vector3 axis = Vector3.forward;
        public Vector3 poleAxis = Vector3.up;
        public Vector3 polePosition;
        public float poleWeight;
        public Transform poleTarget;
        public float clampWeight = 0.1f;
        public int clampSmoothing = 2;
        public float GetAngle()
        {
            throw new NotImplementedException();
        }

        public Vector3 transformAxis
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Vector3 transformPoleAxis
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IterationDelegate OnPreIteration;
        protected override void OnInitiate()
        {
            throw new NotImplementedException();
        }

        protected override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        protected override int minBones
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override Vector3 localDirection
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}