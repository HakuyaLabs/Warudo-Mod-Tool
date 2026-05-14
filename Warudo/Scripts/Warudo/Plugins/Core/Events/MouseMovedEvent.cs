using UnityEngine;
using Event = Warudo.Core.Events.Event;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Events
{
    public class MouseMovedEvent : Event
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Vector2 RelativePosition { get; set; }

        public MouseMovedEvent(int x, int y, Vector2 relativePosition)
        {
            throw new NotImplementedException();
        }
    }
}