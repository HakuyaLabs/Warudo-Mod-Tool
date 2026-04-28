using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class JointBreakBroadcaster : MonoBehaviour
    {
        public PuppetMaster puppetMaster;
        public int muscleIndex;
        void OnJointBreak()
        {
            throw new NotImplementedException();
        }
    }
}