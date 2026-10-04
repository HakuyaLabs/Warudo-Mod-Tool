using System;
using System.Collections.Generic;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using System;
using Object = UnityEngine.Object;

namespace RuntimeAnimationClip
{
    public class SerializedAnimationClipRoot
    {
        public SerializedAnimationClip AnimationClip { get; set; }

        static readonly ISerializer _serializer = new SerializerBuilder().WithTypeConverter(new InfinityFloatConverter()).Build();
        static readonly IDeserializer _deserializer = new DeserializerBuilder().WithTypeConverter(new InfinityFloatConverter()).IgnoreUnmatchedProperties().Build();
        public string Serialize()
        {
            throw new NotImplementedException();
        }

        public static SerializedAnimationClipRoot Deserialize(string yaml)
        {
            throw new NotImplementedException();
        }
    }

    public class SerializedAnimationClip
    {
        public int m_ObjectHideFlags { get; set; }

        public FileReference m_CorrespondingSourceObject { get; set; }

        public FileReference m_PrefabInstance { get; set; }

        public FileReference m_PrefabAsset { get; set; }

        public string m_Name { get; set; }

        public int serializedVersion { get; set; }

        public int m_Legacy { get; set; }

        public int m_Compressed { get; set; }

        public int m_UseHighQualityCurve { get; set; }

        public List<RotationCurve> m_RotationCurves { get; set; }

        public List<object> m_CompressedRotationCurves { get; set; }

        public List<Vector3Curve> m_EulerCurves { get; set; }

        public List<Vector3Curve> m_PositionCurves { get; set; }

        public List<Vector3Curve> m_ScaleCurves { get; set; }

        public List<FloatCurve> m_FloatCurves { get; set; }

        public List<object> m_PPtrCurves { get; set; }

        public int m_SampleRate { get; set; }

        public int m_WrapMode { get; set; }

        public Bounds m_Bounds { get; set; }

        public ClipBindingConstant m_ClipBindingConstant { get; set; }

        public AnimationClipSettings m_AnimationClipSettings { get; set; }

        public List<object> m_EditorCurves { get; set; }

        public List<object> m_EulerEditorCurves { get; set; }

        public int m_HasGenericRootTransform { get; set; }

        public int m_HasMotionFloatCurves { get; set; }

        public List<object> m_Events { get; set; }
    }

    public class Bounds
    {
        public Vctr3 m_Center { get; set; }

        public Vctr3 m_Extent { get; set; }
    }

    public class ClipBindingConstant
    {
        public List<object> genericBindings { get; set; }

        public List<object> pptrCurveMapping { get; set; }
    }

    public class AnimationClipSettings
    {
        public int serializedVersion { get; set; }

        public FileReference m_AdditiveReferencePoseClip { get; set; }

        public float m_AdditiveReferencePoseTime { get; set; }

        public float m_StartTime { get; set; }

        public float m_StopTime { get; set; }

        public float m_OrientationOffsetY { get; set; }

        public float m_Level { get; set; }

        public float m_CycleOffset { get; set; }

        public int m_HasAdditiveReferencePose { get; set; }

        public int m_LoopTime { get; set; }

        public int m_LoopBlend { get; set; }

        public int m_LoopBlendOrientation { get; set; }

        public int m_LoopBlendPositionY { get; set; }

        public int m_LoopBlendPositionXZ { get; set; }

        public int m_KeepOriginalOrientation { get; set; }

        public int m_KeepOriginalPositionY { get; set; }

        public int m_KeepOriginalPositionXZ { get; set; }

        public float m_HeightFromFeet { get; set; }

        public int m_Mirror { get; set; }
    }

    public struct Vctr3
    {
        public float x;
        public float y;
        public float z;
    }

    public struct Qtrnn
    {
        public float x;
        public float y;
        public float z;
        public float w;
    }

    public class FileReference
    {
        public int fileID { get; set; }
    }

    public class FloatCurve
    {
        public Curve curve { get; set; }

        public string attribute { get; set; }

        public string path { get; set; }

        public int classID { get; set; }

        public FileReference script { get; set; }

        public uint bindingIndex { get; set; }
    }

    public class RotationCurve
    {
        public QuaternionCurve curve { get; set; }

        public string path { get; set; }

        public uint bindingIndex { get; set; }
    }

    public class Vector3Curve
    {
        public Vctr3Curve curve { get; set; }

        public string path { get; set; }

        public uint bindingIndex { get; set; }
    }

    public class Curve
    {
        public int serializedVersion { get; set; }

        public List<CurvePoint> m_Curve { get; set; }

        public int m_PreInfinity { get; set; }

        public int m_PostInfinity { get; set; }

        public int m_RotationOrder { get; set; }
    }

    public class QuaternionCurve
    {
        public int serializedVersion { get; set; }

        public List<QuaternionCurvePoint> m_Curve { get; set; }

        public int m_PreInfinity { get; set; }

        public int m_PostInfinity { get; set; }

        public int m_RotationOrder { get; set; }
    }

    public class Vctr3Curve
    {
        public int serializedVersion { get; set; }

        public List<Vector3CurvePoint> m_Curve { get; set; }

        public int m_PreInfinity { get; set; }

        public int m_PostInfinity { get; set; }

        public int m_RotationOrder { get; set; }
    }

    public class CurvePoint
    {
        public int serializedVersion { get; set; }

        public float time { get; set; }

        public float value { get; set; }

        public float inSlope { get; set; }

        public float outSlope { get; set; }

        public int tangentMode { get; set; }

        public int weightedMode { get; set; }

        public float inWeight { get; set; }

        public float outWeight { get; set; }
    }

    public class QuaternionCurvePoint
    {
        public int serializedVersion { get; set; }

        public float time { get; set; }

        public Qtrnn value { get; set; }

        public Qtrnn inSlope { get; set; }

        public Qtrnn outSlope { get; set; }

        public int tangentMode { get; set; }

        public int weightedMode { get; set; }

        public Qtrnn inWeight { get; set; }

        public Qtrnn outWeight { get; set; }
    }

    public class Vector3CurvePoint
    {
        public int serializedVersion { get; set; }

        public float time { get; set; }

        public Vctr3 value { get; set; }

        public Vctr3 inSlope { get; set; }

        public Vctr3 outSlope { get; set; }

        public int tangentMode { get; set; }

        public int weightedMode { get; set; }

        public Vctr3 inWeight { get; set; }

        public Vctr3 outWeight { get; set; }
    }

    public class InfinityFloatConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type)
        {
            throw new NotImplementedException();
        }

        public object ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer)
        {
            throw new NotImplementedException();
        }

        public void WriteYaml(IEmitter emitter, object value, Type type, ObjectSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}