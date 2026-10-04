using System;
using UnityEngine;
using Object = UnityEngine.Object;
using System;

namespace Animancer
{
    partial class AnimancerState
    {
        public AnimancerEvent.Sequence Events
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool HasEvents => throw new NotImplementedException();
        public static bool AutomaticallyClearEvents { get; set; }

        public class EventDispatcher : Key, IUpdatable
        {
            internal static void Acquire(AnimancerState state)
            {
                throw new NotImplementedException();
            }

            internal static void TryClear(EventDispatcher events)
            {
                throw new NotImplementedException();
            }

            public bool HasEvents => throw new NotImplementedException();
            internal AnimancerEvent.Sequence Events
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            void IUpdatable.Update()
            {
                throw new NotImplementedException();
            }

            internal void OnTimeChanged()
            {
                throw new NotImplementedException();
            }

            public override string ToString()
            {
                throw new NotImplementedException();
            }
        }
    }
}