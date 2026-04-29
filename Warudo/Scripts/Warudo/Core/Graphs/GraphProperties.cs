using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Localization;
using Warudo.Core.Scenes;

namespace Warudo.Core.Graphs {
    public class GraphProperties : StructuredData {

        [DataInput]
        [Label("VARIABLES")]
        public GraphVariable[] Variables;

        public Graph Graph { get; set; }
        
        public override Scene Scene {
            get => Graph?.Scene;
            set => throw new NotImplementedException();
        }

        private readonly Dictionary<string, GraphVariable> variableMap = new();

        public override bool ShouldEvaluateClientFunctions => Graph != null && Context.OpenedScene.GetSelectedGraph() == Graph;

        protected override void OnCreate() {
            base.OnCreate();
            Watch(nameof(Variables), RebuildVariableMap);
        }
        
        public void RebuildVariableMap() {
            variableMap.Clear();
            foreach (var variable in Variables) {
                variableMap[variable.Name] = variable;
            }
        }

        public GraphVariable GetVariable(string name) {
            return variableMap.GetValueOrDefault(name);
        }
        
    }

    public class GraphVariable : StructuredData<GraphProperties> {

        [DataInput]
        [Label("NAME")]
        public string Name = "NewVariable";

        [Markdown]
        [HiddenIf(nameof(HideDuplicateNameWarning))]
        public string DuplicateNameWarning = "DUPLICATE_VARIABLE_NAME_WARNING".Localized();

        [DataInput]
        [Label("TYPE")]
        public GraphVariableType VariableType;

        [DataInput]
        [Label("VALUE")]
        [HiddenIf(nameof(HideBooleanValue))]
        public bool BooleanValue;
        
        protected bool HideBooleanValue() => VariableType != GraphVariableType.Boolean;

        [DataInput]
        [Label("VALUE")]
        [HiddenIf(nameof(HideIntegerValue))]
        public int IntegerValue;
  
        protected bool HideIntegerValue() => VariableType != GraphVariableType.Integer;
        
        [DataInput]
        [Label("VALUE")]
        [HiddenIf(nameof(HideFloatValue))]
        public float FloatValue;
        
        protected bool HideFloatValue() => VariableType != GraphVariableType.Float;
        
        [DataInput]
        [Label("VALUE")]
        [HiddenIf(nameof(HideStringValue))]
        public string StringValue;
        
        protected bool HideStringValue() => VariableType != GraphVariableType.String;
        
        [DataInput]
        [Label("VALUE")]
        [HiddenIf(nameof(HideVector3Value))]
        public Vector3 Vector3Value;
        
        protected bool HideVector3Value() => VariableType != GraphVariableType.Vector3;
        
        [DataInput]
        [Label("VALUE")]
        [HiddenIf(nameof(HideBooleanListValue))]
        public bool[] BooleanListValue;
        
        protected bool HideBooleanListValue() => VariableType != GraphVariableType.BooleanList;
        
        [DataInput]
        [Label("VALUE")]
        [HiddenIf(nameof(HideIntegerListValue))]
        public int[] IntegerListValue;
        
        protected bool HideIntegerListValue() => VariableType != GraphVariableType.IntegerList;
        
        [DataInput]
        [Label("VALUE")]
        [HiddenIf(nameof(HideFloatListValue))]
        public float[] FloatListValue;
        
        protected bool HideFloatListValue() => VariableType != GraphVariableType.FloatList;
        
        [DataInput]
        [Label("VALUE")]
        [HiddenIf(nameof(HideStringListValue))]
        public string[] StringListValue;
        
        protected bool HideStringListValue() => VariableType != GraphVariableType.StringList;

        [DataInput]
        [Label("VALUE")]
        [HiddenIf(nameof(HideVector3ListValue))]
        public Vector3[] Vector3ListValue;
        
        protected bool HideVector3ListValue() => VariableType != GraphVariableType.Vector3List;

        protected bool HideDuplicateNameWarning() {
            return Parent == null || Parent.Variables.All(v => v == this || v.Name != Name);
        }

    }

    public enum GraphVariableType {
        Boolean,
        Integer,
        Float,
        String,
        Vector3,
        [Label("BOOLEAN_LIST")]
        BooleanList,
        [Label("INTEGER_LIST")]
        IntegerList,
        [Label("FLOAT_LIST")]
        FloatList,
        [Label("STRING_LIST")]
        StringList,
        [Label("VECTOR3_LIST")]
        Vector3List,
    }
}
