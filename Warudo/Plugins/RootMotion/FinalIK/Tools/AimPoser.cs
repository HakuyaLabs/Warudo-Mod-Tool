using UnityEngine;
using System.Collections;
using RootMotion;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class AimPoser : MonoBehaviour
    {
        public class Pose
        {
            public bool visualize = true;
            public string name;
            public Vector3 direction;
            public float yaw = 75f;
            public float pitch = 45f;
            public bool IsInDirection(Vector3 d)
            {
                throw new NotImplementedException();
            }

            public void SetAngleBuffer(float value)
            {
                throw new NotImplementedException();
            }
        }

        public float angleBuffer = 5f;
        public Pose[] poses = new Pose[0];
        public Pose GetPose(Vector3 localDirection)
        {
            throw new NotImplementedException();
        }

        public void SetPoseActive(Pose pose)
        {
            throw new NotImplementedException();
        }
    }
}