using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Data;
using UnityEngine;
using System.Collections.Generic;
using Warudo.Plugins.Core.Assets.Prop;
using System.Text.RegularExpressions;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class RunJavascriptOnWebView : Node
    {
        public enum VarType
        {
            String,
            Float,
            Boolean,
            Vector2,
            Vector3
        }

        public class InputVar : StructuredData<RunJavascriptOnWebView>, ICollapsibleStructuredData
        {
            public string Name = "newVar";
            public VarType VType;
            public string GetHeader()
            {
                throw new NotImplementedException();
            }
        }

        string NotAllowInputVarAtStartRegex = @"^[\d|\$]";
        string NotAllowInputVarAnyWhereRegex = @"[\s|\.|<|>|\/|-|=|\+|\?|\[|\]|\'|\{|\}|\||&|\^|%|\\|#|@|!]";
        InputVar[] inputs = new InputVar[0];
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public ScreenAsset Screen;
        string JSCode = "console.log('Hello from Warudo!');";
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        public Continuation JSCallbackExit;
        public string Result()
        {
            throw new NotImplementedException();
        }

        public void Callback(string result)
        {
            throw new NotImplementedException();
        }
    }
}