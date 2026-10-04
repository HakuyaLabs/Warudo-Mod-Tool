using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data.Models;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class DecomposeTransformNode : Node
    {
        public TransformData Transform;
        public Vector3 Position() => throw new NotImplementedException();
        public Vector3 Rotation() => throw new NotImplementedException();
        public Vector3 Scale() => throw new NotImplementedException();
    }
}