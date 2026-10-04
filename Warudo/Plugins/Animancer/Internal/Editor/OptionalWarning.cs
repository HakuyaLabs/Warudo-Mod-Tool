using System;
using UnityEngine;
using UnityEngine.Playables;
using Object = UnityEngine.Object;
using System;

namespace Animancer
{
    public enum OptionalWarning
    {
        ProOnly = 1 << 0,
        CreateGraphWhileDisabled = 1 << 1,
        CreateGraphDuringGuiEvent = 1 << 2,
        AnimatorDisabled = 1 << 3,
        NativeControllerHumanoid = 1 << 4,
        NativeControllerHybrid = 1 << 5,
        DuplicateEvent = 1 << 6,
        EndEventInterrupt = 1 << 7,
        UselessEvent = 1 << 8,
        LockedEvents = 1 << 9,
        UnsupportedEvents = 1 << 10,
        UnsupportedSpeed = 1 << 11,
        UnsupportedIK = 1 << 12,
        MixerMinChildren = 1 << 13,
        MixerSynchronizeZeroLength = 1 << 14,
        CustomFadeBounds = 1 << 15,
        CustomFadeNotNull = 1 << 16,
        AnimatorSpeed = 1 << 17,
        UnusedNode = 1 << 18,
        PlayableAssetAnimatorBinding = 1 << 19,
        CloneComplexState = 1 << 20,
        All = ~0,
    }

    public static partial class Validate
    {
        public static void Disable(this OptionalWarning type)
        {
            throw new NotImplementedException();
        }

        public static void Enable(this OptionalWarning type)
        {
            throw new NotImplementedException();
        }

        public static void SetEnabled(this OptionalWarning type, bool enable)
        {
            throw new NotImplementedException();
        }

        public static void Log(this OptionalWarning type, string message, object context = null)
        {
            throw new NotImplementedException();
        }
    }
}