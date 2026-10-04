using System;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer.FSM
{
    public interface IState
    {
        bool CanEnterState { get; }

        bool CanExitState { get; }

        void OnEnterState();
        void OnExitState();
    }

    public interface IOwnedState<TState> : IState where TState : class, IState
    {
        StateMachine<TState> OwnerStateMachine { get; }
    }

    public abstract class State : IState
    {
        public virtual bool CanEnterState => throw new NotImplementedException();
        public virtual bool CanExitState => throw new NotImplementedException();
        public virtual void OnEnterState()
        {
            throw new NotImplementedException();
        }

        public virtual void OnExitState()
        {
            throw new NotImplementedException();
        }
    }

    public static class StateExtensions
    {
        public const string APIDocumentationURL = "https://kybernetik.com.au/animancer/api/Animancer.FSM/";
        public static TState GetPreviousState<TState>(this TState state)
            where TState : class, IState => throw new NotImplementedException();
        public static TState GetNextState<TState>(this TState state)
            where TState : class, IState => throw new NotImplementedException();
        public static bool IsCurrentState<TState>(this TState state)
            where TState : class, IOwnedState<TState> => throw new NotImplementedException();
        public static bool TryEnterState<TState>(this TState state)
            where TState : class, IOwnedState<TState> => throw new NotImplementedException();
        public static bool TryReEnterState<TState>(this TState state)
            where TState : class, IOwnedState<TState> => throw new NotImplementedException();
        public static void ForceEnterState<TState>(this TState state)
            where TState : class, IOwnedState<TState> => throw new NotImplementedException();
    }
}