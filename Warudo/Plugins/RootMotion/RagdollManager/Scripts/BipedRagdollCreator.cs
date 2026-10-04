using UnityEngine;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public class BipedRagdollCreator : RagdollCreator
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

        public bool canBuild;
        public BipedRagdollReferences references;
        public Options options = Options.Default;
        public struct Options
        {
            public float weight;
            public bool spine;
            public bool chest;
            public bool hands;
            public bool feet;
            public JointType joints;
            public float jointRange;
            public float colliderLengthOverlap;
            public ColliderType torsoColliders;
            public ColliderType headCollider;
            public ColliderType armColliders;
            public ColliderType handColliders;
            public ColliderType legColliders;
            public ColliderType footColliders;
            public static Options Default
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
        }

        public static Options AutodetectOptions(BipedRagdollReferences r)
        {
            throw new NotImplementedException();
        }

        public static void Create(BipedRagdollReferences r, Options options)
        {
            throw new NotImplementedException();
        }

        public static void ClearBipedRagdoll(BipedRagdollReferences r)
        {
            throw new NotImplementedException();
        }

        public static bool IsClear(BipedRagdollReferences r)
        {
            throw new NotImplementedException();
        }
    }
}