using System;
using System.Collections.Generic;
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

namespace Warudo.Plugins.Core.Nodes
{
    public abstract class ListMapNode<T> : Node
    {
        public T[] List;
        public string TargetElementType;
        protected UniTask<AutoCompleteList> AutoCompleteType() => throw new NotImplementedException();
        public string Function;
        protected async UniTask<AutoCompleteList> AutoCompleteFunction()
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }
    }

    public class IntegerListMapNode : ListMapNode<int>
    {
    }

    public class FloatListMapNode : ListMapNode<float>
    {
    }

    public class StringListMapNode : ListMapNode<string>
    {
    }

    public class BooleanListMapNode : ListMapNode<bool>
    {
    }

    public class Vector3ListMapNode : ListMapNode<Vector3>
    {
    }
}