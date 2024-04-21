// -----------------------------------------------------------------------
// <copyright file="QuaternionExt.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.QuaternionExt
{
    using UnityEngine;

    public static class QuaternionExt
    {
        public static Vector4 ToVector4(this Quaternion quaternion)
        {
            return new Vector4(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
        }

        public static Quaternion FromVector4(Vector4 vector4)
        {
            return new Quaternion(vector4.x, vector4.y, vector4.z, vector4.w);
        }
    }
}
