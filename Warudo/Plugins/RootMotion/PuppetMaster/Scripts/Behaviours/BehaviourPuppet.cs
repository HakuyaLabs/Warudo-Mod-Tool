using UnityEngine;
using System.Collections;
using RootMotion;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public partial class BehaviourPuppet : BehaviourBase
    {
        protected override string GetTypeSpring()
        {
            throw new NotImplementedException();
        }

        void OpenUserManual()
        {
            throw new NotImplementedException();
        }

        void OpenScriptReference()
        {
            throw new NotImplementedException();
        }

        public enum State
        {
            Puppet,
            Unpinned,
            GetUp
        }

        public enum NormalMode
        {
            Active,
            Unmapped,
            Kinematic
        }

        public class MasterProps
        {
            public NormalMode normalMode;
            public float mappingBlendSpeed = 10f;
            public bool activateOnStaticCollisions;
            public float activateOnImpulse = 0f;
        }

        public struct MuscleProps
        {
            public float unpinParents;
            public float unpinChildren;
            public float unpinGroup;
            public float minMappingWeight;
            public float maxMappingWeight;
            public float minPinWeight;
            public bool disableColliders;
            public float regainPinSpeed;
            public float collisionResistance;
            public float knockOutDistance;
            public PhysicMaterial puppetMaterial;
            public PhysicMaterial unpinnedMaterial;
        }

        public struct MusclePropsGroup
        {
            public string name;
            public Muscle.Group[] groups;
            public MuscleProps props;
        }

        public struct CollisionResistanceMultiplier
        {
            public LayerMask layers;
            public float multiplier;
            public float collisionThreshold;
        }

        public MasterProps masterProps = new MasterProps();
        public LayerMask groundLayers;
        public LayerMask collisionLayers;
        public float collisionThreshold;
        public Weight collisionResistance = new Weight(3f, "Smaller value means more unpinning from collisions so the characters get knocked out more easily. If using a curve, the value will be evaluated by each muscle's target velocity magnitude. This can be used to make collision resistance higher while the character moves or animates faster.");
        public CollisionResistanceMultiplier[] collisionResistanceMultipliers;
        public int maxCollisions = 30;
        public float regainPinSpeed = 1f;
        public float boostFalloff = 1f;
        public MuscleProps defaults;
        public MusclePropsGroup[] groupOverrides;
        public float knockOutDistance = 1f;
        public float unpinnedMuscleWeightMlp = 0.3f;
        public float maxRigidbodyVelocity = 10f;
        public float pinWeightThreshold = 1f;
        public bool unpinnedMuscleKnockout = true;
        public bool dropProps;
        public bool canGetUp = true;
        public float getUpDelay = 5f;
        public float blendToAnimationTime = 0.2f;
        public float maxGetUpVelocity = 0.3f;
        public float minGetUpDuration = 1f;
        public float getUpCollisionResistanceMlp = 2f;
        public float getUpRegainPinSpeedMlp = 2f;
        public float getUpKnockOutDistanceMlp = 10f;
        public Vector3 getUpOffsetProne;
        public Vector3 getUpOffsetSupine;
        public bool isQuadruped;
        public PuppetEvent onGetUpProne;
        public PuppetEvent onGetUpSupine;
        public PuppetEvent onLoseBalance;
        public PuppetEvent onLoseBalanceFromPuppet;
        public PuppetEvent onLoseBalanceFromGetUp;
        public PuppetEvent onRegainBalance;
        public delegate void CollisionImpulseDelegate(MuscleCollision m, float impulse);
        public CollisionDelegate OnCollision;
        public CollisionImpulseDelegate OnCollisionImpulse;
        public State state { get; private set; }

        public bool canMoveTarget = true;
        public override void OnReactivate()
        {
            throw new NotImplementedException();
        }

        public void Reset(Vector3 position, Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        public override void OnTeleport(Quaternion deltaRotation, Vector3 deltaPosition, Vector3 pivot, bool moveToTarget)
        {
            throw new NotImplementedException();
        }

        protected override void OnInitiate()
        {
            throw new NotImplementedException();
        }

        protected override void OnActivate()
        {
            throw new NotImplementedException();
        }

        public override void KillStart()
        {
            throw new NotImplementedException();
        }

        public override void KillEnd()
        {
            throw new NotImplementedException();
        }

        public override void Resurrect()
        {
            throw new NotImplementedException();
        }

        protected override void OnDeactivate()
        {
            throw new NotImplementedException();
        }

        protected override void OnFixedUpdate(float deltaTime)
        {
            throw new NotImplementedException();
        }

        protected override void OnLateUpdate(float deltaTime)
        {
            throw new NotImplementedException();
        }

        protected override void OnReadBehaviour(float deltaTime)
        {
            throw new NotImplementedException();
        }

        public override void OnMuscleAdded(Muscle m)
        {
            throw new NotImplementedException();
        }

        public override void OnMuscleRemoved(Muscle m)
        {
            throw new NotImplementedException();
        }

        protected void MoveTarget(Vector3 position)
        {
            throw new NotImplementedException();
        }

        protected void RotateTarget(Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        protected override void GroundTarget(LayerMask layers)
        {
            throw new NotImplementedException();
        }

        void OnDrawGizmosSelected()
        {
            throw new NotImplementedException();
        }
    }
}