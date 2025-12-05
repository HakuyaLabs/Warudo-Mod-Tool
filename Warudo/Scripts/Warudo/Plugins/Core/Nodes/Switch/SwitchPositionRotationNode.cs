using DG.Tweening;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Data.Models;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SwitchPositionRotationNode : Node
    {
        public bool Condition;
        public PositionRotationData IfTrue;
        public PositionRotationData IfFalse;
        public float ToTrueTransitionTime = 0.4f;
        public float ToTrueTransitionDelay = 0f;
        public Ease ToTrueTransitionEasing = Ease.InOutSine;
        public float ToFalseTransitionTime = 0.4f;
        public float ToFalseTransitionDelay = 0f;
        public Ease ToFalseTransitionEasing = Ease.InOutSine;
        public PositionRotationData Output()
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }
    }
}