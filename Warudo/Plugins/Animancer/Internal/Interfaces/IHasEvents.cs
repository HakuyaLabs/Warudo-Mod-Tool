using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public interface IHasEvents
    {
        AnimancerEvent.Sequence Events { get; }

        ref AnimancerEvent.Sequence.Serializable SerializedEvents { get; }
    }

    public interface ITransitionWithEvents : ITransition, IHasEvents
    {
    }
}