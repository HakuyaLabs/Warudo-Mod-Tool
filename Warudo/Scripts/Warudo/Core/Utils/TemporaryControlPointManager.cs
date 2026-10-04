using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Warudo.Core.Utils {
    /// <summary>
    /// Owns the currently active set of short-lived scene control points.
    /// Rendering and transform gizmo integrations are supplied by the caller so
    /// Warudo.Core does not depend on a particular drawing or gizmo package.
    /// </summary>
    public sealed class TemporaryControlPointManager : IDisposable {

        [Flags]
        public enum TransformOperations {
            None = 0,
            Move = 1 << 0,
            Rotate = 1 << 1,
            Scale = 1 << 2,
            All = Move | Rotate | Scale
        }

        public enum TransformOperation {
            None,
            Move,
            Rotate,
            Scale
        }

        [Flags]
        public enum WritablePoseChannels {
            None = 0,
            Position = 1 << 0,
            Rotation = 1 << 1,
            Scale = 1 << 2,
            All = Position | Rotation | Scale
        }

        public enum TransformCoordinateSpace {
            Global,
            Local
        }

        public enum PivotMode {
            Center,
            LastSelected
        }

        public enum SelectionChangeSource {
            User,
            Programmatic,
            PointRemoved,
            DeclarationsCleared
        }

        public struct Pose {
            public Vector3 Position;
            public Quaternion Rotation;
            public Vector3 Scale;

            public Pose(Vector3 position) : this(position, Quaternion.identity, Vector3.one) { }

            public Pose(Vector3 position, Quaternion rotation, Vector3 scale) {
                Position = position;
                Rotation = rotation;
                Scale = scale;
            }

            public static Pose Identity => new(Vector3.zero, Quaternion.identity, Vector3.one);
        }

        public sealed class PointStyle {
            public Color Color = Color.black;
            public Color HoveredColor = Color.yellow;
            public Color SelectedColor = new(1f, 0.6f, 0f);
            public float Radius = 0.01f;
            public float HitRadius = 20f;
        }

        public sealed class ConnectionStyle {
            public Color Color = Color.black;
            public float Width = 1.5f;
        }

        public delegate void LineDrawer(Vector3 from, Vector3 to, Color color, float width);
        public delegate void SolidCircleDrawer(Vector3 center, Vector3 normal, float radius, Color color);

        /// <summary>
        /// Drawing facade backed by delegates from the feature using the manager.
        /// It includes common curve and dashed-line helpers without exposing the
        /// concrete rendering package through Warudo.Core's public API.
        /// </summary>
        public sealed class Canvas : IDisposable {
            private readonly LineDrawer lineDrawer;
            private readonly SolidCircleDrawer solidCircleDrawer;
            private readonly Action dispose;
            private bool disposed;

            public Canvas(LineDrawer lineDrawer, SolidCircleDrawer solidCircleDrawer = null, Action dispose = null) {
                this.lineDrawer = lineDrawer;
                this.solidCircleDrawer = solidCircleDrawer;
                this.dispose = dispose;
            }

            public void Line(Vector3 from, Vector3 to, Color color, float width = 1f) {
                if (disposed) throw new ObjectDisposedException(nameof(Canvas));
                lineDrawer?.Invoke(from, to, color, width);
            }

            public void Polyline(IReadOnlyList<Vector3> points, Color color, float width = 1f, bool closed = false) {
                if (points == null) throw new ArgumentNullException(nameof(points));
                for (var i = 1; i < points.Count; i++) {
                    Line(points[i - 1], points[i], color, width);
                }
                if (closed && points.Count > 2) Line(points[points.Count - 1], points[0], color, width);
            }

            public void Bezier(Vector3 from, Vector3 control, Vector3 to, Color color, float width = 1f, int segments = 24) {
                if (segments < 1) segments = 1;
                var previous = from;
                for (var i = 1; i <= segments; i++) {
                    var t = i / (float) segments;
                    var inverseT = 1f - t;
                    var current = inverseT * inverseT * from + 2f * inverseT * t * control + t * t * to;
                    Line(previous, current, color, width);
                    previous = current;
                }
            }

            public void Bezier(Vector3 from, Vector3 fromControl, Vector3 toControl, Vector3 to, Color color, float width = 1f, int segments = 24) {
                if (segments < 1) segments = 1;
                var previous = from;
                for (var i = 1; i <= segments; i++) {
                    var t = i / (float) segments;
                    var inverseT = 1f - t;
                    var current = inverseT * inverseT * inverseT * from
                                  + 3f * inverseT * inverseT * t * fromControl
                                  + 3f * inverseT * t * t * toControl
                                  + t * t * t * to;
                    Line(previous, current, color, width);
                    previous = current;
                }
            }

            public void DashedLine(Vector3 from, Vector3 to, Color color, float width = 1f, float dashLength = 0.05f, float gapLength = 0.03f) {
                var distance = Vector3.Distance(from, to);
                if (distance <= Mathf.Epsilon) return;
                dashLength = Mathf.Max(dashLength, Mathf.Epsilon);
                gapLength = Mathf.Max(gapLength, 0f);
                var direction = (to - from) / distance;
                for (var cursor = 0f; cursor < distance; cursor += dashLength + gapLength) {
                    var dashEnd = Mathf.Min(cursor + dashLength, distance);
                    Line(from + direction * cursor, from + direction * dashEnd, color, width);
                }
            }

            public void SolidCircle(Vector3 center, Vector3 normal, float radius, Color color) {
                if (disposed) throw new ObjectDisposedException(nameof(Canvas));
                solidCircleDrawer?.Invoke(center, normal, radius, color);
            }

            public void Dispose() {
                if (disposed) return;
                disposed = true;
                dispose?.Invoke();
            }
        }

        public sealed class GizmoAdapter {
            public Action<Transform, Action<Transform>> Attach;
            public Action<Transform> Detach;
            public Func<Transform, bool> IsTransforming;
            public Func<Transform, TransformOperation> GetOperation;
            public Action<TransformOperation> SetOperation;
            public Func<Transform, TransformCoordinateSpace> GetCoordinateSpace;
        }

        public sealed class SessionOptions {
            public string Name;
            public GameObject VirtualRoot;
            public PivotMode PivotMode = PivotMode.Center;
            public TransformOperations AllowedOperations = TransformOperations.All;
            public Func<Quaternion> LocalPivotRotationProvider;
            public Func<Camera> CameraProvider;
            public Func<Camera, Canvas> CanvasFactory;
            public GizmoAdapter Gizmo;
            public Func<bool> Enabled;

            public Func<Vector2> PointerPositionProvider;
            public Func<bool> PointerDownProvider;
            public Func<bool> PointerHeldProvider;
            public Func<bool> PointerUpProvider;
            public Func<bool> AdditiveSelectionModifier;
            public float ClickMovementThreshold = 5f;
            public bool AllowEmptySelection = true;

            /// <summary>Return false to reject the proposed selection.</summary>
            public Func<SelectionChange, bool> SelectionChanging;
            public Action<SelectionChange> SelectionChanged;
            public Action<TransformChange> TransformStarted;
            public Action<TransformChange> TransformFinished;
            public Action<Session> Ended;
        }

        public sealed class PointOptions {
            public string Name;
            public GameObject VirtualRoot;
            public bool Visible = true;
            public bool Selectable = true;
            public TransformOperations AllowedOperations = TransformOperations.All;
            public WritablePoseChannels WritableChannels = WritablePoseChannels.All;
            public PointStyle Style = new();
            public Action<PointDrawContext> Draw;
            public object UserData;
        }

        public sealed class ConnectionOptions {
            public string Name;
            public bool Visible = true;
            public ConnectionStyle Style = new();
            public Action<ConnectionDrawContext> Draw;
            public object UserData;
        }

        public sealed class SelectionChange {
            internal SelectionChange(Session session, SelectionChangeSource source, IReadOnlyList<object> previous, IReadOnlyList<object> current) {
                Session = session;
                Source = source;
                Previous = previous;
                Current = current;
            }

            public Session Session { get; }
            public SelectionChangeSource Source { get; }
            public IReadOnlyList<object> Previous { get; }
            public IReadOnlyList<object> Current { get; }
        }

        public sealed class TransformChange {
            internal TransformChange(Session session, TransformOperation operation, IReadOnlyList<object> pointIds, bool changed) {
                Session = session;
                Operation = operation;
                PointIds = pointIds;
                Changed = changed;
            }

            public Session Session { get; }
            public TransformOperation Operation { get; }
            public IReadOnlyList<object> PointIds { get; }
            public bool Changed { get; }
        }

        public sealed class PointDrawContext {
            internal PointDrawContext(Canvas canvas, Camera camera, Point point, Pose worldPose, bool selected, bool hovered, bool pointerHeld) {
                Canvas = canvas;
                Camera = camera;
                Point = point;
                WorldPose = worldPose;
                Selected = selected;
                Hovered = hovered;
                PointerHeld = pointerHeld;
            }

            public Canvas Canvas { get; }
            public Camera Camera { get; }
            public Point Point { get; }
            public Pose WorldPose { get; }
            public bool Selected { get; }
            public bool Hovered { get; }
            public bool PointerHeld { get; }
        }

        public sealed class ConnectionDrawContext {
            internal ConnectionDrawContext(Canvas canvas, Camera camera, Connection connection, Point from, Point to, Pose fromWorldPose, Pose toWorldPose) {
                Canvas = canvas;
                Camera = camera;
                Connection = connection;
                From = from;
                To = to;
                FromWorldPose = fromWorldPose;
                ToWorldPose = toWorldPose;
            }

            public Canvas Canvas { get; }
            public Camera Camera { get; }
            public Connection Connection { get; }
            public Point From { get; }
            public Point To { get; }
            public Pose FromWorldPose { get; }
            public Pose ToWorldPose { get; }
        }

        public sealed class Point {
            internal Point(object id, Func<Pose> poseGetter, Action<Pose> poseSetter, PointOptions options) {
                Id = id;
                PoseGetter = poseGetter;
                PoseSetter = poseSetter;
                Options = options;
            }

            public object Id { get; }
            public PointOptions Options { get; internal set; }
            public bool IsReadOnly => PoseSetter == null;

            internal Func<Pose> PoseGetter { get; set; }
            internal Action<Pose> PoseSetter { get; set; }
        }

        public sealed class Connection {
            internal Connection(object id, object fromId, object toId, ConnectionOptions options) {
                Id = id;
                FromId = fromId;
                ToId = toId;
                Options = options;
            }

            public object Id { get; }
            public object FromId { get; internal set; }
            public object ToId { get; internal set; }
            public ConnectionOptions Options { get; internal set; }
        }

        public sealed class Session : IDisposable {
            private sealed class PointSnapshot {
                public Point Point;
                public Pose LocalPose;
                public Pose WorldPose;
            }

            private readonly TemporaryControlPointManager manager;
            private readonly object owner;
            private readonly Dictionary<object, Point> points = new();
            private readonly List<Point> orderedPoints = new();
            private readonly Dictionary<object, Connection> connections = new();
            private readonly List<Connection> orderedConnections = new();
            private readonly List<object> selectedIds = new();
            private readonly Dictionary<object, PointSnapshot> transformSnapshots = new();
            private readonly GameObject pivotObject;

            private bool disposed;
            private bool gizmoAttached;
            private bool transforming;
            private bool transformChanged;
            private bool pointerWasPressed;
            private Vector2 pointerDownPosition;
            private Vector3 transformPivotPosition;
            private Quaternion transformPivotRotation;
            private Vector3 transformPivotScale;
            private TransformOperation transformingOperation;
            private object hoveredId;

            internal Session(TemporaryControlPointManager manager, object owner, ulong generation, SessionOptions options) {
                this.manager = manager;
                this.owner = owner;
                Generation = generation;
                Options = options ?? new SessionOptions();
                pivotObject = new GameObject(string.IsNullOrEmpty(Options.Name) ? "Temporary Control Point Pivot" : $"{Options.Name} Pivot") {
                    hideFlags = HideFlags.HideAndDontSave
                };
            }

            public ulong Generation { get; }
            public object Owner => owner;
            public SessionOptions Options { get; }
            public Transform PivotTransform => pivotObject != null ? pivotObject.transform : null;
            public bool IsActive => !disposed && manager.activeSession == this;
            public bool IsTransforming => transforming;
            public object HoveredId => hoveredId;
            public IReadOnlyList<object> SelectedIds => selectedIds;
            public IReadOnlyList<Point> Points => orderedPoints;
            public IReadOnlyList<Connection> Connections => orderedConnections;

            public Point DeclarePoint(object id, Func<Pose> poseGetter, Action<Pose> poseSetter = null, PointOptions options = null) {
                ThrowIfDisposed();
                if (id == null) throw new ArgumentNullException(nameof(id));
                if (poseGetter == null) throw new ArgumentNullException(nameof(poseGetter));
                options ??= new PointOptions();
                options.Style ??= new PointStyle();

                if (points.TryGetValue(id, out var point)) {
                    FinishTransformBeforeMutation();
                    if (disposed) throw new ObjectDisposedException(nameof(Session));
                    if (points.TryGetValue(id, out point)) {
                        point.PoseGetter = poseGetter;
                        point.PoseSetter = poseSetter;
                        point.Options = options;
                        if (selectedIds.Contains(id)) RefreshPivot();
                        return point;
                    }
                }

                point = new Point(id, poseGetter, poseSetter, options);
                points.Add(id, point);
                orderedPoints.Add(point);
                return point;
            }

            public bool RemovePoint(object id) {
                ThrowIfDisposed();
                if (id == null || !points.TryGetValue(id, out var point)) return false;
                FinishTransformBeforeMutation();
                if (disposed) return false;
                if (!points.TryGetValue(id, out point)) return true;

                points.Remove(id);
                orderedPoints.Remove(point);
                for (var i = orderedConnections.Count - 1; i >= 0; i--) {
                    var connection = orderedConnections[i];
                    if (!Equals(connection.FromId, id) && !Equals(connection.ToId, id)) continue;
                    connections.Remove(connection.Id);
                    orderedConnections.RemoveAt(i);
                }

                if (selectedIds.Contains(id)) {
                    var next = new List<object>(selectedIds);
                    next.Remove(id);
                    ChangeSelection(next, SelectionChangeSource.PointRemoved, false);
                }
                if (Equals(hoveredId, id)) hoveredId = null;
                return true;
            }

            public void ClearPoints() {
                ThrowIfDisposed();
                FinishTransformBeforeMutation();
                if (disposed) return;
                ClearConnections();
                points.Clear();
                orderedPoints.Clear();
                hoveredId = null;
                if (selectedIds.Count > 0) ChangeSelection(new List<object>(), SelectionChangeSource.DeclarationsCleared, false);
                else RefreshPivot();
            }

            public Connection DeclareConnection(object id, object fromId, object toId, ConnectionOptions options = null) {
                ThrowIfDisposed();
                if (id == null) throw new ArgumentNullException(nameof(id));
                if (fromId == null) throw new ArgumentNullException(nameof(fromId));
                if (toId == null) throw new ArgumentNullException(nameof(toId));
                options ??= new ConnectionOptions();
                options.Style ??= new ConnectionStyle();

                if (connections.TryGetValue(id, out var connection)) {
                    connection.FromId = fromId;
                    connection.ToId = toId;
                    connection.Options = options;
                    return connection;
                }

                connection = new Connection(id, fromId, toId, options);
                connections.Add(id, connection);
                orderedConnections.Add(connection);
                return connection;
            }

            public bool RemoveConnection(object id) {
                ThrowIfDisposed();
                if (id == null || !connections.TryGetValue(id, out var connection)) return false;
                connections.Remove(id);
                orderedConnections.Remove(connection);
                return true;
            }

            public void ClearConnections() {
                ThrowIfDisposed();
                connections.Clear();
                orderedConnections.Clear();
            }

            public Point GetPoint(object id) {
                if (id == null) return null;
                points.TryGetValue(id, out var point);
                return point;
            }

            public Connection GetConnection(object id) {
                if (id == null) return null;
                connections.TryGetValue(id, out var connection);
                return connection;
            }

            public bool IsSelected(object id) => id != null && selectedIds.Contains(id);

            public bool SetSelection(IEnumerable<object> ids, SelectionChangeSource source = SelectionChangeSource.Programmatic) {
                ThrowIfDisposed();
                if (ids == null) return ChangeSelection(new List<object>(), source);

                var next = new List<object>();
                var unique = new HashSet<object>();
                foreach (var id in ids) {
                    if (id == null || !points.TryGetValue(id, out var point) || !point.Options.Selectable || !unique.Add(id)) continue;
                    next.Add(id);
                }
                return ChangeSelection(next, source);
            }

            public bool ClearSelection(SelectionChangeSource source = SelectionChangeSource.Programmatic) {
                ThrowIfDisposed();
                return ChangeSelection(new List<object>(), source);
            }

            public void RefreshPivot() {
                ThrowIfDisposed();
                if (transforming) return;
                DetachGizmo();
                SynchronizePivotAndSnapshots();
                AttachGizmo();
            }

            internal bool IsOwnerAlive() {
                if (owner == null) return false;
                return owner is not Object unityObject || unityObject != null;
            }

            internal void UpdateInternal() {
                if (disposed || !IsActive) return;
                if (!IsOwnerAlive()) {
                    manager.Release(this);
                    return;
                }

                var enabled = EvaluateEnabled();
                if (!enabled) {
                    hoveredId = null;
                    FinishTransformBeforeMutation();
                    DetachGizmo();
                    return;
                }

                if (!gizmoAttached && selectedIds.Count > 0) {
                    SynchronizePivotAndSnapshots();
                    AttachGizmo();
                }
                UpdateGizmoState();
                UpdatePointerAndSelection();
                Draw();
            }

            internal void End() {
                if (disposed) return;
                disposed = true;
                DetachGizmo();
                transformSnapshots.Clear();
                selectedIds.Clear();
                hoveredId = null;

                if (pivotObject != null) {
                    if (Application.isPlaying) Object.Destroy(pivotObject);
                    else Object.DestroyImmediate(pivotObject);
                }

                try {
                    Options.Ended?.Invoke(this);
                } catch (Exception exception) {
                    Debug.LogException(exception);
                }
            }

            public void Dispose() {
                manager.Release(this);
            }

            private bool ChangeSelection(List<object> next, SelectionChangeSource source, bool allowVeto = true) {
                if (SelectionsEqual(selectedIds, next)) return true;

                var previousSnapshot = selectedIds.ToArray();
                var currentSnapshot = next.ToArray();
                var change = new SelectionChange(this, source, previousSnapshot, currentSnapshot);
                if (allowVeto && Options.SelectionChanging != null) {
                    try {
                        if (!Options.SelectionChanging(change)) return false;
                    } catch (Exception exception) {
                        Debug.LogException(exception);
                        return false;
                    }
                }

                if (disposed || !IsActive || !SelectionsEqual(selectedIds, previousSnapshot) || !IsValidSelection(next)) return false;
                FinishTransformBeforeMutation();
                if (disposed || !IsActive || !SelectionsEqual(selectedIds, previousSnapshot) || !IsValidSelection(next)) return false;

                selectedIds.Clear();
                selectedIds.AddRange(next);
                try {
                    Options.SelectionChanged?.Invoke(change);
                } catch (Exception exception) {
                    Debug.LogException(exception);
                }

                if (disposed || !IsActive) return true;
                RefreshPivot();
                return true;
            }

            private void FinishTransformBeforeMutation() {
                if (transforming) FinishTransform();
            }

            private void UpdatePointerAndSelection() {
                var camera = Options.CameraProvider?.Invoke();
                if (camera == null) {
                    hoveredId = null;
                    return;
                }

                var pointerPosition = Options.PointerPositionProvider?.Invoke() ?? (Vector2) Input.mousePosition;
                hoveredId = FindHoveredPoint(camera, pointerPosition);

                var pointerDown = Options.PointerDownProvider?.Invoke() ?? Input.GetMouseButtonDown(0);
                if (pointerDown) {
                    pointerWasPressed = true;
                    pointerDownPosition = pointerPosition;
                }

                var pointerUp = Options.PointerUpProvider?.Invoke() ?? Input.GetMouseButtonUp(0);
                if (!pointerUp) return;

                var isClick = pointerWasPressed && Vector2.Distance(pointerDownPosition, pointerPosition) <= Mathf.Max(0f, Options.ClickMovementThreshold);
                pointerWasPressed = false;
                if (!isClick || transforming) return;

                if (hoveredId != null) {
                    var additive = Options.AdditiveSelectionModifier?.Invoke()
                                   ?? (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));
                    var next = additive ? new List<object>(selectedIds) : new List<object>();
                    if (additive && next.Contains(hoveredId)) next.Remove(hoveredId);
                    else next.Add(hoveredId);
                    ChangeSelection(next, SelectionChangeSource.User);
                } else if (Options.AllowEmptySelection && selectedIds.Count > 0) {
                    ChangeSelection(new List<object>(), SelectionChangeSource.User);
                }
            }

            private object FindHoveredPoint(Camera camera, Vector2 pointerPosition) {
                object result = null;
                var closestDistance = float.PositiveInfinity;
                foreach (var point in orderedPoints) {
                    if (!point.Options.Visible || !point.Options.Selectable || !TryGetWorldPose(point, out var worldPose)) continue;
                    var screenPosition = camera.WorldToScreenPoint(worldPose.Position);
                    if (screenPosition.z < 0f) continue;
                    var distance = Vector2.Distance(pointerPosition, new Vector2(screenPosition.x, screenPosition.y));
                    var hitRadius = Mathf.Max(0f, point.Options.Style?.HitRadius ?? 0f);
                    if (distance > hitRadius || distance >= closestDistance) continue;
                    closestDistance = distance;
                    result = point.Id;
                }
                return result;
            }

            private void Draw() {
                var camera = Options.CameraProvider?.Invoke();
                if (camera == null || Options.CanvasFactory == null) return;

                Canvas canvas = null;
                try {
                    canvas = Options.CanvasFactory(camera);
                    if (canvas == null) return;

                    var connectionSnapshot = orderedConnections.ToArray();
                    foreach (var connection in connectionSnapshot) {
                        if (!connection.Options.Visible
                            || !points.TryGetValue(connection.FromId, out var from)
                            || !points.TryGetValue(connection.ToId, out var to)
                            || !from.Options.Visible
                            || !to.Options.Visible
                            || !TryGetWorldPose(from, out var fromPose)
                            || !TryGetWorldPose(to, out var toPose)) continue;

                        var context = new ConnectionDrawContext(canvas, camera, connection, from, to, fromPose, toPose);
                        if (connection.Options.Draw != null) connection.Options.Draw(context);
                        else {
                            var style = connection.Options.Style ?? new ConnectionStyle();
                            canvas.Line(fromPose.Position, toPose.Position, style.Color, style.Width);
                        }
                    }

                    var pointerHeld = Options.PointerHeldProvider?.Invoke() ?? Input.GetMouseButton(0);
                    var pointSnapshot = orderedPoints.ToArray();
                    foreach (var point in pointSnapshot) {
                        if (!point.Options.Visible || !TryGetWorldPose(point, out var worldPose)) continue;
                        var selected = selectedIds.Contains(point.Id);
                        var hovered = Equals(hoveredId, point.Id);
                        var context = new PointDrawContext(canvas, camera, point, worldPose, selected, hovered, pointerHeld);
                        if (point.Options.Draw != null) point.Options.Draw(context);
                        else DrawDefaultPoint(context);
                    }
                } catch (Exception exception) {
                    Debug.LogException(exception);
                } finally {
                    canvas?.Dispose();
                }
            }

            private static void DrawDefaultPoint(PointDrawContext context) {
                var style = context.Point.Options.Style ?? new PointStyle();
                var color = context.Hovered ? style.HoveredColor : context.Selected ? style.SelectedColor : style.Color;
                if (context.PointerHeld && context.Hovered) color = context.Selected ? style.SelectedColor : style.Color;
                context.Canvas.SolidCircle(context.WorldPose.Position, context.Camera.transform.forward, style.Radius, color);
            }

            private void UpdateGizmoState() {
                if (!gizmoAttached || PivotTransform == null) return;
                var adapter = Options.Gizmo;
                var hostIsTransforming = adapter?.IsTransforming?.Invoke(PivotTransform) ?? false;

                if (hostIsTransforming) {
                    if (!transforming) BeginTransform();
                    return;
                }

                if (transforming) FinishTransform();
                SynchronizePivotAndSnapshots();
                EnsureCurrentOperationIsAllowed();
            }

            private void BeginTransform() {
                if (transforming) return;
                transforming = true;
                transformChanged = false;
                transformingOperation = Options.Gizmo?.GetOperation?.Invoke(PivotTransform) ?? TransformOperation.None;
                if (transformSnapshots.Count == 0) CaptureTransformSnapshots();

                try {
                    Options.TransformStarted?.Invoke(new TransformChange(this, transformingOperation, selectedIds.ToArray(), false));
                } catch (Exception exception) {
                    Debug.LogException(exception);
                }
            }

            private void FinishTransform() {
                if (!transforming) return;
                transforming = false;
                var change = new TransformChange(this, transformingOperation, selectedIds.ToArray(), transformChanged);
                try {
                    Options.TransformFinished?.Invoke(change);
                } catch (Exception exception) {
                    Debug.LogException(exception);
                }
                transformingOperation = TransformOperation.None;
                transformChanged = false;
            }

            private void OnPivotChanged(Transform pivot) {
                if (disposed || !IsActive || pivot == null || selectedIds.Count == 0 || !EvaluateEnabled()) return;
                if (!transforming) BeginTransform();

                var operation = transformingOperation;
                if (!IsOperationAllowed(operation)) {
                    EnsureCurrentOperationIsAllowed();
                    return;
                }

                var positionDelta = pivot.position - transformPivotPosition;
                var rotationDelta = pivot.rotation * Quaternion.Inverse(transformPivotRotation);
                var scaleDelta = Divide(pivot.localScale, transformPivotScale);

                foreach (var pointId in selectedIds) {
                    if (!transformSnapshots.TryGetValue(pointId, out var snapshot)
                        || snapshot.Point.PoseSetter == null
                        || !Allows(snapshot.Point.Options.AllowedOperations, operation)) continue;

                    var worldPose = snapshot.WorldPose;
                    var writableChannels = snapshot.Point.Options.WritableChannels;
                    switch (operation) {
                        case TransformOperation.Move:
                            if ((writableChannels & WritablePoseChannels.Position) != 0) {
                                worldPose.Position = snapshot.WorldPose.Position + positionDelta;
                            }
                            break;
                        case TransformOperation.Rotate:
                            if ((writableChannels & WritablePoseChannels.Position) != 0) {
                                worldPose.Position = transformPivotPosition + rotationDelta * (snapshot.WorldPose.Position - transformPivotPosition);
                            }
                            if ((writableChannels & WritablePoseChannels.Rotation) != 0) {
                                worldPose.Rotation = rotationDelta * snapshot.WorldPose.Rotation;
                            }
                            break;
                        case TransformOperation.Scale:
                            if ((writableChannels & WritablePoseChannels.Position) != 0) {
                                var relative = Quaternion.Inverse(transformPivotRotation) * (snapshot.WorldPose.Position - transformPivotPosition);
                                relative = Vector3.Scale(relative, scaleDelta);
                                worldPose.Position = transformPivotPosition + transformPivotRotation * relative;
                            }
                            if ((writableChannels & WritablePoseChannels.Scale) != 0) {
                                worldPose.Scale = Vector3.Scale(snapshot.WorldPose.Scale, scaleDelta);
                            }
                            break;
                    }

                    WriteWorldPose(snapshot.Point, worldPose);
                    if (TryGetLocalPose(snapshot.Point, out var currentPose) && !PoseApproximately(snapshot.LocalPose, currentPose)) {
                        transformChanged = true;
                    }
                }
            }

            private void SynchronizePivotAndSnapshots() {
                if (transforming || selectedIds.Count == 0 || PivotTransform == null) return;
                CaptureTransformSnapshots();
                if (transformSnapshots.Count == 0) return;

                var pivotPosition = CalculatePivotPosition();
                PivotTransform.SetPositionAndRotation(pivotPosition, CalculatePivotRotation());
                PivotTransform.localScale = Vector3.one;
                transformPivotPosition = PivotTransform.position;
                transformPivotRotation = PivotTransform.rotation;
                transformPivotScale = PivotTransform.localScale;
            }

            private void CaptureTransformSnapshots() {
                transformSnapshots.Clear();
                foreach (var id in selectedIds) {
                    if (!points.TryGetValue(id, out var point)
                        || point.PoseSetter == null
                        || !TryGetLocalPose(point, out var localPose)
                        || !TryGetWorldPose(point, localPose, out var worldPose)) continue;
                    transformSnapshots[id] = new PointSnapshot {
                        Point = point,
                        LocalPose = localPose,
                        WorldPose = worldPose
                    };
                }
            }

            private Vector3 CalculatePivotPosition() {
                if (Options.PivotMode == PivotMode.LastSelected) {
                    for (var i = selectedIds.Count - 1; i >= 0; i--) {
                        if (transformSnapshots.TryGetValue(selectedIds[i], out var snapshot)) return snapshot.WorldPose.Position;
                    }
                }

                var position = Vector3.zero;
                var count = 0;
                foreach (var id in selectedIds) {
                    if (!transformSnapshots.TryGetValue(id, out var snapshot)) continue;
                    position += snapshot.WorldPose.Position;
                    count++;
                }
                return count == 0 ? Vector3.zero : position / count;
            }

            private Quaternion CalculatePivotRotation() {
                var space = Options.Gizmo?.GetCoordinateSpace?.Invoke(PivotTransform) ?? TransformCoordinateSpace.Global;
                if (space == TransformCoordinateSpace.Global) return Quaternion.identity;
                if (Options.LocalPivotRotationProvider != null) return Options.LocalPivotRotationProvider();
                if (Options.VirtualRoot != null) return Options.VirtualRoot.transform.rotation;

                for (var i = selectedIds.Count - 1; i >= 0; i--) {
                    if (!points.TryGetValue(selectedIds[i], out var point)) continue;
                    var root = ResolveRoot(point);
                    if (root != null) return root.rotation;
                }
                return Quaternion.identity;
            }

            private void AttachGizmo() {
                if (disposed || selectedIds.Count == 0 || transformSnapshots.Count == 0 || Options.Gizmo?.Attach == null || PivotTransform == null || !EvaluateEnabled()) return;
                try {
                    Options.Gizmo.Attach(PivotTransform, OnPivotChanged);
                    gizmoAttached = true;
                    EnsureCurrentOperationIsAllowed();
                } catch (Exception exception) {
                    Debug.LogException(exception);
                    gizmoAttached = false;
                }
            }

            private void DetachGizmo() {
                if (!gizmoAttached || PivotTransform == null) return;
                try {
                    Options.Gizmo?.Detach?.Invoke(PivotTransform);
                } catch (Exception exception) {
                    Debug.LogException(exception);
                }
                gizmoAttached = false;
                transforming = false;
                transformingOperation = TransformOperation.None;
                transformSnapshots.Clear();
            }

            private bool EvaluateEnabled() {
                try {
                    return Options.Enabled?.Invoke() ?? true;
                } catch (Exception exception) {
                    Debug.LogException(exception);
                    return false;
                }
            }

            private void EnsureCurrentOperationIsAllowed() {
                if (!gizmoAttached || Options.Gizmo?.GetOperation == null || Options.Gizmo.SetOperation == null) return;
                var current = Options.Gizmo.GetOperation(PivotTransform);
                if (IsOperationAllowed(current)) return;
                var allowed = GetAvailableOperations();
                if ((allowed & TransformOperations.Move) != 0) Options.Gizmo.SetOperation(TransformOperation.Move);
                else if ((allowed & TransformOperations.Rotate) != 0) Options.Gizmo.SetOperation(TransformOperation.Rotate);
                else if ((allowed & TransformOperations.Scale) != 0) Options.Gizmo.SetOperation(TransformOperation.Scale);
            }

            private bool IsOperationAllowed(TransformOperation operation) {
                var available = GetAvailableOperations();
                return operation switch {
                    TransformOperation.Move => (available & TransformOperations.Move) != 0,
                    TransformOperation.Rotate => (available & TransformOperations.Rotate) != 0,
                    TransformOperation.Scale => (available & TransformOperations.Scale) != 0,
                    _ => false
                };
            }

            private TransformOperations GetAvailableOperations() {
                var available = TransformOperations.None;
                foreach (var id in selectedIds) {
                    if (!points.TryGetValue(id, out var point) || point.PoseSetter == null) continue;
                    var pointOperations = point.Options.AllowedOperations;
                    var channels = point.Options.WritableChannels;
                    if ((channels & WritablePoseChannels.Position) == 0) pointOperations &= ~TransformOperations.Move;
                    if ((channels & (WritablePoseChannels.Position | WritablePoseChannels.Rotation)) == 0) pointOperations &= ~TransformOperations.Rotate;
                    if ((channels & (WritablePoseChannels.Position | WritablePoseChannels.Scale)) == 0) pointOperations &= ~TransformOperations.Scale;
                    available |= pointOperations;
                }
                return available & Options.AllowedOperations;
            }

            private static bool Allows(TransformOperations operations, TransformOperation operation) {
                return operation switch {
                    TransformOperation.Move => (operations & TransformOperations.Move) != 0,
                    TransformOperation.Rotate => (operations & TransformOperations.Rotate) != 0,
                    TransformOperation.Scale => (operations & TransformOperations.Scale) != 0,
                    _ => false
                };
            }

            private bool TryGetLocalPose(Point point, out Pose pose) {
                try {
                    pose = point.PoseGetter();
                    if (pose.Rotation == default) pose.Rotation = Quaternion.identity;
                    return true;
                } catch (Exception exception) {
                    Debug.LogException(exception);
                    pose = Pose.Identity;
                    return false;
                }
            }

            private bool TryGetWorldPose(Point point, out Pose worldPose) {
                if (!TryGetLocalPose(point, out var localPose)) {
                    worldPose = Pose.Identity;
                    return false;
                }
                return TryGetWorldPose(point, localPose, out worldPose);
            }

            private bool TryGetWorldPose(Point point, Pose localPose, out Pose worldPose) {
                var root = ResolveRoot(point);
                if (root == null) {
                    worldPose = localPose;
                    return true;
                }
                worldPose = new Pose(
                    root.TransformPoint(localPose.Position),
                    root.rotation * localPose.Rotation,
                    Vector3.Scale(root.lossyScale, localPose.Scale)
                );
                return true;
            }

            private void WriteWorldPose(Point point, Pose worldPose) {
                if (point.PoseSetter == null) return;
                var root = ResolveRoot(point);
                var localPose = root == null
                    ? worldPose
                    : new Pose(
                        root.InverseTransformPoint(worldPose.Position),
                        Quaternion.Inverse(root.rotation) * worldPose.Rotation,
                        Divide(worldPose.Scale, root.lossyScale)
                    );
                try {
                    point.PoseSetter(localPose);
                } catch (Exception exception) {
                    Debug.LogException(exception);
                }
            }

            private Transform ResolveRoot(Point point) {
                var rootObject = point.Options.VirtualRoot != null ? point.Options.VirtualRoot : Options.VirtualRoot;
                return rootObject != null ? rootObject.transform : null;
            }

            private static Vector3 Divide(Vector3 value, Vector3 divisor) {
                return new Vector3(
                    Mathf.Abs(divisor.x) <= Mathf.Epsilon ? 1f : value.x / divisor.x,
                    Mathf.Abs(divisor.y) <= Mathf.Epsilon ? 1f : value.y / divisor.y,
                    Mathf.Abs(divisor.z) <= Mathf.Epsilon ? 1f : value.z / divisor.z
                );
            }

            private static bool PoseApproximately(Pose a, Pose b) {
                return (a.Position - b.Position).sqrMagnitude <= 0.00000001f
                       && Quaternion.Angle(a.Rotation, b.Rotation) <= 0.001f
                       && (a.Scale - b.Scale).sqrMagnitude <= 0.00000001f;
            }

            private static bool SelectionsEqual(IReadOnlyList<object> a, IReadOnlyList<object> b) {
                if (a.Count != b.Count) return false;
                for (var i = 0; i < a.Count; i++) {
                    if (!Equals(a[i], b[i])) return false;
                }
                return true;
            }

            private bool IsValidSelection(IReadOnlyList<object> ids) {
                var unique = new HashSet<object>();
                for (var i = 0; i < ids.Count; i++) {
                    var id = ids[i];
                    if (id == null || !unique.Add(id) || !points.TryGetValue(id, out var point) || !point.Options.Selectable) return false;
                }
                return true;
            }

            private void ThrowIfDisposed() {
                if (disposed) throw new ObjectDisposedException(nameof(Session));
            }
        }

        private Session activeSession;
        private ulong nextGeneration;
        private bool disposed;
        private bool resetting;

        public Session ActiveSession => activeSession != null && activeSession.IsActive ? activeSession : null;

        /// <summary>
        /// Acquires the single temporary-control-point channel. Any previous
        /// session is ended before the new one becomes active.
        /// </summary>
        public Session BeginSession(object owner, SessionOptions options = null) {
            if (disposed) throw new ObjectDisposedException(nameof(TemporaryControlPointManager));
            if (resetting) throw new InvalidOperationException("A temporary control point session cannot be acquired from an Ended callback.");
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            Reset();
            activeSession = new Session(this, owner, ++nextGeneration, options);
            return activeSession;
        }

        public bool IsOwnedBy(object owner) => activeSession != null && Equals(activeSession.Owner, owner);

        public void Update() {
            if (disposed) return;
            try {
                activeSession?.UpdateInternal();
            } catch (Exception exception) {
                Debug.LogException(exception);
            }
        }

        public void Reset() {
            if (resetting) return;
            resetting = true;
            try {
                var session = activeSession;
                activeSession = null;
                session?.End();
            } finally {
                resetting = false;
            }
        }

        internal void Release(Session session) {
            if (session == null) return;
            if (activeSession == session) activeSession = null;
            session.End();
        }

        public void Dispose() {
            if (disposed) return;
            Reset();
            disposed = true;
        }
    }
}
