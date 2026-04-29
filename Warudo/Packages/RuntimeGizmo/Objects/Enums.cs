using System;
using Object = UnityEngine.Object;

namespace RuntimeGizmos
{
    public enum TransformSpace
    {
        Global,
        Local
    }

    public enum TransformType
    {
        Move,
        Rotate,
        Scale,
        All
    }

    public enum TransformPivot
    {
        Pivot,
        Center
    }

    public enum Axis
    {
        None,
        X,
        Y,
        Z,
        Any
    }

    public enum CenterType
    {
        All,
        Solo
    }

    public enum ScaleType
    {
        FromPoint,
        FromPointOffset
    }
}