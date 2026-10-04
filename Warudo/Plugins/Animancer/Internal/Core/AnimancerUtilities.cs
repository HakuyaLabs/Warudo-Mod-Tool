using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using Object = UnityEngine.Object;
using System;

namespace Animancer
{
    public static partial class AnimancerUtilities
    {
        public const bool IsAnimancerPro = true;
        public static float Wrap01(float value)
        {
            throw new NotImplementedException();
        }

        public static float Wrap(float value, float length)
        {
            throw new NotImplementedException();
        }

        public static float Round(float value) => throw new NotImplementedException();
        public static float Round(float value, float multiple) => throw new NotImplementedException();
        public static bool IsFinite(this float value) => throw new NotImplementedException();
        public static bool IsFinite(this double value) => throw new NotImplementedException();
        public static bool IsFinite(this Vector2 value) => throw new NotImplementedException();
        public static string ToStringOrNull(object obj)
        {
            throw new NotImplementedException();
        }

        public static void CopyExactArray<T>(T[] copyFrom, ref T[] copyTo)
        {
            throw new NotImplementedException();
        }

        public static void Swap<T>(this T[] array, int a, int b)
        {
            throw new NotImplementedException();
        }

        public static bool IsNullOrEmpty<T>(this T[] array) => throw new NotImplementedException();
        public static bool SetLength<T>(ref T[] array, int length)
        {
            throw new NotImplementedException();
        }

        public static bool IsValid(this AnimancerNode node) => throw new NotImplementedException();
        public static bool IsValid(this ITransitionDetailed transition) => throw new NotImplementedException();
        public static AnimancerState CreateStateAndApply(this ITransition transition, AnimancerPlayable root = null)
        {
            throw new NotImplementedException();
        }

        public static void RemovePlayable(Playable playable, bool destroy = true)
        {
            throw new NotImplementedException();
        }

        public static bool HasEvent(IAnimationClipCollection source, string functionName)
        {
            throw new NotImplementedException();
        }

        public static bool HasEvent(AnimationClip clip, string functionName)
        {
            throw new NotImplementedException();
        }

        public static void CalculateThresholdsFromAverageVelocityXZ(this MixerState<Vector2> mixer)
        {
            throw new NotImplementedException();
        }

        public static void CopyParameterValue(Animator copyFrom, Animator copyTo, AnimatorControllerParameter parameter)
        {
            throw new NotImplementedException();
        }

        public static void CopyParameterValue(AnimatorControllerPlayable copyFrom, AnimatorControllerPlayable copyTo, AnimatorControllerParameter parameter)
        {
            throw new NotImplementedException();
        }

        public static object GetParameterValue(Animator animator, AnimatorControllerParameter parameter)
        {
            throw new NotImplementedException();
        }

        public static object GetParameterValue(AnimatorControllerPlayable playable, AnimatorControllerParameter parameter)
        {
            throw new NotImplementedException();
        }

        public static void SetParameterValue(Animator animator, AnimatorControllerParameter parameter, object value)
        {
            throw new NotImplementedException();
        }

        public static void SetParameterValue(AnimatorControllerPlayable playable, AnimatorControllerParameter parameter, object value)
        {
            throw new NotImplementedException();
        }

        public static NativeArray<T> CreateNativeReference<T>()
            where T : struct
        {
            throw new NotImplementedException();
        }

        public static NativeArray<TransformStreamHandle> ConvertToTransformStreamHandles(IList<Transform> transforms, Animator animator)
        {
            throw new NotImplementedException();
        }

        public static string GetUnsupportedMessage<T>(T value) => throw new NotImplementedException();
        public static ArgumentException CreateUnsupportedArgumentException<T>(T value) => throw new NotImplementedException();
        public static T AddAnimancerComponent<T>(this Animator animator)
            where T : Component, IAnimancerComponent
        {
            throw new NotImplementedException();
        }

        public static T GetOrAddAnimancerComponent<T>(this Animator animator)
            where T : Component, IAnimancerComponent
        {
            throw new NotImplementedException();
        }

        public static T GetComponentInParentOrChildren<T>(this GameObject gameObject)
            where T : class
        {
            throw new NotImplementedException();
        }

        public static bool GetComponentInParentOrChildren<T>(this GameObject gameObject, ref T component)
            where T : class
        {
            throw new NotImplementedException();
        }

        public static void Assert(bool condition, object message)
        {
            throw new NotImplementedException();
        }

        public static void SetDirty(Object target)
        {
            throw new NotImplementedException();
        }

        public static void EditModeSampleAnimation(this AnimationClip clip, Component component, float time = 0)
        {
            throw new NotImplementedException();
        }

        public static void EditModePlay(this AnimationClip clip, Component component)
        {
            throw new NotImplementedException();
        }
    }
}