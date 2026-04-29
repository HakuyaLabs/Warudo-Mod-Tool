using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class ParticleCollisionHandler : MonoBehaviour
    {
        public LayerMask ragdollLayers;
        public float unpin = 0.02f;
    }
}