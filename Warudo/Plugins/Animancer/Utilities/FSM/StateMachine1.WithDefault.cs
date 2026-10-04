using System;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer.FSM
{
    partial class StateMachine<TState>
    {
        public class WithDefault : StateMachine<TState>
        {
            public TState DefaultState
            {
                get => throw new NotImplementedException();
                set
                {
                    throw new NotImplementedException();
                }
            }

            public readonly Action ForceSetDefaultState;
            public WithDefault()
            {
                throw new NotImplementedException();
            }

            public WithDefault(TState defaultState) : this()
            {
                throw new NotImplementedException();
            }

            public override void InitializeAfterDeserialize()
            {
                throw new NotImplementedException();
            }

            public bool TrySetDefaultState() => throw new NotImplementedException();
            public bool TryResetDefaultState() => throw new NotImplementedException();
        }
    }
}