using System;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Utils
{
    public class ReceiveTriggerEventsBehavior : MonoBehaviour
    {
        public Action<Collider> CollisionEnter { get; set; }

        public Action<Collider> CollisionStay { get; set; }

        public Action<Collider> CollisionExit { get; set; }
    }
}