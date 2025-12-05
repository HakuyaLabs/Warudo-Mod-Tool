using Cysharp.Threading.Tasks;
using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.Utilities;
using EmbedIO.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Warudo.Core.Localization;
using Warudo.Core.Plugins;
using Warudo.Core.Scenes;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;

namespace Warudo.Core.Server {
    public class WebApiController : EmbedIO.WebApi.WebApiController {
        [Serializable]
        public class AboutData {
            public bool licensed;
            public string version;
            public List<PluginType> plugins;
            public string translator;
            public List<FeatureStatusData> features;
        }
        protected override void OnBeforeHandler()
        {
            if (Context.Instance.IsApiSecurityEnabled() && !Request.Url.LocalPath.StartsWith("/api/thumbnail"))
            {
                string reqAuthToken = Request.Headers["X-Token"];
                bool isAuth = Context.Instance.CheckApiAuthToken(reqAuthToken);
                if (!isAuth)
                {
                    throw HttpException.Unauthorized();
                }
            }
            base.OnBeforeHandler();
        }

        [Route(HttpVerbs.Get, "/about")]
        public async Task<AboutData> GetAboutData() {
            await UniTask.SwitchToMainThread();
            return new AboutData {
                licensed = Context.LicenseManager.IsLicensed,
                version = Application.version,
                plugins = Context.PluginManager.GetPlugins().Select(it => it.Type.PluginType.Clone()).Select(it => { it.Localize(); return it; }).ToList(),
                translator = Context.LocalizationManager.GetTranslator(),
                features = Context.PluginManager.GetPlugins().SelectMany(it => it.GetFeatureStatusData().Select(it =>
                {
                    it.Name = it.Name.Localized();
                    return it;
                })).ToList()
            };
        }
        
        [Route(HttpVerbs.Get, "/scenes")]
        public SceneEntry[] GetScenes() {
            return Context.SceneManager.GetScenes();
        }

        [Route(HttpVerbs.Post, "/scenes/{name}")]
        public async Task CreateScene(string name) {
            await UniTask.SwitchToMainThread();
            if (Context.SceneManager.HasScene(name) || string.IsNullOrWhiteSpace(name)) {
                throw HttpException.BadRequest();
            }
            await Context.SceneManager.SaveScene(name, Context.SceneManager.LoadDefaultSceneTemplate(), true);
        }
        
        [Route(HttpVerbs.Delete, "/scenes/{name}")]
        public async Task DeleteScene(string name) {
            await UniTask.SwitchToMainThread();
            if (!Context.SceneManager.HasScene(name)) {
                throw HttpException.NotFound();
            }
            Context.SceneManager.DeleteScene(name);
        }
        
        [Route(HttpVerbs.Put, "/openedScene/reload")]
        public async Task ReloadOpenedScene() {
            await UniTask.SwitchToMainThread();
            if (Context.OpenedScene == null) {
                throw HttpException.BadRequest();
            }
            await Context.OpenedScene.Reload();
        }
        
        [Route(HttpVerbs.Put, "/openedScene/restart")]
        public async Task RestartOpenedScene() {
            await UniTask.SwitchToMainThread();
            if (Context.OpenedScene == null) {
                throw HttpException.BadRequest();
            }
            await Context.OpenedScene.Restart();
        }

        [Route(HttpVerbs.Put, "/openedScene/save")]
        public async Task SaveOpenedScene() {
            await UniTask.SwitchToMainThread();
            if (Context.OpenedScene == null) {
                throw HttpException.BadRequest();
            }
            await Context.OpenedScene.Save();
        }
        
        [Serializable]
        public class SaveOpenedSceneAsRequest {
            public string name;
        }
        
        [Route(HttpVerbs.Post, "/openedScene/saveAs")]
        public async Task SaveOpenedSceneAs([JsonData] SetOpenedSceneRequest req) {
            await UniTask.SwitchToMainThread();
            if (Context.SceneManager.HasScene(req.name)) {
                throw HttpException.BadRequest();
            }
            if (Context.OpenedScene == null) {
                throw HttpException.BadRequest();
            }
            await Context.OpenedScene.SaveAs(req.name);
        }
        
        [Route(HttpVerbs.Get, "/openedScene")]
        public async Task<SerializedScene> GetOpenedScene(string name) {
            await UniTask.SwitchToMainThread();
            try {
                if (Context.OpenedScene == null) {
                    await UniTask.WaitUntil(() => Context.OpenedScene != null);
                }
                return Context.OpenedScene!.Serialize().Also(it => it.Localize());
            } catch (Exception e) {
                Log.Error("Failed to get opened scene", e);
                throw;
            }
        }
        
        [Serializable]
        public class SetOpenedSceneRequest {
            public string name;
        }

        [Route(HttpVerbs.Put, "/openedScene")]
        public async Task SetOpenedScene([JsonData] SetOpenedSceneRequest req) {
            await UniTask.SwitchToMainThread();
            await Context.SceneManager.OpenScene(req.name);
        }

        [Route(HttpVerbs.Put, "/actions/openDataFolder")]
        public async Task OpenDataFolder() {
            await UniTask.SwitchToMainThread();
            var url = "file:///" + Application.streamingAssetsPath;
            Debug.Log("Launching " + url);
            Application.OpenURL(url);
        }
        
        [Route(HttpVerbs.Put, "/actions/openLogsFolder")]
        public async Task OpenLogsFolder() {
            await UniTask.SwitchToMainThread();
            var url = $"file:///{Environment.GetEnvironmentVariable("USERPROFILE")!.Replace("\\", "/")}/AppData/LocalLow/HakuyaLabs/Warudo";
            Debug.Log("Launching " + url);
            Application.OpenURL(url);
        }
        
        [Route(HttpVerbs.Put, "/actions/help")]
        public async Task Help() {
            await UniTask.SwitchToMainThread();
            var url = "HELP_URL".Localized();
            Debug.Log("Launching " + url);
            Application.OpenURL(url);
        }

        [Serializable]
        public class ExternalLinkRequest {
            public string link;
        }

        [Route(HttpVerbs.Put, "/actions/external-link")]
        public async Task SetOpenedScene([JsonData] ExternalLinkRequest req) {
            await UniTask.SwitchToMainThread();
            Debug.Log("Launching " + req.link);
            ApplicationHelper.SafeOpenURL(req.link);
        }
        
        [Route(HttpVerbs.Put, "/actions/qq")]
        public async Task QQ() {
            await UniTask.SwitchToMainThread();
            var url = "http://warudo.app/qq";
            Debug.Log("Launching " + url);
            Application.OpenURL(url);
        }
        
        [Route(HttpVerbs.Put, "/actions/discord")]
        public async Task Discord() {
            await UniTask.SwitchToMainThread();
            var url = "https://discord.gg/warudo";
            Debug.Log("Launching " + url);
            Application.OpenURL(url);
        }
        
        [Route(HttpVerbs.Put, "/actions/bilibili")]
        public async Task Bilibili() {
            await UniTask.SwitchToMainThread();
            var url = "https://space.bilibili.com/3494370867153597";
            Debug.Log("Launching " + url);
            Application.OpenURL(url);
        }
        
        [Route(HttpVerbs.Put, "/actions/twitter")]
        public async Task Twitter() {
            await UniTask.SwitchToMainThread();
            var url = "https://twitter.com/hakuyalabs";
            Debug.Log("Launching " + url);
            Application.OpenURL(url);
        }

        [Route(HttpVerbs.Put, "/actions/savePlugins")]
        public async void SavePlugins() {
            await UniTask.SwitchToMainThread();
            Context.PluginManager.SavePluginData();
        }
        
        [Route(HttpVerbs.Put, "/plugins/{id}/actions/openSupportUrl")]
        public async Task OpenSupportUrl(string id) {
            await UniTask.SwitchToMainThread();
            var plugin = Context.PluginManager.GetPlugin(id);
            if (plugin == null) {
                throw HttpException.NotFound();
            }
            var url = plugin.Type.PluginType.supportUrl;
            if (string.IsNullOrWhiteSpace(url)) {
                return;
            }
            Debug.Log("Launching " + url);
            ApplicationHelper.SafeOpenURL(url);
        }

        [Route(HttpVerbs.Get, "/thumbnail")]
        public async Task ResolveThumbnail([QueryField] string uri) {
            await UniTask.SwitchToMainThread();
            try
            {
                // var timer = new BenchmarkTimer($"Resolve thumbnail for {uri}");
                var parsedUri = new Uri(uri);
                var path = parsedUri.LocalPath.TrimStart('/');
                if (path.StartsWith("Scenes"))
                {
                    var sceneName = path.Substring("Scenes/".Length);
                    sceneName = sceneName.Substring(0, sceneName.LastIndexOf('.'));
                    path = $"Scenes/{Context.SceneManager.GetSafeSceneName(sceneName)}.png";
                    parsedUri = new Uri(parsedUri.Scheme + "://" + parsedUri.Authority + "/" + path);
                }
                if (path.StartsWith("Binaries") || (path.StartsWith("Clients") && !path.StartsWith("Clients/Thumbnails")) || path.StartsWith("Plugins") || path.StartsWith("Playground"))
                {
                    throw HttpException.Forbidden();
                }
                var bytes = await Context.ResourceManager.ResolveResourceUriThumbnail(parsedUri);
                // timer.Time();
                if (bytes == null) {
                    throw HttpException.NotFound();
                }
                HttpContext.Response.ContentType = "image/png";
                await using var stream = HttpContext.OpenResponseStream();
                await stream.WriteAsync(bytes, 0, bytes.Length);
            } catch (Exception e) {
                if (e is not HttpException) {
                    Log.UserError("Failed to resolve thumbnail for " + uri, e);
                }
                throw;
            }
        }
        
    }
}
