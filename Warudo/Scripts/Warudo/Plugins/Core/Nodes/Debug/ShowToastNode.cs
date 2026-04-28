using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Server;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class ShowToastNode : Node
    {
        public string Header;
        public string Caption;
        public ToastSeverity Severity;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}