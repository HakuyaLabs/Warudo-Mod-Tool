using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Cysharp.Threading.Tasks;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Server;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class DefineFunctionNode : Node
    {
        public string FunctionName = "NewFunction";
        public ParameterData[] Parameters;
        public string ResultType;
        protected UniTask<AutoCompleteList> AutoCompleteType() => throw new NotImplementedException();
        public Continuation OnInvoke;
        public void Invoke(Dictionary<string, object> parameterValues)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }
    }

    public class ParameterData : StructuredData<DefineFunctionNode>
    {
        public string ParameterName;
        public string ParameterType;
        protected UniTask<AutoCompleteList> AutoCompleteType() => throw new NotImplementedException();
        protected override void OnAssignedParent()
        {
            throw new NotImplementedException();
        }
    }

    public static class GraphFunctions
    {
        public static Dictionary<string, object> FunctionResults { get; }

        public static async UniTask<AutoCompleteList> AutoCompleteType(bool includeObject = true)
        {
            throw new NotImplementedException();
        }
    }
}