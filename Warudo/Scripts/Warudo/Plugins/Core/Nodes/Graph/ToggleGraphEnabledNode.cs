using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Graph
{
    public class ToggleGraphEnabledNode : Node
    {
        public string Blueprint;
        protected async UniTask<AutoCompleteList> AutoCompleteBlueprints()
        {
            throw new NotImplementedException();
        }

        public ToggleAction Action;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}