using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetAssetScaleNode : Node
    {
        public GameObjectAsset Asset;
        public Vector3 LocalScale()
        {
            throw new NotImplementedException();
        }
    }
}