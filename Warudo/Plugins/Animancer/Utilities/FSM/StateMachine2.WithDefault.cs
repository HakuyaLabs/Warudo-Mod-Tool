using System;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer.FSM
{
    partial class StateMachine<TKey, TState>
    {
        public new class WithDefault : StateMachine<TKey, TState>
        {
            public TKey DefaultKey
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

            public WithDefault(TKey defaultKey) : this()
            {
                throw new NotImplementedException();
            }

            public override void InitializeAfterDeserialize()
            {
                throw new NotImplementedException();
            }

            public TState TrySetDefaultState() => throw new NotImplementedException();
            public TState TryResetDefaultState() => throw new NotImplementedException();
        }
    }
}