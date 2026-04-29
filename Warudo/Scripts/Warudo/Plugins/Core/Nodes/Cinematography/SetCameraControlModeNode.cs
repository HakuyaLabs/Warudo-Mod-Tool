using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Cinematography;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetCameraControlModeNode : Node
    {
        public CameraAsset Camera;
        public CameraAsset.CameraControlMode ControlMode = CameraAsset.CameraControlMode.FreeLook;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}