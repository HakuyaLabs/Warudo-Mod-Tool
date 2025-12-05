using System;
using Cysharp.Threading.Tasks;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Serializations;

namespace Warudo.Core.Server {
    public interface IService {
        public void BroadcastOpenedScene();
        public void BroadcastPluginSceneData(string pluginId);
        public void BroadcastEntityDataInputPortValue(Guid id, string port, string value);
        // TODO: Broadcast array operations
        public void BroadcastFrameUpdate(FrameUpdate update);
        public void BroadcastDataConverters(SerializedDataConverters dataConverters);
        public void BroadcastAssetTypeList(SerializedAssetTypeList assetTypes);
        public void BroadcastAssetRemoved(Guid assetId);
        public void BroadcastGraphEnabled(Guid graphId, bool enabled);
        public void BroadcastNodeTypeList(SerializedNodeTypeList nodeTypes);
        public void BroadcastActiveConnections(Guid graphId, string activeConnections);
        public void BroadcastActiveLanguage(string activeLanguage);
        public void BroadcastAssetHierarchy();
        public void BroadcastGraphHierarchy();
        public void Toast(ToastSeverity severity, string header, string summary, string message = null, TimeSpan duration = default);
        public void Toast(string clientId, ToastSeverity severity, string header, string summary, string message = null, TimeSpan duration = default);
        public void PromptMessage(string header, string message, bool markdown = false);
        public void PromptMessage(string clientId, string header, string message, bool markdown = false);
        public UniTask<bool> PromptConfirmation(string header, string message);
        public UniTask<bool> PromptConfirmation(string clientId, string header, string message);
        public UniTask<T> PromptStructuredDataInput<T>(string header, T structuredData = null) where T : StructuredData;
        public UniTask<T> PromptStructuredDataInput<T>(string header, Action<T> structuredDataInitializer) where T : StructuredData;
        public UniTask<T> PromptStructuredDataInput<T>(string clientId, string header, T structuredData = null, Action<T> structuredDataInitializer = null) where T : StructuredData;
        public void ShowProgress(string message, float progress, TimeSpan timeout = default);
        public void HideProgress();
        public void NavigateToAsset(Guid assetId, string port = default);
        public void NavigateToGraph(Guid graphId, Guid nodeId = default);
        public void NavigateToPlugin(string pluginId, string port = default);
    }
    
    public enum ToastSeverity {
        [Label("SUCCESS")]
        Success,
        [Label("INFO")]
        Info,
        [Label("WARNING")]
        Warning,
        [Label("ERROR")]
        Error
    }
}
