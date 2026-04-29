using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public partial class Grounding
    {
        public enum Quality
        {
            Fastest,
            Simple,
            Best
        }

        public LayerMask layers;
        public float maxStep = 0.5f;
        public float heightOffset;
        public float footSpeed = 2.5f;
        public float footRadius = 0.15f;
        public float footCenterOffset;
        public float prediction = 0.05f;
        public float footRotationWeight = 1f;
        public float footRotationSpeed = 7f;
        public float maxFootRotationAngle = 45f;
        public bool rotateSolver;
        public float pelvisSpeed = 5f;
        public float pelvisDamper;
        public float lowerPelvisWeight = 1f;
        public float liftPelvisWeight;
        public float rootSphereCastRadius = 0.1f;
        public bool overstepFallsDown = true;
        public Quality quality = Quality.Best;
        public Leg[] legs { get; private set; }

        public Pelvis pelvis { get; private set; }

        public bool isGrounded { get; private set; }

        public Transform root { get; private set; }

        public RaycastHit rootHit { get; private set; }

        public bool rootGrounded
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public RaycastHit GetRootHit(float maxDistanceMlp = 10f)
        {
            throw new NotImplementedException();
        }

        public bool IsValid(ref string errorMessage)
        {
            throw new NotImplementedException();
        }

        public void Initiate(Transform root, Transform[] feet)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public Vector3 GetLegsPlaneNormal()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string message)
        {
            throw new NotImplementedException();
        }

        public Vector3 up
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public float GetVerticalOffset(Vector3 p1, Vector3 p2)
        {
            throw new NotImplementedException();
        }

        public Vector3 Flatten(Vector3 v)
        {
            throw new NotImplementedException();
        }

        public Vector3 GetFootCenterOffset()
        {
            throw new NotImplementedException();
        }
    }
}