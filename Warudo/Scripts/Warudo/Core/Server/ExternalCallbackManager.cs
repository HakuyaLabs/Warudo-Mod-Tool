using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Warudo.Core.Localization;
using WebSocketSharp;

namespace Warudo.Core.Server
{
    public class ExternalCallbackManager : IDisposable
    {
        public class ExternalCallback
        {
            public string callbackId { get; }
            public string url { get; }
            public string warudoLink { get; }

            public ExternalCallback(string callbackId)
            {
                this.callbackId = callbackId;
                url = $"http://localhost:{Service.Port}/callback/{callbackId}";
                warudoLink = $"warudo://callback/{callbackId}";
            }
        }

        public class ExternalWebSocket
        {
            public string channelId { get; }
            public string websocketUrl { get; }

            public ExternalWebSocket(string channelId)
            {
                this.channelId = channelId;
                websocketUrl = "ws://0.0.0.0:19190";
            }
        }

        [Serializable]
        public class ExternalNNGMessage
        {
            public string callbackId;
            public Dictionary<string, string> data;
        }

        private const string NNGUrl = "ipc:///tmp/warudo-link-callback.ipc";
        private const string LogPrefix = "[WarudoLink-Callbacks]";

        private NNG.Socket socket;
        private Thread thread;
        private volatile bool running;
        private bool disposed;

        public delegate Task<bool> ReceiveCallBack(Dictionary<string, string> result);
        public delegate void SendWebSocketData(byte[] data);
        public delegate Task ReceiveWebSocket(SendWebSocketData Send, MessageEventArgs args);

        private readonly ConcurrentDictionary<string, ReceiveCallBack> callbackHandlers = new();
        private readonly ConcurrentDictionary<string, string> callbackPageDescription = new();
        private readonly ConcurrentDictionary<string, ReceiveWebSocket> wsHandlers = new();

        private const string CallbackHtml = @"<!DOCTYPE html>
<html>
<head>
  <meta charset=""UTF-8"" />
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
  <title>Warudo</title>
  <style>
    * {
      box-sizing: border-box;
    }

    html,
    body {
      margin: 0;
      min-height: 100%;
      font-family:
        Inter, ui-sans-serif, system-ui, -apple-system, BlinkMacSystemFont,
        ""Segoe UI"", ""Microsoft YaHei"", ""PingFang SC"", sans-serif;
      color: #24292f;
    }

    body {
      min-height: 100vh;
      display: grid;
      place-items: center;
      padding: 24px;
    }

    .content {
      width: min(720px, 100%);
      text-align: center;
    }

    .status-icon {
      width: 64px;
      height: 64px;
      display: grid;
      place-items: center;
      margin: 0 auto 22px;
      border-radius: 50%;
      font-size: 32px;
      font-weight: 700;
      background: #ddf4ff;
      color: #0969da;
    }

    .status-icon.success {
      background: #dafbe1;
      color: #1a7f37;
    }

    .status-icon.error {
      background: #ffebe9;
      color: #cf222e;
    }

    h1 {
      margin: 0 0 10px;
      font-size: clamp(26px, 5vw, 34px);
      line-height: 1.2;
    }

    .message {
      margin: 0;
      color: #57606a;
      line-height: 1.7;
      font-size: 15px;
    }
  </style>
</head>
<body>
  <main class=""content"">
    <div id=""statusIcon"" class=""status-icon {iserror}"">{icon}</div>

    <h1 id=""title"">{title}</h1>
    <p id=""message"" class=""message"">
      {message}
    </p>
  </main>
</body>
</html>
";

        private static string Unique(string prefix) => $"{prefix}-{Guid.NewGuid():N}";

        public ExternalCallback CreateExternalCallback(string pluginId, ReceiveCallBack handler)
        {
            if (pluginId == null) throw new ArgumentNullException(nameof(pluginId));
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            string cid = Unique(pluginId);
            callbackHandlers[cid] = handler;
            return new ExternalCallback(cid);
        }

        public ExternalCallback CreateExternalCallback(string pluginId, ReceiveCallBack handler, string description)
        {
            if (pluginId == null) throw new ArgumentNullException(nameof(pluginId));
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            string cid = Unique(pluginId);
            callbackHandlers[cid] = handler;
            callbackPageDescription[cid] = description;
            return new ExternalCallback(cid);
        }

        public void RevokeExternalCallback(string callbackId)
        {
            if (callbackId != null){ 
                callbackHandlers.TryRemove(callbackId, out _); 
                callbackPageDescription.TryRemove(callbackId, out _);
            }
        }

        public void RevokeExternalCallback(ExternalCallback callback)
        {
            if (callback != null) RevokeExternalCallback(callback.callbackId);
        }

        public void RevokeAllCallbacksFromPluginId(string pluginId)
        {
            RemoveByPrefix(callbackHandlers, pluginId);
            RemoveByPrefix(callbackPageDescription, pluginId);
        }

        public ExternalCallbackManager()
        {
            int result = NNG.nng_rep0_open(out socket);
            if (result != 0)
            {
                Debug.LogError($"{LogPrefix} Failed to open Rep0 socket: {result}");
                return;
            }

            result = NNG.nng_listen(socket, NNGUrl, IntPtr.Zero, 0);
            if (result != 0)
            {
                Debug.LogError($"{LogPrefix} Failed to listen on {NNGUrl}: {result}");
                NNG.nng_close(socket);
                socket = default;
                return;
            }

            Debug.Log($"{LogPrefix} Starting {NNGUrl}");
            running = true;
            thread = new Thread(RunNNG)
            {
                IsBackground = true,
                Name = "Warudo External Callback NNG"
            };
            thread.Start();
        }

        public void Dispose()
        {
            if (disposed) return;
            disposed = true;
            running = false;

            if (socket.IsValid)
            {
                NNG.nng_close(socket);
                socket = default;
            }

            if (thread != null)
            {
                if (!thread.Join(1000))
                {
                    Debug.LogWarning($"{LogPrefix} NNG thread did not stop within one second.");
                }
                thread = null;
            }

            callbackHandlers.Clear();
            wsHandlers.Clear();
        }

        public ExternalWebSocket CreateWebSocketChannel(string pluginId, ReceiveWebSocket handler)
        {
            if (pluginId == null) throw new ArgumentNullException(nameof(pluginId));
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            string cid = Unique(pluginId);
            wsHandlers[cid] = handler;
            return new ExternalWebSocket(cid);
        }

        public void RemoveWebSocketChannel(string cid)
        {
            if (cid != null) wsHandlers.TryRemove(cid, out _);
        }

        public void RemoveWebSocketChannel(ExternalWebSocket externalWebSocket)
        {
            if (externalWebSocket != null) RemoveWebSocketChannel(externalWebSocket.channelId);
        }

        public void RemoveAllWebSocketChannelFromPluginId(string pluginId)
        {
            RemoveByPrefix(wsHandlers, pluginId);
        }

        private static void RemoveByPrefix<T>(ConcurrentDictionary<string, T> dictionary, string prefix)
        {
            if (prefix == null) return;
            string fullPrefix = prefix + "-";
            foreach (string key in dictionary.Keys)
            {
                if (key.StartsWith(fullPrefix, StringComparison.Ordinal)) dictionary.TryRemove(key, out _);
            }
        }

        private async Task<bool> InvokeExternalCallbackAsync(string callbackId, Dictionary<string, string> args)
        {
            if (!callbackHandlers.TryGetValue(callbackId, out ReceiveCallBack callback)) return false;
            if (await callback(args)) { 
                callbackHandlers.TryRemove(callbackId, out _); 
                callbackPageDescription.TryRemove(callbackId, out _);
            }
            return true;
        }

        private async Task InvokeExternalCallbackSafelyAsync(string callbackId, Dictionary<string, string> args)
        {
            try
            {
                await InvokeExternalCallbackAsync(callbackId, args);
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
        }

        public void CallWebSocketChannel(string channelId, MessageEventArgs args, SendWebSocketData sender)
        {
            if (wsHandlers.TryGetValue(channelId, out ReceiveWebSocket callback))
            {
                _ = InvokeWebSocketSafelyAsync(callback, sender, args);
            }
        }

        private static async Task InvokeWebSocketSafelyAsync(
            ReceiveWebSocket callback,
            SendWebSocketData sender,
            MessageEventArgs args)
        {
            try
            {
                await callback(sender, args);
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
        }

        private void RunNNG()
        {
            Debug.Log($"{LogPrefix} Running on {NNGUrl}");
            while (running)
            {
                var data = IntPtr.Zero;
                bool received = false;
                try
                {
                    var result = NNG.nng_recvmsg(socket, out data, 0);
                    if (result != 0)
                    {
                        if (running) Debug.LogError($"{LogPrefix} Failed to receive NNG message: {result}");
                        continue;
                    }

                    received = true;
                    if (NNG.nng_msg_len(data).ToUInt64() == 0) continue;

                    string message = NNG.GetMessageUtf8(data);
                    var payload = JsonConvert.DeserializeObject<ExternalNNGMessage>(message);
                    if (payload?.callbackId == null)
                    {
                        Debug.LogWarning($"{LogPrefix} Ignored an invalid callback message.");
                        continue;
                    }

                    _ = InvokeExternalCallbackSafelyAsync(payload.callbackId, payload.data);
                }
                catch (Exception exception)
                {
                    Debug.LogException(exception);
                }
                finally
                {
                    if (received && data != IntPtr.Zero)
                    {
                        NNG.nng_msg_clear(data);
                        int result = NNG.nng_sendmsg(socket, data, 0);
                        if (result == 0)
                        {
                            data = IntPtr.Zero;
                        }
                        else if (running)
                        {
                            Debug.LogError($"{LogPrefix} Failed to send NNG reply: {result}");
                        }
                    }

                    if (data != IntPtr.Zero) NNG.nng_msg_free(data);
                }
            }
        }

        public class WebCallbackController : WebApiController
        {
            [Route(HttpVerbs.Get, "/{callbackId}")]
            public async Task GetCallback(string callbackId)
            {
                HttpContext.Response.ContentType = "text/html; charset=utf-8";
                var manager = Context.ExternalCallbackManager;
                byte[] data;
                if (manager != null)
                {
                    var query = HttpContext.Request.QueryString;
                    var result = query.AllKeys
                        .Where(key => key != null)
                        .ToDictionary(key => key, key => query[key] ?? string.Empty);
                    string description;
                    if (!manager.callbackPageDescription.TryGetValue(callbackId, out description))
                    {
                        description = "";
                    }
                    if (await manager.InvokeExternalCallbackAsync(callbackId, result))
                    {
                        
                        data = BuildCallbackPage(false, description);
                    }
                    else
                    {
                        HttpContext.Response.StatusCode = 400;
                        data = BuildCallbackPage(true);
                    }
                }
                else
                {
                    HttpContext.Response.StatusCode = 503;
                    data = BuildCallbackPage(true);
                }

                HttpContext.Response.ContentLength64 = data.Length;
                await HttpContext.Response.OutputStream.WriteAsync(data, 0, data.Length);
            }

            private static byte[] BuildCallbackPage(bool isError, string description = "")
            {
                string title = (isError
                    ? "CALLBACK_RECEIVED_HTML_TITLE_FAILED"
                    : (description == "" ? "CALLBACK_RECEIVED_HTML_TITLE_SUCCESS": description)).Localized();
                string message = (isError
                    ? "CALLBACK_RECEIVED_HTML_MESSAGE_FAILED"
                    : "CALLBACK_RECEIVED_HTML_MESSAGE_SUCCESS").Localized();

                string html = CallbackHtml
                    .Replace("{title}", title)
                    .Replace("{message}", message)
                    .Replace("{icon}", isError ? "×" : "↩")
                    .Replace("{iserror}", isError ? "error" : string.Empty);
                return Encoding.UTF8.GetBytes(html);
            }
        }
    }
}

