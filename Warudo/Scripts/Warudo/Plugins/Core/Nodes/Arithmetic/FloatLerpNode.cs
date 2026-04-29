using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class FloatLerpNode : Node
    {
        public float A;
        public float SourceValueMin = 0f;
        public float SourceValueMax = 1f;
        public float MappedValueMin = 0f;
        public float MappedValueMax = 1f;
        public bool ClampMappedValue = true;
        public float Result()
        {
            throw new NotImplementedException();
        }
    }
}