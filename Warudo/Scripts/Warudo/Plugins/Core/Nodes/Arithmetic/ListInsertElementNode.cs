using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public abstract class ListInsertElementNode<T> : Node
    {
        public T[] List;
        public T Element;
        public int Index;
        public T[] Result()
        {
            throw new NotImplementedException();
        }
    }

    public class IntegerListInsertElementNode : ListInsertElementNode<int>
    {
    }

    public class FloatListInsertElementNode : ListInsertElementNode<float>
    {
    }

    public class StringListInsertElementNode : ListInsertElementNode<string>
    {
    }

    public class BooleanListInsertElementNode : ListInsertElementNode<bool>
    {
    }

    public class Vector3ListInsertElementNode : ListInsertElementNode<Vector3>
    {
    }
}