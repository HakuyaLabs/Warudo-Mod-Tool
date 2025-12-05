using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class PuppetMasterLite : MonoBehaviour
    {
        public Transform targetRoot;
        public bool fixTargetTransforms = true;
        public float blendTime = 0.1f;
        public float mappingWeight = 1f;
        public float pinWeight = 1f;
        public float muscleWeight = 1f;
        public float muscleSpring = 1000f;
        public float muscleDamper = 100f;
        public bool updateJointAnchors = true;
        public bool angularPinning;
        public MuscleLite[] muscles = new MuscleLite[0];
        public delegate void PuppetMasterLiteDelegate();
        public PuppetMasterLiteDelegate OnRead;
        public PuppetMasterLiteDelegate OnWrite;
        public enum UpdateMode
        {
            Normal,
            Fixed
        }

        public void Activate()
        {
            throw new NotImplementedException();
        }

        public void Deactivate()
        {
            throw new NotImplementedException();
        }
    }
}