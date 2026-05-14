using System.Collections.Generic;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Assets
{
    public interface IMeshData
    {
        string GetPath();
        bool IsVisible();
        bool IsSkinnedMesh();
    }

    public interface IMeshDataParent
    {
        Dictionary<string, SkinnedMeshRenderer> SkinnedMeshRenderers { get; }

        Dictionary<string, MeshRenderer> MeshRenderers { get; }
    }

    public class MeshData<T> : StructuredData<T>, IMeshData, ICollapsibleStructuredData where T : Entity, IMeshDataParent
    {
        public string Path;
        public bool Visible;
        public bool SkinnedMesh;
        public string GetPath() => throw new NotImplementedException();
        public bool IsVisible() => throw new NotImplementedException();
        public bool IsSkinnedMesh() => throw new NotImplementedException();
        public string GetHeader() => throw new NotImplementedException();
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public void UpdateVisibility()
        {
            throw new NotImplementedException();
        }

        public static MeshData<T>[] CreateArray(IMeshDataParent parent, T sdParent)
        {
            throw new NotImplementedException();
        }
    }
}