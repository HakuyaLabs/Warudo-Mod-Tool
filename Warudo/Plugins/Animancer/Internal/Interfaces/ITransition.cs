using Object = UnityEngine.Object;
using System;

namespace Animancer
{
    public interface ITransition : IHasKey, IPolymorphic
    {
        AnimancerState CreateState();
        float FadeDuration { get; }

        FadeMode FadeMode { get; }

        void Apply(AnimancerState state);
    }

    public interface ITransition<TState> : ITransition where TState : AnimancerState
    {
        TState State { get; }

        new TState CreateState();
    }
}