using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SetQuaternionListElementNode : Node
    {
        public Quaternion[] QuaternionList;
        public int Index;
        public Quaternion Value;
        public Quaternion[] OutputList()
        {
            throw new NotImplementedException();
        }
    }
}