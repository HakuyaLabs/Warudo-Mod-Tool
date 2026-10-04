using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class PressureSensor : MonoBehaviour
    {
        public bool visualize;
        public LayerMask layers;
        public Vector3 center { get; private set; }

        public bool inContact { get; private set; }

        public Vector3 bottom { get; private set; }

        public Rigidbody r { get; private set; }

        void Awake()
        {
            throw new NotImplementedException();
        }

        void OnCollisionEnter(Collision c)
        {
            throw new NotImplementedException();
        }

        void OnCollisionStay(Collision c)
        {
            throw new NotImplementedException();
        }

        void OnCollisionExit(Collision c)
        {
            throw new NotImplementedException();
        }

        void FixedUpdate()
        {
            throw new NotImplementedException();
        }

        void LateUpdate()
        {
            throw new NotImplementedException();
        }

        void OnDrawGizmos()
        {
            throw new NotImplementedException();
        }
    }
}