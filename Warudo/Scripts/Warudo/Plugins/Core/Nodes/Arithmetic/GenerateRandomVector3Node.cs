using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GenerateRandomVector3Node : Node
    {
        public ModeType Mode = ModeType.WithinBoundingBox;
        public enum ModeType
        {
            WithinBoundingBox,
            WithinSphere
        }

        public Vector3 ValueMin = -Vector3.one;
        public Vector3 ValueMax = Vector3.one;
        public float SphereRadius = 1f;
        public Vector3 Result()
        {
            throw new NotImplementedException();
        }
    }
}