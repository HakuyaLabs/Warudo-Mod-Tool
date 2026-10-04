using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public static partial class Validate
    {
        public static void AssertNotLegacy(AnimationClip clip)
        {
            throw new NotImplementedException();
        }

        public static void AssertRoot(AnimancerNode node, AnimancerPlayable root)
        {
            throw new NotImplementedException();
        }

        public static void AssertPlayable(AnimancerNode node)
        {
            throw new NotImplementedException();
        }

        public static void AssertCanRemoveChild(AnimancerState state, IList<AnimancerState> childStates, int childCount)
        {
            throw new NotImplementedException();
        }
    }
}