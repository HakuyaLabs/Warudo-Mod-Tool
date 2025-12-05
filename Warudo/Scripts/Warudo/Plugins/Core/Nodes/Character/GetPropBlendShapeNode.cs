using Cysharp.Threading.Tasks;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Assets.Prop;
using Warudo.Plugins.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetPropBlendShapeNode : Node
    {
        public PropAsset Prop;
        public string TargetSkinnedMesh;
        public async UniTask<AutoCompleteList> AutoCompleteSkinnedMesh()
        {
            throw new NotImplementedException();
        }

        public string BlendShape;
        protected async UniTask<AutoCompleteList> AutoCompleteBlendShapes()
        {
            throw new NotImplementedException();
        }

        public float OutputValue()
        {
            throw new NotImplementedException();
        }
    }
}