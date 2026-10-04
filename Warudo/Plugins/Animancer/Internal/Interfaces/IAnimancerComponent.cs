using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public interface IAnimancerComponent
    {
        bool enabled { get; }

        GameObject gameObject { get; }

        Animator Animator { get; set; }

        AnimancerPlayable Playable { get; }

        bool IsPlayableInitialized { get; }

        bool ResetOnDisable { get; }

        AnimatorUpdateMode UpdateMode { get; set; }

        object GetKey(AnimationClip clip);
    }
}