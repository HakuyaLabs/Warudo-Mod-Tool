using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class MuscleLite
    {
        public string name;
        public ConfigurableJoint joint;
        public Transform target;
        public float pinWeightMlp = 1f;
        public float muscleWeightMlp = 1f;
        public float muscleDamperMlp = 1f;
        public float mappingWeightMlp = 1f;
        public Transform transform { get; private set; }

        public Rigidbody rigidbody { get; private set; }

        public Vector3 positionOffset { get; private set; }

        public int index { get; private set; }

        public void Initiate(MuscleLite[] colleagues)
        {
            throw new NotImplementedException();
        }

        public void FixTargetTransforms()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void MoveToTarget()
        {
            throw new NotImplementedException();
        }

        public void ClearVelocities()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update(float pinWeightMaster, float muscleWeightMaster, float muscleSpring, float muscleDamper, bool angularPinning)
        {
            throw new NotImplementedException();
        }

        public void Map(float masterWeight)
        {
            throw new NotImplementedException();
        }

        public void UpdateAnchor(bool supportTranslationAnimation)
        {
            throw new NotImplementedException();
        }
    }
}