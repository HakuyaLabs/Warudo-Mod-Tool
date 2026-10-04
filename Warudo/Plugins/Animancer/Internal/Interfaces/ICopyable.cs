using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public interface ICopyable<T>
    {
        void CopyFrom(T copyFrom);
    }

    public static partial class AnimancerUtilities
    {
        public static T Clone<T>(this T original)
            where T : class, ICopyable<T>, new()
        {
            throw new NotImplementedException();
        }
    }
}