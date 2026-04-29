using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class OffsetRotationListNode : Node
    {
        public Quaternion[] Rotations;
        public Vector3[] OffsetEulerAngles;
        public Quaternion[] OutputRotations()
        {
            throw new NotImplementedException();
        }
    }
}