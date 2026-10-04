using System;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class ExitEvent : Key, IUpdatable
    {
        public static void Register(AnimancerNode node, Action callback)
        {
            throw new NotImplementedException();
        }

        public static bool Unregister(AnimancerPlayable animancer)
        {
            throw new NotImplementedException();
        }

        public static bool Unregister(AnimancerNode node)
        {
            throw new NotImplementedException();
        }

        void IUpdatable.Update()
        {
            throw new NotImplementedException();
        }
    }
}