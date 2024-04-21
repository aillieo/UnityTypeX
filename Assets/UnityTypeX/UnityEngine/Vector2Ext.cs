// -----------------------------------------------------------------------
// <copyright file="Vector2Ext.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.Vector2Ext
{
    using UnityEngine;

    public static class Vector2Ext
    {
        public static Vector2 SetX(this Vector2 v2, float x)
        {
            return new Vector2(x, v2.y);
        }

        public static Vector3 SetY(this Vector2 v2, float y)
        {
            return new Vector3(v2.x, y);
        }

        public static Vector2 Rotate(Vector2 vector2, float angle)
        {
            // [[ cos -sin ]
            //  [ sin  cos ]]
            angle = angle * Mathf.Deg2Rad;
            return new Vector2(
                    (float)((vector2.x * Mathf.Cos(angle)) - (vector2.y * Mathf.Sin(angle))),
                    (float)((vector2.x * Mathf.Sin(angle)) + (vector2.y * Mathf.Cos(angle))));
        }

        public static Vector3 ToVector3XZ(this Vector2 vector2, float y = 0f)
        {
            return new Vector3(vector2.x, y, vector2.y);
        }
    }
}
