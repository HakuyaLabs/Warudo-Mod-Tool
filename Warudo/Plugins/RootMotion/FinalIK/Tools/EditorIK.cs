using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class EditorIK : MonoBehaviour
    {
        public Animator animator;
        public EditorIKPose defaultPose;
        public Transform[] bones = new Transform[0];
        public IK ik { get; private set; }

        public void StoreDefaultPose()
        {
            throw new NotImplementedException();
        }

        public bool Initiate()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}