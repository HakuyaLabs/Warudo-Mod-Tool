using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public interface IWrapper
    {
        object WrappedObject { get; }
    }

    public static partial class AnimancerUtilities
    {
        public static object GetWrappedObject(object wrapper)
        {
            throw new NotImplementedException();
        }

        public static bool TryGetWrappedObject<T>(object wrapper, out T wrapped)
            where T : class
        {
            throw new NotImplementedException();
        }
    }
}