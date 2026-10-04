using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Events;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Event
{
    public class OnDisableGraphNode : Node
    {
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
    }
}