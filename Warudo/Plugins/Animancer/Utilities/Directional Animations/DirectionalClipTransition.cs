using System;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class DirectionalClipTransition : ClipTransition, ICopyable<DirectionalClipTransition>
    {
        public ref DirectionalAnimationSet AnimationSet => throw new NotImplementedException();
        public override UnityEngine.Object MainObject => throw new NotImplementedException();
        public void SetDirection(Vector2 direction) => throw new NotImplementedException();
        public void SetDirection(int direction) => throw new NotImplementedException();
        public void SetDirection(DirectionalAnimationSet.Direction direction) => throw new NotImplementedException();
        public void SetDirection(DirectionalAnimationSet8.Direction direction) => throw new NotImplementedException();
        public override void GatherAnimationClips(ICollection<AnimationClip> clips)
        {
            throw new NotImplementedException();
        }

        public virtual void CopyFrom(DirectionalClipTransition copyFrom)
        {
            throw new NotImplementedException();
        }
    }
}