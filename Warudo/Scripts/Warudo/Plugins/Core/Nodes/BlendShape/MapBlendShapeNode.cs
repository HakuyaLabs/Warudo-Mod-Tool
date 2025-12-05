using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class MapBlendShapeNode : ProcessBlendShapesNode
    {
        public string SourceBlendShape;
        public string MappedBlendShape;
        public float MappedValueMin = 0f;
        public float MappedValueMax = 1f;
        public bool Clamp = true;
        public Dictionary<string, float> OutputBlendShapes()
        {
            throw new NotImplementedException();
        }
    }
}