using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class MultiGateNode : Node
    {
        public int ExitCount = 2;
        public bool Loop = true;
        public int CurrentExit = 1;
        public int CurrentExitOutput() => throw new NotImplementedException();
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Reset()
        {
            throw new NotImplementedException();
        }

        public void SetupExitPorts()
        {
            throw new NotImplementedException();
        }
    }
}