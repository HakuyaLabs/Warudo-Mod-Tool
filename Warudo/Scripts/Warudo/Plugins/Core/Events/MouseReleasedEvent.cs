using Warudo.Core.Events;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Events
{
    public class MouseReleasedEvent : Event
    {
        public MouseButton Button { get; set; }

        public MouseReleasedEvent(MouseButton button)
        {
            throw new NotImplementedException();
        }
    }
}