using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class InteractionObject : MonoBehaviour
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

        public class InteractionEvent
        {
            public float time;
            public bool pause;
            public bool pickUp;
            public AnimatorEvent[] animations;
            public Message[] messages;
            public UnityEvent unityEvent;
            public void Activate(Transform t)
            {
                throw new NotImplementedException();
            }
        }

        public class Message
        {
            public string function;
            public GameObject recipient;
            public void Send(Transform t)
            {
                throw new NotImplementedException();
            }
        }

        public class AnimatorEvent
        {
            public Animator animator;
            public Animation animation;
            public string animationState;
            public float crossfadeTime = 0.3f;
            public int layer;
            public bool resetNormalizedTime;
            public void Activate(bool pickUp)
            {
                throw new NotImplementedException();
            }
        }

        public class WeightCurve
        {
            public enum Type
            {
                PositionWeight,
                RotationWeight,
                PositionOffsetX,
                PositionOffsetY,
                PositionOffsetZ,
                Pull,
                Reach,
                RotateBoneWeight,
                Push,
                PushParent,
                PoserWeight,
                BendGoalWeight
            }

            public Type type;
            public AnimationCurve curve;
            public float GetValue(float timer)
            {
                throw new NotImplementedException();
            }
        }

        public class Multiplier
        {
            public WeightCurve.Type curve;
            public float multiplier = 1f;
            public WeightCurve.Type result;
            public float GetValue(WeightCurve weightCurve, float timer)
            {
                throw new NotImplementedException();
            }
        }

        public Transform otherLookAtTarget;
        public Transform otherTargetsRoot;
        public Transform positionOffsetSpace;
        public WeightCurve[] weightCurves;
        public Multiplier[] multipliers;
        public InteractionEvent[] events;
        public float length { get; private set; }

        public InteractionSystem lastUsedInteractionSystem { get; private set; }

        public void Initiate()
        {
            throw new NotImplementedException();
        }

        public Transform lookAtTarget
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public InteractionTarget GetTarget(FullBodyBipedEffector effectorType, InteractionSystem interactionSystem)
        {
            throw new NotImplementedException();
        }

        public bool CurveUsed(WeightCurve.Type type)
        {
            throw new NotImplementedException();
        }

        public InteractionTarget[] GetTargets()
        {
            throw new NotImplementedException();
        }

        public Transform GetTarget(FullBodyBipedEffector effectorType, string tag)
        {
            throw new NotImplementedException();
        }

        public void OnStartInteraction(InteractionSystem interactionSystem)
        {
            throw new NotImplementedException();
        }

        public void Apply(IKSolverFullBodyBiped solver, FullBodyBipedEffector effector, InteractionTarget target, float timer, float weight, bool isPaused)
        {
            throw new NotImplementedException();
        }

        public float GetValue(WeightCurve.Type weightCurveType, InteractionTarget target, float timer)
        {
            throw new NotImplementedException();
        }

        public Transform targetsRoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        void Start()
        {
            throw new NotImplementedException();
        }
    }
}