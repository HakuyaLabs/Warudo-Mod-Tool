using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Plugins.Core.Assets.Environment;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Light
{
    public class SetLightColorNode : Node
    {
        public LightAsset Light;
        public Color Color = new(1, 0.9568627f, 0.8392157f);
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}