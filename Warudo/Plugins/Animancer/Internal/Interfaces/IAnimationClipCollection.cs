using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Playables;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public interface IAnimationClipCollection
    {
        void GatherAnimationClips(ICollection<AnimationClip> clips);
    }

    public static partial class AnimancerUtilities
    {
        public static void Gather(this ICollection<AnimationClip> clips, AnimationClip clip)
        {
            throw new NotImplementedException();
        }

        public static void Gather(this ICollection<AnimationClip> clips, IList<AnimationClip> gatherFrom)
        {
            throw new NotImplementedException();
        }

        public static void Gather(this ICollection<AnimationClip> clips, IEnumerable<AnimationClip> gatherFrom)
        {
            throw new NotImplementedException();
        }

        public static void GatherFromAsset(this ICollection<AnimationClip> clips, PlayableAsset asset)
        {
            throw new NotImplementedException();
        }

        public static void GatherFromSource(this ICollection<AnimationClip> clips, IAnimationClipSource source)
        {
            throw new NotImplementedException();
        }

        public static void GatherFromSource(this ICollection<AnimationClip> clips, IEnumerable source)
        {
            throw new NotImplementedException();
        }

        public static bool GatherFromSource(this ICollection<AnimationClip> clips, object source)
        {
            throw new NotImplementedException();
        }

        public static bool TryGetFrameRate(object clipSource, out float frameRate)
        {
            throw new NotImplementedException();
        }
    }
}