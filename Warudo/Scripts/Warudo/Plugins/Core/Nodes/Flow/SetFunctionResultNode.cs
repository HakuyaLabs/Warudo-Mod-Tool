using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using Warudo.Core.Serializations;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetFunctionResultNode : Node
    {
        public string Function;
        public string ResultType;
        public string Hint = "THIS_FUNCTION_DOES_NOT_HAVE_A_RESULT".Localized();
        protected bool HideHint() => throw new NotImplementedException();
        protected async UniTask<AutoCompleteList> AutoCompleteFunction()
        {
            throw new NotImplementedException();
        }

        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(SerializedNode serialized)
        {
            throw new NotImplementedException();
        }

        public override void OnAllNodesDeserialized(SerializedNode serialized)
        {
            throw new NotImplementedException();
        }

        public void UpdateReturnType()
        {
            throw new NotImplementedException();
        }
    }
}