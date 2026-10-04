using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class RigidbodyController : MonoBehaviour
    {
        public Transform target;
        public float forceWeight = 1f;
        public float torqueWeight = 1f;
        public bool useTargetVelocity = true;
        public void OnTargetTeleported()
        {
            throw new NotImplementedException();
        }
    }
}