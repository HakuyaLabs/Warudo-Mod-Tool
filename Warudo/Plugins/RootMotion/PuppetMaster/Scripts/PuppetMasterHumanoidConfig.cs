using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public partial class PuppetMaster : MonoBehaviour
    {
    }

    public class PuppetMasterHumanoidConfig : ScriptableObject
    {
        public class HumanoidMuscle
        {
            public string name;
            public HumanBodyBones bone;
            public Muscle.Props props;
        }

        public PuppetMaster.State state;
        public PuppetMaster.StateSettings stateSettings = PuppetMaster.StateSettings.Default;
        public PuppetMaster.Mode mode;
        public float blendTime = 0.1f;
        public bool fixTargetTransforms = true;
        public int solverIterationCount = 6;
        public bool visualizeTargetPose = true;
        public float mappingWeight = 1f;
        public float pinWeight = 1f;
        public float muscleWeight = 1f;
        public float muscleSpring = 100f;
        public float muscleDamper = 0f;
        public float pinPow = 4f;
        public float pinDistanceFalloff = 5;
        public bool angularPinning;
        public bool updateJointAnchors = true;
        public bool supportTranslationAnimation;
        public bool angularLimits;
        public bool internalCollisions;
        public HumanoidMuscle[] muscles = new HumanoidMuscle[0];
        public void ApplyTo(PuppetMaster p)
        {
            throw new NotImplementedException();
        }
    }
}