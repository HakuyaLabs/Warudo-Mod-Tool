using System;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace RuntimeGizmos
{
    public class TransformGizmoCustomGizmo : MonoBehaviour
    {
        public bool autoFindTransformGizmo = true;
        public TransformGizmo transformGizmo;
        public CustomTransformGizmos customTranslationGizmos = new CustomTransformGizmos();
        public CustomTransformGizmos customRotationGizmos = new CustomTransformGizmos();
        public CustomTransformGizmos customScaleGizmos = new CustomTransformGizmos();
        public bool scaleBasedOnDistance = true;
        public float scaleMultiplier = .4f;
        public int gizmoLayer = 2;
        LayerMask mask;
        void Awake()
        {
            throw new NotImplementedException();
        }

        void OnEnable()
        {
            throw new NotImplementedException();
        }

        void OnDisable()
        {
            throw new NotImplementedException();
        }

        void CheckForSelectedAxis()
        {
            throw new NotImplementedException();
        }

        void OnDrawCustomGizmos()
        {
            throw new NotImplementedException();
        }

        void DrawCustomGizmo(CustomTransformGizmos customGizmo)
        {
            throw new NotImplementedException();
        }

        void ShowProperGizmoType()
        {
            throw new NotImplementedException();
        }
    }

    public class CustomTransformGizmos
    {
        public Transform xAxisGizmo;
        public Transform yAxisGizmo;
        public Transform zAxisGizmo;
        public Transform anyAxisGizmo;
        Collider xAxisGizmoCollider;
        Collider yAxisGizmoCollider;
        Collider zAxisGizmoCollider;
        Collider anyAxisGizmoCollider;
        Vector3 originalXAxisScale;
        Vector3 originalYAxisScale;
        Vector3 originalZAxisScale;
        Vector3 originalAnyAxisScale;
        public void Init(int layer)
        {
            throw new NotImplementedException();
        }

        public void SetEnable(bool enable)
        {
            throw new NotImplementedException();
        }

        public void SetAxis(AxisInfo axisInfo)
        {
            throw new NotImplementedException();
        }

        public void SetPosition(Vector3 position)
        {
            throw new NotImplementedException();
        }

        public void ScaleMultiply(Vector4 scaleMultiplier)
        {
            throw new NotImplementedException();
        }

        public Axis GetSelectedAxis(Collider selectedCollider)
        {
            throw new NotImplementedException();
        }

        void SetLayerRecursively(GameObject gameObject, int layer)
        {
            throw new NotImplementedException();
        }
    }
}