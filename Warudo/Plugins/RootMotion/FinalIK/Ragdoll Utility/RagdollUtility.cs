using UnityEngine;
using System.Collections;
using RootMotion.FinalIK;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class RagdollUtility : MonoBehaviour
    {
        public IK ik;
        public float ragdollToAnimationTime = 0.2f;
        public bool applyIkOnRagdoll;
        public float applyVelocity = 1f;
        public float applyAngularVelocity = 1f;
        public void EnableRagdoll()
        {
            throw new NotImplementedException();
        }

        public void DisableRagdoll()
        {
            throw new NotImplementedException();
        }

        public class Rigidbone
        {
            public Rigidbody r;
            public Transform t;
            public Collider collider;
            public Joint joint;
            public Rigidbody c;
            public bool updateAnchor;
            public Vector3 deltaPosition;
            public Quaternion deltaRotation;
            public float deltaTime;
            public Vector3 lastPosition;
            public Quaternion lastRotation;
            public Rigidbone(Rigidbody r)
            {
                throw new NotImplementedException();
            }

            public void RecordVelocity()
            {
                throw new NotImplementedException();
            }

            public void WakeUp(float velocityWeight, float angularVelocityWeight)
            {
                throw new NotImplementedException();
            }
        }

        public class Child
        {
            public Transform t;
            public Vector3 localPosition;
            public Quaternion localRotation;
            public Child(Transform transform)
            {
                throw new NotImplementedException();
            }

            public void FixTransform(float weight)
            {
                throw new NotImplementedException();
            }

            public void StoreLocalState()
            {
                throw new NotImplementedException();
            }
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void FixedUpdate()
        {
            throw new NotImplementedException();
        }

        public void LateUpdate()
        {
            throw new NotImplementedException();
        }

        void OnDestroy()
        {
            throw new NotImplementedException();
        }
    }
}