using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class InteractionTrigger : MonoBehaviour
    {
        void OpenUserManual()
        {
            throw new NotImplementedException();
        }

        void OpenScriptReference()
        {
            throw new NotImplementedException();
        }

        void OpenTutorial4()
        {
            throw new NotImplementedException();
        }

        void SupportGroup()
        {
            throw new NotImplementedException();
        }

        void ASThread()
        {
            throw new NotImplementedException();
        }

        public class CharacterPosition
        {
            public bool use;
            public Vector2 offset;
            public float angleOffset;
            public float maxAngle = 45f;
            public float radius = 0.5f;
            public bool orbit;
            public bool fixYAxis;
            public Vector3 offset3D
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public Vector3 direction3D
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public bool IsInRange(Transform character, Transform trigger, out float error)
            {
                throw new NotImplementedException();
            }
        }

        public class CameraPosition
        {
            public Collider lookAtTarget;
            public Vector3 direction = -Vector3.forward;
            public float maxDistance = 0.5f;
            public float maxAngle = 45f;
            public bool fixYAxis;
            public Quaternion GetRotation()
            {
                throw new NotImplementedException();
            }

            public bool IsInRange(Transform raycastFrom, RaycastHit hit, Transform trigger, out float error)
            {
                throw new NotImplementedException();
            }
        }

        public class Range
        {
            public string name;
            public bool show = true;
            public class Interaction
            {
                public InteractionObject interactionObject;
                public FullBodyBipedEffector[] effectors;
            }

            public CharacterPosition characterPosition;
            public CameraPosition cameraPosition;
            public Interaction[] interactions;
            public bool IsInRange(Transform character, Transform raycastFrom, RaycastHit raycastHit, Transform trigger, out float maxError)
            {
                throw new NotImplementedException();
            }
        }

        public Range[] ranges = new Range[0];
        public int GetBestRangeIndex(Transform character, Transform raycastFrom, RaycastHit raycastHit)
        {
            throw new NotImplementedException();
        }
    }
}