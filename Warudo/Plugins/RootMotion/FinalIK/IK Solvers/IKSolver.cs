using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public abstract class IKSolver
    {
        public bool executedInEditor;
        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public abstract bool IsValid(ref string message);
        public void Initiate(Transform root)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public Vector3 IKPosition;
        public float IKPositionWeight = 1f;
        public virtual Vector3 GetIKPosition()
        {
            throw new NotImplementedException();
        }

        public void SetIKPosition(Vector3 position)
        {
            throw new NotImplementedException();
        }

        public float GetIKPositionWeight()
        {
            throw new NotImplementedException();
        }

        public void SetIKPositionWeight(float weight)
        {
            throw new NotImplementedException();
        }

        public Transform GetRoot()
        {
            throw new NotImplementedException();
        }

        public bool initiated { get; private set; }

        public abstract IKSolver.Point[] GetPoints();
        public abstract IKSolver.Point GetPoint(Transform transform);
        public abstract void FixTransforms();
        public abstract void StoreDefaultLocalState();
        public class Point
        {
            public Transform transform;
            public float weight = 1f;
            public Vector3 solverPosition;
            public Quaternion solverRotation = Quaternion.identity;
            public Vector3 defaultLocalPosition;
            public Quaternion defaultLocalRotation;
            public void StoreDefaultLocalState()
            {
                throw new NotImplementedException();
            }

            public void FixTransform()
            {
                throw new NotImplementedException();
            }

            public void UpdateSolverPosition()
            {
                throw new NotImplementedException();
            }

            public void UpdateSolverLocalPosition()
            {
                throw new NotImplementedException();
            }

            public void UpdateSolverState()
            {
                throw new NotImplementedException();
            }

            public void UpdateSolverLocalState()
            {
                throw new NotImplementedException();
            }
        }

        public class Bone : Point
        {
            public float length;
            public float sqrMag;
            public Vector3 axis = -Vector3.right;
            public RotationLimit rotationLimit
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

            public void Swing(Vector3 swingTarget, float weight = 1f)
            {
                throw new NotImplementedException();
            }

            public static void SolverSwing(Bone[] bones, int index, Vector3 swingTarget, float weight = 1f)
            {
                throw new NotImplementedException();
            }

            public void Swing2D(Vector3 swingTarget, float weight = 1f)
            {
                throw new NotImplementedException();
            }

            public void SetToSolverPosition()
            {
                throw new NotImplementedException();
            }

            public Bone()
            {
                throw new NotImplementedException();
            }

            public Bone(Transform transform)
            {
                throw new NotImplementedException();
            }

            public Bone(Transform transform, float weight)
            {
                throw new NotImplementedException();
            }
        }

        public class Node : Point
        {
            public float length;
            public float effectorPositionWeight;
            public float effectorRotationWeight;
            public Vector3 offset;
            public Node()
            {
                throw new NotImplementedException();
            }

            public Node(Transform transform)
            {
                throw new NotImplementedException();
            }

            public Node(Transform transform, float weight)
            {
                throw new NotImplementedException();
            }
        }

        public delegate void UpdateDelegate();
        public delegate void IterationDelegate(int i);
        public UpdateDelegate OnPreInitiate;
        public UpdateDelegate OnPostInitiate;
        public UpdateDelegate OnPreUpdate;
        public UpdateDelegate OnPostUpdate;
        protected abstract void OnInitiate();
        protected abstract void OnUpdate();
        protected bool firstInitiation = true;
        protected Transform root;
        protected void LogWarning(string message)
        {
            throw new NotImplementedException();
        }

        public static Transform ContainsDuplicateBone(Bone[] bones)
        {
            throw new NotImplementedException();
        }

        public static bool HierarchyIsValid(IKSolver.Bone[] bones)
        {
            throw new NotImplementedException();
        }

        protected static float PreSolveBones(ref Bone[] bones)
        {
            throw new NotImplementedException();
        }
    }
}