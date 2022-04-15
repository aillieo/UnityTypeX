using UnityEngine;

namespace AillieoUtils.UnityTypeExt
{

    public static class RenderTextureExt
    {
        public static Texture2D ToTexture2D(this RenderTexture renderTexture, TextureFormat format = TextureFormat.RGB24, bool textureReadable = true)
        {
            RenderTexture active = null;
            if (renderTexture != RenderTexture.active)
            {
                active = RenderTexture.active;
                RenderTexture.active = renderTexture;
            }

            Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, format, false, false);
            texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture2D.Apply(false, !textureReadable);

            if (active != null)
            {
                RenderTexture.active = active;
            }

            return texture2D;
        }
    }
}
