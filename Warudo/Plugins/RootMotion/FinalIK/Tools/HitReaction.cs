using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class HitReaction : OffsetModifier
    {
        public abstract class HitPoint
        {
            public string name;
            public Collider collider;
            float crossFadeTime = 0.1f;
            public bool inProgress
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            protected float crossFader { get; private set; }

            protected float timer { get; private set; }

            protected Vector3 force { get; private set; }

            public virtual void Hit(Vector3 force, Vector3 point)
            {
                throw new NotImplementedException();
            }

            public void Apply(IKSolverFullBodyBiped solver, float weight)
            {
                throw new NotImplementedException();
            }

            protected abstract float GetLength();
            protected abstract void CrossFadeStart();
            protected abstract void OnApply(IKSolverFullBodyBiped solver, float weight);
        }

        public class HitPointEffector : HitPoint
        {
            public class EffectorLink
            {
                public FullBodyBipedEffector effector;
                public float weight;
                public void Apply(IKSolverFullBodyBiped solver, Vector3 offset, float crossFader)
                {
                    throw new NotImplementedException();
                }

                public void CrossFadeStart()
                {
                    throw new NotImplementedException();
                }
            }

            public AnimationCurve offsetInForceDirection;
            public AnimationCurve offsetInUpDirection;
            public EffectorLink[] effectorLinks;
            protected override float GetLength()
            {
                throw new NotImplementedException();
            }

            protected override void CrossFadeStart()
            {
                throw new NotImplementedException();
            }

            protected override void OnApply(IKSolverFullBodyBiped solver, float weight)
            {
                throw new NotImplementedException();
            }
        }

        public class HitPointBone : HitPoint
        {
            public class BoneLink
            {
                public Transform bone;
                public float weight;
                public void Apply(IKSolverFullBodyBiped solver, Quaternion offset, float crossFader)
                {
                    throw new NotImplementedException();
                }

                public void CrossFadeStart()
                {
                    throw new NotImplementedException();
                }
            }

            public AnimationCurve aroundCenterOfMass;
            public BoneLink[] boneLinks;
            public override void Hit(Vector3 force, Vector3 point)
            {
                throw new NotImplementedException();
            }

            protected override float GetLength()
            {
                throw new NotImplementedException();
            }

            protected override void CrossFadeStart()
            {
                throw new NotImplementedException();
            }

            protected override void OnApply(IKSolverFullBodyBiped solver, float weight)
            {
                throw new NotImplementedException();
            }
        }

        public HitPointEffector[] effectorHitPoints;
        public HitPointBone[] boneHitPoints;
        public bool inProgress
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override void OnModifyOffset()
        {
            throw new NotImplementedException();
        }

        public void Hit(Collider collider, Vector3 force, Vector3 point)
        {
            throw new NotImplementedException();
        }
    }
}