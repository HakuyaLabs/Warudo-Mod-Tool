using UnityEngine;
using System.Collections;
using RootMotion.Dynamics;
using RootMotion;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class PuppetMasterProp : MonoBehaviour
    {
        public Transform meshRoot;
        public Muscle.Props muscleProps;
        public bool forceLayers = true;
        public float mass = 1f;
        public int propType;
        public PhysicMaterial pickedUpMaterial;
        public Vector3 additionalPinOffsetAdd;
        public float additionalPinWeight = 1f;
        public float additionalPinMass = 1f;
        public bool isPickedUp { get; private set; }

        public Rigidbody GetRigidbody()
        {
            throw new NotImplementedException();
        }

        public Vector3 inertiaTensor { get; private set; }

        public Vector3 localCenterOfMass { get; private set; }

        protected virtual void OnPickUp(PuppetMaster puppetMaster, int propMuscleIndex)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnDrop(PuppetMaster puppetMaster, int propMuscleIndex)
        {
            throw new NotImplementedException();
        }

        protected Muscle propMuscle { get; private set; }

        public void PickUp(PuppetMaster puppetMaster, int propMuscleIndex)
        {
            throw new NotImplementedException();
        }

        public void Drop(PuppetMaster puppetMaster, int propMuscleIndex)
        {
            throw new NotImplementedException();
        }

        protected virtual void Awake()
        {
            throw new NotImplementedException();
        }

        protected virtual void Start()
        {
            throw new NotImplementedException();
        }

        protected virtual void Update()
        {
            throw new NotImplementedException();
        }

        void OnDrawGizmosSelected()
        {
            throw new NotImplementedException();
        }
    }
}