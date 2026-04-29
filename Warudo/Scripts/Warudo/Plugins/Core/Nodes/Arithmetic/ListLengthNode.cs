using System;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public abstract class ListLengthNode<T> : Node
    {
        public T[] List;
        public int Result()
        {
            throw new NotImplementedException();
        }
    }

    public class IntegerListLengthNode : ListLengthNode<int>
    {
    }

    public class FloatListLengthNode : ListLengthNode<float>
    {
    }

    public class StringListLengthNode : ListLengthNode<string>
    {
    }

    public class BooleanListLengthNode : ListLengthNode<bool>
    {
    }

    public class Vector3ListLengthNode : ListLengthNode<Vector3>
    {
    }
}