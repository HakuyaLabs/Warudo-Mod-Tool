using System;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public abstract class ListLastIndexOfElementNode<T> : Node
    {
        public T[] List;
        public T Element;
        public virtual int Result()
        {
            throw new NotImplementedException();
        }
    }

    public class IntegerListLastIndexOfElementNode : ListLastIndexOfElementNode<int>
    {
    }

    public class FloatListLastIndexOfElementNode : ListLastIndexOfElementNode<float>
    {
    }

    public class StringListLastIndexOfElementNode : ListLastIndexOfElementNode<string>
    {
    }

    public class BooleanListLastIndexOfElementNode : ListLastIndexOfElementNode<bool>
    {
    }

    public class Vector3ListLastIndexOfElementNode : ListLastIndexOfElementNode<Vector3>
    {
        public override int Result()
        {
            throw new NotImplementedException();
        }
    }
}