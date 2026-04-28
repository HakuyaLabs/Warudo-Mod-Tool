using System;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public abstract class ListContainsElementNode<T> : Node
    {
        public T[] List;
        public T Element;
        public virtual bool Result()
        {
            throw new NotImplementedException();
        }
    }

    public class IntegerListContainsElementNode : ListContainsElementNode<int>
    {
    }

    public class FloatListContainsElementNode : ListContainsElementNode<float>
    {
    }

    public class StringListContainsElementNode : ListContainsElementNode<string>
    {
    }

    public class BooleanListContainsElementNode : ListContainsElementNode<bool>
    {
    }

    public class Vector3ListContainsElementNode : ListContainsElementNode<Vector3>
    {
        public override bool Result()
        {
            throw new NotImplementedException();
        }
    }
}