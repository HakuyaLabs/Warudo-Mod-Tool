using Warudo.Core.Attributes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class DataFunctionNode : FunctionNode
    {
        protected override bool IsFlow => throw new NotImplementedException();
    }
}