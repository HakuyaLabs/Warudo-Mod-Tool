using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using RootMotion;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public partial class PuppetMaster : MonoBehaviour
    {
        void OpenUserManualSetup()
        {
            throw new NotImplementedException();
        }

        void OpenUserManualComponent()
        {
            throw new NotImplementedException();
        }

        void OpenUserManualPerformance()
        {
            throw new NotImplementedException();
        }

        void OpenScriptReference()
        {
            throw new NotImplementedException();
        }

        void OpenSetupTutorial()
        {
            throw new NotImplementedException();
        }

        void OpenComponentTutorial()
        {
            throw new NotImplementedException();
        }

        public enum Mode
        {
            Active,
            Kinematic,
            Disabled
        }

        public PuppetMasterHumanoidConfig humanoidConfig;
        public Transform targetRoot;
        public State state;
        public StateSettings stateSettings = StateSettings.Default;
        void ResetStateSettings()
        {
            throw new NotImplementedException();
        }

        public Mode mode;
        public float blendTime = 0.1f;
        public bool fixTargetTransforms = true;
        public int solverIterationCount = 6;
        public bool visualizeTargetPose = true;
        public float mappingWeight = 1f;
        public float pinWeight = 1f;
        public float muscleWeight = 1f;
        public float muscleSpring = 100f;
        public float muscleDamper = 0f;
        public float pinPow = 4f;
        public float pinDistanceFalloff = 5;
        public bool angularPinning;
        public bool updateJointAnchors = true;
        public bool supportTranslationAnimation;
        public bool angularLimits;
        public bool internalCollisions;
        public Muscle[] muscles = new Muscle[0];
        public PropMuscle[] propMuscles = new PropMuscle[0];
        public delegate void UpdateDelegate();
        public delegate void MuscleDelegate(Muscle muscle);
        public UpdateDelegate OnPostInitiate;
        public UpdateDelegate OnRead;
        public UpdateDelegate OnWrite;
        public UpdateDelegate OnPostLateUpdate;
        public UpdateDelegate OnFixTransforms;
        public UpdateDelegate OnHierarchyChanged;
        public MuscleDelegate OnMuscleRemoved;
        public MuscleDelegate OnMuscleDisconnected;
        public MuscleDelegate OnMuscleReconnected;
        public Animator targetAnimator
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

        public Animation targetAnimation { get; private set; }

        public BehaviourBase[] behaviours = new BehaviourBase[0];
        public bool isActive
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool initiated { get; private set; }

        public List<SolverManager> solvers = new List<SolverManager>();
        public bool manualInternalCollisionControl;
        public bool manualAngularLimitControl;
        public bool mapDisconnectedMuscles = true;
        public enum UpdateMode
        {
            Normal,
            AnimatePhysics,
            FixedUpdate
        }

        public UpdateMode updateMode
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool controlsAnimator
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool isBlending
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Teleport(Vector3 position, Quaternion rotation, bool moveToTarget)
        {
            throw new NotImplementedException();
        }

        public void SetInternalCollisionsManual(bool collide, bool useInternalCollisionIgnores)
        {
            throw new NotImplementedException();
        }

        public void SetAngularLimitsManual(bool limited)
        {
            throw new NotImplementedException();
        }

        void OnDisable()
        {
            throw new NotImplementedException();
        }

        void OnEnable()
        {
            throw new NotImplementedException();
        }

        void Awake()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public Transform FindTargetRootRecursive(Transform t)
        {
            throw new NotImplementedException();
        }

        public void Initiate()
        {
            throw new NotImplementedException();
        }

        void OnDestroy()
        {
            throw new NotImplementedException();
        }

        public void OnPreSimulate(float deltaTime)
        {
            throw new NotImplementedException();
        }

        public void OnPostSimulate()
        {
            throw new NotImplementedException();
        }

        public virtual void FixedUpdate()
        {
            throw new NotImplementedException();
        }

        protected virtual void Update()
        {
            throw new NotImplementedException();
        }

        protected virtual void LateUpdate()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnLateUpdate()
        {
            throw new NotImplementedException();
        }

        public void FlagInternalCollisionsForUpdate()
        {
            throw new NotImplementedException();
        }

        public void UpdateInternalCollisions(Muscle m)
        {
            throw new NotImplementedException();
        }

        public void IgnoreInternalCollisions(Muscle m)
        {
            throw new NotImplementedException();
        }

        public void ResetInternalCollisions(Muscle m, bool useInternalCollisionIgnores)
        {
            throw new NotImplementedException();
        }

        public void FlagAngularLimitsForUpdate()
        {
            throw new NotImplementedException();
        }
    }
}