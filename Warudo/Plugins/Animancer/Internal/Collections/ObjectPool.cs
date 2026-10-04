using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public static class ObjectPool
    {
        public static T Acquire<T>()
            where T : class, new() => throw new NotImplementedException();
        public static void Acquire<T>(out T item)
            where T : class, new() => throw new NotImplementedException();
        public static void Release<T>(T item)
            where T : class, new() => throw new NotImplementedException();
        public static void Release<T>(ref T item)
            where T : class, new()
        {
            throw new NotImplementedException();
        }

        public const string NotClearError = " They must be cleared before being released to the pool and not modified after that.";
        public static List<T> AcquireList<T>()
        {
            throw new NotImplementedException();
        }

        public static void Acquire<T>(out List<T> list) => throw new NotImplementedException();
        public static void Release<T>(List<T> list)
        {
            throw new NotImplementedException();
        }

        public static void Release<T>(ref List<T> list)
        {
            throw new NotImplementedException();
        }

        public static HashSet<T> AcquireSet<T>()
        {
            throw new NotImplementedException();
        }

        public static void Acquire<T>(out HashSet<T> set) => throw new NotImplementedException();
        public static void Release<T>(HashSet<T> set)
        {
            throw new NotImplementedException();
        }

        public static void Release<T>(ref HashSet<T> set)
        {
            throw new NotImplementedException();
        }

        public static StringBuilder AcquireStringBuilder()
        {
            throw new NotImplementedException();
        }

        public static void Release(StringBuilder builder)
        {
            throw new NotImplementedException();
        }

        public static string ReleaseToString(this StringBuilder builder)
        {
            throw new NotImplementedException();
        }

        public static class Disposable
        {
            public static ObjectPool<T>.Disposable Acquire<T>(out T item)
                where T : class, new() => throw new NotImplementedException();
            public static ObjectPool<List<T>>.Disposable AcquireList<T>(out List<T> list)
            {
                throw new NotImplementedException();
            }

            public static ObjectPool<HashSet<T>>.Disposable AcquireSet<T>(out HashSet<T> set)
            {
                throw new NotImplementedException();
            }

            public static ObjectPool<GUIContent>.Disposable AcquireContent(out GUIContent content, string text = null, string tooltip = null, bool narrowText = true)
            {
                throw new NotImplementedException();
            }
        }
    }

    public static class ObjectPool<T>
        where T : class, new()
    {
        public static int Count
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public static void IncreaseCountTo(int count)
        {
            throw new NotImplementedException();
        }

        public static int Capacity
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public static void IncreaseCapacityTo(int capacity)
        {
            throw new NotImplementedException();
        }

        public static T Acquire()
        {
            throw new NotImplementedException();
        }

        public static void Release(T item)
        {
            throw new NotImplementedException();
        }

        public static string GetDetails()
        {
            throw new NotImplementedException();
        }

        public readonly struct Disposable : IDisposable
        {
            public readonly T Item;
            public readonly Action<T> OnRelease;
            public Disposable(out T item, Action<T> onRelease = null)
            {
                throw new NotImplementedException();
            }

            void IDisposable.Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}