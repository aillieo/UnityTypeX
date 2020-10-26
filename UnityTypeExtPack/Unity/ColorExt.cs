using UnityEngine;

namespace AillieoUtils.UnityTypeExt
{

    public static class ColorExt
    {

        public static Color SetAlpha(this Color c, float a)
        {
            return new Color(c.r, c.g, c.b, a);
        }
    }
}
