using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Warudo.Core.Utils {
    public static class UnityExtensions {
        public static Quaternion TransformRotation(this Transform transform, Quaternion rotation) {
            return transform.rotation * rotation;
        }
        
        public static Quaternion InverseTransformRotation(this Transform transform, Quaternion rotation) {
            return Quaternion.Inverse(transform.rotation) * rotation;
        }
        
        public static bool ContainsNaN(this Vector3 vector) {
            return float.IsNaN(vector.x) || float.IsNaN(vector.y) || float.IsNaN(vector.z);
        }
        
        public static void SetLeft(this RectTransform rt, float left) {
            rt.offsetMin = new Vector2(left, rt.offsetMin.y);
        }
 
        public static void SetRight(this RectTransform rt, float right) {
            rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
        }
 
        public static void SetTop(this RectTransform rt, float top) {
            rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
        }
 
        public static void SetBottom(this RectTransform rt, float bottom) {
            rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
        }
    
        public static Color WithAlpha(this Color color, float alpha) {
            return new Color(color.r, color.g, color.b, alpha);
        }
    
        public static int AddLayerToLayerMask(this int layerMask, int layer)
        {
            return layerMask | 1 << layer;
        }
   
        public static int RemoveLayerFromLayerMask(this int layerMask, int layer)
        {
            return layerMask & ~(1 << layer);
        }
 
        public static void AddLayerToCullingMask(this Camera camera, int layer)
        {
            camera.cullingMask |= 1 << layer;
        }
   
        public static void RemoveLayerFromCullingMask(this Camera camera, int layer)
        {
            camera.cullingMask &= ~(1 << layer);
        }
    
        public static void SetAlpha(this Graphic graphic, float alpha) {
            var color = graphic.color;
            color.a = alpha;
            graphic.color = color;
        }
        
        public static Quaternion[] FillWithIdentity(this Quaternion[] array) {
            for (var i = 0; i < array.Length; i++) {
                array[i] = Quaternion.identity;
            }
            return array;
        }
        
        public static float[] FillWithOne(this float[] array) {
            for (var i = 0; i < array.Length; i++) {
                array[i] = 1;
            }
            return array;
        }

        public static void SetLayerRecursively(this Transform parent, int layer, Func<Transform, bool> predicate = default) {
            if (predicate == default || predicate(parent)) {
                parent.gameObject.layer = layer;
            }
            for (int i = 0, count = parent.childCount; i < count; i++) {
                parent.GetChild(i).SetLayerRecursively(layer, predicate);
            }
        }
        
        public static Quaternion SmoothDamp(Quaternion current, Quaternion target, ref Quaternion currentVelocity, float smoothTime) {
            if (Time.deltaTime < Mathf.Epsilon) return current;
            var dot = Quaternion.Dot(current, target);
            var inverse = dot > 0f ? 1f : -1f;
            target.x *= inverse;
            target.y *= inverse;
            target.z *= inverse;
            target.w *= inverse;
            var result = new Vector4(
                Mathf.SmoothDamp(current.x, target.x, ref currentVelocity.x, smoothTime),
                Mathf.SmoothDamp(current.y, target.y, ref currentVelocity.y, smoothTime),
                Mathf.SmoothDamp(current.z, target.z, ref currentVelocity.z, smoothTime),
                Mathf.SmoothDamp(current.w, target.w, ref currentVelocity.w, smoothTime)).normalized;
            var e = Vector4.Project(new Vector4(currentVelocity.x, currentVelocity.y, currentVelocity.z, currentVelocity.w), result);
            currentVelocity.x -= e.x;
            currentVelocity.y -= e.y;
            currentVelocity.z -= e.z;
            currentVelocity.w -= e.w;
            return new Quaternion(result.x, result.y, result.z, result.w);
        }
        
        public static T GetOrAddComponent<T>(this GameObject go) where T : Component {
            var component = go.GetComponent<T>();
            return component != null ? component : go.AddComponent<T>();
        }
        
        public static AnimationCurve Smoothed(this AnimationCurve curve) {
            for (var index = 0; index < curve.length; ++index)
                curve.SmoothTangents(index, 0.0f);
            return curve;
        }
		
        public static string GetPath(this Transform transform, Transform relativeTransform = null) {
            var hierarchyPath = transform.name;
            while (transform.parent != null && transform.parent != relativeTransform)
            {
                transform = transform.parent;
                hierarchyPath = transform.name + "/" + hierarchyPath;
            }
            return hierarchyPath;
        }
        
        public static Vector3 RotatePointAroundPivot(this Vector3 point, Vector3 pivot, Vector3 angles)
        {
            return Quaternion.Euler(angles) * (point - pivot) + pivot;
        }

        public static Vector3 WithX(this Vector3 vector, float newValue)
        {
            vector.x = newValue;
            return vector;
        }

        public static Vector3 WithY(this Vector3 vector, float newValue)
        {
            vector.y = newValue;
            return vector;
        }

        public static Vector3 WithZ(this Vector3 vector, float newValue)
        {
            vector.z = newValue;
            return vector;
        }

        public static void SetX(this Transform transform, float x)
        {
            var position = transform.position;
            position = new Vector3(x, position.y, position.z);
            transform.position = position;
        }

        public static void SetY(this Transform transform, float y)
        {
            var position = transform.position;
            position = new Vector3(position.x, y, position.z);
            transform.position = position;
        }

        public static void SetZ(this Transform transform, float z)
        {
            var position = transform.position;
            position = new Vector3(position.x, position.y, z);
            transform.position = position;
        }

        public static void SetAnchoredX(this RectTransform transform, float x)
        {
            var position = transform.anchoredPosition;
            position = new Vector2(x, position.y);
            transform.anchoredPosition = position;
        }

        public static void SetAnchoredY(this RectTransform transform, float y)
        {
            var position = transform.anchoredPosition;
            position = new Vector2(position.x, y);
            transform.anchoredPosition = position;
        }

        public static void DeltaX(this Transform transform, float dx)
        {
            var position = transform.position;
            position = new Vector3(position.x + dx, position.y, position.z);
            transform.position = position;
        }

        public static void DeltaY(this Transform transform, float dy)
        {
            var position = transform.position;
            position = new Vector3(position.x, position.y + dy, position.z);
            transform.position = position;
        }

        public static void DeltaZ(this Transform transform, float dz)
        {
            var position = transform.position;
            position = new Vector3(position.x, position.y, position.z + dz);
            transform.position = position;
        }

        public static void SetLocalScale(this Transform transform, float xyz)
        {
            transform.localScale = new Vector3(xyz, xyz, xyz);
        }

        public static void SetLocalScaleX(this Transform transform, float x)
        {
            var scale = transform.localScale;
            transform.localScale = new Vector3(x, scale.y, scale.z);
        }

        public static void SetLocalScaleY(this Transform transform, float y)
        {
            var scale = transform.localScale;
            transform.localScale = new Vector3(scale.x, y, scale.z);
        }

        public static void SetLocalScaleXY(this Transform transform, float x, float y = default)
        {
            if (y == default) y = x;
            transform.localScale = new Vector3(x, y, transform.localScale.z);
        }

        public static void SetLocalX(this Transform transform, float x)
        {
            var localPosition = transform.localPosition;
            localPosition = new Vector3(x, localPosition.y, localPosition.z);
            transform.localPosition = localPosition;
        }

        public static void SetLocalY(this Transform transform, float y)
        {
            var localPosition = transform.localPosition;
            localPosition = new Vector3(localPosition.x, y, localPosition.z);
            transform.localPosition = localPosition;
        }

        public static void SetLocalZ(this Transform transform, float z)
        {
            var localPosition = transform.localPosition;
            localPosition = new Vector3(localPosition.x, localPosition.y, z);
            transform.localPosition = localPosition;
        }

        public static void SetLocalEulerAnglesX(this Transform transform, float x)
        {
            var eulerAngles = transform.localEulerAngles;
            eulerAngles = new Vector3(x, eulerAngles.y, eulerAngles.z);
            transform.localEulerAngles = eulerAngles;
        }

        public static void SetLocalEulerAnglesY(this Transform transform, float y)
        {
            var eulerAngles = transform.localEulerAngles;
            eulerAngles = new Vector3(eulerAngles.x, y, eulerAngles.z);
            transform.localEulerAngles = eulerAngles;
        }

        public static void SetLocalEulerAnglesZ(this Transform transform, float z)
        {
            var eulerAngles = transform.localEulerAngles;
            eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, z);
            transform.localEulerAngles = eulerAngles;
        }
        
        public static bool ApproximatelyEquals(this Quaternion q1, Quaternion q2, float epsilon = 0.0000004f) {
            return Mathf.Abs(Quaternion.Dot(q1, q2)) >= 1 - epsilon;
        }
        
        public static Vector3 GenerateRandomPositionAtViewportBounds(this Camera camera, Vector2? viewportPosition = null, float z = 0.1f) {
            if (viewportPosition == null) viewportPosition = camera.GenerateRandomViewportPositionAtViewportBounds();
            var start = camera.ViewportToWorldPoint(new Vector3(viewportPosition.Value.x, viewportPosition.Value.y, z));
            return start;
        }
        
        public static Vector2 GenerateRandomViewportPositionAtViewportBounds(this Camera camera) {
            // Get a random position at the edge of the screen
            float x;
            float y;
            do {
                x = Random.Range(-1f, 2f);
                y = Random.Range(-1f, 2f);
            } while (x is > 0f and < 1f && y is > 0f and < 1f);
            return new Vector2(x, y);
        }

        public static Vector2 PointOnUnitSquare(this float angle) {
            angle %= 360;
            if (angle < 0) angle += 360;
            if (angle <= 45)
                // From middle-top to top-right
                return Vector2.Lerp(new Vector2(0.5f, 1), new Vector2(1, 1), angle / 45f);
            if (angle <= 90)
                // From top-right to right-middle
                return Vector2.Lerp(new Vector2(1, 1), new Vector2(1, 0.5f), (angle - 45) / 45f);
            if (angle <= 135)
                // From right-middle to bottom-right
                return Vector2.Lerp(new Vector2(1, 0.5f), new Vector2(1, 0), (angle - 90) / 45f);
            if (angle <= 180)
                // From bottom-right to middle-bottom
                return Vector2.Lerp(new Vector2(1, 0), new Vector2(0.5f, 0), (angle - 135) / 45f);
            if (angle <= 225)
                // From middle-bottom to bottom-left
                return Vector2.Lerp(new Vector2(0.5f, 0), new Vector2(0, 0), (angle - 180) / 45f);
            if (angle <= 270)
                // From bottom-left to left-middle
                return Vector2.Lerp(new Vector2(0, 0), new Vector2(0, 0.5f), (angle - 225) / 45f);
            if (angle <= 315)
                // From left-middle to top-left
                return Vector2.Lerp(new Vector2(0, 0.5f), new Vector2(0.5f, 1), (angle - 270) / 45f);
            return Vector2.Lerp(new Vector2(0.5f, 1), new Vector2(0.5f, 1), (angle - 315) / 45f);
        }

        public static Quaternion ConstrainBy(this Quaternion rotation, Vector3 maximalAngles) {
            var euler = rotation.eulerAngles.Wrapped();
            // Constraint the rotation to the maximal rotation.
            euler.x = Mathf.Clamp(euler.x, -maximalAngles.x, maximalAngles.x);
            euler.y = Mathf.Clamp(euler.y, -maximalAngles.y, maximalAngles.y);
            euler.z = Mathf.Clamp(euler.z, -maximalAngles.z, maximalAngles.z);
            return Quaternion.Euler(euler);
        }
        
        public static Vector3 ConstrainBy(this Vector3 position, Vector3 maximalTranslation) {
            position.x = Mathf.Clamp(position.x, -maximalTranslation.x, maximalTranslation.x);
            position.y = Mathf.Clamp(position.y, -maximalTranslation.y, maximalTranslation.y);
            position.z = Mathf.Clamp(position.z, -maximalTranslation.z, maximalTranslation.z);
            return position;
        }
        
        public static Vector3 Wrapped(this Vector3 euler) {
            euler.x = Mathf.Repeat(euler.x + 180f, 360f) - 180f;
            euler.y = Mathf.Repeat(euler.y + 180f, 360f) - 180f;
            euler.z = Mathf.Repeat(euler.z + 180f, 360f) - 180f;
            return euler;
        }
        
        public static Vector3 WrappedEulerAngles(this Quaternion quaternion) {
            return quaternion.eulerAngles.Wrapped();
        }
        
        public static float WrappedEulerAngle(this float angle) {
            return Mathf.Repeat(angle + 180f, 360f) - 180f;
        }

        public static string NormalizeMaterialName(this string name) {
            return name?.Replace(" (Instance)", "");
        }

        public static void DeleteComponents(this GameObject go, params Type[] exceptions) {
            // Steps:
            // 1. DFS through all children transforms of go, deepest children first.
            // 2. For each transform, collect a list of components.
            // 3. Build a dependency graph of component types via [RequireComponent] attributes.
            //    - Use a static cache to avoid repeated reflection per type.
            // 4. For each component, check if it or its dependencies (direct or transitive) are in the exceptions list.
            // 5. If not, and it's not Transform, remove it.
            // 6. Use DestroyImmediate instead of Destroy.
            
            // Create a set of exception types for faster lookup
            var exceptionSet = new HashSet<Type>(exceptions ?? Type.EmptyTypes) {
                // Always keep Transform component
                typeof(Transform)
            };

            // Get all GameObjects in hierarchy (deepest first)
            var gameObjects = CollectGameObjectsDFS(go.transform);
            
            // Process each GameObject
            foreach (var gameObject in gameObjects) {
                // Get all components on this GameObject
                var components = gameObject.GetComponents<Component>();
                var componentsToDelete = new List<Component>();
                
                // Check each component
                foreach (var component in components) {
                    if (component == null) continue;
                    
                    var componentType = component.GetType();
                    
                    // Check if component matches any exception type (including inheritance/interfaces)
                    if (IsExceptionType(componentType, exceptionSet)) continue;
                    
                    // Check if any exception component on this GameObject depends on this component
                    bool isRequiredByException = false;
                    foreach (var otherComponent in components) {
                        if (otherComponent == null || otherComponent == component) continue;
                        
                        var otherComponentType = otherComponent.GetType();
                        
                        // Check if otherComponent is an exception
                        if (IsExceptionType(otherComponentType, exceptionSet) && RequiresComponent(otherComponentType, componentType)) {
                            isRequiredByException = true;
                            break;
                        }
                    }
                    
                    if (!isRequiredByException) {
                        componentsToDelete.Add(component);
                    }
                }
                
                // Delete components in reverse order to handle potential dependencies
                for (int i = componentsToDelete.Count - 1; i >= 0; i--) {
                    if (componentsToDelete[i] != null) {
                        UnityEngine.Object.DestroyImmediate(componentsToDelete[i]);
                    }
                }
            }
        }
        
        private static IEnumerable<GameObject> CollectGameObjectsDFS(Transform root) {
            // Collect children first (deepest first)
            for (int i = 0; i < root.childCount; i++) {
                foreach (var gameObject in CollectGameObjectsDFS(root.GetChild(i))) {
                    yield return gameObject;
                }
            }
            // Then add the current GameObject
            yield return root.gameObject;
        }
        
        // Static cache for RequireComponent dependencies
        private static readonly Dictionary<Type, HashSet<Type>> RequiredComponentsCache = new Dictionary<Type, HashSet<Type>>();
        
        private static bool RequiresComponent(Type requirer, Type requiredComponent) {
            // Get all types required by requirer
            var requiredTypes = GetRequiredComponents(requirer);
            
            // Check if requiredComponent is in the required types (direct dependency)
            if (requiredTypes.Contains(requiredComponent)) return true;
            
            // Check if requiredComponent inherits from or implements any required type
            foreach (var requiredType in requiredTypes) {
                if (requiredType.IsAssignableFrom(requiredComponent)) return true;
            }
            
            // Check transitive dependencies: if requirer requires X, and X requires requiredComponent
            foreach (var requiredType in requiredTypes) {
                if (RequiresComponent(requiredType, requiredComponent)) return true;
            }
            
            return false;
        }
        
        private static HashSet<Type> GetRequiredComponents(Type type) {
            // Check cache first
            if (RequiredComponentsCache.TryGetValue(type, out var cached)) {
                return cached;
            }
            
            var requiredTypes = new HashSet<Type>();
            
            // Get all RequireComponent attributes
            var requireAttributes = type.GetCustomAttributes(typeof(RequireComponent), true);
            
            foreach (RequireComponent attribute in requireAttributes) {
                if (attribute.m_Type0 != null) requiredTypes.Add(attribute.m_Type0);
                if (attribute.m_Type1 != null) requiredTypes.Add(attribute.m_Type1);
                if (attribute.m_Type2 != null) requiredTypes.Add(attribute.m_Type2);
            }
            
            // Cache the result
            RequiredComponentsCache[type] = requiredTypes;
            
            return requiredTypes;
        }

        private static bool IsExceptionType(Type type, HashSet<Type> exceptionSet) {
            foreach (var exceptionType in exceptionSet) {
                if (exceptionType.IsAssignableFrom(type)) {
                    return true;
                }
            }
            return false;
        }
    }
}
