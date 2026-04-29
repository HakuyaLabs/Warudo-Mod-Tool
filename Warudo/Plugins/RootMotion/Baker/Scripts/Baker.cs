using UnityEngine;
using System.Collections;
using UnityEngine.Playables;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public abstract class Baker : MonoBehaviour
    {
        void OpenUserManual()
        {
            throw new NotImplementedException();
        }

        void OpenScriptReference()
        {
            throw new NotImplementedException();
        }

        void SupportGroup()
        {
            throw new NotImplementedException();
        }

        void ASThread()
        {
            throw new NotImplementedException();
        }

        public enum Mode
        {
            AnimationClips = 0,
            AnimationStates = 1,
            PlayableDirector = 2,
            Realtime = 3
        }

        public int frameRate = 30;
        public float keyReductionError = 0.01f;
        public Mode mode;
        public AnimationClip[] animationClips = new AnimationClip[0];
        public string[] animationStates = new string[0];
        public string saveToFolder = "Assets";
        public string appendName = "_Baked";
        public string saveName = "Baked Clip";
        public bool isBaking { get; private set; }

        public float bakingProgress { get; private set; }

        public Animator animator;
        public PlayableDirector director;
        public delegate void BakerDelegate(AnimationClip clip, float time);
        public BakerDelegate OnStartClip;
        public BakerDelegate OnUpdateClip;
        public class ClipSettings
        {
            public enum BasedUponRotation
            {
                Original = 0,
                BodyOrientation = 1,
            }

            public enum BasedUponY
            {
                Original = 0,
                CenterOfMass = 1,
                Feet = 2,
            }

            public enum BasedUponXZ
            {
                Original = 0,
                CenterOfMass = 1,
            }

            public bool loopTime;
            public bool loopBlend;
            public float cycleOffset;
            public bool loopBlendOrientation;
            public BasedUponRotation basedUponRotation;
            public float orientationOffsetY;
            public bool loopBlendPositionY;
            public BasedUponY basedUponY;
            public float level;
            public bool loopBlendPositionXZ;
            public BasedUponXZ basedUponXZ;
            public bool mirror;
        }

        public bool inheritClipSettings;
        public ClipSettings clipSettings;
        protected abstract Transform GetCharacterRoot();
        protected abstract void OnStartBaking();
        protected abstract void OnSetLoopFrame(float time);
        protected abstract void OnSetCurves(ref AnimationClip clip);
        protected abstract void OnSetKeyframes(float time, bool lastFrame);
        protected float clipLength { get; private set; }

        protected bool addLoopFrame;
        public void BakeClip()
        {
            throw new NotImplementedException();
        }

        public void StartBaking()
        {
            throw new NotImplementedException();
        }

        public void StopBaking()
        {
            throw new NotImplementedException();
        }
    }
}