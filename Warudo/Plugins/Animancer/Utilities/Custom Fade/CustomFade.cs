using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public abstract partial class CustomFade : Key, IUpdatable
    {
        private readonly struct NodeWeight
        {
            public readonly AnimancerNode Node;
            public readonly float StartingWeight;
            public NodeWeight(AnimancerNode node)
            {
                throw new NotImplementedException();
            }
        }

        protected void Apply(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        protected void Apply(AnimancerNode node)
        {
            throw new NotImplementedException();
        }

        protected abstract float CalculateWeight(float progress);
        protected abstract void Release();
        void IUpdatable.Update()
        {
            throw new NotImplementedException();
        }
    }
}