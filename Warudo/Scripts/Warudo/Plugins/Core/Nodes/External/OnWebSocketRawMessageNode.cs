using Cysharp.Threading.Tasks;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using Warudo.Plugins.Core.Events;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.External
{
    public class OnWebSocketRawMessageNode : Node
    {
        public string Info = "ON_WEBSOCKET_RAW_MESSAGE_INFO".Localized();
        public string RawMessage() => throw new NotImplementedException();
        public Continuation Exit;
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }
    }
}