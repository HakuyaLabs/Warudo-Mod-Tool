using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    partial struct AnimancerEvent
    {
        public partial class Sequence : IEnumerable<AnimancerEvent>, ICopyable<Sequence>
        {
            internal const string IndexOutOfRangeError = "index must be within the range of 0 <= index < " + nameof(Count);
            public int Count { get; private set; }

            public bool IsEmpty
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public const int DefaultCapacity = 8;
            public int Capacity
            {
                get => throw new NotImplementedException();
                set
                {
                    throw new NotImplementedException();
                }
            }

            public int Version
            {
                get => throw new NotImplementedException();
                private set
                {
                    throw new NotImplementedException();
                }
            }

            public void SetShouldNotModifyReason(string reason)
            {
                throw new NotImplementedException();
            }

            public void OnSequenceModified()
            {
                throw new NotImplementedException();
            }

            public AnimancerEvent EndEvent
            {
                get => throw new NotImplementedException();
                set
                {
                    throw new NotImplementedException();
                }
            }

            public Action OnEnd
            {
                get => throw new NotImplementedException();
                set
                {
                    throw new NotImplementedException();
                }
            }

            public float NormalizedEndTime
            {
                get => throw new NotImplementedException();
                set
                {
                    throw new NotImplementedException();
                }
            }

            public static float GetDefaultNormalizedStartTime(float speed) => throw new NotImplementedException();
            public static float GetDefaultNormalizedEndTime(float speed) => throw new NotImplementedException();
            public ref string[] Names => throw new NotImplementedException();
            public string GetName(int index)
            {
                throw new NotImplementedException();
            }

            public void SetName(int index, string name)
            {
                throw new NotImplementedException();
            }

            public int IndexOf(string name, int startIndex = 0)
            {
                throw new NotImplementedException();
            }

            public int IndexOfRequired(string name, int startIndex = 0)
            {
                throw new NotImplementedException();
            }

            public Sequence()
            {
                throw new NotImplementedException();
            }

            public Sequence(int capacity)
            {
                throw new NotImplementedException();
            }

            public Sequence(Sequence copyFrom)
            {
                throw new NotImplementedException();
            }

            public AnimancerEvent this[int index]
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public AnimancerEvent this[string name] => throw new NotImplementedException();
            public void AssertNormalizedTimes(AnimancerState state)
            {
                throw new NotImplementedException();
            }

            public void AssertNormalizedTimes(AnimancerState state, bool isLooping)
            {
                throw new NotImplementedException();
            }

            public string DeepToString(bool multiLine = true)
            {
                throw new NotImplementedException();
            }

            public FastEnumerator<AnimancerEvent> GetEnumerator() => throw new NotImplementedException();
            IEnumerator<AnimancerEvent> IEnumerable<AnimancerEvent>.GetEnumerator() => throw new NotImplementedException();
            IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
            public int IndexOf(AnimancerEvent animancerEvent) => throw new NotImplementedException();
            public int IndexOfRequired(AnimancerEvent animancerEvent) => throw new NotImplementedException();
            public int IndexOf(int indexHint, AnimancerEvent animancerEvent)
            {
                throw new NotImplementedException();
            }

            public int IndexOfRequired(int indexHint, AnimancerEvent animancerEvent)
            {
                throw new NotImplementedException();
            }

            public int Add(AnimancerEvent animancerEvent)
            {
                throw new NotImplementedException();
            }

            public int Add(float normalizedTime, Action callback) => throw new NotImplementedException();
            public int Add(int indexHint, AnimancerEvent animancerEvent)
            {
                throw new NotImplementedException();
            }

            public int Add(int indexHint, float normalizedTime, Action callback) => throw new NotImplementedException();
            public void AddRange(IEnumerable<AnimancerEvent> enumerable)
            {
                throw new NotImplementedException();
            }

            public void AddCallback(int index, Action callback)
            {
                throw new NotImplementedException();
            }

            public void AddCallback(string name, Action callback) => throw new NotImplementedException();
            public void RemoveCallback(int index, Action callback)
            {
                throw new NotImplementedException();
            }

            public void RemoveCallback(string name, Action callback) => throw new NotImplementedException();
            public void SetCallback(int index, Action callback)
            {
                throw new NotImplementedException();
            }

            public void SetCallback(string name, Action callback) => throw new NotImplementedException();
            public int SetNormalizedTime(int index, float normalizedTime)
            {
                throw new NotImplementedException();
            }

            public int SetNormalizedTime(string name, float normalizedTime) => throw new NotImplementedException();
            public int SetNormalizedTime(AnimancerEvent animancerEvent, float normalizedTime) => throw new NotImplementedException();
            public void Remove(int index)
            {
                throw new NotImplementedException();
            }

            public bool Remove(string name)
            {
                throw new NotImplementedException();
            }

            public bool Remove(AnimancerEvent animancerEvent)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public void CopyFrom(Sequence copyFrom)
            {
                throw new NotImplementedException();
            }

            public void AddAllEvents(AnimationClip animation)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(AnimancerEvent[] array, int index)
            {
                throw new NotImplementedException();
            }

            public bool ContentsAreEqual(Sequence other)
            {
                throw new NotImplementedException();
            }
        }
    }
}