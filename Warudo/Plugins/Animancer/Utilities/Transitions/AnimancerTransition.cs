using Animancer.Units;
using System;
using UnityEngine;
using Object = UnityEngine.Object;
using System;

namespace Animancer
{
    public abstract class AnimancerTransition<TState> : ITransition<TState>, ITransitionDetailed, ITransitionWithEvents, ICopyable<AnimancerTransition<TState>> where TState : AnimancerState
    {
        public float FadeDuration
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual bool IsLooping => throw new NotImplementedException();
        public virtual float NormalizedStartTime
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual float Speed
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public abstract float MaximumDuration { get; }

        public AnimancerEvent.Sequence Events
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ref AnimancerEvent.Sequence.Serializable SerializedEvents => throw new NotImplementedException();
        public AnimancerState BaseState { get; private set; }

        public TState State
        {
            get
            {
                throw new NotImplementedException();
            }

            protected set
            {
                throw new NotImplementedException();
            }
        }

        public virtual bool IsValid => throw new NotImplementedException();
        public virtual object Key => throw new NotImplementedException();
        public virtual FadeMode FadeMode => throw new NotImplementedException();
        public abstract TState CreateState();
        AnimancerState ITransition.CreateState() => throw new NotImplementedException();
        public virtual void Apply(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        public virtual Object MainObject { get; }

        public virtual string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public virtual void CopyFrom(AnimancerTransition<TState> copyFrom)
        {
            throw new NotImplementedException();
        }

        public static void ApplyDetails(AnimancerState state, float speed, float normalizedStartTime)
        {
            throw new NotImplementedException();
        }
    }
}