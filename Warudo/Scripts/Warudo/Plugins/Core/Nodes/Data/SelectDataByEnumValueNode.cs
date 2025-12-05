using System;
using System.Linq;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Localization;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.Data
{
    public class SelectDataByEnumValueNode : EnumNode
    {
        public object InputEnumValue;
        public string[] Cases;
        public object Output()
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public void SetupInputPorts()
        {
            throw new NotImplementedException();
        }
    }
}