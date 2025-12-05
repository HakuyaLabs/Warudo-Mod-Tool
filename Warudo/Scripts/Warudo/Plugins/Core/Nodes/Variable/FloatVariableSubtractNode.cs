using System.Linq;
using Cysharp.Threading.Tasks;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Variable
{
    public class FloatVariableSubtractNode : Node
    {
        public string VariableName;
        public float Value;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        protected async UniTask<AutoCompleteList> AutoCompleteVariableName()
        {
            throw new NotImplementedException();
        }
    }
}