using System;
using UnityEngine;
using UnityEngine.Animations;
using Unity.Collections;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public abstract class AnimatedProperty<TJob, TValue> : AnimancerJob<TJob>, IDisposable where TJob : struct, IAnimationJob where TValue : struct
    {
        protected NativeArray<PropertyStreamHandle> _Properties;
        protected NativeArray<TValue> _Values;
        public AnimatedProperty(IAnimancerComponent animancer, int propertyCount, NativeArrayOptions options = NativeArrayOptions.ClearMemory)
        {
            throw new NotImplementedException();
        }

        public AnimatedProperty(IAnimancerComponent animancer, string propertyName) : this(animancer, 1, NativeArrayOptions.UninitializedMemory)
        {
            throw new NotImplementedException();
        }

        public AnimatedProperty(IAnimancerComponent animancer, params string[] propertyNames) : this(animancer, propertyNames.Length, NativeArrayOptions.UninitializedMemory)
        {
            throw new NotImplementedException();
        }

        public void InitializeProperty(Animator animator, int index, string name) => throw new NotImplementedException();
        public void InitializeProperty(Animator animator, int index, Transform transform, Type type, string name) => throw new NotImplementedException();
        protected abstract void CreateJob();
        public TValue Value => throw new NotImplementedException();
        public static implicit operator TValue(AnimatedProperty<TJob, TValue> properties)
        {
            throw new NotImplementedException();
        }

        public TValue GetValue(int index) => throw new NotImplementedException();
        public TValue this[int index] => throw new NotImplementedException();
        public void GetValues(ref TValue[] values)
        {
            throw new NotImplementedException();
        }

        public TValue[] GetValues()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose() => throw new NotImplementedException();
        protected virtual void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}