using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class Muscle
    {
        public enum Group
        {
            Hips = 0,
            Spine = 1,
            Head = 2,
            Arm = 3,
            Hand = 4,
            Leg = 5,
            Foot = 6,
            Tail = 7,
            Prop = 8
        }

        public class InternalCollisionIgnoreSettings
        {
            public bool ignoreAll;
            public ConfigurableJoint[] muscles = new ConfigurableJoint[0];
            public Group[] groups = new Group[0];
        }

        public class Props
        {
            public Group group;
            public float mappingWeight = 1f;
            public float pinWeight = 1f;
            public float muscleWeight = 1f;
            public float muscleDamper = 1f;
            public bool mapPosition
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

            public InternalCollisionIgnoreSettings internalCollisionIgnores = new InternalCollisionIgnoreSettings();
            public Transform[] animatedTargetChildren = new Transform[0];
            public Props()
            {
                throw new NotImplementedException();
            }

            public Props(float pinWeight, float muscleWeight, float mappingWeight, float muscleDamper, Group group = Group.Hips)
            {
                throw new NotImplementedException();
            }

            public void Clamp()
            {
                throw new NotImplementedException();
            }
        }

        public struct State
        {
            public float mappingWeightMlp;
            public float pinWeightMlp;
            public float muscleWeightMlp;
            public float maxForceMlp;
            public float muscleDamperMlp;
            public float muscleDamperAdd;
            public float immunity;
            public float impulseMlp;
            public Vector3 velocity;
            public Vector3 angularVelocity;
            public bool isDisconnected;
            public bool resetFlag;
            public static State Default
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public void Clamp()
            {
                throw new NotImplementedException();
            }
        }

        public string name;
        public ConfigurableJoint joint;
        public Transform target;
        public Props props = new Props();
        public State state = State.Default;
        public int[] parentIndexes = new int[0];
        public int[] childIndexes = new int[0];
        public bool[] childFlags = new bool[0];
        public int[] kinshipDegrees = new int[0];
        public MuscleCollisionBroadcaster broadcaster;
        public JointBreakBroadcaster jointBreakBroadcaster;
        public Vector3 positionOffset;
        public Transform transform { get; private set; }

        public Rigidbody rigidbody { get; private set; }

        public Transform connectedBodyTarget { get; private set; }

        public Vector3 targetAnimatedPosition { get; private set; }

        public Quaternion targetAnimatedWorldRotation { get; private set; }

        public Collider[] colliders
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

        public Vector3 targetVelocity { get; private set; }

        public Rigidbody additionalRigidbody { get; private set; }

        public ConfigurableJoint additionalPin;
        public Transform additionalPinTarget;
        public float additionalPinWeight;
        public Vector3 mappedVelocity;
        public Vector3 mappedAngularVelocity;
        public bool isPropMuscle;
        public int index = -1;
        public Quaternion targetRotationRelative { get; private set; }

        public bool IsValid(bool log)
        {
            throw new NotImplementedException();
        }

        public Rigidbody rebuildConnectedBody { get; private set; }

        public Transform rebuildTargetParent { get; private set; }

        public Vector3 defaultTargetPosRelToMuscle { get; private set; }

        public Quaternion defaultTargetRotRelToMuscle { get; private set; }

        public Quaternion defaultMuscleRotRelToTarget { get; private set; }

        public void Rebuild()
        {
            throw new NotImplementedException();
        }

        public virtual void Initiate(Muscle[] colleagues)
        {
            throw new NotImplementedException();
        }

        public void InitiateAdditionalPin()
        {
            throw new NotImplementedException();
        }

        public void UpdateColliders()
        {
            throw new NotImplementedException();
        }

        public void DisableColliders()
        {
            throw new NotImplementedException();
        }

        public void EnableColliders()
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

        public void IgnoreAngularLimits(bool ignore)
        {
            throw new NotImplementedException();
        }

        public void ResetTargetLocalPosition()
        {
            throw new NotImplementedException();
        }

        public void FixTargetTransforms()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void MoveToTarget()
        {
            throw new NotImplementedException();
        }

        public void SetKinematic(bool to)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void ClearVelocities()
        {
            throw new NotImplementedException();
        }

        public void UpdateAnchor(bool supportTranslationAnimation)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(float pinWeightMaster, float muscleWeightMaster, float muscleSpring, float muscleDamper, float pinPow, float pinDistanceFalloff, bool rotationTargetChanged, bool angularPinning, float deltaTime)
        {
            throw new NotImplementedException();
        }

        public bool ignoreTargetVelocity;
        public Vector3 targetMappedPosition;
        public Quaternion targetMappedRotation = Quaternion.identity;
        public Vector3 targetSampledPosition;
        public Quaternion targetSampledRotation = Quaternion.identity;
        public void StoreTargetMappedPosition()
        {
            throw new NotImplementedException();
        }

        public void StoreTargetMappedRotation()
        {
            throw new NotImplementedException();
        }

        public void Map(float mappingWeightMaster)
        {
            throw new NotImplementedException();
        }

        public void CalculateMappedVelocity()
        {
            throw new NotImplementedException();
        }

        public void MapDisconnected()
        {
            throw new NotImplementedException();
        }

        public class TargetChild
        {
            public Transform t;
            public Vector3 defaultLocalPosition;
            public Quaternion defaultLocalRotation = Quaternion.identity;
            public TargetChild(Transform t)
            {
                throw new NotImplementedException();
            }

            public void Map()
            {
                throw new NotImplementedException();
            }
        }

        public void SetMuscleRotation(float muscleWeightMaster, float muscleSpring, float muscleDamper)
        {
            throw new NotImplementedException();
        }
    }
}