using System;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Localization;
using Warudo.Plugins.Core.Events;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes.External
{
    public class OnWebSocketActionNode : Node
    {
        public string Info;
        public string Action = "MyAction";
        public WebSocketActionDataType DataType;
        public bool BooleanData() => throw new NotImplementedException();
        public int IntegerData() => throw new NotImplementedException();
        public float FloatData() => throw new NotImplementedException();
        public string StringData() => throw new NotImplementedException();
        public Vector3 Vector3Data() => throw new NotImplementedException();
        public Quaternion QuaternionData() => throw new NotImplementedException();
        public bool[] BooleanListData() => throw new NotImplementedException();
        public int[] IntegerListData() => throw new NotImplementedException();
        public float[] FloatListData() => throw new NotImplementedException();
        public string[] StringListData() => throw new NotImplementedException();
        public Vector3[] Vector3ListData() => throw new NotImplementedException();
        public Quaternion[] QuaternionListData() => throw new NotImplementedException();
        public JToken JTokenData() => throw new NotImplementedException();
        public Continuation Exit;
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public void ParseData(JToken data)
        {
            throw new NotImplementedException();
        }
    }

    public enum WebSocketActionDataType
    {
        None,
        Boolean,
        Integer,
        Float,
        String,
        Vector3,
        Quaternion,
        BooleanList,
        IntegerList,
        FloatList,
        StringList,
        Vector3List,
        QuaternionList,
        JToken
    }
}