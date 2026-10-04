using UnityEngine;
using Warudo.Plugins.Core.Events;

namespace Warudo.Plugins.ProceduralAnimations.Behaviors {
    public class KeyboardKeyInfo : MonoBehaviour {

        public Keystroke keystroke;
        public Finger preferredFinger;

    }

    public enum Finger {
        LeftThumb,
        LeftIndex,
        LeftMiddle,
        LeftRing,
        LeftLittle,
        RightThumb,
        RightIndex,
        RightMiddle,
        RightRing,
        RightLittle
    }
}
