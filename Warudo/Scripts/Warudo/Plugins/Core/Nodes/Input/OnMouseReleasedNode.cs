using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Plugins.Core.Events;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class OnMouseReleasedNode : Node
    {
        public Continuation Exit;
        public MouseButton Button;
        public virtual Vector2 PixelPosition() => throw new NotImplementedException();
        public virtual Vector2 NormalizedPosition() => throw new NotImplementedException();
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }
    }
}