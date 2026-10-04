using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class LazyStack<T>
        where T : new()
    {
        public T Current { get; private set; }

        public LazyStack()
        {
            throw new NotImplementedException();
        }

        public LazyStack(int capacity)
        {
            throw new NotImplementedException();
        }

        public T Increment()
        {
            throw new NotImplementedException();
        }

        public void Decrement()
        {
            throw new NotImplementedException();
        }
    }
}