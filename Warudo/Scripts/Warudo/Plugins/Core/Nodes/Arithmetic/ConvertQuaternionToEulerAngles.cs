using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class ConvertQuaternionToEulerAnglesNode : Node
    {
        public Quaternion Quaternion;
        public Vector3 EulerAngles()
        {
            throw new NotImplementedException();
        }

        public float EulerAngleX()
        {
            throw new NotImplementedException();
        }

        public float EulerAngleY()
        {
            throw new NotImplementedException();
        }

        public float EulerAngleZ()
        {
            throw new NotImplementedException();
        }
    }
}