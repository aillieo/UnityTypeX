// -----------------------------------------------------------------------
// <copyright file="Vector3Ext.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.Vector3Ext
{
    using UnityEngine;

    public static class Vector3Ext
    {
        public static Vector3 SetX(this Vector3 v3, float x)
        {
            return new Vector3(x, v3.y, v3.z);
        }

        public static Vector3 SetY(this Vector3 v3, float y)
        {
            return new Vector3(v3.x, y, v3.z);
        }

        public static Vector3 SetZ(this Vector3 v3, float z)
        {
            return new Vector3(v3.x, v3.y, z);
        }

        public static Vector2 ToVector2XZ(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.z);
        }
    }
}
