using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using Object = UnityEngine.Object;
using System;

namespace Animancer
{
    public partial class AnimancerPlayable : PlayableBehaviour, IEnumerator, IPlayableWrapper, IAnimationClipCollection
    {
        public static float DefaultFadeDuration
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        internal PlayableGraph _Graph;
        public PlayableGraph Graph => throw new NotImplementedException();
        internal Playable _RootPlayable;
        internal Playable _LayerMixer;
        Playable IPlayableWrapper.Playable => throw new NotImplementedException();
        IPlayableWrapper IPlayableWrapper.Parent => throw new NotImplementedException();
        float IPlayableWrapper.Weight => throw new NotImplementedException();
        int IPlayableWrapper.ChildCount => throw new NotImplementedException();
        AnimancerNode IPlayableWrapper.GetChild(int index) => throw new NotImplementedException();
        public LayerList Layers { get; private set; }

        public StateDictionary States { get; private set; }

        public IAnimancerComponent Component { get; private set; }

        public int CommandCount => throw new NotImplementedException();
        public DirectorUpdateMode UpdateMode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public float Speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool KeepChildrenConnected
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool SkipFirstFade
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public static AnimancerPlayable Create()
        {
            throw new NotImplementedException();
        }

        public static AnimancerPlayable Create(PlayableGraph graph) => throw new NotImplementedException();
        protected static T Create<T>(PlayableGraph graph, T template)
            where T : AnimancerPlayable, new() => throw new NotImplementedException();
        public override void OnPlayableCreate(Playable playable)
        {
            throw new NotImplementedException();
        }

        public static void SetNextGraphName(string name)
        {
            throw new NotImplementedException();
        }

        public bool TryGetOutput(out PlayableOutput output)
        {
            throw new NotImplementedException();
        }

        public void CreateOutput(IAnimancerComponent animancer) => throw new NotImplementedException();
        public void CreateOutput(Animator animator, IAnimancerComponent animancer)
        {
            throw new NotImplementedException();
        }

        public void InsertOutputPlayable(Playable playable)
        {
            throw new NotImplementedException();
        }

        public AnimationScriptPlayable InsertOutputJob<T>(T data)
            where T : struct, IAnimationJob
        {
            throw new NotImplementedException();
        }

        public bool IsValid => throw new NotImplementedException();
        public void DestroyGraph()
        {
            throw new NotImplementedException();
        }

        public bool DestroyOutput()
        {
            throw new NotImplementedException();
        }

        public override void OnPlayableDestroy(Playable playable)
        {
            throw new NotImplementedException();
        }

        public List<IDisposable> Disposables => throw new NotImplementedException();
        ~AnimancerPlayable()
        {
            throw new NotImplementedException();
        }

        public bool ApplyAnimatorIK
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool ApplyFootIK
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public object GetKey(AnimationClip clip) => throw new NotImplementedException();
        public AnimancerState Play(AnimationClip clip) => throw new NotImplementedException();
        public AnimancerState Play(AnimancerState state) => throw new NotImplementedException();
        public AnimancerState Play(AnimationClip clip, float fadeDuration, FadeMode mode = default) => throw new NotImplementedException();
        public AnimancerState Play(AnimancerState state, float fadeDuration, FadeMode mode = default)
        {
            throw new NotImplementedException();
        }

        public AnimancerState Play(ITransition transition) => throw new NotImplementedException();
        public AnimancerState Play(ITransition transition, float fadeDuration, FadeMode mode = default)
        {
            throw new NotImplementedException();
        }

        public AnimancerState TryPlay(object key) => throw new NotImplementedException();
        public AnimancerState TryPlay(object key, float fadeDuration, FadeMode mode = default) => throw new NotImplementedException();
        public AnimancerState Stop(IHasKey hasKey) => throw new NotImplementedException();
        public AnimancerState Stop(object key)
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public bool IsPlaying(IHasKey hasKey) => throw new NotImplementedException();
        public bool IsPlaying(object key) => throw new NotImplementedException();
        public bool IsPlaying()
        {
            throw new NotImplementedException();
        }

        public bool IsPlayingClip(AnimationClip clip)
        {
            throw new NotImplementedException();
        }

        public float GetTotalWeight()
        {
            throw new NotImplementedException();
        }

        public void GatherAnimationClips(ICollection<AnimationClip> clips) => throw new NotImplementedException();
        bool IEnumerator.MoveNext()
        {
            throw new NotImplementedException();
        }

        object IEnumerator.Current => throw new NotImplementedException();
        void IEnumerator.Reset()
        {
            throw new NotImplementedException();
        }

        public bool IsGraphPlaying
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        public void UnpauseGraph()
        {
            throw new NotImplementedException();
        }

        public void PauseGraph()
        {
            throw new NotImplementedException();
        }

        public void Evaluate() => throw new NotImplementedException();
        public void Evaluate(float deltaTime) => throw new NotImplementedException();
        public string GetDescription()
        {
            throw new NotImplementedException();
        }

        public void AppendDescription(StringBuilder text)
        {
            throw new NotImplementedException();
        }

        public void AppendInternalDetails(StringBuilder text, string sectionPrefix, string itemPrefix)
        {
            throw new NotImplementedException();
        }

        public void RequirePreUpdate(IUpdatable updatable)
        {
            throw new NotImplementedException();
        }

        public void RequirePostUpdate(IUpdatable updatable)
        {
            throw new NotImplementedException();
        }

        public void CancelPreUpdate(IUpdatable updatable) => throw new NotImplementedException();
        public void CancelPostUpdate(IUpdatable updatable) => throw new NotImplementedException();
        public int PreUpdatableCount => throw new NotImplementedException();
        public int PostUpdatableCount => throw new NotImplementedException();
        public IUpdatable GetPreUpdatable(int index) => throw new NotImplementedException();
        public IUpdatable GetPostUpdatable(int index) => throw new NotImplementedException();
        public static AnimancerPlayable Current { get; private set; }

        public static float DeltaTime { get; private set; }

        public ulong FrameID { get; private set; }

        public override void PrepareFrame(Playable playable, FrameData info)
        {
            throw new NotImplementedException();
        }

        public static bool IsRunningPostUpdate(AnimancerPlayable animancer) => throw new NotImplementedException();
        private class PostUpdate : PlayableBehaviour
        {
            public static PostUpdate Create(AnimancerPlayable root)
            {
                throw new NotImplementedException();
            }

            public override void OnPlayableCreate(Playable playable) => throw new NotImplementedException();
            public bool IsConnected
            {
                get => throw new NotImplementedException();
                set
                {
                    throw new NotImplementedException();
                }
            }

            public override void PrepareFrame(Playable playable, FrameData info)
            {
                throw new NotImplementedException();
            }
        }
    }
}