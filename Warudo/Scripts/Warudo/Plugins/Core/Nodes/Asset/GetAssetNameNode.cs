using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Scenes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetAssetNameNode : Node
    {
        public Asset Asset;
        public string AssetName() => throw new NotImplementedException();
    }
}