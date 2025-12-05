using UnityEngine;
using System.Collections;
using RootMotion;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public abstract class Prop : MonoBehaviour
    {
        public int propType;
        public ConfigurableJoint muscle;
        public Muscle.Props muscleProps = new Muscle.Props();
        public bool forceLayers = true;
        public ConfigurableJoint additionalPin;
        public Transform additionalPinTarget;
        public float additionalPinWeight = 1f;
        public PhysicMaterial pickedUpMaterial;
        public PhysicMaterial droppedMaterial;
        public bool isPickedUp
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public PropRoot propRoot { get; private set; }

        public void PickUp(PropRoot propRoot)
        {
            throw new NotImplementedException();
        }

        public void Drop()
        {
            throw new NotImplementedException();
        }

        public void StartPickedUp(PropRoot propRoot)
        {
            throw new NotImplementedException();
        }

        public bool initiated { get; private set; }

        protected virtual void OnPickUp(PropRoot propRoot)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnDrop()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnStart()
        {
            throw new NotImplementedException();
        }

        void Start()
        {
            throw new NotImplementedException();
        }

        void OnDrawGizmos()
        {
            throw new NotImplementedException();
        }
    }
}