// -----------------------------------------------------------------------
// <copyright file="Texture2DExt.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.RenderTextureExt
{
    using UnityEngine;

    public static class Texture2DExt
    {
        public static Texture2D ToReadable(this Texture2D texture)
        {
            if (texture.isReadable)
            {
                return texture;
            }
            else
            {
                RenderTexture tempRT = RenderTexture.GetTemporary(texture.width, texture.height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
                Graphics.Blit(texture, tempRT);

                Texture2D readableTexture = new Texture2D(texture.width, texture.height, texture.format, texture.mipmapCount, false);
                RenderTexture.active = tempRT;
                readableTexture.ReadPixels(new Rect(0, 0, tempRT.width, tempRT.height), 0, 0);
                readableTexture.Apply();

                RenderTexture.ReleaseTemporary(tempRT);

                return readableTexture;
            }
        }
    }
}
