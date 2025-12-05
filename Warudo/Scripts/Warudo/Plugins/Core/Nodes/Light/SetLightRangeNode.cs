using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Plugins.Core.Assets.Environment;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Light
{
    public class SetLightRangeNode : Node
    {
        public PointLightAsset Light;
        public float Range = 10f;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}