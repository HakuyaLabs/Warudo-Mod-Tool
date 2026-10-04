using System;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Mixins
{
    public class PlaybackMixin : BehavioralMixin
    {
        public Action<float> OnSeek { get; set; }

        public Action OnPlay { get; set; }

        public Action OnPause { get; set; }

        public Action OnStop { get; set; }

        public void Enable(float length)
        {
            throw new NotImplementedException();
        }

        public void Disable()
        {
            throw new NotImplementedException();
        }

        public void Update(bool isPlaying, float currentTime)
        {
            throw new NotImplementedException();
        }

        public float Volume
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsHidden { get; set; }

        public bool IsLooping
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        protected bool PlaybackEnabled;
        protected bool HidePlaybackMixin() => throw new NotImplementedException();
        protected bool PlaybackSeekInRealtime;
        protected bool PlaybackIsPlaying;
        protected float PlaybackCurrentTime;
        protected float PlaybackLength;
        protected float PlaybackSeeker;
        protected float PlaybackVolume = 0.5f;
        protected bool HideVolume() => throw new NotImplementedException();
        protected bool PlaybackLoop;
        protected bool HideLoop() => throw new NotImplementedException();
        public void SetUseVolume(bool hide)
        {
            throw new NotImplementedException();
        }

        public void SetUseLoop(bool hide)
        {
            throw new NotImplementedException();
        }

        public void SetSeekInRealtime(bool realtime)
        {
            throw new NotImplementedException();
        }

        protected void PlaybackPlay()
        {
            throw new NotImplementedException();
        }

        protected void PlaybackPause()
        {
            throw new NotImplementedException();
        }

        protected void PlaybackStop()
        {
            throw new NotImplementedException();
        }

        public override void OnCreate()
        {
            throw new NotImplementedException();
        }
    }
}