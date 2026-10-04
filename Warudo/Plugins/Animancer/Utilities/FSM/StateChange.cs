using System;
using System;
using Object = UnityEngine.Object;

namespace Animancer.FSM
{
    public struct StateChange<TState> : IDisposable where TState : class, IState
    {
        public static bool IsActive => throw new NotImplementedException();
        public static StateMachine<TState> StateMachine => throw new NotImplementedException();
        public static TState PreviousState
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public static TState NextState
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        internal StateChange(StateMachine<TState> stateMachine, TState previousState, TState nextState)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public override string ToString() => throw new NotImplementedException();
        public static string CurrentToString() => throw new NotImplementedException();
    }
}