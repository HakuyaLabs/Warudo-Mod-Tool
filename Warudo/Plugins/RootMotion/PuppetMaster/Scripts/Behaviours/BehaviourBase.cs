using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public abstract class BehaviourBase : MonoBehaviour
    {
        public PuppetMaster puppetMaster;
        public delegate void BehaviourDelegate();
        public delegate void BehaviourUpdateDelegate(float deltaTime);
        public delegate void HitDelegate(MuscleHit hit);
        public delegate void CollisionDelegate(MuscleCollision collision);
        public abstract void OnReactivate();
        public BehaviourDelegate OnPreActivate;
        public BehaviourDelegate OnPreInitiate;
        public BehaviourUpdateDelegate OnPreFixedUpdate;
        public BehaviourUpdateDelegate OnPreUpdate;
        public BehaviourUpdateDelegate OnPreLateUpdate;
        public BehaviourUpdateDelegate OnPreRead;
        public BehaviourUpdateDelegate OnPreWrite;
        public BehaviourDelegate OnPreDeactivate;
        public BehaviourDelegate OnPreFixTransforms;
        public HitDelegate OnPreMuscleHit;
        public CollisionDelegate OnPreMuscleCollision;
        public CollisionDelegate OnPreMuscleCollisionExit;
        public BehaviourDelegate OnHierarchyChanged;
        public virtual void Resurrect()
        {
            throw new NotImplementedException();
        }

        public virtual void Freeze()
        {
            throw new NotImplementedException();
        }

        public virtual void Unfreeze()
        {
            throw new NotImplementedException();
        }

        public virtual void KillStart()
        {
            throw new NotImplementedException();
        }

        public virtual void KillEnd()
        {
            throw new NotImplementedException();
        }

        public virtual void OnTeleport(Quaternion deltaRotation, Vector3 deltaPosition, Vector3 pivot, bool moveToTarget)
        {
            throw new NotImplementedException();
        }

        public virtual void OnMuscleDisconnected(Muscle m)
        {
            throw new NotImplementedException();
        }

        public virtual void OnMuscleReconnected(Muscle m)
        {
            throw new NotImplementedException();
        }

        public virtual void OnMuscleAdded(Muscle m)
        {
            throw new NotImplementedException();
        }

        public virtual void OnMuscleRemoved(Muscle m)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnActivate()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnDeactivate()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnInitiate()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnFixedUpdate(float deltaTime)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnUpdate(float deltaTime)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnLateUpdate(float deltaTime)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnReadBehaviour(float deltaTime)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnWriteBehaviour(float deltaTime)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnDrawGizmosBehaviour()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnFixTransformsBehaviour()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnMuscleHitBehaviour(MuscleHit hit)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnMuscleCollisionBehaviour(MuscleCollision collision)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnMuscleCollisionExitBehaviour(MuscleCollision collision)
        {
            throw new NotImplementedException();
        }

        public BehaviourDelegate OnPostActivate;
        public BehaviourDelegate OnPostInitiate;
        public BehaviourUpdateDelegate OnPostFixedUpdate;
        public BehaviourUpdateDelegate OnPostUpdate;
        public BehaviourUpdateDelegate OnPostLateUpdate;
        public BehaviourUpdateDelegate OnPostRead;
        public BehaviourUpdateDelegate OnPostWrite;
        public BehaviourDelegate OnPostDeactivate;
        public BehaviourDelegate OnPostDrawGizmos;
        public BehaviourDelegate OnPostFixTransforms;
        public HitDelegate OnPostMuscleHit;
        public CollisionDelegate OnPostMuscleCollision;
        public CollisionDelegate OnPostMuscleCollisionExit;
        public bool deactivated;
        public bool forceActive { get; protected set; }

        public void Initiate()
        {
            throw new NotImplementedException();
        }

        public void OnFixTransforms()
        {
            throw new NotImplementedException();
        }

        public void OnRead(float deltaTime)
        {
            throw new NotImplementedException();
        }

        public void OnWrite(float deltaTime)
        {
            throw new NotImplementedException();
        }

        public void OnMuscleHit(MuscleHit hit)
        {
            throw new NotImplementedException();
        }

        public void OnMuscleCollision(MuscleCollision collision)
        {
            throw new NotImplementedException();
        }

        public void OnMuscleCollisionExit(MuscleCollision collision)
        {
            throw new NotImplementedException();
        }

        public void Activate()
        {
            throw new NotImplementedException();
        }

        void OnDisable()
        {
            throw new NotImplementedException();
        }

        public void FixedUpdateB(float deltaTime)
        {
            throw new NotImplementedException();
        }

        public void UpdateB(float deltaTime)
        {
            throw new NotImplementedException();
        }

        public void LateUpdateB(float deltaTime)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnDrawGizmos()
        {
            throw new NotImplementedException();
        }

        protected virtual string GetTypeSpring()
        {
            throw new NotImplementedException();
        }

        public struct PuppetEvent
        {
            public string switchToBehaviour;
            public AnimatorEvent[] animations;
            public UnityEvent unityEvent;
            public bool switchBehaviour
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public void Trigger(PuppetMaster puppetMaster, bool switchBehaviourEnabled = true)
            {
                throw new NotImplementedException();
            }
        }

        public class AnimatorEvent
        {
            public string animationState;
            public float crossfadeTime = 0.3f;
            public int layer;
            public bool resetNormalizedTime;
            public void Activate(Animator animator, Animation animation)
            {
                throw new NotImplementedException();
            }
        }

        protected void RotateTargetToRootMuscle()
        {
            throw new NotImplementedException();
        }

        protected void TranslateTargetToRootMuscle(float maintainY)
        {
            throw new NotImplementedException();
        }

        protected void RemovePropMuscles()
        {
            throw new NotImplementedException();
        }

        protected virtual void GroundTarget(LayerMask layers)
        {
            throw new NotImplementedException();
        }

        protected bool ContainsRemovablePropMuscle()
        {
            throw new NotImplementedException();
        }
    }
}