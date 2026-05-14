using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public class SolverManager : MonoBehaviour
    {
        public bool fixTransforms = true;
        public void Disable()
        {
            throw new NotImplementedException();
        }

        protected virtual void InitiateSolver()
        {
            throw new NotImplementedException();
        }

        protected virtual void UpdateSolver()
        {
            throw new NotImplementedException();
        }

        protected virtual void FixTransforms()
        {
            throw new NotImplementedException();
        }

        void OnDisable()
        {
            throw new NotImplementedException();
        }

        void Start()
        {
            throw new NotImplementedException();
        }

        void Update()
        {
            throw new NotImplementedException();
        }

        void FixedUpdate()
        {
            throw new NotImplementedException();
        }

        void LateUpdate()
        {
            throw new NotImplementedException();
        }

        public void UpdateSolverExternal()
        {
            throw new NotImplementedException();
        }
    }
}