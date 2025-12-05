using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public abstract class ListAddElementNode<T> : Node
    {
        public T[] List;
        public T Element;
        public T[] Result()
        {
            throw new NotImplementedException();
        }
    }

    public class IntegerListAddElementNode : ListAddElementNode<int>
    {
    }

    public class FloatListAddElementNode : ListAddElementNode<float>
    {
    }

    public class StringListAddElementNode : ListAddElementNode<string>
    {
    }

    public class BooleanListAddElementNode : ListAddElementNode<bool>
    {
    }

    public class Vector3ListAddElementNode : ListAddElementNode<Vector3>
    {
    }
}