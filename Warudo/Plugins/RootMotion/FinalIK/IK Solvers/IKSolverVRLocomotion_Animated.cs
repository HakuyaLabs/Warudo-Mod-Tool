using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public partial class IKSolverVR : IKSolver
    {
        public partial class Locomotion
        {
            public float moveThreshold = 0.3f;
            byte animationHeader;
            public float minAnimationSpeed = 0.2f;
            public float maxAnimationSpeed = 3f;
            public float animationSmoothTime = 0.1f;
            byte rootPositionHeader;
            public Vector2 standOffset;
            public float rootLerpSpeedWhileMoving = 30f;
            public float rootLerpSpeedWhileStopping = 10f;
            public float rootLerpSpeedWhileTurning = 10f;
            public float maxRootOffset = 0.5f;
            byte rootRotationHeader;
            public float maxRootAngleMoving = 10f;
            public float maxRootAngleStanding = 90f;
            public float stepLengthMlp = 1f;
            public void Initiate_Animated(Animator animator, Vector3[] positions)
            {
                throw new NotImplementedException();
            }

            public void Reset_Animated(Vector3[] positions)
            {
                throw new NotImplementedException();
            }

            public void Solve_Animated(IKSolverVR solver, float scale, float deltaTime)
            {
                throw new NotImplementedException();
            }
        }
    }
}