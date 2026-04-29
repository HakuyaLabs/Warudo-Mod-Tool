using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class PuppetControllerLite : MonoBehaviour, ICollisionEventListener
    {
        public class Group
        {
            public string name;
            public int[] indices = new int[0];
            public float pinWeightMlp = 0.5f;
            public float muscleWeightMlp = 0.5f;
            public float drag = 2f;
            public float blendInTime = 0.05f;
            public float blendOutTime = 1f;
            public bool enabled { get; private set; }

            public float mappingWeight { get; private set; }

            public void TryDamage(Collision collision, CollisionEventBroadcaster broadcaster)
            {
                throw new NotImplementedException();
            }

            public void Update(PuppetMasterLite puppetMaster)
            {
                throw new NotImplementedException();
            }
        }

        public PuppetMasterLite puppetMaster;
        public LayerMask collisionLayers;
        public Group[] groups = new Group[0];
        void Start()
        {
            throw new NotImplementedException();
        }

        void FixedUpdate()
        {
            throw new NotImplementedException();
        }

        public void OnCollisionEnterEvent(Collision collision, CollisionEventBroadcaster broadcaster)
        {
            throw new NotImplementedException();
        }

        public void OnCollisionStayEvent(Collision collision, CollisionEventBroadcaster broadcaster)
        {
            throw new NotImplementedException();
        }

        public void OnCollisionExitEvent(Collision collision, CollisionEventBroadcaster broadcaster)
        {
            throw new NotImplementedException();
        }
    }
}