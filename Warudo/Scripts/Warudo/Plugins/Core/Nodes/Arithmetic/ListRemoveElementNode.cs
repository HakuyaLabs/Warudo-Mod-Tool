using System;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public abstract class ListRemoveElementNode<T> : Node
    {
        public T[] List;
        public T Element;
        public bool RemoveAll = true;
        public T[] Result()
        {
            throw new NotImplementedException();
        }

        protected virtual bool Equals(T x, T y)
        {
            throw new NotImplementedException();
        }
    }

    public class IntegerListRemoveElementNode : ListRemoveElementNode<int>
    {
    }

    public class FloatListRemoveElementNode : ListRemoveElementNode<float>
    {
    }

    public class StringListRemoveElementNode : ListRemoveElementNode<string>
    {
    }

    public class BooleanListRemoveElementNode : ListRemoveElementNode<bool>
    {
    }

    public class Vector3ListRemoveElementNode : ListRemoveElementNode<Vector3>
    {
        protected override bool Equals(Vector3 x, Vector3 y)
        {
            throw new NotImplementedException();
        }
    }
}