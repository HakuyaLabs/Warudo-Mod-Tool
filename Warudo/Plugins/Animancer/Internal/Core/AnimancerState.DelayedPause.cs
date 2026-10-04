using UnityEngine.Playables;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    partial class AnimancerState
    {
        public class DelayedPause : Key, IUpdatable
        {
            public AnimancerPlayable Root { get; set; }

            public AnimancerState State { get; set; }

            public static void Register(AnimancerState state)
            {
                throw new NotImplementedException();
            }

            public void Update()
            {
                throw new NotImplementedException();
            }
        }
    }
}