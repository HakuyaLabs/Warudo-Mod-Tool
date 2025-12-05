using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swan;
using UnityEngine;
using Warudo.Core.Localization;
using Warudo.Core.Utils;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Warudo.Core.Server {
    public abstract class WebSocketService : WebSocketBehavior {

        public static void Clear() {
            MostRecentClientIds.Clear();
        }

        protected static ConcurrentDictionary<Type, string> MostRecentClientIds { get; } = new();

        protected string MostRecentClientId => MostRecentClientIds.GetValueOrDefault(GetType());

        protected abstract UniTask<bool> HandleAction(string action, JObject data);

        protected override async void OnMessage(MessageEventArgs args) {
            try {
                var message = JObject.Parse(args.Data);
                if (!message.ContainsKey("action")) {
                    Debug.LogWarning("Received data but action is null");
                    return;
                }
                var action = message.GetValue("action")!;
                var data = message.ContainsKey("data") ? message["data"] as JObject : null;

                try {
                    MostRecentClientIds[GetType()] = ID;
                    if (Flags.Get("DebugServiceMostRecentClient", false)) Debug.Log($"Most recent client for {GetType().Name} is now {ID}");
                    if (!await HandleAction(action.ToString(), data)) {
                        Debug.LogWarning($"Unknown action: {action}");
                    }
                } catch (Exception handlerException) {
                    Log.Error($"Failed to handle action: {action}", handlerException);
                    Send(GenerateError(action.ToString(), handlerException.ToString()));
                }
            }
            catch (Exception e) {
                Log.Error("Failed to handle message", e);
                throw;
            }
        }

        protected void Respond(string action, object o, bool log = true) {
            if (log && Application.isEditor && Flags.Get("DebugService", false)) Debug.Log("Sending message to " + ID + " / " + Context.UserEndPoint.Port);
            if (o is ILocalizable localizable) localizable.Localize();
            var message = GenerateMessage(action, o);
            if (log && Application.isEditor && Flags.Get("DebugService", false)) Debug.Log("Sending " + message);
            Send(message);
        }
        
        protected void SendToClient(string clientId, string action, object o, bool log = true) {
            Sessions.TryGetSession(clientId, out var session);
            if (session == null) {
                Debug.LogWarning($"Client {clientId} is no longer opened");
                return;
            }
            if (log && Application.isEditor && Flags.Get("DebugService", false)) Debug.Log("Sending message to " + clientId + " / " + session.Context.UserEndPoint.Port);
            if (o is ILocalizable localizable) localizable.Localize();
            var message = GenerateMessage(action, o);
            if (log && Application.isEditor && Flags.Get("DebugService", false)) Debug.Log("Sending " + message);
            session.Context.WebSocket.Send(message);
        }

        protected void Broadcast(string action, object o, bool log = true) {
            if (Sessions == null || Sessions.Count == 0) return;
            if (o is ILocalizable localizable) localizable.Localize();
            var message = GenerateMessage(action, o);
            if (log && Application.isEditor && Flags.Get("DebugService", false)) Debug.Log("Sending " + message);
            Sessions.Broadcast(message);
        }
        
        protected void Broadcast(string action, JObject jObject, bool log = true) {
            if (Sessions == null || Sessions.Count == 0) return;
            var message = new JObject {
                ["action"] = action,
                ["data"] = jObject
            }.ToString(Formatting.None);
            if (log && Application.isEditor && Flags.Get("DebugService", false)) Debug.Log("Sending " + message);
            Sessions.Broadcast(message);
        }
        
        protected void BroadcastRaw(string action, string json) {
            if (Sessions == null || Sessions.Count == 0) return;
            Sessions.Broadcast($"{{\"action\":\"{action}\",\"data\":\"{json}\"}}");
        }

        private string GenerateMessage(string action, object o) {
            return JsonConvert.SerializeObject(new Message {
                action = action,
                data = o
            }, Formatting.None);
        }
        
        private string GenerateError(string action, string error) {
            return JsonConvert.SerializeObject(new Message {
                action = action,
                error = error
            }, Formatting.None);
        }

        public bool HasConnectedSessions() {
            return Sessions?.Count > 0;
        }

        [Serializable]
        protected class Message {
            public string action;
            public string error;
            public object data;
        }
        
    }
}
