using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class SubBehaviourBalancer : SubBehaviourBase
    {
        public class Settings
        {
            public float damperForSpring = 1f;
            public float maxForceMlp = 0.05f;
            public float IMlp = 1f;
            public float velocityF = 0.5f;
            public Vector3 copOffset;
            public float torqueMlp = 0f;
            public float maxTorqueMag = 45f;
        }

        public ConfigurableJoint joint { get; private set; }

        public Vector3 dir { get; private set; }

        public Vector3 dirVel { get; private set; }

        public Vector3 cop { get; private set; }

        public Vector3 com { get; private set; }

        public Vector3 comV { get; private set; }

        public void Initiate(BehaviourBase behaviour, Settings settings, Rigidbody Ibody, Rigidbody[] rigidbodies, ConfigurableJoint joint, Transform[] copPoints, PressureSensor pressureSensor)
        {
            throw new NotImplementedException();
        }

        void Solve(float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}