using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Cinematography;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class ResetCameraTransformNode : Node
    {
        public CameraAsset Camera;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}