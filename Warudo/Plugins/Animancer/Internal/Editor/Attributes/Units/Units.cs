using System;
using Object = UnityEngine.Object;

namespace Animancer.Units
{
    public sealed class DegreesAttribute : UnitsAttribute
    {
        public DegreesAttribute() : base(" º")
        {
            throw new NotImplementedException();
        }
    }

    public sealed class DegreesPerSecondAttribute : UnitsAttribute
    {
        public DegreesPerSecondAttribute() : base(" º/s")
        {
            throw new NotImplementedException();
        }
    }

    public sealed class MetersAttribute : UnitsAttribute
    {
        public MetersAttribute() : base(" m")
        {
            throw new NotImplementedException();
        }
    }

    public sealed class MetersPerSecondAttribute : UnitsAttribute
    {
        public MetersPerSecondAttribute() : base(" m/s")
        {
            throw new NotImplementedException();
        }
    }

    public sealed class MetersPerSecondPerSecondAttribute : UnitsAttribute
    {
        public MetersPerSecondPerSecondAttribute() : base(" m/s\xB2")
        {
            throw new NotImplementedException();
        }
    }

    public sealed class MultiplierAttribute : UnitsAttribute
    {
        public MultiplierAttribute() : base(" x")
        {
            throw new NotImplementedException();
        }
    }

    public sealed class SecondsAttribute : UnitsAttribute
    {
        public SecondsAttribute() : base(" s")
        {
            throw new NotImplementedException();
        }
    }
}