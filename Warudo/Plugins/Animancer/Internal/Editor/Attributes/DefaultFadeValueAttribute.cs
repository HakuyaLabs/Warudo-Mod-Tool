using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class DefaultFadeValueAttribute : DefaultValueAttribute
    {
        public override object Primary => throw new NotImplementedException();
        public DefaultFadeValueAttribute()
        {
            throw new NotImplementedException();
        }
    }
}