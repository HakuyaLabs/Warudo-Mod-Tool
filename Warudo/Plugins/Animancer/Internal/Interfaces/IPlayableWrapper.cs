using UnityEngine;
using UnityEngine.Playables;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public interface IPlayableWrapper
    {
        IPlayableWrapper Parent { get; }

        float Weight { get; }

        Playable Playable { get; }

        int ChildCount { get; }

        AnimancerNode GetChild(int index);
        bool KeepChildrenConnected { get; }

        float Speed { get; set; }

        bool ApplyAnimatorIK { get; set; }

        bool ApplyFootIK { get; set; }
    }
}