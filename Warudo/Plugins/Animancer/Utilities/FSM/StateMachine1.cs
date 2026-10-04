using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer.FSM
{
    public interface IStateMachine
    {
        object CurrentState { get; }

        object PreviousState { get; }

        object NextState { get; }

        bool CanSetState(object state);
        object CanSetState(IList states);
        bool TrySetState(object state);
        bool TrySetState(IList states);
        bool TryResetState(object state);
        bool TryResetState(IList states);
        void ForceSetState(object state);
        void SetAllowNullStates(bool allow = true);
    }

    public partial class StateMachine<TState> : IStateMachine where TState : class, IState
    {
        public TState CurrentState => throw new NotImplementedException();
        public TState PreviousState => throw new NotImplementedException();
        public TState NextState => throw new NotImplementedException();
        public StateMachine()
        {
            throw new NotImplementedException();
        }

        public StateMachine(TState state)
        {
            throw new NotImplementedException();
        }

        public virtual void InitializeAfterDeserialize()
        {
            throw new NotImplementedException();
        }

        public bool CanSetState(TState state)
        {
            throw new NotImplementedException();
        }

        public TState CanSetState(IList<TState> states)
        {
            throw new NotImplementedException();
        }

        public bool TrySetState(TState state)
        {
            throw new NotImplementedException();
        }

        public bool TrySetState(IList<TState> states)
        {
            throw new NotImplementedException();
        }

        public bool TryResetState(TState state)
        {
            throw new NotImplementedException();
        }

        public bool TryResetState(IList<TState> states)
        {
            throw new NotImplementedException();
        }

        public void ForceSetState(TState state)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => throw new NotImplementedException();
        public void SetAllowNullStates(bool allow = true)
        {
            throw new NotImplementedException();
        }

        object IStateMachine.CurrentState => throw new NotImplementedException();
        object IStateMachine.PreviousState => throw new NotImplementedException();
        object IStateMachine.NextState => throw new NotImplementedException();
        object IStateMachine.CanSetState(IList states) => throw new NotImplementedException();
        bool IStateMachine.CanSetState(object state) => throw new NotImplementedException();
        void IStateMachine.ForceSetState(object state) => throw new NotImplementedException();
        bool IStateMachine.TryResetState(IList states) => throw new NotImplementedException();
        bool IStateMachine.TryResetState(object state) => throw new NotImplementedException();
        bool IStateMachine.TrySetState(IList states) => throw new NotImplementedException();
        bool IStateMachine.TrySetState(object state) => throw new NotImplementedException();
        void IStateMachine.SetAllowNullStates(bool allow) => throw new NotImplementedException();
    }
}