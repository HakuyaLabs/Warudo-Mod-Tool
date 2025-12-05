using Cysharp.Threading.Tasks;
using DG.Tweening.Plugins.Core.PathCore;
using EmbedIO;
using EmbedIO.Actions;
using EmbedIO.Files;
using EmbedIO.WebApi;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Events;
using Warudo.Core.Graphs;
using Warudo.Core.Licensing;
using Warudo.Core.Localization;
using Warudo.Core.ModUtils;
using Warudo.Core.Persistence;
using Warudo.Core.Plugins;
using Warudo.Core.Rendering;
using Warudo.Core.Resource;
using Warudo.Core.Scenes;
using Warudo.Core.Serializations;
using Warudo.Core.Server;
using Warudo.Core.UI;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Utils;
using WebSocketSharp.Server;
using Object = UnityEngine.Object;
using Scene = Warudo.Core.Scenes.Scene;
using SceneManager = Warudo.Core.Scenes.SceneManager;
using WebApiController = Warudo.Core.Server.WebApiController;

namespace Warudo.Core {
    public class Context : SingletonMonoBehavior<Context> {
        
        public static bool IsDestroyed => Instance == null;
        
        public static PluginManager PluginManager => Instance.pluginManager;
        public static ResourceManager ResourceManager => Instance.resourceManager;
        public static PersistentDataManager PersistentDataManager => Instance.persistentDataManager;
        public static SceneManager SceneManager => Instance.sceneManager;
        public static AutoCompleteManager AutoCompleteManager => Instance.autoCompleteManager;
        public static LocalizationManager LocalizationManager => Instance.localizationManager;
        public static RenderingPipelineManager RenderingPipelineManager => Instance.renderingPipelineManager;
        public static LicenseManager LicenseManager => Instance.licenseManager;

        public static TypeRegistry TypeRegistry => Instance.typeRegistry; 

        public static NodeTypeRegistry NodeTypeRegistry => Instance.nodeTypeRegistry;

        public static AssetTypeRegistry AssetTypeRegistry => Instance.assetTypeRegistry;
        public static PluginTypeRegistry PluginTypeRegistry => Instance.pluginTypeRegistry;
        public static StructuredDataTypeRegistry StructuredDataTypeRegistry => Instance.structuredDataTypeRegistry;
        
        public static EntityStore EntityStore => Instance.entityStore;
        public static EventBus EventBus => Instance.eventBus;
        public static PluginRouter PluginRouter => Instance.pluginRouter;

        public static Toast Toast => Instance.toast;
        
        public static Scene OpenedScene => Instance.openedScene;
        
        public static Service Service => Instance != null ? Instance.service : null;
        public static ServiceMessageQueue ServiceMessageQueue => Instance.serviceMessageQueue;

        private readonly PluginManager pluginManager = new();
        private readonly ResourceManager resourceManager = new();
        private readonly PersistentDataManager persistentDataManager = new();
        private readonly SceneManager sceneManager = new();
        private readonly AutoCompleteManager autoCompleteManager = new();
        private readonly LocalizationManager localizationManager = new();
        private readonly RenderingPipelineManager renderingPipelineManager = new();
        private readonly LicenseManager licenseManager = new();

        private readonly TypeRegistry typeRegistry = new();
        private readonly NodeTypeRegistry nodeTypeRegistry = new();
        private readonly AssetTypeRegistry assetTypeRegistry = new();
        private readonly PluginTypeRegistry pluginTypeRegistry = new();
        private readonly StructuredDataTypeRegistry structuredDataTypeRegistry = new();

        private readonly EntityStore entityStore = new();
        private readonly EventBus eventBus = new();
        private readonly PluginRouter pluginRouter = new();
        private readonly Toast toast = new();

        private Scene openedScene;

        private WebServer httpServer;
        private WebSocketServer wsServer;
        private Service service;
        private ServiceMessageQueue serviceMessageQueue = new();
        private bool startedServer;
        private string apiAuthToken;

        public Context()
        {
            string[] commandLines = System.Environment.GetCommandLineArgs();
            if (Application.isEditor || (commandLines.Any(it => it.ToLowerInvariant() == "--disable-api-security")))
            {
                apiAuthToken = null;
            } 
            else
            {
                apiAuthToken = Guid.NewGuid().ToString("N").ToUpperInvariant();
                Debug.Log($"One Time API Auth Token: {apiAuthToken}");
            }
            if (Application.isEditor || (commandLines.Any(it => it.ToLowerInvariant() == "--enable-webrtc")))
            {
                Debug.Log($"WARNING: WebView is enabled WebRTC");
            }
        }

        public async UniTask InitializeComponents() {
            await typeRegistry.Initialize();
            toast.Initialize();
            renderingPipelineManager.Initialize();
            ModReferences.Initialize();
            DataConverters.Initialize();

        }

        public void StartServer() {
            if (startedServer) {
                throw new Exception("Server already started");
            }
            Debug.Log("Starting server");
            WebSocketService.Clear();
            Service.Clear();

            httpServer = CreateHttpServer($"http://localhost:{Service.Port}");
            httpServer.Start();

            var wsUri = WebSocketHelpers.CreateLocalHostUri(19053);
            wsServer = new WebSocketServer(wsUri);
            wsServer.AddWebSocketService<Service>("/", it => {
                if (Context.Instance.IsApiSecurityEnabled())
                {
                    it.Protocol = apiAuthToken;
                }
                service = it;
            });
            wsServer.Start();

            startedServer = true;
        }

        public void StopServer() {
            if (!startedServer) return;
            Debug.Log("Stopping server");

            httpServer?.Dispose();
            wsServer?.Stop();
            startedServer = false;
        }

        public async UniTask OpenScene(SerializedScene serializedScene) {
            openedScene?.Destroy();
            PluginManager.GetPlugins().ForEach(it => {
                try {
                    it.OnSceneUnloaded(openedScene);
                } catch (Exception e) {
                    Log.Error($"OnSceneUnloaded for plugin {it.PluginId} threw an exception", e);
                }
            });
            
            ObjectPools.Dispose();
            
            // Clear message queue
            serviceMessageQueue.Clear();

            // Load the first in-build scene, which is our base scene
            await UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);

            openedScene = new Scene();
            openedScene.Deserialize(serializedScene);
            
            PluginManager.GetPlugins().ForEach(it => {
                try {
                    it.OnSceneLoaded(openedScene, serializedScene);
                } catch (Exception e) {
                    Log.Error($"OnSceneLoaded for plugin {it.PluginId} threw an exception", e);
                }
            });

            openedScene.LoadedTime = Time.realtimeSinceStartup;
            
            service?.BroadcastOpenedScene();
        }

        protected override void Dispose() {
            StopServer();
            openedScene?.Destroy();
            pluginManager.Dispose();

            resourceManager.Dispose();
            autoCompleteManager.Dispose();
            localizationManager.Dispose();
            typeRegistry.Dispose();
            nodeTypeRegistry.Dispose();
            assetTypeRegistry.Dispose();
            pluginTypeRegistry.Dispose();
            structuredDataTypeRegistry.Dispose();
            entityStore.Dispose();


            ObjectPools.Dispose();
            ModReferences.Dispose();
        }

        private void FixedUpdate() {
            if (OpenedScene == null) return;

            foreach (var it in PluginManager.GetPlugins()) it.FixedUpdate();
            OpenedScene.FixedUpdate();
        }
        
        private List<StructuredData> deadStructuredData = new();

        private void Update() {
            if (OpenedScene == null) return;
            
            foreach (var it in PluginManager.GetPlugins()) it.PreUpdate();
            OpenedScene.PreUpdate();

            foreach (var it in PluginManager.GetPlugins()) it.Update();
            OpenedScene.Update();

            foreach (var it in PluginManager.GetPlugins()) it.PostUpdate();
            OpenedScene.PostUpdate();
            
            deadStructuredData.Clear();
            foreach (var kv in EntityStore.GetStructuredDataEntities()) {
                var sd = kv.Value;
                if (sd.Parent != null && !sd.Parent.Created) {
                    if (Application.isEditor) {
                        Debug.LogWarning($"Parent of {sd.GetType().Name} is no longer valid. Destroying.");
                    }
                    deadStructuredData.Add(sd);
                }
                kv.Value.Update();
            }
            foreach (var sd in deadStructuredData) {
                sd.Destroy();
                EntityStore.Remove(sd.Id);
            }

            serviceMessageQueue.Update();
            OpenedScene.ActiveFrames++;
        }

        private async void LateUpdate() {
            if (OpenedScene == null) return;
            
            foreach (var it in PluginManager.GetPlugins()) it.LateUpdate();
            OpenedScene.LateUpdate();
            
            foreach (var it in PluginManager.GetPlugins()) it.PostLateUpdate();
            OpenedScene.PostLateUpdate();

            await UniTask.WaitForEndOfFrame(this);
            foreach (var it in PluginManager.GetPlugins()) it.EndOfFrame();
            OpenedScene.EndOfFrame();
            renderingPipelineManager.OnEndOfFrame();
        }
        
        private void OnDrawGizmos() {
            if (!Application.isPlaying || OpenedScene == null) return;
            
            OpenedScene.OnDrawGizmos();
        }
        
        private void OnRenderObject() {
            if (!Application.isPlaying || OpenedScene == null) return;
            
            OpenedScene.OnDrawGizmos();
        }

        public void OnConfirmedQuit() {
            pluginManager.OnApplicationQuit();
        }
        public bool CheckApiAuthToken(string apiToken) {
            if (apiAuthToken == null)
            {
                return true;
            }
            if (string.IsNullOrWhiteSpace(apiToken)) {
                return false;
            }
            return apiAuthToken == apiToken.ToUpperInvariant();
        }

        public string GetApiAuthToken(Assembly assembly) {
            if (!IsApiSecurityEnabled()) return null;
            if (assembly == typeof(Context).Assembly || assembly == Context.Instance.CoreAssembly || assembly == Context.Instance.PluginsCoreAssembly)
            {
                return apiAuthToken;
            }
            return "";
        }

        public bool IsApiSecurityEnabled() {
            return apiAuthToken != null;
        }

        private static async Task UseNewtonsoftJsonSerializer(IHttpContext context, object data) {
            context.Response.ContentType = MimeType.Json;
            await using var text = context.OpenResponseText(new UTF8Encoding(false));
            await text.WriteAsync(JsonConvert.SerializeObject(data)).ConfigureAwait(false);
        }

        class MapAndProtectStaticFileNameModule: WebModuleBase
        {
            public MapAndProtectStaticFileNameModule(string baseRoute) : base(baseRoute)
            {
            }
            public override bool IsFinalHandler => false;
            protected override async Task OnRequestAsync(IHttpContext context)
            {
                var originalPath = context.RequestedPath;
                if (originalPath.StartsWith("/Scenes"))
                {
                    var fileName = originalPath.Substring("/Scenes".Length + 1);
                    if (fileName.EndsWith(".png"))
                    {
                        fileName = fileName.Substring(0, fileName.Length - 4);
                        fileName = Context.SceneManager.GetSafeSceneName(EmbedIO.Utilities.UrlEncodedDataParser.Parse(fileName, false).AllKeys[0]);
                        var bytes = await File.ReadAllBytesAsync(Application.streamingAssetsPath + $"/Scenes/{fileName}.png");
                        context.Response.ContentType = "image/png";
                        await context.Response.OutputStream.WriteAsync(bytes, 0, bytes.Length);
                        context.SetHandled();
                        return;
                    }
                }
                if (originalPath.StartsWith("/Binaries") || (originalPath.StartsWith("/Clients") &&  !originalPath.StartsWith("/Clients/Thumbnails")) || originalPath.StartsWith("/Plugins") || originalPath.StartsWith("/Playground"))
                {
                    context.Response.StatusCode = 403;
                    await context.SendStringAsync("Access to this resource is forbidden.", MimeType.PlainText, Encoding.UTF8);
                    context.SetHandled();
                    return;
                }
                await Task.CompletedTask;
            }
        }
        
        private static WebServer CreateHttpServer(string url) {
            var server = new WebServer(o => o
                    .WithUrlPrefix(url)
                    .WithMode(HttpListenerMode.EmbedIO))
                .WithLocalSessionManager()
                .WithCors()
                .WithWebApi("/api", serializer: UseNewtonsoftJsonSerializer, (WebApiModule m) => m
                    .WithController<WebApiController>()
                    .HandleUnhandledException(UnhandledExceptionResponse))
                .WithModule(new MapAndProtectStaticFileNameModule("/"))
                .WithStaticFolder("/", Application.streamingAssetsPath, true, m => m
                    .WithContentCaching(true)) // Add static files after other modules to avoid conflicts
                .WithModule(new ActionModule("/", HttpVerbs.Any, ctx => ctx.SendDataAsync(new { Message = "Error" })));
            
            // Listen for state changes.
            server.StateChanged += (s, e) => Debug.Log("Webserver new state: " + e.NewState);

            return server;
        }
        
        private static Task UnhandledExceptionResponse(IHttpContext context, Exception exception) {
            Log.Error("Exception when processing HTTP request: " + context.Request.HttpMethod + " " + context.Request.Url.PathAndQuery, exception);
            return context.SendStringAsync(exception.PrettyPrint(),
                MimeType.PlainText,
                Encoding.UTF8);
        }

    }

    public class SingletonMonoBehavior<T> : MonoBehaviour where T : MonoBehaviour {
        private static T instance;
        private bool shouldStart = true;

        public static T Instance {
            get => instance ? instance : instance = FindObjectOfType(typeof(T)) as T;
            set => instance = value;
        }

        protected void Awake() {
            if (instance != null) {
                Debug.LogWarning("Singleton " + typeof(T) + " already exists. Destroying the new one");
                Destroy(this);
                shouldStart = false;
                return;
            }
            DontDestroyOnLoad(gameObject);
            instance = this as T;
            Debug.Log("Creating singleton " + typeof(T));
            OnAwake();
        }

        protected virtual void OnAwake() {
        }

        protected void Start() {
            if (shouldStart) OnStart();
        }
        
        protected virtual void OnStart() {
        }

        protected void OnDestroy() {
            Dispose();
            if (instance == this) {
                Debug.Log("Destroying singleton " + typeof(T));
                instance = null;
            }
        }
        
        protected virtual void Dispose() {
        }

        internal Assembly CoreAssembly { get; private set; }

        public void SetInternalAssembly(Assembly assembly) {
            if (CoreAssembly != null) {
                throw new Exception("Internal assembly already set");
            }
            CoreAssembly = assembly;
        }
        
        internal Assembly PluginsCoreAssembly { get; private set; }
        
        public void SetPluginsCoreAssembly(Assembly assembly) {
            if (PluginsCoreAssembly != null) {
                throw new Exception("Plugins core assembly already set");
            }
            PluginsCoreAssembly = assembly;
        }
    }
}
