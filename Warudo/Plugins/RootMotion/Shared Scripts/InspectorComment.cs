using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public class InspectorComment : PropertyAttribute
    {
        public string name;
        public string color = "white";
        public InspectorComment(string name)
        {
            throw new NotImplementedException();
        }

        public InspectorComment(string name, string color)
        {
            throw new NotImplementedException();
        }
    }
}