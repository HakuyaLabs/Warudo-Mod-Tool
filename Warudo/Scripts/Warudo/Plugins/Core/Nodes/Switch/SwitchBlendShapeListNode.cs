using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class SwitchBlendShapeListNode : Node
    {
        public bool Condition;
        public Dictionary<string, float> IfTrue;
        public Dictionary<string, float> IfFalse;
        public float ToTrueTransitionTime = 0.4f;
        public float ToTrueTransitionDelay = 0f;
        public Ease ToTrueTransitionEasing = Ease.InOutSine;
        public float ToFalseTransitionTime = 0.4f;
        public float ToFalseTransitionDelay = 0f;
        public Ease ToFalseTransitionEasing = Ease.InOutSine;
        public Dictionary<string, float> Output()
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }
    }
}