using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class IsCharacterExpressionActiveNode : Node
    {
        public CharacterAsset Character;
        public string Expression;
        public bool Value()
        {
            throw new NotImplementedException();
        }

        protected async UniTask<AutoCompleteList> AutoCompleteExpression()
        {
            throw new NotImplementedException();
        }
    }
}