using System.Linq;
using System.Text.RegularExpressions;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using Warudo.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class StringRegexNode : Node
    {
        public string A = "";
        public string Regex = "";
        public string InvalidRegexHint = "THIS_REGEX_IS_INVALID".Localized();
        public string Result = "";
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public bool IsMatched()
        {
            throw new NotImplementedException();
        }
    }
}