using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using Warudo.Core.Scenes;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetAssetPropertyNode : Node
    {
        public override Entity StructuredDataParent => throw new NotImplementedException();
        public Asset Asset;
        public string DataPath;
        public string Status = "THIS_DATA_PATH_IS_NOT_WRITABLE".Localized();
        public bool DisableClientUpdates;
        protected bool HideStatus() => throw new NotImplementedException();
        public float TransitionTime = 0f;
        public Ease TransitionEasing = Ease.OutCubic;
        protected bool IsTransitionUnsupported()
        {
            throw new NotImplementedException();
        }

        public bool Toggle;
        protected bool HideBooleanToggle()
        {
            throw new NotImplementedException();
        }

        public string SerializedTargetValue;
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(SerializedNode serialized)
        {
            throw new NotImplementedException();
        }

        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        public Continuation OnTransitionEnd;
    }
}