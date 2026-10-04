using System;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class ClipTransitionSequence : ClipTransition, ISerializationCallbackReceiver, ICopyable<ClipTransitionSequence>
    {
        public ref ClipTransition[] Others => throw new NotImplementedException();
        public ClipTransition LastTransition => throw new NotImplementedException();
        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            throw new NotImplementedException();
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            throw new NotImplementedException();
        }

        public override void Apply(AnimancerState state)
        {
            throw new NotImplementedException();
        }

        public override bool IsValid
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool IsLooping => throw new NotImplementedException();
        public override float Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override float MaximumDuration
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override float AverageAngularSpeed
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override Vector3 AverageVelocity
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override void GatherAnimationClips(ICollection<AnimationClip> clips)
        {
            throw new NotImplementedException();
        }

        public virtual void CopyFrom(ClipTransitionSequence copyFrom)
        {
            throw new NotImplementedException();
        }

        public AnimancerEvent EndEvent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddEvent(float time, bool normalized, Action callback)
        {
            throw new NotImplementedException();
        }
    }
}