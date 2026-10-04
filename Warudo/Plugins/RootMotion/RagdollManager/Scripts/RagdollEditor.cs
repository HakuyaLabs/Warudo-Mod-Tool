using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class RagdollEditor : MonoBehaviour
    {
        void OpenUserManual()
        {
            throw new NotImplementedException();
        }

        void OpenScriptReference()
        {
            throw new NotImplementedException();
        }

        void OpenTutorial()
        {
            throw new NotImplementedException();
        }

        public enum Mode
        {
            Colliders,
            Joints
        }

        public Rigidbody selectedRigidbody;
        public Collider selectedCollider;
        public bool symmetry = true;
        public Mode mode;
    }
}