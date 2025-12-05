using Warudo.Core.Graphs;
using Warudo.Core.Attributes;
using Warudo.Plugins.Core.Assets.Prop;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SendMessageToScreenBrowserNode : Node
    {
        public ScreenAsset Screen;
        public string Message;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}