using System;
using Cysharp.Threading.Tasks;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class ForLoopNode : Node
    {
        public int FirstIndex = 1;
        public int LastIndex = 10;
        public float Interval = 0f;
        public float InitialDelay = 0f;
        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation LoopBody;
        public Continuation OnLoopEnd;
        public Continuation Exit;
        public int Index() => throw new NotImplementedException();
    }
}