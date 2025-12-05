using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public static class PhysXTools
    {
        public static void Predict(Rigidbody r, int steps, out Vector3 position, out Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        public static void Predict(Rigidbody r, int steps, out Vector3 position, out Quaternion rotation, Vector3 gravity, float drag, float angularDrag)
        {
            throw new NotImplementedException();
        }

        public static void Predict(ref Vector3 position, ref Quaternion rotation, ref Vector3 velocity, ref Vector3 angularVelocity, Vector3 gravity, float drag, float angularDrag)
        {
            throw new NotImplementedException();
        }

        public static Vector3 GetCenterOfMass(PuppetMaster puppet)
        {
            throw new NotImplementedException();
        }

        public static Vector3 GetCenterOfMass(Rigidbody[] rigidbodies)
        {
            throw new NotImplementedException();
        }

        public static Vector3 GetCenterOfMassVelocity(Rigidbody[] rigidbodies)
        {
            throw new NotImplementedException();
        }

        public static void DivByInertia(ref Vector3 v, Quaternion rotation, Vector3 inertiaTensor)
        {
            throw new NotImplementedException();
        }

        public static void ScaleByInertia(ref Vector3 v, Quaternion rotation, Vector3 inertiaTensor)
        {
            throw new NotImplementedException();
        }

        public static Vector3 GetAngularVelocity(Quaternion lastRotation, Quaternion rotation, float deltaTime)
        {
            throw new NotImplementedException();
        }

        public static Vector3 GetFromToAcceleration(Vector3 fromV, Vector3 toV)
        {
            throw new NotImplementedException();
        }

        public static Vector3 GetAngularAcceleration(Quaternion fromR, Quaternion toR)
        {
            throw new NotImplementedException();
        }

        public static void AddFromToTorque(Rigidbody r, Quaternion toR, ForceMode forceMode)
        {
            throw new NotImplementedException();
        }

        public static void AddFromToTorque(Rigidbody r, Vector3 fromV, Vector3 toV, ForceMode forceMode)
        {
            throw new NotImplementedException();
        }

        public static void AddFromToForce(Rigidbody r, Vector3 fromV, Vector3 toV, ForceMode forceMode)
        {
            throw new NotImplementedException();
        }

        public static Vector3 GetLinearAcceleration(Vector3 fromPoint, Vector3 toPoint)
        {
            throw new NotImplementedException();
        }

        public static Quaternion ToJointSpace(ConfigurableJoint joint)
        {
            throw new NotImplementedException();
        }

        public static Vector3 CalculateInertiaTensorCuboid(Vector3 size, float mass)
        {
            throw new NotImplementedException();
        }

        public static Vector3 Div(Vector3 v, Vector3 v2)
        {
            throw new NotImplementedException();
        }

        public static bool RayCapsuleIntersectUnscaled(Vector3 origin, Vector3 direction, CapsuleCollider capsule)
        {
            throw new NotImplementedException();
        }

        public static bool RayCapsuleIntersect(Vector3 origin, Vector3 direction, CapsuleCollider capsule, float uniformScale)
        {
            throw new NotImplementedException();
        }

        public static bool RayCapsuleIntersect(Vector3 origin, Vector3 direction, Vector3 capsuleTransformPos, Quaternion capsuleTransformRot, Vector3 capsuleCenter, float capsuleRadius, float capsuleHeight, int capsuleDir, float scale)
        {
            throw new NotImplementedException();
        }

        public static bool RayCapsuleIntersect(Vector3 rayOrigin, Vector3 rayDir, Vector3 c1, Vector3 c2, float cRadius)
        {
            throw new NotImplementedException();
        }
    }
}