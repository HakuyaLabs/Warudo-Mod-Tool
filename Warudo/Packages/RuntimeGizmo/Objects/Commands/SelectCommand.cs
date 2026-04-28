using System;
using CommandUndoRedo;
using UnityEngine;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

namespace RuntimeGizmos
{
    public abstract class SelectCommand : ICommand
    {
        protected Transform target;
        protected TransformGizmo transformGizmo;
        public SelectCommand(TransformGizmo transformGizmo, Transform target)
        {
            throw new NotImplementedException();
        }

        public abstract void Execute();
        public abstract void UnExecute();
    }

    public class AddTargetCommand : SelectCommand
    {
        List<Transform> targetRoots = new List<Transform>();
        public AddTargetCommand(TransformGizmo transformGizmo, Transform target, List<Transform> targetRoots) : base(transformGizmo, target)
        {
            throw new NotImplementedException();
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }

    public class RemoveTargetCommand : SelectCommand
    {
        public RemoveTargetCommand(TransformGizmo transformGizmo, Transform target) : base(transformGizmo, target)
        {
            throw new NotImplementedException();
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }

    public class ClearTargetsCommand : SelectCommand
    {
        List<Transform> targetRoots = new List<Transform>();
        public ClearTargetsCommand(TransformGizmo transformGizmo, List<Transform> targetRoots) : base(transformGizmo, null)
        {
            throw new NotImplementedException();
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }

    public class ClearAndAddTargetCommand : SelectCommand
    {
        List<Transform> targetRoots = new List<Transform>();
        public ClearAndAddTargetCommand(TransformGizmo transformGizmo, Transform target, List<Transform> targetRoots) : base(transformGizmo, target)
        {
            throw new NotImplementedException();
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}