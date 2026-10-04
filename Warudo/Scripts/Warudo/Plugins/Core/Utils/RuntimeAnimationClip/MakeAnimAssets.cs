using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace RuntimeAnimationClip
{
    public class AnimBuilder
    {
        const int TransformClassID = 4;
        const int AnimatorClassID = 95;
        const int SkinnedMeshRendererClassID = 137;
        public AnimCurveVector3 rootPosition = null;
        public AnimCurveQuaternion rootRotation = null;
        public readonly Dictionary<byte, AnimCurveFloat> humanoidCurves = new();
        public readonly AnimCurveVector3[] humanIKPositions = new AnimCurveVector3[4];
        public readonly AnimCurveQuaternion[] humanIKRotations = new AnimCurveQuaternion[4];
        public readonly Dictionary<string, AnimCurveTransformVector3> transformPosCurves = new();
        public readonly Dictionary<string, AnimCurveTransformQuaternion> transformRotCurves = new();
        public readonly Dictionary<string, AnimCurveTransformVector3> transformScaleCurves = new();
        public readonly Dictionary<string, AnimCurveTransformVector3> transformEulerRotCurves = new();
        public readonly Dictionary<(string smrPath, string bsName), AnimCurveFloat> blendshapeCurves = new();
        public readonly Dictionary<(string path, int typeID, string attribute), AnimCurveBool> booleanCurves = new();
        public string name = "New AnimationClip";
        public int sampleRate = 60;
        public float maxTime { get; private set; }

        public float startTime = 0;
        public float endTime = 0;
        public bool mirror = false;
        public bool loopTime = false;
        public bool loopPose = false;
        public float cycleOffset = 0;
        public bool loopBlendOrientation = false;
        public RTOBasedUpon keepOriginalOrientation = RTOBasedUpon.Original;
        public float orientationOffsetY = 0;
        public bool loopBlendPositionY = false;
        public RTPYBasedUpon keepOriginalPositionY = RTPYBasedUpon.Original;
        public float level = 0;
        public bool loopBlendPositionXZ = false;
        public RTPXZBasedUpon keepOriginalPositionXZ = RTPXZBasedUpon.Original;
        public void SetHumanPositionCurve(float[] timeStamps, Vector3[] rootPositions)
        {
            throw new NotImplementedException();
        }

        public void RemoveHumanPositionCurve()
        {
            throw new NotImplementedException();
        }

        public void SetHumanRotationCurve(float[] timeStamps, Quaternion[] rootRotations)
        {
            throw new NotImplementedException();
        }

        public void RemoveHumanRotationCurve()
        {
            throw new NotImplementedException();
        }

        public void AddMuscleCurve(float[] timeStamps, int muscleIdx, float[] muscleValues)
        {
            throw new NotImplementedException();
        }

        public void RemoveMuscleCurve(int muscleIdx)
        {
            throw new NotImplementedException();
        }

        public void AddBlendShapeCurve(float[] timeStamps, string smrPath, string bsName, float[] bsValues)
        {
            throw new NotImplementedException();
        }

        public void RemoveBlendShapeCurve(string smrPath, string bsName)
        {
            throw new NotImplementedException();
        }

        public void AddTransformPosCurve(float[] timeStamps, string path, Vector3[] posValues)
        {
            throw new NotImplementedException();
        }

        public void RemoveTransformPosCurve(string path)
        {
            throw new NotImplementedException();
        }

        public void AddTransformScaleCurve(float[] timeStamps, string path, Vector3[] scaleValues)
        {
            throw new NotImplementedException();
        }

        public void RemoveTransformScaleCurve(string path)
        {
            throw new NotImplementedException();
        }

        public void AddTransformQuatRotCurve(float[] timeStamps, string path, Quaternion[] rotValues)
        {
            throw new NotImplementedException();
        }

        public void RemoveTransformQuatRotCurve(string path)
        {
            throw new NotImplementedException();
        }

        public void AddTransformEulerRotCurve(float[] timeStamps, string path, Vector3[] rotValues, byte rotationOrder = 4)
        {
            throw new NotImplementedException();
        }

        public void RemoveTransformEulerRotCurve(string path)
        {
            throw new NotImplementedException();
        }

        public void AddIKCurveT(float[] timeStamps, HumanIKGoals target, Vector3[] posValues)
        {
            throw new NotImplementedException();
        }

        public void RemoveIKCurveT(HumanIKGoals target)
        {
            throw new NotImplementedException();
        }

        public void AddIKCurveQ(float[] timeStamps, HumanIKGoals target, Quaternion[] rotValues)
        {
            throw new NotImplementedException();
        }

        public void RemoveIKCurveQ(HumanIKGoals target)
        {
            throw new NotImplementedException();
        }

        public void AddBooleanCurve(float[] timeStamps, string path, int typeID, string attribute, bool[] boolValues)
        {
            throw new NotImplementedException();
        }

        public void RemoveBooleanCurve(string path, int typeID, string attribute)
        {
            throw new NotImplementedException();
        }

        public void ExportAsset(string filepath)
        {
            throw new NotImplementedException();
        }

        void UpdateMaxTime(float newLastTime)
        {
            throw new NotImplementedException();
        }

        void UpdateMaxTime()
        {
            throw new NotImplementedException();
        }

        void GenerateAnimationClipCurves(SerializedAnimationClip animationClip)
        {
            throw new NotImplementedException();
        }

        void GenerateAnimationClipSettings(SerializedAnimationClip animationClip)
        {
            throw new NotImplementedException();
        }

        public enum RTOBasedUpon
        {
            Original,
            BodyOrientation
        }

        public enum RTPYBasedUpon
        {
            Original,
            CenterOfMass,
            Feet
        }

        public enum RTPXZBasedUpon
        {
            Original,
            CenterOfMass
        }

        public enum HumanIKGoals
        {
            LeftFoot,
            RightFoot,
            LeftHand,
            RightHand
        }
    }

    public abstract class AnimCurve<T>
    {
        public float[] TimeStamps;
        public T[] Values;
        protected AnimCurve(float[] timestamps, T[] values)
        {
            throw new NotImplementedException();
        }

        public abstract void AddCurve(SerializedAnimationClip animationClip, string attribute, int classID, string path);
        static protected FloatCurve GetNewFloatCurve(int classID, string path, string attribute)
        {
            throw new NotImplementedException();
        }

        static protected CurvePoint GetNewCurvePoint(float time, float value)
        {
            throw new NotImplementedException();
        }
    }

    public class AnimCurveFloat : AnimCurve<float>
    {
        public AnimCurveFloat(float[] timestamps, float[] values) : base(timestamps, values)
        {
            throw new NotImplementedException();
        }

        public override void AddCurve(SerializedAnimationClip animationClip, string attribute, int classID, string path = "")
        {
            throw new NotImplementedException();
        }
    }

    public class AnimCurveBool : AnimCurve<bool>
    {
        public AnimCurveBool(float[] timestamps, bool[] values) : base(timestamps, values)
        {
            throw new NotImplementedException();
        }

        public override void AddCurve(SerializedAnimationClip animationClip, string attribute, int classID, string path = "")
        {
            throw new NotImplementedException();
        }
    }

    public class AnimCurveVector3 : AnimCurve<Vector3>
    {
        public AnimCurveVector3(float[] timestamps, Vector3[] values) : base(timestamps, values)
        {
            throw new NotImplementedException();
        }

        public override void AddCurve(SerializedAnimationClip animationClip, string attribute, int classID, string path = "")
        {
            throw new NotImplementedException();
        }
    }

    public class AnimCurveQuaternion : AnimCurve<Quaternion>
    {
        public AnimCurveQuaternion(float[] timestamps, Quaternion[] values) : base(timestamps, values)
        {
            throw new NotImplementedException();
        }

        public override void AddCurve(SerializedAnimationClip animationClip, string attribute, int classID, string path = "")
        {
            throw new NotImplementedException();
        }
    }

    public class AnimCurveTransformVector3 : AnimCurve<Vector3>
    {
        public AnimCurveTransformVector3(float[] timestamps, Vector3[] values, byte rotOrder = 0) : base(timestamps, values)
        {
            throw new NotImplementedException();
        }

        public override void AddCurve(SerializedAnimationClip animationClip, string attribute, int classID = 4, string path = "")
        {
            throw new NotImplementedException();
        }
    }

    public class AnimCurveTransformQuaternion : AnimCurve<Quaternion>
    {
        public AnimCurveTransformQuaternion(float[] timestamps, Quaternion[] values) : base(timestamps, values)
        {
            throw new NotImplementedException();
        }

        public override void AddCurve(SerializedAnimationClip animationClip, string attribute, int classID = 4, string path = "")
        {
            throw new NotImplementedException();
        }
    }
}