using System;
using Object = UnityEngine.Object;

namespace Animancer.FSM
{
    public partial class StateMachine<TKey, TState>
    {
        public new class InputBuffer : InputBuffer<StateMachine<TKey, TState>>
        {
            public TKey Key { get; set; }

            public InputBuffer()
            {
                throw new NotImplementedException();
            }

            public InputBuffer(StateMachine<TKey, TState> stateMachine) : base(stateMachine)
            {
                throw new NotImplementedException();
            }

            public bool Buffer(TKey key, float timeOut)
            {
                throw new NotImplementedException();
            }

            public void Buffer(TKey key, TState state, float timeOut)
            {
                throw new NotImplementedException();
            }

            protected override bool TryEnterState() => throw new NotImplementedException();
            public override void Clear()
            {
                throw new NotImplementedException();
            }
        }
    }
}