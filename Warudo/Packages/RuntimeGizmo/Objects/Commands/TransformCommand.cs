using System;
using CommandUndoRedo;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace RuntimeGizmos
{
    public class TransformCommand : ICommand
    {
        TransformValues newValues;
        TransformValues oldValues;
        Transform transform;
        TransformGizmo transformGizmo;
        public TransformCommand(TransformGizmo transformGizmo, Transform transform)
        {
            throw new NotImplementedException();
        }

        public void StoreNewTransformValues()
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void UnExecute()
        {
            throw new NotImplementedException();
        }

        struct TransformValues
        {
            public Vector3 position;
            public Quaternion rotation;
            public Vector3 scale;
        }
    }
}