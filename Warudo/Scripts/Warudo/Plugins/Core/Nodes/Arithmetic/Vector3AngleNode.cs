using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class Vector3AngleNode : Node
    {
        public Vector3 A;
        public Vector3 B;
        public float OutputFloat()
        {
            throw new NotImplementedException();
        }
    }
}