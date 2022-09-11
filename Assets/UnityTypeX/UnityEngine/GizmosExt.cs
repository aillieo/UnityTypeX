using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils.TypeX.GizmosExt
{
    public static class GizmosExt
    {
        public static void DrawArrow(Vector3 position, Vector3 direction, float headLength = 0.5f, float headAngle = 20f)
        {
            Gizmos.DrawRay(position, direction);
            Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + headAngle, 0) * new Vector3(0, 0, 1);
            Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - headAngle, 0) * new Vector3(0, 0, 1);
            Gizmos.DrawRay(position + direction, right * headLength);
            Gizmos.DrawRay(position + direction, left * headLength);
        }

        public static void DrawCircle(Vector3 position, Vector3 up, float radius, int segments = 90)
        {
            Vector3 vector = Quaternion.Euler(90, 0, 0) * (up * radius);
            for (int i = 0; i < segments; i++)
            {
                Vector3 v = Quaternion.AngleAxis(360f / segments, up) * vector;
                Gizmos.DrawLine(position + vector, position + v);
                vector = v;
            }
        }

        public static void PushColor(Color color)
        {
            Gizmos.color = color;
        }

        private static readonly Stack<Color> colorStack = new Stack<Color>();
        public static void PopColor(Color color)
        {
            colorStack.Push(Gizmos.color);
            Gizmos.color = color;
        }

        public static void PopColor()
        {
            if (colorStack.Count > 0)
            {
                Color c = colorStack.Pop();
                Gizmos.color = c;
            }
        }
    }
}
