using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class AnimancerTransitionAsset<TTransition> : AnimancerTransitionAssetBase where TTransition : ITransition
    {
        public TTransition Transition
        {
            get
            {
                throw new NotImplementedException();
            }

            set => throw new NotImplementedException();
        }

        public override ITransition GetTransition()
        {
            throw new NotImplementedException();
        }

        public bool HasTransition => throw new NotImplementedException();
    }
}