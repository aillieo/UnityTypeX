// -----------------------------------------------------------------------
// <copyright file="TransformExt.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.TransformExt
{
    using System;
    using UnityEngine;

    public static class TransformExt
    {
        public static void InvokeRecursively(this Transform transform, Action<Transform> action)
        {
            action(transform);
            for (int i = 0, imax = transform.childCount; i < imax; i++)
            {
                action(transform.GetChild(i));
            }
        }

        public static void InvokeRecursivelyPost(this Transform transform, Action<Transform> action)
        {
            for (int i = 0, imax = transform.childCount; i < imax; i++)
            {
                action(transform.GetChild(i));
            }

            action(transform);
        }

        public static Transform FindRecursive(this Transform transform, string name)
        {
            foreach (Transform t in transform)
            {
                if (t.name == name)
                {
                    return t;
                }
                else
                {
                    Transform result = t.FindRecursive(name);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }
    }
}
