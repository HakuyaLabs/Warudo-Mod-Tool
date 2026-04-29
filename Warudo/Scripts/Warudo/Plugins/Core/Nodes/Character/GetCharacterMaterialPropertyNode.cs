using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using Warudo.Plugins.Core.Assets;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetCharacterMaterialPropertyNode : Node
    {
        public CharacterAsset Character;
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