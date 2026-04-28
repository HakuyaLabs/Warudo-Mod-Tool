using System;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public abstract class ListIndexOfElementNode<T> : Node
    {
        public T[] List;
        public T Element;
        public virtual int Result()
        {
            throw new NotImplementedException();
        }
    }

    public class IntegerListIndexOfElementNode : ListIndexOfElementNode<int>
    {
    }

    public class FloatListIndexOfElementNode : ListIndexOfElementNode<float>
    {
    }

    public class StringListIndexOfElementNode : ListIndexOfElementNode<string>
    {
    }

    public class BooleanListIndexOfElementNode : ListIndexOfElementNode<bool>
    {
    }

    public class Vector3ListIndexOfElementNode : ListIndexOfElementNode<Vector3>
    {
        public override int Result()
        {
            throw new NotImplementedException();
        }
    }
}