using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class Inertia : OffsetModifier
    {
        public class Body
        {
            public class EffectorLink
            {
                public FullBodyBipedEffector effector;
                public float weight;
            }

            public Transform transform;
            public EffectorLink[] effectorLinks;
            public float speed = 10f;
            public float acceleration = 3f;
            public float matchVelocity;
            public float gravity;
            public void Reset()
            {
                throw new NotImplementedException();
            }

            public void Update(IKSolverFullBodyBiped solver, float weight, float deltaTime)
            {
                throw new NotImplementedException();
            }
        }

        public Body[] bodies;
        public OffsetLimits[] limits;
        public void ResetBodies()
        {
            throw new NotImplementedException();
        }

        protected override void OnModifyOffset()
        {
            throw new NotImplementedException();
        }
    }
}