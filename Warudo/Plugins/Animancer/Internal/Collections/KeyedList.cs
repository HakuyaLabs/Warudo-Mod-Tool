using System;
using System.Collections;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class Key : Key.IListItem
    {
        public interface IListItem
        {
            Key Key { get; }
        }

        public const int NotInList = -1;
        public static int IndexOf(Key key) => throw new NotImplementedException();
        public static bool IsInList(Key key) => throw new NotImplementedException();
        Key IListItem.Key => throw new NotImplementedException();
        public class KeyedList<T> : IList<T>, ICollection where T : class, IListItem
        {
            public KeyedList()
            {
                throw new NotImplementedException();
            }

            public KeyedList(int capacity)
            {
                throw new NotImplementedException();
            }

            public int Count => throw new NotImplementedException();
            public int Capacity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public T this[int index]
            {
                get => throw new NotImplementedException();
                set
                {
                    throw new NotImplementedException();
                }
            }

            public bool Contains(T item)
            {
                throw new NotImplementedException();
            }

            public int IndexOf(T item)
            {
                throw new NotImplementedException();
            }

            public void Add(T item)
            {
                throw new NotImplementedException();
            }

            public void AddNew(T item)
            {
                throw new NotImplementedException();
            }

            public void Insert(int index, T item)
            {
                throw new NotImplementedException();
            }

            public void RemoveAt(int index)
            {
                throw new NotImplementedException();
            }

            public void RemoveAtSwap(int index)
            {
                throw new NotImplementedException();
            }

            public bool Remove(T item)
            {
                throw new NotImplementedException();
            }

            public bool RemoveSwap(T item)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public void CopyTo(T[] array, int index) => throw new NotImplementedException();
            void ICollection.CopyTo(Array array, int index) => throw new NotImplementedException();
            bool ICollection<T>.IsReadOnly => throw new NotImplementedException();
            public List<T>.Enumerator GetEnumerator() => throw new NotImplementedException();
            IEnumerator<T> IEnumerable<T>.GetEnumerator() => throw new NotImplementedException();
            IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
            bool ICollection.IsSynchronized => throw new NotImplementedException();
            object ICollection.SyncRoot => throw new NotImplementedException();
        }
    }
}