using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class DontAllowFade : Key, IUpdatable
    {
        public static void Assert(AnimancerPlayable animancer)
        {
            throw new NotImplementedException();
        }

        void IUpdatable.Update()
        {
            throw new NotImplementedException();
        }
    }
}