using UnityEngine.Animations;
using Unity.Collections;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class AnimatedBool : AnimatedProperty<AnimatedBool.Job, bool>
    {
        public AnimatedBool(IAnimancerComponent animancer, int propertyCount, NativeArrayOptions options = NativeArrayOptions.ClearMemory) : base(animancer, propertyCount, options)
        {
            throw new NotImplementedException();
        }

        public AnimatedBool(IAnimancerComponent animancer, string propertyName) : base(animancer, propertyName)
        {
            throw new NotImplementedException();
        }

        public AnimatedBool(IAnimancerComponent animancer, params string[] propertyNames) : base(animancer, propertyNames)
        {
            throw new NotImplementedException();
        }

        protected override void CreateJob()
        {
            throw new NotImplementedException();
        }

        public struct Job : IAnimationJob
        {
            public NativeArray<PropertyStreamHandle> properties;
            public NativeArray<bool> values;
            public void ProcessRootMotion(AnimationStream stream)
            {
                throw new NotImplementedException();
            }

            public void ProcessAnimation(AnimationStream stream)
            {
                throw new NotImplementedException();
            }
        }
    }
}