using Warudo.Core.Events;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Events
{
    public class MousePressedEvent : Event
    {
        public MouseButton Button { get; set; }

        public MousePressedEvent(MouseButton button)
        {
            throw new NotImplementedException();
        }
    }
}