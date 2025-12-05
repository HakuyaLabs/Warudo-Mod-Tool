using System;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Plugins.Core.Assets.Cinematography;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetMainCameraNode : Node
    {
        public CameraAsset Camera()
        {
            throw new NotImplementedException();
        }

        protected CorePlugin CorePlugin => throw new NotImplementedException();
    }
}