using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class InteractionSystem : MonoBehaviour
    {
        void OpenUserManual()
        {
            throw new NotImplementedException();
        }

        void OpenScriptReference()
        {
            throw new NotImplementedException();
        }

        void OpenTutorial1()
        {
            throw new NotImplementedException();
        }

        void OpenTutorial2()
        {
            throw new NotImplementedException();
        }

        void OpenTutorial3()
        {
            throw new NotImplementedException();
        }

        void OpenTutorial4()
        {
            throw new NotImplementedException();
        }

        void SupportGroup()
        {
            throw new NotImplementedException();
        }

        void ASThread()
        {
            throw new NotImplementedException();
        }

        public string targetTag = "";
        public float fadeInTime = 0.3f;
        public float speed = 1f;
        public float resetToDefaultsSpeed = 1f;
        public Collider characterCollider;
        public Transform FPSCamera;
        public LayerMask camRaycastLayers;
        public float camRaycastDistance = 1f;
        public bool inInteraction
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsInInteraction(FullBodyBipedEffector effectorType)
        {
            throw new NotImplementedException();
        }

        public bool IsPaused(FullBodyBipedEffector effectorType)
        {
            throw new NotImplementedException();
        }

        public bool IsPaused()
        {
            throw new NotImplementedException();
        }

        public bool IsInSync()
        {
            throw new NotImplementedException();
        }

        public bool StartInteraction(FullBodyBipedEffector effectorType, InteractionObject interactionObject, bool interrupt)
        {
            throw new NotImplementedException();
        }

        public bool StartInteractionWithClosestTarget(FullBodyBipedEffector effectorType, InteractionObject interactionObject, bool interrupt)
        {
            throw new NotImplementedException();
        }

        public bool StartInteraction(FullBodyBipedEffector effectorType, InteractionObject interactionObject, InteractionTarget target, bool interrupt)
        {
            throw new NotImplementedException();
        }

        public bool PauseInteraction(FullBodyBipedEffector effectorType)
        {
            throw new NotImplementedException();
        }

        public bool ResumeInteraction(FullBodyBipedEffector effectorType)
        {
            throw new NotImplementedException();
        }

        public bool StopInteraction(FullBodyBipedEffector effectorType)
        {
            throw new NotImplementedException();
        }

        public void PauseAll()
        {
            throw new NotImplementedException();
        }

        public void ResumeAll()
        {
            throw new NotImplementedException();
        }

        public void StopAll()
        {
            throw new NotImplementedException();
        }

        public InteractionObject GetInteractionObject(FullBodyBipedEffector effectorType)
        {
            throw new NotImplementedException();
        }

        public float GetProgress(FullBodyBipedEffector effectorType)
        {
            throw new NotImplementedException();
        }

        public float GetMinActiveProgress()
        {
            throw new NotImplementedException();
        }

        public bool TriggerInteraction(int index, bool interrupt)
        {
            throw new NotImplementedException();
        }

        public bool TriggerInteraction(int index, bool interrupt, out InteractionObject interactionObject)
        {
            throw new NotImplementedException();
        }

        public bool TriggerInteraction(int index, bool interrupt, out InteractionTarget interactionTarget)
        {
            throw new NotImplementedException();
        }

        public InteractionTrigger.Range GetClosestInteractionRange()
        {
            throw new NotImplementedException();
        }

        public InteractionObject GetClosestInteractionObjectInRange()
        {
            throw new NotImplementedException();
        }

        public InteractionTarget GetClosestInteractionTargetInRange()
        {
            throw new NotImplementedException();
        }

        public InteractionObject[] GetClosestInteractionObjectsInRange()
        {
            throw new NotImplementedException();
        }

        public InteractionTarget[] GetClosestInteractionTargetsInRange()
        {
            throw new NotImplementedException();
        }

        public bool TriggerEffectorsReady(int index)
        {
            throw new NotImplementedException();
        }

        public InteractionTrigger.Range GetTriggerRange(int index)
        {
            throw new NotImplementedException();
        }

        public int GetClosestTriggerIndex()
        {
            throw new NotImplementedException();
        }

        public void StoreDefaults()
        {
            throw new NotImplementedException();
        }

        public FullBodyBipedIK ik
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public List<InteractionTrigger> triggersInRange { get; private set; }

        public delegate void InteractionDelegate(FullBodyBipedEffector effectorType, InteractionObject interactionObject);
        public delegate void InteractionEventDelegate(FullBodyBipedEffector effectorType, InteractionObject interactionObject, InteractionObject.InteractionEvent interactionEvent);
        public InteractionDelegate OnInteractionStart;
        public InteractionDelegate OnInteractionPause;
        public InteractionDelegate OnInteractionPickUp;
        public InteractionDelegate OnInteractionResume;
        public InteractionDelegate OnInteractionStop;
        public InteractionEventDelegate OnInteractionEvent;
        public RaycastHit raycastHit;
        FullBodyBipedIK fullBody;
        public InteractionLookAt lookAt = new InteractionLookAt();
        public bool initiated { get; private set; }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void OnTriggerEnter(Collider c)
        {
            throw new NotImplementedException();
        }

        public void OnTriggerExit(Collider c)
        {
            throw new NotImplementedException();
        }

        void OnDrawGizmosSelected()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        void UpdateEffectors()
        {
            throw new NotImplementedException();
        }

        void OnFixTransforms()
        {
            throw new NotImplementedException();
        }

        void OnDestroy()
        {
            throw new NotImplementedException();
        }
    }
}