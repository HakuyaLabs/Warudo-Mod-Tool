using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class Vector3NormalizeNode : Node
    {
        public Vector3 Vector3;
        public Vector3 OutputVector3()
        {
            throw new NotImplementedException();
        }
    }
}