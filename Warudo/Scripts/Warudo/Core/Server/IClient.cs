using System;
using System.Collections.Generic;
using Warudo.Core.Serializations;

namespace Warudo.Core.Server {
    public interface IClient {
        #region Entities
        public void GetEntityDataInputPortValue(Guid entityId, string portKey);
        public void SetEntityDataInputPortValue(Guid entityId, string portKey, string value, bool broadcast);
        public void ResetEntityDataInputPortValue(Guid entityId, string portKey);
        public void InvokeEntityTriggerPort(Guid entityId, string portKey);
        public void AppendEntityDataInputPortArray(Guid entityId, string arrayPortKey);
        public void GetEntityDataInputPortArrayElement(Guid entityId, string arrayPortKey, int index);
        public void SetEntityDataInputPortArrayElement(Guid entityId, string arrayPortKey, int index, string value, bool broadcast);
        public void RemoveEntityDataInputPortArrayElement(Guid entityId, string arrayPortKey, int index);
        public void MoveEntityDataInputPortArrayElement(Guid entityId, string arrayPortKey, int fromIndex, int toIndex);
        public void DuplicateEntityDataInputPortArrayElement(Guid entityId, string arrayPortKey, int index);
        #endregion
        
        #region Plugins
        public void GetPlugins();
        public void GetSelectedPlugin();
        public void SetSelectedPlugin(string pluginId);
        #endregion
        
        #region Assets
        public void GetSelectedAsset();
        public void SetSelectedAsset(Guid assetId);
        public void GetAssetTypeList();
        public void AddAssetOfType(string type);
        public void AddAssetOfTypeToGroup(string type, string group);
        public void AddAsset(SerializedAsset asset);
        public void RemoveAsset(Guid assetId);
        public void RemoveAssetGroup(string group);
        public void DuplicateAsset(Guid assetId);
        public void SetAssetName(Guid assetId, string name);
        public void ImportAsset(string serializedAssetString);
        public void ApplyAssetProperties(Guid assetId, string serializedProperties);
        public void ExportAsset(Guid assetId);
        #endregion
        
        #region Graphs

        public void AddGraph();
        public void AddGraphToGroup(string group);
        public void RemoveGraph(Guid graphId);
        public void RemoveGraphGroup(string group);
        public void DuplicateGraph(Guid graphId);
        public void SetGraphName(Guid graphId, string name);
        public void SetGraphEnabled(Guid graphId, bool enabled);
        public void GetSelectedGraph();
        public void SetSelectedGraph(Guid assetId);
        public void GetNodeTypeList();
        public void AddDataConnection(Guid graphId, Guid outputNodeId, Guid inputNodeId, string outputPortKey, string inputPortKey);
        public void AddFlowConnection(Guid graphId, Guid outputNodeId, Guid inputNodeId, string outputPortKey, string inputPortKey);
        public void RemoveDataConnection(Guid graphId, Guid outputNodeId, Guid inputNodeId, string outputPortKey, string inputPortKey);
        public void RemoveFlowConnection(Guid graphId, Guid outputNodeId, Guid inputNodeId, string outputPortKey, string inputPortKey);
        public void AddNodeOfType(Guid graphId, string type, float x, float y);
        public void AddNode(Guid graphId, SerializedNode node);
        public void RemoveNode(Guid graphId, Guid node);
        public void SetNodePosition(Guid graphId, Guid nodeId, float x, float y);
        public void SetPanning(Guid graphId, float x, float y);
        public void SetScaling(Guid graphId, float scaling);
        public void ImportGraph(string serializedGraphString);
        public void ExportGraph(Guid graphId);
        public void InvokeFlowAtInput(Guid graphId, Guid nodeId, string inputPortKey);
        #endregion
        
        #region Others
        
        public void GetEnumTypes(IEnumerable<string> types);
        public void GetAutoCompleteLists(IEnumerable<Guid> ids, ulong t);
        public void ResolveResourceUriMeta(IEnumerable<Uri> uris);
        public void GetActiveLanguage();
        public void GetDataConverters();
        public void OnConnected();
        public void SendPluginMessage(string pluginId, string action, string payload);
        public void SetStructuredDataCollapsed(Guid structuredDataId, bool collapsed);
        public void SetAssetHierarchy(HierarchyNode assetHierarchy);
        public void SetGraphHierarchy(HierarchyNode graphHierarchy);
        #endregion
    }
}
