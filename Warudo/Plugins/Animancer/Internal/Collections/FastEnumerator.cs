using System;
using System.Collections;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public struct FastEnumerator<T> : IList<T>, IEnumerator<T>
    {
        public int Count
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Index
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public T Current
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

        object IEnumerator.Current => throw new NotImplementedException();
        public FastEnumerator(IList<T> list) : this(list, list.Count)
        {
            throw new NotImplementedException();
        }

        public FastEnumerator(IList<T> list, int count)
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public bool MovePrevious()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        public FastEnumerator<T> GetEnumerator() => throw new NotImplementedException();
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => throw new NotImplementedException();
        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
        public int IndexOf(T item) => throw new NotImplementedException();
        public T this[int index]
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

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly => throw new NotImplementedException();
        public bool Contains(T item) => throw new NotImplementedException();
        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
    }
}