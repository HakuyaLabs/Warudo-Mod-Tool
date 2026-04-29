using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Scenes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class AssetReferenceNode : Node
    {
        public Asset SceneAsset;
        public Asset Asset()
        {
            throw new NotImplementedException();
        }
    }
}