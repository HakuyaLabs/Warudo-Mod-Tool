using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class Amplifier : OffsetModifier
    {
        public class Body
        {
            public class EffectorLink
            {
                public FullBodyBipedEffector effector;
                public float weight;
            }

            public Transform transform;
            public Transform relativeTo;
            public EffectorLink[] effectorLinks;
            public float verticalWeight = 1f;
            public float horizontalWeight = 1f;
            public float speed = 3f;
            public void Update(IKSolverFullBodyBiped solver, float w, float deltaTime)
            {
                throw new NotImplementedException();
            }
        }

        public Body[] bodies;
        protected override void OnModifyOffset()
        {
            throw new NotImplementedException();
        }
    }
}