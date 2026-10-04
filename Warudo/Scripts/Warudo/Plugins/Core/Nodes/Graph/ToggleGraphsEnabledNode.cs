using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Graph
{
    public class ToggleGraphsEnabledNode : Node
    {
        public string[] Blueprints;
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