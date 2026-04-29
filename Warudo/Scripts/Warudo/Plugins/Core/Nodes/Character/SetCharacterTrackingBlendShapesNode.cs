using System.Collections.Generic;
using Warudo.Core.Attributes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetCharacterTrackingBlendShapesNode : OverrideCharacterBlendShapesNode
    {
        protected override Dictionary<string, Dictionary<string, float>> TargetBlendShapes => throw new NotImplementedException();
        protected override Dictionary<string, Dictionary<string, object>> TargetMaterialProperties => throw new NotImplementedException();
    }
}