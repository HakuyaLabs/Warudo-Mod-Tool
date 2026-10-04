using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class Vector3ReflectNode : Node
    {
        public Vector3 InDirection;
        public Vector3 InNormal;
        public Vector3 OutputVector3()
        {
            throw new NotImplementedException();
        }
    }
}