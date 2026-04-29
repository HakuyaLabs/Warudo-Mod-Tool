using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using Warudo.Plugins.Core.Assets;
using Warudo.Plugins.Core.Assets.Prop;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetPropMaterialPropertyNode : Node
    {
        public PropAsset Prop;
        public MaterialPropertyAccessorMixin MaterialPropertyAccessor;
        public object OutputValue()
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }
    }
}