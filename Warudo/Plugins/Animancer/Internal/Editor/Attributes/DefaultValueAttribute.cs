using System;
using System.Reflection;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class DefaultValueAttribute : Attribute
    {
        public virtual object Primary { get; protected set; }

        public virtual object Secondary { get; protected set; }

        public DefaultValueAttribute(object primary, object secondary = null)
        {
            throw new NotImplementedException();
        }

        protected DefaultValueAttribute()
        {
            throw new NotImplementedException();
        }
    }
}