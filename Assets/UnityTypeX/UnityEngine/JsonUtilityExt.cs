using System;
using UnityEngine;

namespace AillieoUtils.TypeX.JsonUtilityExt
{

    public static class JsonUtilityExt
    {
        public static T[] ArrayFromJson<T>(string json)
        {
            string newJson = "{ \"array\": " + json + "}";
            JsonWrapper<T> wrapper = JsonUtility.FromJson<JsonWrapper<T>>(newJson);
            return wrapper.array;
        }

        [Serializable]
        private class JsonWrapper<T>
        {
            public T[] array;
        }
    }
}
