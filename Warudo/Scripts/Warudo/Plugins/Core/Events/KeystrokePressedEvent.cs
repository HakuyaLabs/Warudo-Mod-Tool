using Warudo.Core.Events;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Events
{
    public class KeystrokePressedEvent : Event
    {
        public Keystroke Keystroke { get; set; }

        public bool Ctrl { get; set; }

        public bool Shift { get; set; }

        public bool Alt { get; set; }

        public bool Meta { get; set; }

        public KeystrokePressedEvent(Keystroke keystroke, bool ctrl, bool shift, bool alt, bool meta)
        {
            throw new NotImplementedException();
        }
    }
}