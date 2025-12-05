using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class Constraints
    {
        public Transform transform;
        public Transform target;
        public Vector3 positionOffset;
        public Vector3 position;
        public float positionWeight;
        public Vector3 rotationOffset;
        public Vector3 rotation;
        public float rotationWeight;
        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public void Initiate(Transform transform)
        {
            throw new NotImplementedException();
        }

        public void FixTransforms()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}