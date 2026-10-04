using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public abstract class ListSliceNode<T> : Node
    {
        public T[] List;
        public int StartIndex;
        public int Length = 0;
        public T[] Result()
        {
            throw new NotImplementedException();
        }
    }

    public class IntegerListSliceNode : ListSliceNode<int>
    {
    }

    public class FloatListSliceNode : ListSliceNode<float>
    {
    }

    public class StringListSliceNode : ListSliceNode<string>
    {
    }

    public class BooleanListSliceNode : ListSliceNode<bool>
    {
    }

    public class Vector3ListSliceNode : ListSliceNode<Vector3>
    {
    }
}