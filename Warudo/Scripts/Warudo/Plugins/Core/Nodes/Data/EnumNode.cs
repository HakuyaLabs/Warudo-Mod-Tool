using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public abstract class EnumNode : Node
    {
        public string Info;
        public string EnumType;
        protected async UniTask<AutoCompleteList> AutoCompleteEnumType()
        {
            throw new NotImplementedException();
        }

        protected async UniTask<AutoCompleteList> AutoCompleteEnumValue()
        {
            throw new NotImplementedException();
        }

        protected Type EnumSystemType;
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        protected virtual void SetupEnumType()
        {
            throw new NotImplementedException();
        }
    }
}