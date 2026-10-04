using UnityEngine;
using System.Collections;
using System;
using RootMotion;
using System;
using Object = UnityEngine.Object;

namespace RootMotion.FinalIK
{
    public partial class IKSolverVR : IKSolver
    {
        public abstract class BodyPart
        {
            protected abstract void OnRead(Vector3[] positions, Quaternion[] rotations, bool hasChest, bool hasNeck, bool hasShoulders, bool hasToes, bool hasLegs, int rootIndex, int index);
            public abstract void PreSolve(float scale);
            public abstract void Write(ref Vector3[] solvedPositions, ref Quaternion[] solvedRotations);
            public abstract void ApplyOffsets(float scale);
            public abstract void ResetOffsets();
            public float sqrMag { get; private set; }

            public float mag { get; private set; }

            public VirtualBone[] bones = new VirtualBone[0];
            protected bool initiated;
            protected Vector3 rootPosition;
            protected Quaternion rootRotation = Quaternion.identity;
            protected int index = -1;
            protected int LOD;
            public void SetLOD(int LOD)
            {
                throw new NotImplementedException();
            }

            public void Read(Vector3[] positions, Quaternion[] rotations, bool hasChest, bool hasNeck, bool hasShoulders, bool hasToes, bool hasLegs, int rootIndex, int index)
            {
                throw new NotImplementedException();
            }

            public void MovePosition(Vector3 position)
            {
                throw new NotImplementedException();
            }

            public void MoveRotation(Quaternion rotation)
            {
                throw new NotImplementedException();
            }

            public void Translate(Vector3 position, Quaternion rotation)
            {
                throw new NotImplementedException();
            }

            public void TranslateRoot(Vector3 newRootPos, Quaternion newRootRot)
            {
                throw new NotImplementedException();
            }

            public void RotateTo(VirtualBone bone, Quaternion rotation, float weight = 1f)
            {
                throw new NotImplementedException();
            }

            public void Visualize(Color color)
            {
                throw new NotImplementedException();
            }

            public void Visualize()
            {
                throw new NotImplementedException();
            }
        }
    }
}