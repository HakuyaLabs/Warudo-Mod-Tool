using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
using UnityEngine.Playables;
using Object = UnityEngine.Object;
using System;

namespace Animancer
{
    public class PlayableAssetState : AnimancerState, ICopyable<PlayableAssetState>
    {
        public interface ITransition : ITransition<PlayableAssetState>
        {
        }

        public PlayableAsset Asset { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override Object MainObject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override float Length => throw new NotImplementedException();
        protected override void OnSetIsPlaying()
        {
            throw new NotImplementedException();
        }

        public override void CopyIKFlags(AnimancerNode copyFrom)
        {
            throw new NotImplementedException();
        }

        public override bool ApplyAnimatorIK
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ApplyFootIK
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public PlayableAssetState(PlayableAsset asset)
        {
            throw new NotImplementedException();
        }

        protected override void CreatePlayable(out Playable playable)
        {
            throw new NotImplementedException();
        }

        public IList<Object> Bindings
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public void SetBindings(params Object[] bindings)
        {
            throw new NotImplementedException();
        }

        public static void GetBindingDetails(PlayableBinding binding, out string name, out Type type, out bool isMarkers)
        {
            throw new NotImplementedException();
        }

        public override void Destroy()
        {
            throw new NotImplementedException();
        }

        public override AnimancerState Clone(AnimancerPlayable root)
        {
            throw new NotImplementedException();
        }

        void ICopyable<PlayableAssetState>.CopyFrom(PlayableAssetState copyFrom)
        {
            throw new NotImplementedException();
        }

        protected override void AppendDetails(StringBuilder text, string separator)
        {
            throw new NotImplementedException();
        }
    }
}