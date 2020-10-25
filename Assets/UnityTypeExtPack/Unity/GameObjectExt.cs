using System;
using UnityEngine;

namespace AillieoUtils.UnityTypeExt
{

	public static class GameObjectExt
	{
        public static void SetLayerRecursively(this GameObject gameObject, int layer)
        {
            gameObject.layer = layer;
            Transform transform = gameObject.transform;
            for (int i = 0, imax = transform.childCount; i < imax; i++)
            {
                SetLayerRecursively(transform.GetChild(i).gameObject, layer);
            }
        }


        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            if (component == null)
            {
                component = gameObject.AddComponent<T>();
            }
            return component;
        }

        public static Component GetOrAddComponent(this GameObject gameObject, Type type)
        {
            Component component = gameObject.GetComponent(type);
            if (component == null)
            {
                component = gameObject.AddComponent(type);
            }
            return component;
        }
    }
}
