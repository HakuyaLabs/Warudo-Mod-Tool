using UnityEngine;
using Event = Warudo.Core.Events.Event;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Events
{
    public class TriggerEnteredEvent : Event
    {
        public Collider SenderCollider { get; private set; }

        public Collider ReceiverCollider { get; private set; }

        public string ReceiverName { get; private set; }

        public TriggerEnteredEvent(Collider senderCollider, Collider receiverCollider, string receiverName)
        {
            throw new NotImplementedException();
        }
    }
}