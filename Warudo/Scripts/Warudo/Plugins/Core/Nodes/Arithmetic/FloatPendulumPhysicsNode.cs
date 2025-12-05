using System;
using System.Linq;
using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Object = UnityEngine.Object;
using System;

namespace Warudo.Plugins.Core.Nodes
{
    public class FloatPendulumPhysicsNode : Node
    {
        public float A;
        public float SourceValueMin = 0f;
        public float SourceValueMax = 1f;
        public float Intensity = 1f;
        public float OutputValue()
        {
            throw new NotImplementedException();
        }

        public ArmData[] Arms;
        public bool Visualize = false;
        public class ArmData : StructuredData, ICollapsibleStructuredData
        {
            public float Length = 10f;
            public float Mass = 0.25f;
            public float Drag = 0.25f;
            public float Spring = 0.5f;
            public float Damping = 0.5f;
            public float Gravity = 1f;
            public Rigidbody Rigidbody;
            public HingeJoint HingeJoint;
            public string GetHeader() => throw new NotImplementedException();
        }

        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public void SetupArms()
        {
            throw new NotImplementedException();
        }

        protected override void OnDestroy()
        {
            throw new NotImplementedException();
        }

        public override void OnFixedUpdate()
        {
            throw new NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        protected CorePlugin CorePlugin => throw new NotImplementedException();
    }
}