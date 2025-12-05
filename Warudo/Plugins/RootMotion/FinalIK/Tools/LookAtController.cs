using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class LookAtController : MonoBehaviour
    {
        public LookAtIK ik;
        public Transform target;
        public float weight = 1f;
        public Vector3 offset;
        public float targetSwitchSmoothTime = 0.3f;
        public float weightSmoothTime = 0.3f;
        public bool smoothTurnTowardsTarget = true;
        public float maxRadiansDelta = 3f;
        public float maxMagnitudeDelta = 3f;
        public float slerpSpeed = 3f;
        public Vector3 pivotOffsetFromRoot = Vector3.up;
        public float minDistance = 1f;
        public float maxRootAngle = 45f;
        void Start()
        {
            throw new NotImplementedException();
        }

        void LateUpdate()
        {
            throw new NotImplementedException();
        }

        void ApplyMinDistance()
        {
            throw new NotImplementedException();
        }
    }
}