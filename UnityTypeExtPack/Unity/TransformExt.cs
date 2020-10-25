using UnityEngine;

namespace AillieoUtils.UnityTypeExt
{
    public static class TransformExt
    {

        public static Transform FindRecursive(this Transform transform, string name)
        {
            foreach (Transform t in transform)
            {
                if (t.name == name)
                {
                    return t;
                }
                else
                {
                    Transform result = t.FindRecursive(name);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }

    }
}
