using System;
using System.IO;
using UnityEngine;

namespace Warudo.Core.Utils
{
    public static class ApplicationHelper
    {
        public static void SafeOpenURL(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                Debug.LogWarning("Attempted to open an empty or null URL.");
                return;
            }
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                Debug.LogWarning($"Attempted to open an invalid URL: {url}");
                return;
            }
            var uri = new Uri(url);
            if (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps && uri.Scheme != Uri.UriSchemeMailto && uri.Scheme != Uri.UriSchemeFile)
            {
                Debug.LogWarning($"Attempted to open a URL with unsupported scheme: {uri.Scheme}");
                return;
            }
            if (uri.Scheme == Uri.UriSchemeFile)
            {
                if ((!File.Exists(uri.LocalPath)) && (!Directory.Exists(uri.LocalPath)))
                {
                    Debug.LogWarning($"File does not exist: {uri.LocalPath}");
                    return;
                }
                var basePath = Context.PersistentDataManager.GetBasePath();
                var fullPath = Path.GetFullPath(Path.Combine(basePath, uri.LocalPath)).Replace("\\", "/");
                if (!fullPath.StartsWith(basePath, StringComparison.OrdinalIgnoreCase))
                {
                    Debug.LogWarning($"Attempted to open a file outside of the base path({basePath}): {fullPath}");
                    return;
                }
                var relativePath = Path.GetRelativePath(basePath, fullPath);
                if (relativePath.StartsWith(".") || relativePath.StartsWith("Binaries") || relativePath.StartsWith("Clients") || relativePath.StartsWith("Playground") || relativePath.StartsWith("Plugins"))
                {
                    Debug.LogWarning($"Attempted to open a file in a restricted directory: {relativePath}");
                    return;
                }
            }
            Application.OpenURL(url);
        }
    }
}