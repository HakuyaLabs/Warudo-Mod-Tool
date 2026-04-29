using System;
using System.Net;
using UnityEngine;
using Warudo.Core.Utils;

namespace Warudo.Core.Utils {
    public static class WebSocketHelpers {

        public static string CreateLocalHostUri(int port) {
            // Apparently sometimes localhost's dnsSafeHost is null or invalid, so we need a fallback
            var wsUri = $"ws://localhost:{port}";
            try {
                var result = new Uri(wsUri);
                var dnsSafeHost = result.DnsSafeHost;
                var ipAddress = ToIPAddress(dnsSafeHost);
                if (ipAddress == null) {
                    Debug.LogWarning($"Could not resolve localhost IP address (dnsSafeHost: {dnsSafeHost}), falling back to 127.0.0.1");
                    wsUri = $"ws://127.0.0.1:{port}";
                } else {
                    Debug.Log("Resolved localhost IP address to " + ipAddress);
                }
                static IPAddress ToIPAddress(string value) {
                    if (string.IsNullOrEmpty(value))
                        return null;
                    if (IPAddress.TryParse(value, out var address))
                        return address;
                    try {
                        return Dns.GetHostAddresses(value)[0];
                    } catch {
                        return null;
                    }
                }
            } catch (Exception e) {
                Log.Error("Failed to determine if wsUri is valid", e);
            }
            return wsUri;
        }
        
    }
}
