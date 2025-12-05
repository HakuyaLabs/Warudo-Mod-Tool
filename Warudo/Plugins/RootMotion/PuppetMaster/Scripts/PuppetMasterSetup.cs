using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public partial class PuppetMaster : MonoBehaviour
    {
        public static PuppetMaster SetUp(Transform target, Transform ragdoll, int characterControllerLayer, int ragdollLayer)
        {
            throw new NotImplementedException();
        }

        public static PuppetMaster SetUp(Transform target, int characterControllerLayer, int ragdollLayer)
        {
            throw new NotImplementedException();
        }

        public void SetUpTo(Transform setUpTo, int characterControllerLayer, int ragdollLayer)
        {
            throw new NotImplementedException();
        }

        public static void RemoveRagdollComponents(Transform target, int characterControllerLayer)
        {
            throw new NotImplementedException();
        }
    }
}