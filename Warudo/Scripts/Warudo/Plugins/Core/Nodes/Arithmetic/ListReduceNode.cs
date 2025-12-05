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
    public abstract class ListReduceNode<T> : Node
    {
        public T[] List;
        public string Function;
        protected async UniTask<AutoCompleteList> AutoCompleteFunction()
        {
            throw new NotImplementedException();
        }

        public T Result()
        {
            throw new NotImplementedException();
        }
    }

    public class IntegerListReduceNode : ListReduceNode<int>
    {
    }

    public class FloatListReduceNode : ListReduceNode<float>
    {
    }

    public class StringListReduceNode : ListReduceNode<string>
    {
    }

    public class BooleanListReduceNode : ListReduceNode<bool>
    {
    }

    public class Vector3ListReduceNode : ListReduceNode<Vector3>
    {
    }
}