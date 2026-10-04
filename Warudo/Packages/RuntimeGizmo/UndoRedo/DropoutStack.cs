using System;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

namespace CommandUndoRedo
{
    public class DropoutStack<T> : LinkedList<T>
    {
        int _maxLength = int.MaxValue;
        public int maxLength
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public DropoutStack()
        {
            throw new NotImplementedException();
        }

        public DropoutStack(int maxLength)
        {
            throw new NotImplementedException();
        }

        public void Push(T item)
        {
            throw new NotImplementedException();
        }

        public T Pop()
        {
            throw new NotImplementedException();
        }

        void SetMaxLength(int max)
        {
            throw new NotImplementedException();
        }
    }
}