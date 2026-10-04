using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Plugins.Core.Events;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class IsKeystrokePressedNode : Node
    {
        public Keystroke Keystroke;
        public bool RequireCtrl;
        public bool RequireShift;
        public bool RequireAlt;
        public bool RequireMeta;
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public bool IsPressed()
        {
            throw new NotImplementedException();
        }
    }
}