using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public class TriggerEventBroadcaster : MonoBehaviour
    {
        public GameObject target;
        void OnTriggerEnter(Collider collider)
        {
            throw new NotImplementedException();
        }

        void OnTriggerStay(Collider collider)
        {
            throw new NotImplementedException();
        }

        void OnTriggerExit(Collider collider)
        {
            throw new NotImplementedException();
        }
    }
}