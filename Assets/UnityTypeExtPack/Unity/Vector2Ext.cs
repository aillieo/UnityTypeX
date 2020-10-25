using UnityEngine;

namespace AillieoUtils.UnityTypeExt
{

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
    }
}
