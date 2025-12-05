using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public abstract class ListRemoveIndexNode<T> : Node
    {
        public T[] List;
        public int Index;
        public T[] Result()
        {
            throw new NotImplementedException();
        }
    }

    public class IntegerListRemoveIndexNode : ListRemoveIndexNode<int>
    {
    }

    public class FloatListRemoveIndexNode : ListRemoveIndexNode<float>
    {
    }

    public class StringListRemoveIndexNode : ListRemoveIndexNode<string>
    {
    }

    public class BooleanListRemoveIndexNode : ListRemoveIndexNode<bool>
    {
    }

    public class Vector3ListRemoveIndexNode : ListRemoveIndexNode<Vector3>
    {
    }
}