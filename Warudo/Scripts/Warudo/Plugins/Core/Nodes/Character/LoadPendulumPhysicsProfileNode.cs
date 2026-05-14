using System.IO;
using System.Linq;
using Cysharp.Threading.Tasks;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.MotionCapture;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class LoadPendulumPhysicsProfileNode : Node
    {
        public GenericTrackerAsset Tracker;
        public string PendulumPhysicsProfile;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}