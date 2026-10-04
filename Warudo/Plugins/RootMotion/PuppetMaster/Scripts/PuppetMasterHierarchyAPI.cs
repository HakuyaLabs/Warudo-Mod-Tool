using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.Dynamics
{
    public enum MuscleRemoveMode
    {
        Sever,
        Explode,
        Numb,
    }

    public enum MuscleDisconnectMode
    {
        Sever,
        Explode
    }

    public partial class PuppetMaster : MonoBehaviour
    {
        public bool AddPropMuscle(ConfigurableJoint addPropMuscleTo, Vector3 position, Quaternion rotation, Vector3 additionalPinOffset, Transform targetParent = null, PuppetMasterProp initiateWithProp = null)
        {
            throw new NotImplementedException();
        }

        public bool IsDisconnecting(int muscleIndex)
        {
            throw new NotImplementedException();
        }

        public bool IsReconnecting(int muscleIndex)
        {
            throw new NotImplementedException();
        }

        public void DisconnectMuscleRecursive(int index, MuscleDisconnectMode disconnectMode = MuscleDisconnectMode.Sever, bool deactivate = false)
        {
            throw new NotImplementedException();
        }

        public void ReconnectMuscleRecursive(int index)
        {
            throw new NotImplementedException();
        }

        public void AddMuscle(ConfigurableJoint joint, Transform target, Rigidbody connectTo, Transform targetParent, Muscle.Props muscleProps = null, bool forceTreeHierarchy = false, bool forceLayers = true)
        {
            throw new NotImplementedException();
        }

        public void Rebuild()
        {
            throw new NotImplementedException();
        }

        public void RemoveMuscleRecursive(ConfigurableJoint joint, bool attachTarget, bool blockTargetAnimation = false, MuscleRemoveMode removeMode = MuscleRemoveMode.Sever)
        {
            throw new NotImplementedException();
        }

        public void ReplaceMuscle(ConfigurableJoint oldJoint, ConfigurableJoint newJoint)
        {
            throw new NotImplementedException();
        }

        public void SetMuscles(Muscle[] newMuscles)
        {
            throw new NotImplementedException();
        }

        public void DisableMuscleRecursive(ConfigurableJoint joint)
        {
            throw new NotImplementedException();
        }

        public void EnableMuscleRecursive(ConfigurableJoint joint)
        {
            throw new NotImplementedException();
        }

        public void FlattenHierarchy()
        {
            throw new NotImplementedException();
        }

        public void TreeHierarchy()
        {
            throw new NotImplementedException();
        }

        public void FixMusclePositions()
        {
            throw new NotImplementedException();
        }

        public void FixMusclePositionsAndRotations()
        {
            throw new NotImplementedException();
        }

        public bool HierarchyIsFlat()
        {
            throw new NotImplementedException();
        }
    }
}