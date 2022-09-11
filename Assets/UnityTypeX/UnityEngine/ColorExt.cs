using UnityEngine;

namespace AillieoUtils.TypeX.ColorExt
{

    public static class ColorExt
    {

        public static Color SetAlpha(this Color c, float a)
        {
            return new Color(c.r, c.g, c.b, a);
        }

        public static string ToHtmlStringRGBA(this Color c)
        {
            return ColorUtility.ToHtmlStringRGBA(c);
        }

        public static string ToHtmlStringRGB(this Color c)
        {
            return ColorUtility.ToHtmlStringRGB(c);
        }
    }
}
