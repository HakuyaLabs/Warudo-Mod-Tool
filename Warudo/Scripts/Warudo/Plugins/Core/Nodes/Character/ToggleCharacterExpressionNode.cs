using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class ToggleCharacterExpressionNode : Node
    {
        public CharacterAsset Character;
        public string Expression;
        public bool IsTransient;
        public ToggleAction Action;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        protected async UniTask<AutoCompleteList> AutoCompleteExpression()
        {
            throw new NotImplementedException();
        }
    }
}