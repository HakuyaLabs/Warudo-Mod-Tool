using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Data
{
    public class SelectDataByBooleanNode : Node
    {
        public object IfFalse;
        public object IfTrue;
        public bool InputBoolean;
        public object Output()
        {
            throw new NotImplementedException();
        }
    }
}