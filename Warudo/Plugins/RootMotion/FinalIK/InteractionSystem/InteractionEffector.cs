using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RootMotion;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class InteractionEffector
    {
        public FullBodyBipedEffector effectorType { get; private set; }

        public bool isPaused { get; private set; }

        public InteractionObject interactionObject { get; private set; }

        public bool inInteraction
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public InteractionEffector(FullBodyBipedEffector effectorType)
        {
            throw new NotImplementedException();
        }

        public void Initiate(InteractionSystem interactionSystem)
        {
            throw new NotImplementedException();
        }

        public void StoreDefaults()
        {
            throw new NotImplementedException();
        }

        public bool ResetToDefaults(float speed, float deltaTime)
        {
            throw new NotImplementedException();
        }

        public bool Pause()
        {
            throw new NotImplementedException();
        }

        public bool Resume()
        {
            throw new NotImplementedException();
        }

        public bool Start(InteractionObject interactionObject, string tag, float fadeInTime, bool interrupt)
        {
            throw new NotImplementedException();
        }

        public bool Start(InteractionObject interactionObject, InteractionTarget interactionTarget, float fadeInTime, bool interrupt)
        {
            throw new NotImplementedException();
        }

        public void Update(Transform root, float speed, float deltaTime)
        {
            throw new NotImplementedException();
        }

        public float progress
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Stop()
        {
            throw new NotImplementedException();
        }

        public void OnPostFBBIK()
        {
            throw new NotImplementedException();
        }
    }
}