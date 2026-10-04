using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer.FSM
{
    public partial class StateMachine<TState>
    {
        public class InputBuffer : InputBuffer<StateMachine<TState>>
        {
            public InputBuffer()
            {
                throw new NotImplementedException();
            }

            public InputBuffer(StateMachine<TState> stateMachine) : base(stateMachine)
            {
                throw new NotImplementedException();
            }
        }

        public class InputBuffer<TStateMachine>
            where TStateMachine : StateMachine<TState>
        {
            public TStateMachine StateMachine
            {
                get => throw new NotImplementedException();
                set
                {
                    throw new NotImplementedException();
                }
            }

            public TState State { get; set; }

            public float TimeOut { get; set; }

            public bool IsActive => throw new NotImplementedException();
            public InputBuffer()
            {
                throw new NotImplementedException();
            }

            public InputBuffer(TStateMachine stateMachine)
            {
                throw new NotImplementedException();
            }

            public void Buffer(TState state, float timeOut)
            {
                throw new NotImplementedException();
            }

            protected virtual bool TryEnterState() => throw new NotImplementedException();
            public bool Update() => throw new NotImplementedException();
            public bool Update(float deltaTime)
            {
                throw new NotImplementedException();
            }

            public virtual void Clear()
            {
                throw new NotImplementedException();
            }
        }
    }
}