using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using CommandUndoRedo;
using UnityEngine.Events;
using UnityEngine.Rendering;
using System;
using Object = UnityEngine.Object;

namespace RuntimeGizmos
{
    public class TransformGizmo : MonoBehaviour
    {
        public float fovSlope = 0.028f;
        public TransformSpace space = TransformSpace.Local;
        public TransformType transformType = TransformType.Move;
        public TransformPivot pivot = TransformPivot.Pivot;
        public CenterType centerType = CenterType.All;
        public ScaleType scaleType = ScaleType.FromPoint;
        public KeyCode SetMoveType = KeyCode.W;
        public KeyCode SetRotateType = KeyCode.E;
        public KeyCode SetScaleType = KeyCode.R;
        public KeyCode SetAllTransformType = KeyCode.JoystickButton19;
        public KeyCode SetSpaceToggle = KeyCode.Q;
        public KeyCode SetPivotModeToggle = KeyCode.JoystickButton19;
        public KeyCode SetCenterTypeToggle = KeyCode.JoystickButton19;
        public KeyCode SetScaleTypeToggle = KeyCode.JoystickButton19;
        public KeyCode translationSnapping = KeyCode.JoystickButton19;
        public Color xColor = new Color(1, 0, 0, 0.8f);
        public Color yColor = new Color(0, 1, 0, 0.8f);
        public Color zColor = new Color(0, 0, 1, 0.8f);
        public Color allColor = new Color(.7f, .7f, .7f, 0.8f);
        public Color selectedColor = new Color(1, 1, 0, 0.8f);
        public Color hoverColor = new Color(1, .75f, 0, 0.8f);
        public float planesOpacity = .2f;
        public float movementSnap = .25f;
        public float rotationSnap = 15f;
        public float scaleSnap = 1f;
        public float handleLength = .12f;
        public float handleWidth = .0012f;
        public float planeSize = .014f;
        public float triangleSize = .009f;
        public float boxSize = .01f;
        public int circleDetail = 160;
        public float allMoveHandleLengthMultiplier = 1f;
        public float allRotateHandleLengthMultiplier = 1.4f;
        public float allScaleHandleLengthMultiplier = 1.6f;
        public float minSelectedDistanceCheck = .01f;
        public float moveSpeedMultiplier = 1f;
        public float scaleSpeedMultiplier = 1f;
        public float rotateSpeedMultiplier = 1f;
        public float allRotateSpeedMultiplier = 20f;
        public bool useFirstSelectedAsMain = true;
        public float mouseMultiplier = 1f;
        public bool circularRotationMethod = false;
        public bool forceUpdatePivotPointOnChange = true;
        public int maxUndoStored = 100;
        public UndoRedo undoRedo = new UndoRedo();
        public bool manuallyHandleGizmo;
        public LayerMask selectionMask = Physics.DefaultRaycastLayers;
        public Action onCheckForSelectedAxis;
        public Action onDrawCustomGizmo;
        public Camera fromCamera { get; set; }

        public bool isTransforming { get; private set; }

        public float totalScaleAmount { get; private set; }

        public Quaternion totalRotationAmount { get; private set; }

        public Axis translatingAxis
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Axis translatingAxisPlane
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool hasTranslatingAxisPlane
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public TransformType transformingType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Vector3 pivotPoint { get; private set; }

        Vector3 totalCenterPivotPoint;
        public Transform mainTargetRoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public UnityEvent<Transform> onTransformUpdated = new();
        public AxisInfo axisInfo;
        public Axis nearAxis = Axis.None;
        public Axis planeAxis = Axis.None;
        public TransformType translatingType;
        public AxisVectors handleLines = new AxisVectors();
        public AxisVectors handlePlanes = new AxisVectors();
        public AxisVectors handleTriangles = new AxisVectors();
        public AxisVectors handleSquares = new AxisVectors();
        public AxisVectors circlesLines = new AxisVectors();
        List<Transform> targetRootsOrdered = new List<Transform>();
        Dictionary<Transform, TargetInfo> targetRoots = new Dictionary<Transform, TargetInfo>();
        HashSet<Renderer> highlightedRenderers = new HashSet<Renderer>();
        HashSet<Transform> children = new HashSet<Transform>();
        List<Transform> childrenBuffer = new List<Transform>();
        List<Renderer> renderersBuffer = new List<Renderer>();
        List<Material> materialsBuffer = new List<Material>();
        WaitForEndOfFrame waitForEndOFFrame = new WaitForEndOfFrame();
        Coroutine forceUpdatePivotCoroutine;
        public static Material lineMaterial;
        public static Material outlineMaterial;
        void Start()
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

        void OnDestroy()
        {
            throw new NotImplementedException();
        }

        void Update()
        {
            throw new NotImplementedException();
        }

        void LateUpdate()
        {
            throw new NotImplementedException();
        }

        void DrawQuadsURP(CommandBuffer cmd, Material material, List<Vector3> lines, Color color)
        {
            throw new NotImplementedException();
        }

        void DrawTrianglesURP(CommandBuffer cmd, Material material, List<Vector3> lines, Color color)
        {
            throw new NotImplementedException();
        }

        public Color GetColor(TransformType type, Color normalColor, Color nearColor, bool forceUseNormal = false)
        {
            throw new NotImplementedException();
        }

        public Color GetColor(TransformType type, Color normalColor, Color nearColor, float alpha, bool forceUseNormal = false)
        {
            throw new NotImplementedException();
        }

        public Color GetColor(TransformType type, Color normalColor, Color nearColor, bool setAlpha, float alpha, bool forceUseNormal = false)
        {
            throw new NotImplementedException();
        }

        void HandleUndoRedo()
        {
            throw new NotImplementedException();
        }

        public TransformSpace GetProperTransformSpace()
        {
            throw new NotImplementedException();
        }

        public bool TransformTypeContains(TransformType type)
        {
            throw new NotImplementedException();
        }

        public bool TranslatingTypeContains(TransformType type, bool checkIsTransforming = true)
        {
            throw new NotImplementedException();
        }

        public bool TransformTypeContains(TransformType mainType, TransformType type)
        {
            throw new NotImplementedException();
        }

        public float GetHandleLength(TransformType type, Axis axis = Axis.None, bool multiplyDistanceMultiplier = true)
        {
            throw new NotImplementedException();
        }

        void SetSpaceAndType()
        {
            throw new NotImplementedException();
        }

        void TransformSelected()
        {
            throw new NotImplementedException();
        }

        IEnumerator TransformSelected(TransformType transType)
        {
            throw new NotImplementedException();
        }

        float CalculateSnapAmount(float snapValue, float currentAmount, out float remainder)
        {
            throw new NotImplementedException();
        }

        Vector3 GetNearAxisDirection(out Vector3 otherAxis1, out Vector3 otherAxis2)
        {
            throw new NotImplementedException();
        }

        Vector3 GetNearAxisLocalDirection(out Vector3 otherAxis1, out Vector3 otherAxis2)
        {
            throw new NotImplementedException();
        }

        void GetTarget()
        {
            throw new NotImplementedException();
        }

        public Vector2 GetMultipliedMousePosition()
        {
            throw new NotImplementedException();
        }

        public void AddTarget(Transform target, bool addCommand = true)
        {
            throw new NotImplementedException();
        }

        public void RemoveTarget(Transform target, bool addCommand = true)
        {
            throw new NotImplementedException();
        }

        public void ClearTargets(bool addCommand = true)
        {
            throw new NotImplementedException();
        }

        void ClearAndAddTarget(Transform target)
        {
            throw new NotImplementedException();
        }

        void AddTargetHighlightedRenderers(Transform target)
        {
            throw new NotImplementedException();
        }

        void GetTargetRenderers(Transform target, List<Renderer> renderers)
        {
            throw new NotImplementedException();
        }

        void ClearAllHighlightedRenderers()
        {
            throw new NotImplementedException();
        }

        void RemoveTargetHighlightedRenderers(Transform target)
        {
            throw new NotImplementedException();
        }

        void RemoveHighlightedRenderers(List<Renderer> renderers)
        {
            throw new NotImplementedException();
        }

        void AddTargetRoot(Transform targetRoot)
        {
            throw new NotImplementedException();
        }

        void RemoveTargetRoot(Transform targetRoot)
        {
            throw new NotImplementedException();
        }

        void AddAllChildren(Transform target)
        {
            throw new NotImplementedException();
        }

        void RemoveAllChildren(Transform target)
        {
            throw new NotImplementedException();
        }

        public void SetPivotPoint()
        {
            throw new NotImplementedException();
        }

        void SetPivotPointOffset(Vector3 offset)
        {
            throw new NotImplementedException();
        }

        IEnumerator ForceUpdatePivotPointAtEndOfFrame()
        {
            throw new NotImplementedException();
        }

        void ForceUpdatePivotPointOnChange()
        {
            throw new NotImplementedException();
        }

        public void SetTranslatingAxis(TransformType type, Axis axis, Axis planeAxis = Axis.None)
        {
            throw new NotImplementedException();
        }

        public AxisInfo GetAxisInfo()
        {
            throw new NotImplementedException();
        }

        void SetNearAxis()
        {
            throw new NotImplementedException();
        }

        void HandleNearestLines(TransformType type, AxisVectors axisVectors, float minSelectedDistanceCheck)
        {
            throw new NotImplementedException();
        }

        void HandleNearestPlanes(TransformType type, AxisVectors axisVectors, float minSelectedDistanceCheck)
        {
            throw new NotImplementedException();
        }

        void HandleNearest(TransformType type, float xClosestDistance, float yClosestDistance, float zClosestDistance, float allClosestDistance, float minSelectedDistanceCheck)
        {
            throw new NotImplementedException();
        }

        float ClosestDistanceFromMouseToLines(List<Vector3> lines)
        {
            throw new NotImplementedException();
        }

        float ClosestDistanceFromMouseToPlanes(List<Vector3> planePoints)
        {
            throw new NotImplementedException();
        }

        void SetAxisInfo()
        {
            throw new NotImplementedException();
        }

        public float GetDistanceMultiplier()
        {
            throw new NotImplementedException();
        }

        void SetLines()
        {
            throw new NotImplementedException();
        }

        void SetHandleLines()
        {
            throw new NotImplementedException();
        }

        int AxisDirectionMultiplier(Vector3 direction, Vector3 otherDirection)
        {
            throw new NotImplementedException();
        }

        void SetHandlePlanes()
        {
            throw new NotImplementedException();
        }

        void SetHandleTriangles()
        {
            throw new NotImplementedException();
        }

        void AddTriangles(Vector3 axisEnd, Vector3 axisDirection, Vector3 axisOtherDirection1, Vector3 axisOtherDirection2, float size, List<Vector3> resultsBuffer)
        {
            throw new NotImplementedException();
        }

        void SetHandleSquares()
        {
            throw new NotImplementedException();
        }

        void AddSquares(Vector3 axisStart, Vector3 axisDirection, Vector3 axisOtherDirection1, Vector3 axisOtherDirection2, float size, List<Vector3> resultsBuffer)
        {
            throw new NotImplementedException();
        }

        void AddQuads(Vector3 axisStart, Vector3 axisDirection, Vector3 axisOtherDirection1, Vector3 axisOtherDirection2, float length, float width, List<Vector3> resultsBuffer)
        {
            throw new NotImplementedException();
        }

        void AddQuads(Vector3 axisStart, Vector3 axisEnd, Vector3 axisOtherDirection1, Vector3 axisOtherDirection2, float width, List<Vector3> resultsBuffer)
        {
            throw new NotImplementedException();
        }

        void AddQuad(Vector3 axisStart, Vector3 axisOtherDirection1, Vector3 axisOtherDirection2, float width, List<Vector3> resultsBuffer)
        {
            throw new NotImplementedException();
        }

        Square GetBaseSquare(Vector3 axisEnd, Vector3 axisOtherDirection1, Vector3 axisOtherDirection2, float size)
        {
            throw new NotImplementedException();
        }

        void SetCircles(AxisInfo axisInfo, AxisVectors axisVectors)
        {
            throw new NotImplementedException();
        }

        void AddCircle(Vector3 origin, Vector3 axisDirection, float size, List<Vector3> resultsBuffer, bool depthTest = true)
        {
            throw new NotImplementedException();
        }

        void DrawLines(List<Vector3> lines, Color color)
        {
            throw new NotImplementedException();
        }

        void DrawTriangles(List<Vector3> lines, Color color)
        {
            throw new NotImplementedException();
        }

        void DrawQuads(List<Vector3> lines, Color color)
        {
            throw new NotImplementedException();
        }

        void DrawFilledCircle(List<Vector3> lines, Color color)
        {
            throw new NotImplementedException();
        }

        void SetMaterial()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public static void OnRenderPass(CommandBuffer cmd)
        {
            throw new NotImplementedException();
        }

        class MeshPool
        {
            public int Count => throw new NotImplementedException();
            public MeshPool()
            {
                throw new NotImplementedException();
            }

            public Mesh Get()
            {
                throw new NotImplementedException();
            }

            public void Release(Mesh mesh)
            {
                throw new NotImplementedException();
            }

            public void ReleaseAll()
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}