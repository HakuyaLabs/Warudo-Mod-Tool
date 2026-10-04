using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class ToggleBlueprintsInGroupEnabledNode : Node
    {
        public string Group;
        protected async UniTask<AutoCompleteList> AutoCompleteGroup()
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