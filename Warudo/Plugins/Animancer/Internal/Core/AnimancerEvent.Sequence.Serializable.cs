using SerializableCallback = UnityEngine.Events.UnityEvent;
using UnityEngine;
using System;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    partial struct AnimancerEvent
    {
        partial class Sequence
        {
            public class Serializable : ICopyable<Serializable>
            {
                public ref float[] NormalizedTimes => throw new NotImplementedException();
                public ref SerializableCallback[] Callbacks => throw new NotImplementedException();
                public ref string[] Names => throw new NotImplementedException();
                public Sequence Events
                {
                    get
                    {
                        throw new NotImplementedException();
                    }

                    set => throw new NotImplementedException();
                }

                public Sequence GetEventsOptional()
                {
                    throw new NotImplementedException();
                }

                public static implicit operator Sequence(Serializable serializable)
                {
                    throw new NotImplementedException();
                }

                internal Sequence InitializedEvents => throw new NotImplementedException();
                public static Action GetInvoker(SerializableCallback callback) => throw new NotImplementedException();
                public static bool HasPersistentCalls(SerializableCallback callback)
                {
                    throw new NotImplementedException();
                }

                public float GetNormalizedEndTime(float speed = 1)
                {
                    throw new NotImplementedException();
                }

                public void SetNormalizedEndTime(float normalizedTime)
                {
                    throw new NotImplementedException();
                }

                public void CopyFrom(Serializable copyFrom)
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}