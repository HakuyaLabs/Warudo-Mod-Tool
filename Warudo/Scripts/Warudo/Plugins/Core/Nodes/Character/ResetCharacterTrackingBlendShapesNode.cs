using Cysharp.Threading.Tasks;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class ResetCharacterTrackingBlendShapesNode : Node
    {
        public CharacterAsset Character;
        public bool ApplyToAllSkinnedMeshes = true;
        public string TargetSkinnedMesh = "Body";
        protected bool DisableTargetSkinnedMesh() => throw new NotImplementedException();
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        public async UniTask<AutoCompleteList> AutoCompleteSkinnedMesh()
        {
            throw new NotImplementedException();
        }
    }
}