using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class GetAssetRotationNode : Node
    {
        public GameObjectAsset Asset;
        public BonePositionType Type = BonePositionType.WorldRotation;
        public enum BonePositionType
        {
            WorldRotation,
            LocalRotation
        }

        public Vector3 WorldRotation()
        {
            throw new NotImplementedException();
        }
    }
}