using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class Vector3ProjectOnPlaneNode : Node
    {
        public Vector3 A;
        public Vector3 PlaneNormal;
        public Vector3 OutputVector3()
        {
            throw new NotImplementedException();
        }
    }
}