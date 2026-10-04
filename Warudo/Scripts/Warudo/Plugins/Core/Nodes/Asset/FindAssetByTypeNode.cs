using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Scenes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class FindAssetByTypeNode : Node
    {
        public string AssetType;
        public object Asset()
        {
            throw new NotImplementedException();
        }
    }
}