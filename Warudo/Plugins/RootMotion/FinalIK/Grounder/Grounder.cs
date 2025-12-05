using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public abstract class Grounder : MonoBehaviour
    {
        public float weight = 1f;
        public Grounding solver = new Grounding();
        public delegate void GrounderDelegate();
        public GrounderDelegate OnPreGrounder;
        public GrounderDelegate OnPostGrounder;
        public GrounderDelegate OnPostIK;
        public abstract void ResetPosition();
        public bool initiated { get; protected set; }

        protected Vector3 GetSpineOffsetTarget()
        {
            throw new NotImplementedException();
        }

        protected void LogWarning(string message)
        {
            throw new NotImplementedException();
        }

        protected abstract void OpenUserManual();
        protected abstract void OpenScriptReference();
    }
}