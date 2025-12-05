using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public partial class Grounding
    {
        public class Leg
        {
            public bool isGrounded { get; private set; }

            public Vector3 IKPosition { get; private set; }

            public Quaternion rotationOffset = Quaternion.identity;
            public bool initiated { get; private set; }

            public float heightFromGround { get; private set; }

            public Vector3 velocity { get; private set; }

            public Transform transform { get; private set; }

            public float IKOffset { get; private set; }

            public bool invertFootCenter;
            public RaycastHit heelHit { get; private set; }

            public RaycastHit capsuleHit { get; private set; }

            public RaycastHit GetHitPoint
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public void SetFootPosition(Vector3 position)
            {
                throw new NotImplementedException();
            }

            public void Initiate(Grounding grounding, Transform transform)
            {
                throw new NotImplementedException();
            }

            public void OnEnable()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public void Process()
            {
                throw new NotImplementedException();
            }

            public float stepHeightFromGround
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}