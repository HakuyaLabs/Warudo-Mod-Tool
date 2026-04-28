using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Assets.Cinematography;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetCameraOrbitNode : Node
    {
        public CameraAsset Camera;
        bool IsCameraOrbitMode()
        {
            throw new NotImplementedException();
        }

        float GetOrbitX()
        {
            throw new NotImplementedException();
        }

        float GetOrbitY()
        {
            throw new NotImplementedException();
        }

        Vector3 GetOrbitOffset()
        {
            throw new NotImplementedException();
        }
    }
}