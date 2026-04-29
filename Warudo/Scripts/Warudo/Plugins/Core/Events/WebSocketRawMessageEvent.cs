using Warudo.Core.Events;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Events
{
    public class WebSocketRawMessageEvent : Event
    {
        public string RawMessage { get; }

        public WebSocketRawMessageEvent(string rawMessage)
        {
            throw new NotImplementedException();
        }
    }
}