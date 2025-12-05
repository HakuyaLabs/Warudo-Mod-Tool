using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Variable
{
    public abstract class GetVariableNode<T> : Node
    {
        public abstract GraphVariableType VariableType { get; }

        public abstract T Get(GraphVariable variable);
        public string TargetGraph;
        public string VariableName;
        public T Value()
        {
            throw new NotImplementedException();
        }

        public Warudo.Core.Graphs.Graph GetTargetGraph()
        {
            throw new NotImplementedException();
        }

        protected async UniTask<AutoCompleteList> AutoCompleteVariableName()
        {
            throw new NotImplementedException();
        }

        protected async UniTask<AutoCompleteList> AutoCompleteTargetGraph()
        {
            throw new NotImplementedException();
        }
    }
}