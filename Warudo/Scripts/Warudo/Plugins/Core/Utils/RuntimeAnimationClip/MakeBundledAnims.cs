using AssetsTools.NET;
using AssetsTools.NET.Extra;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace RuntimeAnimationClip
{
    public static class MakeBundledAnims
    {
        const int AnimationClipClassID = (int)AssetClassID.AnimationClip;
        const int GameObjectClassID = (int)AssetClassID.GameObject;
        const int TransformClassID = (int)AssetClassID.Transform;
        const int AnimatorClassID = (int)AssetClassID.Animator;
        const int SkinnedMeshRendererClassID = (int)AssetClassID.SkinnedMeshRenderer;
        static readonly System.Random R = new();
        public static readonly string[] AnimatorHumanBindings = {"MotionT.x", "MotionT.y", "MotionT.z", "MotionQ.x", "MotionQ.y", "MotionQ.z", "MotionQ.w", "RootT.x", "RootT.y", "RootT.z", "RootQ.x", "RootQ.y", "RootQ.z", "RootQ.w", "LeftFootT.x", "LeftFootT.y", "LeftFootT.z", "LeftFootQ.x", "LeftFootQ.y", "LeftFootQ.z", "LeftFootQ.w", "RightFootT.x", "RightFootT.y", "RightFootT.z", "RightFootQ.x", "RightFootQ.y", "RightFootQ.z", "RightFootQ.w", "LeftHandT.x", "LeftHandT.y", "LeftHandT.z", "LeftHandQ.x", "LeftHandQ.y", "LeftHandQ.z", "LeftHandQ.w", "RightHandT.x", "RightHandT.y", "RightHandT.z", "RightHandQ.x", "RightHandQ.y", "RightHandQ.z", "RightHandQ.w", "Spine Front-Back", "Spine Left-Right", "Spine Twist Left-Right", "Chest Front-Back", "Chest Left-Right", "Chest Twist Left-Right", "UpperChest Front-Back", "UpperChest Left-Right", "UpperChest Twist Left-Right", "Neck Nod Down-Up", "Neck Tilt Left-Right", "Neck Turn Left-Right", "Head Nod Down-Up", "Head Tilt Left-Right", "Head Turn Left-Right", "Left Eye Down-Up", "Left Eye In-Out", "Right Eye Down-Up", "Right Eye In-Out", "Jaw Close", "Jaw Left-Right", "Left Upper Leg Front-Back", "Left Upper Leg In-Out", "Left Upper Leg Twist In-Out", "Left Lower Leg Stretch", "Left Lower Leg Twist In-Out", "Left Foot Up-Down", "Left Foot Twist In-Out", "Left Toes Up-Down", "Right Upper Leg Front-Back", "Right Upper Leg In-Out", "Right Upper Leg Twist In-Out", "Right Lower Leg Stretch", "Right Lower Leg Twist In-Out", "Right Foot Up-Down", "Right Foot Twist In-Out", "Right Toes Up-Down", "Left Shoulder Down-Up", "Left Shoulder Front-Back", "Left Arm Down-Up", "Left Arm Front-Back", "Left Arm Twist In-Out", "Left Forearm Stretch", "Left Forearm Twist In-Out", "Left Hand Down-Up", "Left Hand In-Out", "Right Shoulder Down-Up", "Right Shoulder Front-Back", "Right Arm Down-Up", "Right Arm Front-Back", "Right Arm Twist In-Out", "Right Forearm Stretch", "Right Forearm Twist In-Out", "Right Hand Down-Up", "Right Hand In-Out", "LeftHand.Thumb.1 Stretched", "LeftHand.Thumb.Spread", "LeftHand.Thumb.2 Stretched", "LeftHand.Thumb.3 Stretched", "LeftHand.Index.1 Stretched", "LeftHand.Index.Spread", "LeftHand.Index.2 Stretched", "LeftHand.Index.3 Stretched", "LeftHand.Middle.1 Stretched", "LeftHand.Middle.Spread", "LeftHand.Middle.2 Stretched", "LeftHand.Middle.3 Stretched", "LeftHand.Ring.1 Stretched", "LeftHand.Ring.Spread", "LeftHand.Ring.2 Stretched", "LeftHand.Ring.3 Stretched", "LeftHand.Little.1 Stretched", "LeftHand.Little.Spread", "LeftHand.Little.2 Stretched", "LeftHand.Little.3 Stretched", "RightHand.Thumb.1 Stretched", "RightHand.Thumb.Spread", "RightHand.Thumb.2 Stretched", "RightHand.Thumb.3 Stretched", "RightHand.Index.1 Stretched", "RightHand.Index.Spread", "RightHand.Index.2 Stretched", "RightHand.Index.3 Stretched", "RightHand.Middle.1 Stretched", "RightHand.Middle.Spread", "RightHand.Middle.2 Stretched", "RightHand.Middle.3 Stretched", "RightHand.Ring.1 Stretched", "RightHand.Ring.Spread", "RightHand.Ring.2 Stretched", "RightHand.Ring.3 Stretched", "RightHand.Little.1 Stretched", "RightHand.Little.Spread", "RightHand.Little.2 Stretched", "RightHand.Little.3 Stretched", "SpineTDOF.x", "SpineTDOF.y", "SpineTDOF.z", "ChestTDOF.x", "ChestTDOF.y", "ChestTDOF.z", "UpperChestTDOF.x", "UpperChestTDOF.y", "UpperChestTDOF.z", "NeckTDOF.x", "NeckTDOF.y", "NeckTDOF.z", "HeadTDOF.x", "HeadTDOF.y", "HeadTDOF.z", "LeftUpperLegTDOF.x", "LeftUpperLegTDOF.y", "LeftUpperLegTDOF.z", "LeftLowerLegTDOF.x", "LeftLowerLegTDOF.y", "LeftLowerLegTDOF.z", "LeftFootTDOF.x", "LeftFootTDOF.y", "LeftFootTDOF.z", "LeftToesTDOF.x", "LeftToesTDOF.y", "LeftToesTDOF.z", "RightUpperLegTDOF.x", "RightUpperLegTDOF.y", "RightUpperLegTDOF.z", "RightLowerLegTDOF.x", "RightLowerLegTDOF.y", "RightLowerLegTDOF.z", "RightFootTDOF.x", "RightFootTDOF.y", "RightFootTDOF.z", "RightToesTDOF.x", "RightToesTDOF.y", "RightToesTDOF.z", "LeftShoulderTDOF.x", "LeftShoulderTDOF.y", "LeftShoulderTDOF.z", "LeftUpperArmTDOF.x", "LeftUpperArmTDOF.y", "LeftUpperArmTDOF.z", "LeftLowerArmTDOF.x", "LeftLowerArmTDOF.y", "LeftLowerArmTDOF.z", "LeftHandTDOF.x", "LeftHandTDOF.y", "LeftHandTDOF.z", "RightShoulderTDOF.x", "RightShoulderTDOF.y", "RightShoulderTDOF.z", "RightUpperArmTDOF.x", "RightUpperArmTDOF.y", "RightUpperArmTDOF.z", "RightLowerArmTDOF.x", "RightLowerArmTDOF.y", "RightLowerArmTDOF.z", "RightHandTDOF.x", "RightHandTDOF.y", "RightHandTDOF.z"};
        static readonly Dictionary<string, byte> AnimatorHumanAttributes = HumanAttrDictFromArray(AnimatorHumanBindings);
        public static void CreateAnimationsBundle(string blankBundlePath, ICollection<string> animPaths, string outputPath)
        {
            throw new NotImplementedException();
        }

        static Dictionary<string, byte> HumanAttrDictFromArray(string[] arr)
        {
            throw new NotImplementedException();
        }

        static bool IsAnimatorHumanAttribute(string attrName)
        {
            throw new NotImplementedException();
        }

        static byte GetAnimatorHumanAttribute(string attrName)
        {
            throw new NotImplementedException();
        }

        static bool IsAnimatorHumanBinding(byte attr)
        {
            throw new NotImplementedException();
        }

        static string GetAnimatorHumanBinding(byte attr)
        {
            throw new NotImplementedException();
        }

        static long RandomLong()
        {
            throw new NotImplementedException();
        }

        static SerializedAnimationClipRoot GetClip(string animPath)
        {
            throw new NotImplementedException();
        }

        static void GetFrameTimes(CurveCollection StreamedCurves, out Dictionary<float, uint> FrameTimes)
        {
            throw new NotImplementedException();
        }

        static bool IsSignificantSlope(float slope)
        {
            throw new NotImplementedException();
        }

        static bool IsSignificantDiff(float val1, float val2)
        {
            throw new NotImplementedException();
        }

        static void SplitStreamedAndConstantCurves(SerializedAnimationClip animationClip, out CurveCollection StreamedCurves, out CurveCollection ConstantCurves)
        {
            throw new NotImplementedException();
        }

        static void SplitQuaternionCurves(List<RotationCurve> QuaternionCurves, List<RotationCurve> StreamedCurves, List<RotationCurve> ConstantCurves)
        {
            throw new NotImplementedException();
        }

        static void SplitVector3Curves(List<Vector3Curve> Vector3Curves, List<Vector3Curve> StreamedCurves, List<Vector3Curve> ConstantCurves)
        {
            throw new NotImplementedException();
        }

        static void SplitFloatCurves(List<FloatCurve> FloatCurves, List<FloatCurve> StreamedCurves, List<FloatCurve> ConstantCurves)
        {
            throw new NotImplementedException();
        }

        static void RecalcTimeSettings(SerializedAnimationClip clip)
        {
            throw new NotImplementedException();
        }

        static void ConvertAnimationClip(SerializedAnimationClip clip, AssetTypeValueField baseField)
        {
            throw new NotImplementedException();
        }

        static bool VerifyCurveBindings(AssetTypeValueField genericBindingsArray, CurveCollection StreamedCurves, CurveCollection ConstantCurves, List<FloatCurve> clipFloatCurves)
        {
            throw new NotImplementedException();
        }

        static void GenerateIndexArray(AssetTypeValueField indexArray, AssetTypeValueField genericBindingsArray)
        {
            throw new NotImplementedException();
        }

        static void GenerateDoFArray(int startAttribute, int endAttribute, AssetTypeValueField DoFArrayArray, Dictionary<int, float> humanBindingDeltas)
        {
            throw new NotImplementedException();
        }

        static void GenerateTDoFArray(int startAttribute, int arraySize, AssetTypeValueField TDoFArrayArray, Dictionary<int, float> humanBindingDeltas)
        {
            throw new NotImplementedException();
        }

        static void FillValueArrayDelta(AssetTypeValueField valueArrayDeltaArray, CurveCollection CurveColl, Dictionary<int, float> humanBindingDeltas = null)
        {
            throw new NotImplementedException();
        }

        static void InitDefaultXForms(AssetTypeValueField muscleClip)
        {
            throw new NotImplementedException();
        }

        static void FillStartStopAndGoals(AssetTypeValueField muscleClip, List<FloatCurve> Curves)
        {
            throw new NotImplementedException();
        }

        static void AddUintItem(AssetTypeValueField arrayValueField, uint value)
        {
            throw new NotImplementedException();
        }

        static void AddUintItem(AssetTypeValueField arrayValueField, float value)
        {
            throw new NotImplementedException();
        }

        static void AddFloatItem(AssetTypeValueField arrayValueField, float value)
        {
            throw new NotImplementedException();
        }

        static uint AddTransformBindings(AssetTypeValueField genericBindingsArray, CurveCollection CurveColl)
        {
            throw new NotImplementedException();
        }

        static bool AddFloatCurveBindings(AssetTypeValueField genericBindingsArray, List<FloatCurve> FloatCurves, List<FloatCurve> clipFloatCurves, uint lastBinding = 0)
        {
            throw new NotImplementedException();
        }

        static bool AddGenericBinding(AssetTypeValueField genericBindingsArray, FloatCurve curve)
        {
            throw new NotImplementedException();
        }

        static void AddBinding(AssetTypeValueField genericBindingsArray, int classID, byte customType, uint path, uint attribute)
        {
            throw new NotImplementedException();
        }

        static void GenerateConstantClip(AssetTypeValueField constantClipArray, CurveCollection ConstantCurves)
        {
            throw new NotImplementedException();
        }

        static float GenerateStreamedClip(AssetTypeValueField streamedClipArray, CurveCollection StreamedCurves, Dictionary<float, uint> FrameTimes)
        {
            throw new NotImplementedException();
        }

        private record CurveCollection
        {
            public List<RotationCurve> RotationCurves = new();
            public List<Vector3Curve> EulerCurves = new();
            public List<Vector3Curve> PositionCurves = new();
            public List<Vector3Curve> ScaleCurves = new();
            public List<FloatCurve> FloatCurves = new();
            public int Count()
            {
                throw new NotImplementedException();
            }

            public bool HasTransformCurves()
            {
                throw new NotImplementedException();
            }
        }
    }
}