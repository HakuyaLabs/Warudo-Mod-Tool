using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class LiteralVector3ListNode : Node
    {
        public Vector3[] Value;
        public Vector3[] Output()
        {
            throw new NotImplementedException();
        }
    }
}