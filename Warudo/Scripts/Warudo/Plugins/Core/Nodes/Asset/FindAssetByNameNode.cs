using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Scenes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class FindAssetByNameNode : Node
    {
        public string AssetName;
        public bool ExactMatch = true;
        public object Asset()
        {
            throw new NotImplementedException();
        }
    }
}