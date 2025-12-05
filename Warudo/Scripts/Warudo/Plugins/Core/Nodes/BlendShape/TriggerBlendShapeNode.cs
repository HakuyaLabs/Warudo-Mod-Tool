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
    public class TriggerBlendShapeNode : ProcessBlendShapesNode
    {
        public string SourceBlendShape;
        public string TriggeredBlendShape;
        public float TriggerThreshold = 0.8f;
        public float TriggeredValue = 1f;
        public Dictionary<string, float> OutputBlendShapes()
        {
            throw new NotImplementedException();
        }
    }
}