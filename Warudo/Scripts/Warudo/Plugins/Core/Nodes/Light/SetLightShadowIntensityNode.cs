using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Plugins.Core.Assets.Environment;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Light
{
    public class SetLightShadowIntensityNode : Node
    {
        public LightAsset Light;
        public float ShadowIntensity = 1f;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}