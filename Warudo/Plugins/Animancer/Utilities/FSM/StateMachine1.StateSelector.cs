using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

namespace Animancer.FSM
{
    public interface IPrioritizable : IState
    {
        float Priority { get; }
    }

    public partial class StateMachine<TState>
    {
        public class StateSelector : SortedList<float, TState>
        {
            public StateSelector() : base(ReverseComparer<float>.Instance)
            {
                throw new NotImplementedException();
            }

            public void Add<TPrioritizable>(TPrioritizable state)
                where TPrioritizable : TState, IPrioritizable => throw new NotImplementedException();
        }
    }

    public class ReverseComparer<T> : IComparer<T>
    {
        public static readonly ReverseComparer<T> Instance = new ReverseComparer<T>();
        public int Compare(T x, T y) => throw new NotImplementedException();
    }
}