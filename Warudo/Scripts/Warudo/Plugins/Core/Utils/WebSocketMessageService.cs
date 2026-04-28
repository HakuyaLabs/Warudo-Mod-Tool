using Warudo.Plugins.Core.Events;
using WebSocketSharp;
using WebSocketSharp.Server;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Utils
{
    public class WebSocketMessageService : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}