using System;
using Warudo.Core.Attributes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class LiteralEnumValueNode : EnumNode
    {
        public string EnumValue;
        public object Output()
        {
            throw new NotImplementedException();
        }
    }
}