using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class AimController : MonoBehaviour
    {
        public AimIK ik;
        public float weight = 1f;
        public Transform target;
        public float targetSwitchSmoothTime = 0.3f;
        public float weightSmoothTime = 0.3f;
        public bool smoothTurnTowardsTarget = true;
        public float maxRadiansDelta = 3f;
        public float maxMagnitudeDelta = 3f;
        public float slerpSpeed = 3f;
        public float smoothDampTime = 0f;
        public Vector3 pivotOffsetFromRoot = Vector3.up;
        public float minDistance = 1f;
        public Vector3 offset;
        public float maxRootAngle = 45f;
        public bool turnToTarget;
        public float turnToTargetTime = 0.2f;
        public bool useAnimatedAimDirection;
        public Vector3 animatedAimDirection = Vector3.forward;
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