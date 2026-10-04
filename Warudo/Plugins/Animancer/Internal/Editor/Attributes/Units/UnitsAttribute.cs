using System;
using Object = UnityEngine.Object;

namespace Animancer.Units
{
    public class UnitsAttribute : SelfDrawerAttribute
    {
        public Validate.Value Rule { get; set; }

        protected UnitsAttribute()
        {
            throw new NotImplementedException();
        }

        public UnitsAttribute(string suffix)
        {
            throw new NotImplementedException();
        }

        public UnitsAttribute(float[] multipliers, string[] suffixes, int unitIndex = 0)
        {
            throw new NotImplementedException();
        }
    }
}