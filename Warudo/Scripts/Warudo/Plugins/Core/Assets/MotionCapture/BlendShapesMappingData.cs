using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Data.Models;
using Warudo.Core.Serializations;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets.MotionCapture
{
    public class BlendShapesMappingData : StructuredData<GenericTrackerAsset>
    {
        public bool IsOpened { get; set; }

        public string TypeId = "BlendShapesMappingData";
        public MappingData[] BlendShapeMappings;
        public override bool ShouldEvaluateClientFunctions => throw new NotImplementedException();
        public void Update(Dictionary<string, float> inputBlendShapes)
        {
            throw new NotImplementedException();
        }

        public void Initialize(Dictionary<string, (float, float, float, float)> initialMappings)
        {
            throw new NotImplementedException();
        }

        protected override void OnAssignedParent()
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(SerializedStructuredData serialized)
        {
            throw new NotImplementedException();
        }

        protected override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        public class MessagePackObject
        {
            public float[] SourceValues;
            public float[] TargetValues;
        }
    }

    public class MappingData : StructuredData
    {
        public string BlendShape;
        public float SourceValueMin = 0f;
        public float SourceValueMax = 1f;
        public float TargetValueMin = 0f;
        public float TargetValueMax = 1f;
        public float SourceValue;
        public float TargetValue;
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}