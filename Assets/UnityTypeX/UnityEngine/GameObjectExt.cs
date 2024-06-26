// -----------------------------------------------------------------------
// <copyright file="GameObjectExt.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.GameObjectExt
{
    using System;
    using System.Linq;
    using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif

    public static class GameObjectExt
    {
        public static void InvokeRecursively(this GameObject gameObject, Action<GameObject> action)
        {
            action(gameObject);
            Transform transform = gameObject.transform;
            for (int i = 0, imax = transform.childCount; i < imax; i++)
            {
                action(transform.GetChild(i).gameObject);
            }
        }

        public static void InvokeRecursivelyPost(this GameObject gameObject, Action<GameObject> action)
        {
            Transform transform = gameObject.transform;
            for (int i = 0, imax = transform.childCount; i < imax; i++)
            {
                action(transform.GetChild(i).gameObject);
            }

            action(gameObject);
        }

        public static void SetLayerRecursively(this GameObject gameObject, int layer)
        {
            InvokeRecursively(gameObject, go => go.layer = layer);
        }

        public static T GetOrAddComponent<T>(this GameObject gameObject)
            where T : Component
        {
            if (!gameObject.TryGetComponent(out T component))
            {
                component = gameObject.AddComponent<T>();
            }

            return component;
        }

        public static Component GetOrAddComponent(this GameObject gameObject, Type type)
        {
            if (!gameObject.TryGetComponent(type, out Component component))
            {
                component = gameObject.AddComponent(type);
            }

            return component;
        }

        public static T GetComponentInChildrenExcludeSelf<T>(this GameObject gameObject, bool includeInactive = false)
            where T : Component
        {
            return gameObject.GetComponentsInChildren<T>(includeInactive)
                .FirstOrDefault(c => c.gameObject != gameObject);
        }

        public static Component GetComponentInChildrenExcludeSelf(this GameObject gameObject, Type type, bool includeInactive = false)
        {
            return gameObject.GetComponentsInChildren(type, includeInactive)
                .FirstOrDefault(c => c.gameObject != gameObject);
        }

        public static T[] GetComponentsInChildrenExcludeSelf<T>(this GameObject gameObject, bool includeInactive = false)
            where T : Component
        {
            return gameObject.GetComponentsInChildren<T>(includeInactive)
                .Where(c => c.gameObject != gameObject)
                .ToArray();
        }

        public static Component[] GetComponentsInChildrenExcludeSelf<T>(this GameObject gameObject, Type type, bool includeInactive = false)
        {
            return gameObject.GetComponentsInChildren(type, includeInactive)
                .Where(c => c.gameObject != gameObject)
                .ToArray();
        }

        public static bool IsPrefab(this GameObject gameObject)
        {
#if UNITY_EDITOR
            return PrefabUtility.GetCorrespondingObjectFromSource(gameObject) == null && PrefabUtility.GetPrefabInstanceHandle(gameObject) != null;
#else
            return !(gameObject.scene.IsValid() || gameObject.scene.isLoaded);
#endif
        }

        public static string GetPathInHierarchy(this GameObject gameObject, string separator = "/")
        {
            var path = gameObject.name;

            Transform parent = gameObject.transform.parent;

            while (parent != null)
            {
                path = parent.name + separator + path;
                parent = parent.parent;
            }

            return path;
        }
    }
}
