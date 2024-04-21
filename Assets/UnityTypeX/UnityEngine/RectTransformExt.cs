// -----------------------------------------------------------------------
// <copyright file="RectTransformExt.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.RectTransformExt
{
    using UnityEngine;

    public static class RectTransformExt
    {
        public static void Strentch(this RectTransform rectTransform)
        {
            rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 0);
            rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, 0);
            rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, 0);
            rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, 0);
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
        }

        public static void GetViewportCorners(this RectTransform rectTransform, Vector3[] corners)
        {
            rectTransform.GetWorldCorners(corners);

            var canvas = rectTransform.GetComponentInParent<Canvas>();
            if (canvas != null)
            {
                var camera = canvas.rootCanvas.worldCamera;
                if (camera != null)
                {
                    for (int i = 0; i < corners.Length; i++)
                    {
                        corners[i] = camera.WorldToViewportPoint(corners[i]);
                    }
                }
            }
        }

        private static readonly Vector3[] cornersCache = new Vector3[4];

        public static Rect GetViewportRect(this RectTransform rectTransform)
        {
            // 1 -- 2
            // |    |
            // 0 -- 3
            GetViewportCorners(rectTransform, cornersCache);
            return new Rect(cornersCache[0], cornersCache[2] - cornersCache[0]);
        }

        public static void GetScreenCorners(this RectTransform rectTransform, Vector3[] corners)
        {
            rectTransform.GetWorldCorners(corners);

            var canvas = rectTransform.GetComponentInParent<Canvas>();
            if (canvas != null)
            {
                var camera = canvas.rootCanvas.worldCamera;
                if (camera != null)
                {
                    for (int i = 0; i < corners.Length; i++)
                    {
                        corners[i] = camera.WorldToScreenPoint(corners[i]);
                    }
                }
            }
        }

        public static bool FullySeen(this RectTransform rectTransform)
        {
            var rect = rectTransform.GetViewportRect();
            return rect.xMin >= 0 && rect.yMin >= 0 && rect.xMax <= 1 && rect.yMax <= 1;
        }

        private static readonly Vector3[] cornersCache2 = new Vector3[4];

        public static void EnsureInScreen(this RectTransform rectTransform)
        {
            var rect = rectTransform.GetViewportRect();

            var lb = rect.min;
            var rt = rect.max;

            // 计算ViewPort空间下需要调整的偏移量
            Vector2 offset = Vector2.zero;

            if (lb.x < 0)
            {
                offset.x = -lb.x;
            }
            else if (rt.x > 1)
            {
                offset.x = 1 - rt.x;
            }

            if (lb.y < 0)
            {
                offset.y = -lb.y;
            }
            else if (rt.y > 1)
            {
                offset.y = 1 - rt.y;
            }

            Vector2 rectOffset = Vector2.zero;
            var canvas = rectTransform.GetComponentInParent<Canvas>();
            if (canvas != null)
            {
                // rootCanvas空间
                var rootCanvas = canvas.rootCanvas;
                var rootRect = rootCanvas.transform as RectTransform;
                var width = rootRect.rect.size.x;
                var height = rootRect.rect.size.y;
                rectOffset.x = width * offset.x;
                rectOffset.y = height * offset.y;
            }
            else
            {
                // 屏幕空间
                rectOffset.x = Screen.width * offset.x;
                rectOffset.y = Screen.height * offset.y;
            }

            rectTransform.anchoredPosition += rectOffset;
        }
    }
}
