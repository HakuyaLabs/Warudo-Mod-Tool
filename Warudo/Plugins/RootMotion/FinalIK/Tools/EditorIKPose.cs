using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class EditorIKPose : ScriptableObject
    {
        public Vector3[] localPositions = new Vector3[0];
        public Quaternion[] localRotations = new Quaternion[0];
        public bool poseStored
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Store(Transform[] T)
        {
            throw new NotImplementedException();
        }

        public bool Restore(Transform[] T)
        {
            throw new NotImplementedException();
        }
    }
}