using UnityEngine;
using System.Collections;
using RootMotion.FinalIK;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class PenetrationAvoidance : OffsetModifier
    {
        public class Avoider
        {
            public class EffectorLink
            {
                public FullBodyBipedEffector effector;
                public float weight;
            }

            public Transform[] raycastFrom;
            public Transform raycastTo;
            public float raycastRadius;
            public EffectorLink[] effectors;
            public float smoothTimeIn = 0.1f;
            public float smoothTimeOut = 0.3f;
            public LayerMask layers;
            public void Solve(IKSolverFullBodyBiped solver, float weight)
            {
                throw new NotImplementedException();
            }
        }

        public Avoider[] avoiders;
        protected override void OnModifyOffset()
        {
            throw new NotImplementedException();
        }
    }
}