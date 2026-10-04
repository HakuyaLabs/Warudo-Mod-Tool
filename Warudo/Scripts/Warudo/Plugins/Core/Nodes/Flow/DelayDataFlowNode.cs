using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using Warudo.Core.Serializations;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class DelayDataFlowNode : Node
    {
        public string UnsupportedText = "INPUT_TYPE_UNSUPPORTED".Localized();
        public object InputValue;
        public float Delay = 0.4f;
        public object OutputValue()
        {
            throw new NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        public override void Destroy()
        {
            throw new NotImplementedException();
        }

        private class Datum
        {
            public float Timestamp;
            public object Value;
            public Type StructuredDataType;
        }
    }
}