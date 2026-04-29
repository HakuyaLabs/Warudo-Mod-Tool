using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetVector3ListElementNode : Node
    {
        public Vector3[] Vector3List;
        public int Index;
        public Vector3 OutputVector3()
        {
            throw new NotImplementedException();
        }
    }
}