using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public class GenericBaker : Baker
    {
        public bool markAsLegacy;
        public Transform root;
        public Transform rootNode;
        public Transform[] ignoreList;
        public Transform[] bakePositionList;
        void Awake()
        {
            throw new NotImplementedException();
        }

        protected override Transform GetCharacterRoot()
        {
            throw new NotImplementedException();
        }

        protected override void OnStartBaking()
        {
            throw new NotImplementedException();
        }

        protected override void OnSetLoopFrame(float time)
        {
            throw new NotImplementedException();
        }

        protected override void OnSetCurves(ref AnimationClip clip)
        {
            throw new NotImplementedException();
        }

        protected override void OnSetKeyframes(float time, bool lastFrame)
        {
            throw new NotImplementedException();
        }
    }
}