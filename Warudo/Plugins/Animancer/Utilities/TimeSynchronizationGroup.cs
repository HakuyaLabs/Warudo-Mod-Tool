using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class TimeSynchronizationGroup : HashSet<object>
    {
        public AnimancerComponent Animancer
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public float? NormalizedTime { get; set; }

        public TimeSynchronizationGroup(AnimancerComponent animancer)
        {
            throw new NotImplementedException();
        }

        public bool StoreTime(object key) => throw new NotImplementedException();
        public bool StoreTime(object key, AnimancerState state)
        {
            throw new NotImplementedException();
        }

        public bool SyncTime(object key) => throw new NotImplementedException();
        public bool SyncTime(object key, float deltaTime) => throw new NotImplementedException();
        public bool SyncTime(object key, AnimancerState state) => throw new NotImplementedException();
        public bool SyncTime(object key, AnimancerState state, float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}