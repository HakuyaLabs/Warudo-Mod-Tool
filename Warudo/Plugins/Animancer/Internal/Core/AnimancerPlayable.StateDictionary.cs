using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    partial class AnimancerPlayable
    {
        public class StateDictionary : IEnumerable<AnimancerState>, IAnimationClipCollection
        {
            public static IEqualityComparer<object> EqualityComparer { get; set; }

            internal StateDictionary(AnimancerPlayable root)
            {
                throw new NotImplementedException();
            }

            public int Count => throw new NotImplementedException();
            public ClipState Create(AnimationClip clip) => throw new NotImplementedException();
            public ClipState Create(object key, AnimationClip clip)
            {
                throw new NotImplementedException();
            }

            public void CreateIfNew(AnimationClip clip0, AnimationClip clip1)
            {
                throw new NotImplementedException();
            }

            public void CreateIfNew(AnimationClip clip0, AnimationClip clip1, AnimationClip clip2)
            {
                throw new NotImplementedException();
            }

            public void CreateIfNew(AnimationClip clip0, AnimationClip clip1, AnimationClip clip2, AnimationClip clip3)
            {
                throw new NotImplementedException();
            }

            public void CreateIfNew(params AnimationClip[] clips)
            {
                throw new NotImplementedException();
            }

            public AnimancerState Current => throw new NotImplementedException();
            public AnimancerState this[AnimationClip clip] => throw new NotImplementedException();
            public AnimancerState this[IHasKey hasKey] => throw new NotImplementedException();
            public AnimancerState this[object key] => throw new NotImplementedException();
            public bool TryGet(AnimationClip clip, out AnimancerState state)
            {
                throw new NotImplementedException();
            }

            public bool TryGet(IHasKey hasKey, out AnimancerState state)
            {
                throw new NotImplementedException();
            }

            public bool TryGet(object key, out AnimancerState state)
            {
                throw new NotImplementedException();
            }

            public AnimancerState GetOrCreate(AnimationClip clip, bool allowSetClip = false) => throw new NotImplementedException();
            public AnimancerState GetOrCreate(ITransition transition)
            {
                throw new NotImplementedException();
            }

            public AnimancerState GetOrCreate(object key, AnimationClip clip, bool allowSetClip = false)
            {
                throw new NotImplementedException();
            }

            public static string GetClipMismatchError(object key, AnimationClip oldClip, AnimationClip newClip) => throw new NotImplementedException();
            internal void Register(AnimancerState state)
            {
                throw new NotImplementedException();
            }

            internal void Unregister(AnimancerState state)
            {
                throw new NotImplementedException();
            }

            public Dictionary<object, AnimancerState>.ValueCollection.Enumerator GetEnumerator() => throw new NotImplementedException();
            IEnumerator<AnimancerState> IEnumerable<AnimancerState>.GetEnumerator() => throw new NotImplementedException();
            IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
            public void GatherAnimationClips(ICollection<AnimationClip> clips)
            {
                throw new NotImplementedException();
            }

            public bool Destroy(AnimationClip clip)
            {
                throw new NotImplementedException();
            }

            public bool Destroy(IHasKey hasKey)
            {
                throw new NotImplementedException();
            }

            public bool Destroy(object key)
            {
                throw new NotImplementedException();
            }

            public void DestroyAll(IList<AnimationClip> clips)
            {
                throw new NotImplementedException();
            }

            public void DestroyAll(IEnumerable<AnimationClip> clips)
            {
                throw new NotImplementedException();
            }

            public void DestroyAll(IAnimationClipSource source)
            {
                throw new NotImplementedException();
            }

            public void DestroyAll(IAnimationClipCollection source)
            {
                throw new NotImplementedException();
            }
        }
    }
}