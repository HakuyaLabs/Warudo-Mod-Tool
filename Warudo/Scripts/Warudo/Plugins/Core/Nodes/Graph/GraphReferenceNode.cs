using System.Linq;
using Cysharp.Threading.Tasks;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Graph
{
    public class GraphReferenceNode : Node
    {
        public string Blueprint;
        protected async UniTask<AutoCompleteList> AutoCompleteBlueprints()
        {
            throw new NotImplementedException();
        }

        public string Asset()
        {
            throw new NotImplementedException();
        }
    }
}