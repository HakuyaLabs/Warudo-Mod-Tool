using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public abstract class ListResizeNode<T> : Node
    {
        public T[] List;
        public int Size;
        public T[] Result()
        {
            throw new NotImplementedException();
        }
    }

    public class IntegerListResizeNode : ListResizeNode<int>
    {
    }

    public class FloatListResizeNode : ListResizeNode<float>
    {
    }

    public class StringListResizeNode : ListResizeNode<string>
    {
    }

    public class BooleanListResizeNode : ListResizeNode<bool>
    {
    }

    public class Vector3ListResizeNode : ListResizeNode<Vector3>
    {
    }
}