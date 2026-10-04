using UnityEngine;
using System.Collections.Generic;
using System.Threading;
using System;
using Object = UnityEngine.Object;

public class DynamicBone : MonoBehaviour
{
    public Transform m_Root = null;
    public List<Transform> m_Roots = null;
    public float m_UpdateRate = 60.0f;
    public enum UpdateMode
    {
        Normal,
        AnimatePhysics,
        UnscaledTime,
        Default
    }

    public UpdateMode m_UpdateMode = UpdateMode.Default;
    public float m_Damping = 0.1f;
    public AnimationCurve m_DampingDistrib = null;
    public float m_Elasticity = 0.1f;
    public AnimationCurve m_ElasticityDistrib = null;
    public float m_Stiffness = 0.1f;
    public AnimationCurve m_StiffnessDistrib = null;
    public float m_Inert = 0;
    public AnimationCurve m_InertDistrib = null;
    public float m_Friction = 0;
    public AnimationCurve m_FrictionDistrib = null;
    public float m_Radius = 0;
    public AnimationCurve m_RadiusDistrib = null;
    public float m_EndLength = 0;
    public Vector3 m_EndOffset = Vector3.zero;
    public Vector3 m_Gravity = Vector3.zero;
    public Vector3 m_Force = Vector3.zero;
    public float m_BlendWeight = 1.0f;
    public List<DynamicBoneColliderBase> m_Colliders = null;
    public List<Transform> m_Exclusions = null;
    public enum FreezeAxis
    {
        None,
        X,
        Y,
        Z
    }

    public FreezeAxis m_FreezeAxis = FreezeAxis.None;
    public bool m_DistantDisable = false;
    public Transform m_ReferenceObject = null;
    public float m_DistanceToObject = 20;
    public bool m_Multithread = true;
    Vector3 m_ObjectMove;
    Vector3 m_ObjectPrevPosition;
    float m_ObjectScale;
    float m_Time = 0;
    float m_Weight = 1.0f;
    bool m_DistantDisabled = false;
    int m_PreUpdateCount = 0;
    class Particle
    {
        public Transform m_Transform;
        public int m_ParentIndex;
        public int m_ChildCount;
        public float m_Damping;
        public float m_Elasticity;
        public float m_Stiffness;
        public float m_Inert;
        public float m_Friction;
        public float m_Radius;
        public float m_BoneLength;
        public bool m_isCollide;
        public bool m_TransformNotNull;
        public Vector3 m_Position;
        public Vector3 m_PrevPosition;
        public Vector3 m_EndOffset;
        public Vector3 m_InitLocalPosition;
        public Quaternion m_InitLocalRotation;
        public Vector3 m_TransformPosition;
        public Vector3 m_TransformLocalPosition;
        public Matrix4x4 m_TransformLocalToWorldMatrix;
    }

    class ParticleTree
    {
        public Transform m_Root;
        public Vector3 m_LocalGravity;
        public Matrix4x4 m_RootWorldToLocalMatrix;
        public float m_BoneTotalLength;
        public List<Particle> m_Particles = new List<Particle>();
        public Vector3 m_RestGravity;
    }

    List<ParticleTree> m_ParticleTrees = new List<ParticleTree>();
    float m_DeltaTime;
    List<DynamicBoneColliderBase> m_EffectiveColliders;
    bool m_WorkAdded = false;
    static List<DynamicBone> s_PendingWorks = new List<DynamicBone>();
    static List<DynamicBone> s_EffectiveWorks = new List<DynamicBone>();
    static AutoResetEvent s_AllWorksDoneEvent;
    static int s_RemainWorkCount;
    static Semaphore s_WorkQueueSemaphore;
    static int s_WorkQueueIndex;
    static int s_UpdateCount;
    static int s_PrepareFrame;
    void Start()
    {
        throw new NotImplementedException();
    }

    void FixedUpdate()
    {
        throw new NotImplementedException();
    }

    void Update()
    {
        throw new NotImplementedException();
    }

    void LateUpdate()
    {
        throw new NotImplementedException();
    }

    void Prepare()
    {
        throw new NotImplementedException();
    }

    bool IsNeedUpdate()
    {
        throw new NotImplementedException();
    }

    void PreUpdate()
    {
        throw new NotImplementedException();
    }

    void CheckDistance()
    {
        throw new NotImplementedException();
    }

    void OnEnable()
    {
        throw new NotImplementedException();
    }

    void OnDisable()
    {
        throw new NotImplementedException();
    }

    void OnValidate()
    {
        throw new NotImplementedException();
    }

    bool IsRootChanged()
    {
        throw new NotImplementedException();
    }

    void OnDidApplyAnimationProperties()
    {
        throw new NotImplementedException();
    }

    void OnDrawGizmosSelected()
    {
        throw new NotImplementedException();
    }

    void DrawGizmos(ParticleTree pt)
    {
        throw new NotImplementedException();
    }

    public void SetWeight(float w)
    {
        throw new NotImplementedException();
    }

    public float GetWeight()
    {
        throw new NotImplementedException();
    }

    void UpdateParticles()
    {
        throw new NotImplementedException();
    }

    public void SetupParticles()
    {
        throw new NotImplementedException();
    }

    void AppendParticleTree(Transform root)
    {
        throw new NotImplementedException();
    }

    void AppendParticles(ParticleTree pt, Transform b, int parentIndex, float boneLength)
    {
        throw new NotImplementedException();
    }

    public void UpdateParameters()
    {
        throw new NotImplementedException();
    }

    void UpdateParameters(ParticleTree pt)
    {
        throw new NotImplementedException();
    }

    void InitTransforms()
    {
        throw new NotImplementedException();
    }

    void InitTransforms(ParticleTree pt)
    {
        throw new NotImplementedException();
    }

    void ResetParticlesPosition()
    {
        throw new NotImplementedException();
    }

    void ResetParticlesPosition(ParticleTree pt)
    {
        throw new NotImplementedException();
    }

    void UpdateParticles1(float timeVar, int loopIndex)
    {
        throw new NotImplementedException();
    }

    void UpdateParticles1(ParticleTree pt, float timeVar, int loopIndex)
    {
        throw new NotImplementedException();
    }

    void UpdateParticles2(float timeVar)
    {
        throw new NotImplementedException();
    }

    void UpdateParticles2(ParticleTree pt, float timeVar)
    {
        throw new NotImplementedException();
    }

    void SkipUpdateParticles()
    {
        throw new NotImplementedException();
    }

    void SkipUpdateParticles(ParticleTree pt)
    {
        throw new NotImplementedException();
    }

    static Vector3 MirrorVector(Vector3 v, Vector3 axis)
    {
        throw new NotImplementedException();
    }

    void ApplyParticlesToTransforms()
    {
        throw new NotImplementedException();
    }

    void ApplyParticlesToTransforms(ParticleTree pt, Vector3 ax, Vector3 ay, Vector3 az, bool nx, bool ny, bool nz)
    {
        throw new NotImplementedException();
    }

    static void AddPendingWork(DynamicBone db)
    {
        throw new NotImplementedException();
    }

    static void AddWorkToQueue(DynamicBone db)
    {
        throw new NotImplementedException();
    }

    static DynamicBone GetWorkFromQueue()
    {
        throw new NotImplementedException();
    }

    static void ThreadProc()
    {
        throw new NotImplementedException();
    }

    static void InitThreadPool()
    {
        throw new NotImplementedException();
    }

    static void ExecuteWorks()
    {
        throw new NotImplementedException();
    }
}