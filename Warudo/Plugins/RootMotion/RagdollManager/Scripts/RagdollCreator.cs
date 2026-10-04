using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public abstract class RagdollCreator : MonoBehaviour
    {
        public enum ColliderType
        {
            Box,
            Capsule
        }

        public enum JointType
        {
            Configurable,
            Character
        }

        public enum Direction
        {
            X = 0,
            Y = 1,
            Z = 2
        }

        public struct CreateJointParams
        {
            public Rigidbody rigidbody;
            public Rigidbody connectedBody;
            public Transform child;
            public Vector3 worldSwingAxis;
            public Limits limits;
            public JointType type;
            public struct Limits
            {
                public float minSwing;
                public float maxSwing;
                public float swing2;
                public float twist;
                public Limits(float minSwing, float maxSwing, float swing2, float twist)
                {
                    throw new NotImplementedException();
                }
            }

            public CreateJointParams(Rigidbody rigidbody, Rigidbody connectedBody, Transform child, Vector3 worldSwingAxis, Limits limits, JointType type)
            {
                throw new NotImplementedException();
            }
        }

        public static void ClearAll(Transform root)
        {
            throw new NotImplementedException();
        }

        protected static void ClearTransform(Transform transform)
        {
            throw new NotImplementedException();
        }

        protected static void CreateCollider(Transform t, Vector3 startPoint, Vector3 endPoint, ColliderType colliderType, float lengthOverlap, float width)
        {
            throw new NotImplementedException();
        }

        protected static void CreateCollider(Transform t, Vector3 startPoint, Vector3 endPoint, ColliderType colliderType, float lengthOverlap, float width, float proportionAspect, Vector3 widthDirection)
        {
            throw new NotImplementedException();
        }

        protected static float GetScaleF(Transform t)
        {
            throw new NotImplementedException();
        }

        protected static Vector3 Abs(Vector3 v)
        {
            throw new NotImplementedException();
        }

        protected static void Vector3Abs(ref Vector3 v)
        {
            throw new NotImplementedException();
        }

        protected static Vector3 DirectionIntToVector3(int dir)
        {
            throw new NotImplementedException();
        }

        protected static Vector3 DirectionToVector3(Direction dir)
        {
            throw new NotImplementedException();
        }

        protected static int DirectionVector3ToInt(Vector3 dir)
        {
            throw new NotImplementedException();
        }

        protected static Vector3 GetLocalOrthoDirection(Transform transform, Vector3 worldDir)
        {
            throw new NotImplementedException();
        }

        protected static Rigidbody GetConnectedBody(Transform bone, ref Transform[] bones)
        {
            throw new NotImplementedException();
        }

        protected static void CreateJoint(CreateJointParams p)
        {
            throw new NotImplementedException();
        }
    }
}