using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public class HitReactionVRIK : OffsetModifierVRIK
    {
        public AnimationCurve[] offsetCurves;
        public abstract class Offset
        {
            public string name;
            public Collider collider;
            float crossFadeTime = 0.1f;
            protected float crossFader { get; private set; }

            protected float timer { get; private set; }

            protected Vector3 force { get; private set; }

            public virtual void Hit(Vector3 force, AnimationCurve[] curves, Vector3 point)
            {
                throw new NotImplementedException();
            }

            public void Apply(VRIK ik, AnimationCurve[] curves, float weight)
            {
                throw new NotImplementedException();
            }

            protected abstract float GetLength(AnimationCurve[] curves);
            protected abstract void CrossFadeStart();
            protected abstract void OnApply(VRIK ik, AnimationCurve[] curves, float weight);
        }

        public class PositionOffset : Offset
        {
            public class PositionOffsetLink
            {
                public IKSolverVR.PositionOffset positionOffset;
                public float weight;
                public void Apply(VRIK ik, Vector3 offset, float crossFader)
                {
                    throw new NotImplementedException();
                }

                public void CrossFadeStart()
                {
                    throw new NotImplementedException();
                }
            }

            public int forceDirCurveIndex;
            public int upDirCurveIndex = 1;
            public PositionOffsetLink[] offsetLinks;
            protected override float GetLength(AnimationCurve[] curves)
            {
                throw new NotImplementedException();
            }

            protected override void CrossFadeStart()
            {
                throw new NotImplementedException();
            }

            protected override void OnApply(VRIK ik, AnimationCurve[] curves, float weight)
            {
                throw new NotImplementedException();
            }
        }

        public class RotationOffset : Offset
        {
            public class RotationOffsetLink
            {
                public IKSolverVR.RotationOffset rotationOffset;
                public float weight;
                public void Apply(VRIK ik, Quaternion offset, float crossFader)
                {
                    throw new NotImplementedException();
                }

                public void CrossFadeStart()
                {
                    throw new NotImplementedException();
                }
            }

            public int curveIndex;
            public RotationOffsetLink[] offsetLinks;
            public override void Hit(Vector3 force, AnimationCurve[] curves, Vector3 point)
            {
                throw new NotImplementedException();
            }

            protected override float GetLength(AnimationCurve[] curves)
            {
                throw new NotImplementedException();
            }

            protected override void CrossFadeStart()
            {
                throw new NotImplementedException();
            }

            protected override void OnApply(VRIK ik, AnimationCurve[] curves, float weight)
            {
                throw new NotImplementedException();
            }
        }

        public PositionOffset[] positionOffsets;
        public RotationOffset[] rotationOffsets;
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