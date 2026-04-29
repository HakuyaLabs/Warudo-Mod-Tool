using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SequenceNode : Node
    {
        public int ExitCount = 2;
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public void SetupExitPorts()
        {
            throw new NotImplementedException();
        }
    }
}