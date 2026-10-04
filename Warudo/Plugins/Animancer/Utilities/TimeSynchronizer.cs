using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class TimeSynchronizer<T>
    {
        public T CurrentGroup { get; set; }

        public bool SynchronizeDefaultGroup { get; set; }

        public double NormalizedTime { get; set; }

        public TimeSynchronizer()
        {
            throw new NotImplementedException();
        }

        public TimeSynchronizer(T group, bool synchronizeDefaultGroup = false)
        {
            throw new NotImplementedException();
        }

        public void StoreTime(AnimancerLayer layer) => throw new NotImplementedException();
        public void StoreTime(AnimancerState state) => throw new NotImplementedException();
        public bool SyncTime(AnimancerLayer layer, T group) => throw new NotImplementedException();
        public bool SyncTime(AnimancerLayer layer, T group, float deltaTime) => throw new NotImplementedException();
        public bool SyncTime(AnimancerState state, T group) => throw new NotImplementedException();
        public bool SyncTime(AnimancerState state, T group, float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}