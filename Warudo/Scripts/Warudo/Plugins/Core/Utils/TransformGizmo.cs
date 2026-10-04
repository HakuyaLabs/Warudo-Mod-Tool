using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Warudo.Core;
using Warudo.Core.Utils;
using Object = UnityEngine.Object;
using System;

namespace Warudo.Plugins.Core.Utils
{
    public class TransformGizmo
    {
        public Dictionary<Transform, RuntimeGizmos.TransformGizmo> Instances => throw new NotImplementedException();
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool IsTransforming()
        {
            throw new NotImplementedException();
        }

        public void AddTarget(Transform transform, Action<Transform> callback = null, Action<RuntimeGizmos.TransformGizmo> initializer = null)
        {
            throw new NotImplementedException();
        }

        public void AddTargets(IEnumerable<Transform> transforms, Action<Transform> callback = null, Action<RuntimeGizmos.TransformGizmo> initializer = null)
        {
            throw new NotImplementedException();
        }

        public void RemoveTarget(Transform transform)
        {
            throw new NotImplementedException();
        }

        public void RemoveTargets(IEnumerable<Transform> transforms)
        {
            throw new NotImplementedException();
        }

        public void ClearTargets()
        {
            throw new NotImplementedException();
        }

        public RuntimeGizmos.TransformGizmo GetInternalGizmo(Transform transform)
        {
            throw new NotImplementedException();
        }

        public void OnUpdate()
        {
            throw new NotImplementedException();
        }
    }
}