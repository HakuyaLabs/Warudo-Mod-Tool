using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public static class BakerUtilities
    {
        public static void ReduceKeyframes(AnimationCurve curve, float maxError)
        {
            throw new NotImplementedException();
        }

        public static Keyframe[] GetReducedKeyframes(AnimationCurve curve, float maxError)
        {
            throw new NotImplementedException();
        }

        public static void SetLoopFrame(float time, AnimationCurve curve)
        {
            throw new NotImplementedException();
        }

        public static void SetTangentMode(AnimationCurve curve)
        {
            throw new NotImplementedException();
        }

        public static Quaternion EnsureQuaternionContinuity(Quaternion lastQ, Quaternion q)
        {
            throw new NotImplementedException();
        }
    }

    public class BakerHumanoidQT
    {
        public AnimationCurve rotX, rotY, rotZ, rotW;
        public AnimationCurve posX, posY, posZ;
        public BakerHumanoidQT(string name)
        {
            throw new NotImplementedException();
        }

        public BakerHumanoidQT(Transform transform, AvatarIKGoal goal, string name)
        {
            throw new NotImplementedException();
        }

        public Quaternion EvaluateRotation(float time)
        {
            throw new NotImplementedException();
        }

        public Vector3 EvaluatePosition(float time)
        {
            throw new NotImplementedException();
        }

        public TQ Evaluate(float time)
        {
            throw new NotImplementedException();
        }

        public void GetCurvesFromClip(AnimationClip clip, Animator animator)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void SetIKKeyframes(float time, Avatar avatar, Transform root, float humanScale, Vector3 bodyPosition, Quaternion bodyRotation)
        {
            throw new NotImplementedException();
        }

        public void SetKeyframes(float time, Vector3 pos, Quaternion rot)
        {
            throw new NotImplementedException();
        }

        public void MoveLastKeyframes(float time)
        {
            throw new NotImplementedException();
        }

        public void SetLoopFrame(float time)
        {
            throw new NotImplementedException();
        }

        public void SetRootLoopFrame(float time)
        {
            throw new NotImplementedException();
        }

        public void MultiplyLength(AnimationCurve curve, float mlp)
        {
            throw new NotImplementedException();
        }

        public void SetCurves(ref AnimationClip clip, float maxError, float lengthMlp)
        {
            throw new NotImplementedException();
        }
    }

    public class BakerMuscle
    {
        public AnimationCurve curve;
        public BakerMuscle(int muscleIndex)
        {
            throw new NotImplementedException();
        }

        public void MultiplyLength(AnimationCurve curve, float mlp)
        {
            throw new NotImplementedException();
        }

        public void SetCurves(ref AnimationClip clip, float maxError, float lengthMlp)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void SetKeyframe(float time, float[] muscles)
        {
            throw new NotImplementedException();
        }

        public void SetLoopFrame(float time)
        {
            throw new NotImplementedException();
        }
    }

    public class BakerTransform
    {
        public Transform transform;
        public AnimationCurve posX, posY, posZ, rotX, rotY, rotZ, rotW;
        public BakerTransform(Transform transform, Transform root, bool recordPosition, bool isRootNode)
        {
            throw new NotImplementedException();
        }

        public void SetRelativeSpace(Vector3 position, Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        public void SetCurves(ref AnimationClip clip)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void ReduceKeyframes(float maxError)
        {
            throw new NotImplementedException();
        }

        public void SetKeyframes(float time)
        {
            throw new NotImplementedException();
        }

        public void AddLoopFrame(float time)
        {
            throw new NotImplementedException();
        }
    }
}