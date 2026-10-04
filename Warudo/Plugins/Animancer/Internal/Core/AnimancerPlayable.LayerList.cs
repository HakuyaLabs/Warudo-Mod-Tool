using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    partial class AnimancerPlayable
    {
        public class LayerList : IEnumerable<AnimancerLayer>, IAnimationClipCollection
        {
            protected readonly AnimancerPlayable Root;
            protected readonly AnimationLayerMixerPlayable LayerMixer;
            protected LayerList(AnimancerPlayable root)
            {
                throw new NotImplementedException();
            }

            internal LayerList(AnimancerPlayable root, out Playable layerMixer) : this(root)
            {
                throw new NotImplementedException();
            }

            public virtual void Activate(AnimancerPlayable root)
            {
                throw new NotImplementedException();
            }

            protected void Activate(AnimancerPlayable root, Playable mixer)
            {
                throw new NotImplementedException();
            }

            public int Count
            {
                get => throw new NotImplementedException();
                set
                {
                    throw new NotImplementedException();
                }
            }

            public void SetMinCount(int min)
            {
                throw new NotImplementedException();
            }

            public static int DefaultCapacity { get; set; }

            public static void SetMinDefaultCapacity(int min)
            {
                throw new NotImplementedException();
            }

            public int Capacity
            {
                get => throw new NotImplementedException();
                set
                {
                    throw new NotImplementedException();
                }
            }

            public AnimancerLayer Add()
            {
                throw new NotImplementedException();
            }

            public AnimancerLayer this[int index]
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public AnimancerLayer GetLayer(int index) => throw new NotImplementedException();
            public FastEnumerator<AnimancerLayer> GetEnumerator() => throw new NotImplementedException();
            IEnumerator<AnimancerLayer> IEnumerable<AnimancerLayer>.GetEnumerator() => throw new NotImplementedException();
            IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
            public void GatherAnimationClips(ICollection<AnimationClip> clips) => throw new NotImplementedException();
            public virtual bool IsAdditive(int index)
            {
                throw new NotImplementedException();
            }

            public virtual void SetAdditive(int index, bool value)
            {
                throw new NotImplementedException();
            }

            public virtual void SetMask(int index, AvatarMask mask)
            {
                throw new NotImplementedException();
            }

            public void SetDebugName(int index, string name) => throw new NotImplementedException();
            public Vector3 AverageVelocity
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}