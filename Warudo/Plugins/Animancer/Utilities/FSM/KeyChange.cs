using System;
using System;
using Object = UnityEngine.Object;

namespace Animancer.FSM
{
    public struct KeyChange<TKey> : IDisposable
    {
        public static bool IsActive => throw new NotImplementedException();
        public static IKeyedStateMachine<TKey> StateMachine => throw new NotImplementedException();
        public static TKey PreviousKey
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public static TKey NextKey
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        internal KeyChange(IKeyedStateMachine<TKey> stateMachine, TKey previousKey, TKey nextKey)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public override string ToString() => throw new NotImplementedException();
        public static string CurrentToString() => throw new NotImplementedException();
    }
}