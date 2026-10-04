using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class SubBehaviourCOM : SubBehaviourBase
    {
        public enum Mode
        {
            FeetCentroid,
            CenterOfPressure
        }

        public Mode mode;
        public float velocityDamper = 1f;
        public float velocityLerpSpeed = 5f;
        public float velocityMax = 1f;
        public float centerOfPressureSpeed = 5f;
        public Vector3 offset;
        public Vector3 position { get; private set; }

        public Vector3 direction { get; private set; }

        public float angle { get; private set; }

        public Vector3 velocity { get; private set; }

        public Vector3 centerOfPressure { get; private set; }

        public Quaternion rotation { get; private set; }

        public Quaternion inverseRotation { get; private set; }

        public bool isGrounded { get; private set; }

        public float lastGroundedTime { get; private set; }

        public bool[] groundContacts;
        public Vector3[] groundContactPoints;
        public void Initiate(BehaviourBase behaviour, LayerMask groundLayers)
        {
            throw new NotImplementedException();
        }
    }
}