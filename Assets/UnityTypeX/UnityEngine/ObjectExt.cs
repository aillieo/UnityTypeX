// -----------------------------------------------------------------------
// <copyright file="ObjectExt.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.GameObjectExt
{
    using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif

    public static class ObjectExt
    {
        public static void SafeDestroy(this Object obj)
        {
            if (obj == null)
            {
                return;
            }

#if UNITY_EDITOR
            if (EditorUtility.IsPersistent(obj))
            {
                return;
            }

            if (Application.isPlaying)
            {
                Object.Destroy(obj);
            }
            else
            {
                Object.DestroyImmediate(obj);
            }
#else
            Object.Destroy(obj);
#endif
        }
    }
}
