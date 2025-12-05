using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public struct MuscleCollision
    {
        public int muscleIndex;
        public Collision collision;
        public bool isStay;
        public MuscleCollision(int muscleIndex, Collision collision, bool isStay = false)
        {
            throw new NotImplementedException();
        }
    }

    public struct MuscleHit
    {
        public int muscleIndex;
        public float unPin;
        public Vector3 force;
        public Vector3 position;
        public MuscleHit(int muscleIndex, float unPin, Vector3 force, Vector3 position)
        {
            throw new NotImplementedException();
        }
    }

    public class MuscleCollisionBroadcaster : MonoBehaviour
    {
        public PuppetMaster puppetMaster;
        public int muscleIndex;
        public void Hit(float unPin, Vector3 force, Vector3 position)
        {
            throw new NotImplementedException();
        }

        void OnCollisionEnter(Collision collision)
        {
            throw new NotImplementedException();
        }

        void OnCollisionStay(Collision collision)
        {
            throw new NotImplementedException();
        }

        void OnCollisionExit(Collision collision)
        {
            throw new NotImplementedException();
        }
    }
}