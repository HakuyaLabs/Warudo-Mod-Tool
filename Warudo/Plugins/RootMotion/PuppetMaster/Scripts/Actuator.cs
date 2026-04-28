using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class Actuator : MonoBehaviour
    {
        public Transform target;
        public float spring = 1000f;
        public float damper = 100f;
    }
}