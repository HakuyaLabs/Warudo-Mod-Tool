using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class ConstrainBlendShapeNode : ProcessBlendShapesNode
    {
        public Dictionary<string, float> ConstraintsBlendShapes;
        public string ConstraintBlendShape;
        public string[] ConstrainedBlendShapes;
        public float ConstraintValueMin = 0f;
        public float ConstraintValueMax = 1f;
        public float ConstrainedValueMax = 1f;
        public float ConstrainedValueMin = 0f;
        public Dictionary<string, float> OutputBlendShapes()
        {
            throw new NotImplementedException();
        }
    }
}