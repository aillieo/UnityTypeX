using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AillieoUtils.TypeX.GameObjectExt
{
    public static class ObjectExt
    {
        public static void SafeDestroy(this Object obj)
        {
            if (obj == null)
            {
                return;
            }

#if UNITY_EDITOR
            if (EditorUtility.IsPersistent(obj))
            {
                return;
            }

            if (Application.isPlaying)
            {
                Object.Destroy(obj);
            }
            else
            {
                Object.DestroyImmediate(obj);
            }
#else
            Object.Destroy(obj);
#endif
        }
    }
}
