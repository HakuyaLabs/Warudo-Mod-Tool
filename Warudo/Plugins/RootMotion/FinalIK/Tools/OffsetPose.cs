using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class OffsetPose : MonoBehaviour
    {
        public class EffectorLink
        {
            public FullBodyBipedEffector effector;
            public Vector3 offset;
            public Vector3 pin;
            public Vector3 pinWeight;
            public void Apply(IKSolverFullBodyBiped solver, float weight, Quaternion rotation)
            {
                throw new NotImplementedException();
            }
        }

        public EffectorLink[] effectorLinks = new EffectorLink[0];
        public void Apply(IKSolverFullBodyBiped solver, float weight)
        {
            throw new NotImplementedException();
        }

        public void Apply(IKSolverFullBodyBiped solver, float weight, Quaternion rotation)
        {
            throw new NotImplementedException();
        }
    }
}