using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class Vector3CrossNode : Node
    {
        public Vector3 A;
        public Vector3 B;
        public Vector3 OutputVector3()
        {
            throw new NotImplementedException();
        }
    }
}