using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public partial class PuppetMaster : MonoBehaviour
    {
        public void SetMuscleWeights(Muscle.Group group, float muscleWeight, float pinWeight = 1f, float mappingWeight = 1f, float muscleDamper = 1f)
        {
            throw new NotImplementedException();
        }

        public void SetMuscleWeights(Transform target, float muscleWeight, float pinWeight = 1f, float mappingWeight = 1f, float muscleDamper = 1f)
        {
            throw new NotImplementedException();
        }

        public void SetMuscleWeights(HumanBodyBones humanBodyBone, float muscleWeight, float pinWeight = 1f, float mappingWeight = 1f, float muscleDamper = 1f)
        {
            throw new NotImplementedException();
        }

        public void SetMuscleWeightsRecursive(Transform target, float muscleWeight, float pinWeight = 1f, float mappingWeight = 1f, float muscleDamper = 1f)
        {
            throw new NotImplementedException();
        }

        public void SetMuscleWeightsRecursive(int muscleIndex, float muscleWeight, float pinWeight = 1f, float mappingWeight = 1f, float muscleDamper = 1f)
        {
            throw new NotImplementedException();
        }

        public void SetMuscleWeightsRecursive(HumanBodyBones humanBodyBone, float muscleWeight, float pinWeight = 1f, float mappingWeight = 1f, float muscleDamper = 1f)
        {
            throw new NotImplementedException();
        }

        public void SetMuscleWeights(int muscleIndex, float muscleWeight, float pinWeight, float mappingWeight, float muscleDamper)
        {
            throw new NotImplementedException();
        }

        public Muscle GetMuscle(Transform target)
        {
            throw new NotImplementedException();
        }

        public Muscle GetMuscle(Rigidbody rigidbody)
        {
            throw new NotImplementedException();
        }

        public Muscle GetMuscle(ConfigurableJoint joint)
        {
            throw new NotImplementedException();
        }

        public bool ContainsJoint(ConfigurableJoint joint)
        {
            throw new NotImplementedException();
        }

        public int GetMuscleIndex(HumanBodyBones humanBodyBone)
        {
            throw new NotImplementedException();
        }

        public int GetMuscleIndex(Transform target)
        {
            throw new NotImplementedException();
        }

        public int GetMuscleIndex(Rigidbody rigidbody)
        {
            throw new NotImplementedException();
        }

        public int GetMuscleIndex(ConfigurableJoint joint)
        {
            throw new NotImplementedException();
        }
    }
}