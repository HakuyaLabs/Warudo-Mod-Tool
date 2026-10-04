using UnityEngine;
using System;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public partial class AnimancerTransitionAssetBase
    {
        public class UnShared : UnShared<AnimancerTransitionAssetBase>
        {
        }

        public class UnShared<TAsset> : ITransition, ITransitionWithEvents, IWrapper where TAsset : AnimancerTransitionAssetBase
        {
            public TAsset Asset
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            object IWrapper.WrappedObject => throw new NotImplementedException();
            public ITransition BaseTransition => throw new NotImplementedException();
            public virtual bool IsValid
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public bool HasAsset => throw new NotImplementedException();
            public AnimancerState BaseState
            {
                get => throw new NotImplementedException();
                protected set
                {
                    throw new NotImplementedException();
                }
            }

            protected virtual void OnSetBaseState()
            {
                throw new NotImplementedException();
            }

            public virtual AnimancerEvent.Sequence Events
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public virtual ref AnimancerEvent.Sequence.Serializable SerializedEvents
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public void ClearCachedEvents()
            {
                throw new NotImplementedException();
            }

            public virtual void Apply(AnimancerState state)
            {
                throw new NotImplementedException();
            }

            public virtual object Key
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public virtual float FadeDuration
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public virtual FadeMode FadeMode
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            AnimancerState ITransition.CreateState()
            {
                throw new NotImplementedException();
            }
        }

        public class UnShared<TAsset, TTransition, TState> : UnShared<TAsset>, ITransition<TState> where TAsset : AnimancerTransitionAsset<TTransition> where TTransition : ITransition<TState>, IHasEvents where TState : AnimancerState
        {
            public TTransition Transition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            protected override void OnSetBaseState()
            {
                throw new NotImplementedException();
            }

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

            public override ref AnimancerEvent.Sequence.Serializable SerializedEvents => throw new NotImplementedException();
            public virtual TState CreateState() => throw new NotImplementedException();
        }
    }
}