using UnityEngine;
using System.Collections;
using System;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public class Hierarchy
    {
        public static bool HierarchyIsValid(Transform[] bones)
        {
            throw new NotImplementedException();
        }

        public static UnityEngine.Object ContainsDuplicate(UnityEngine.Object[] objects)
        {
            throw new NotImplementedException();
        }

        public static bool IsAncestor(Transform transform, Transform ancestor)
        {
            throw new NotImplementedException();
        }

        public static bool ContainsChild(Transform transform, Transform child)
        {
            throw new NotImplementedException();
        }

        public static void AddAncestors(Transform transform, Transform blocker, ref Transform[] array)
        {
            throw new NotImplementedException();
        }

        public static Transform GetAncestor(Transform transform, int minChildCount)
        {
            throw new NotImplementedException();
        }

        public static Transform GetFirstCommonAncestor(Transform t1, Transform t2)
        {
            throw new NotImplementedException();
        }

        public static Transform GetFirstCommonAncestor(Transform[] transforms)
        {
            throw new NotImplementedException();
        }

        public static Transform GetFirstCommonAncestorRecursive(Transform transform, Transform[] transforms)
        {
            throw new NotImplementedException();
        }

        public static bool IsCommonAncestor(Transform transform, Transform[] transforms)
        {
            throw new NotImplementedException();
        }
    }
}