// -----------------------------------------------------------------------
// <copyright file="JsonUtilityExt.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.JsonUtilityExt
{
    using System;
    using System.Text;
    using UnityEngine;

    public static class JsonUtilityExt
    {
        public static T[] ArrayFromJson<T>(string json)
        {
            string wrapped = JsonWrapper<T>.WrapJson(json);
            JsonWrapper<T> wrapper = JsonUtility.FromJson<JsonWrapper<T>>(wrapped);
            return wrapper.array;
        }

        public static string ArrayToJson<T>(T[] array, bool prettyPrint = false)
        {
            if (array == null)
            {
                return string.Empty;
            }

            string rawJson = JsonUtility.ToJson(new JsonWrapper<T>() { array = array }, prettyPrint);
            return JsonWrapper<T>.UnwrapJson(rawJson, prettyPrint);
        }

        [Serializable]
        private class JsonWrapper<T>
        {
            public T[] array;

            public static string WrapJson(string rawJson)
            {
                return $"{{ \"array\":  {rawJson}  }}";
            }

            public static string UnwrapJson(string rawJson, bool prettyPrint)
            {
                int firstBracket = rawJson.IndexOf('[');
                int lastBracket = rawJson.LastIndexOf(']');
                int start = firstBracket;
                int length = lastBracket + 1 - start;
                string newJson = rawJson.Substring(start, length);

                if (prettyPrint)
                {
                    string[] lines = newJson.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    int lineCount = lines.Length;
                    StringBuilder stringBuilder = new StringBuilder();

                    stringBuilder.AppendLine(lines[0]);
                    for (int i = 1; i < lineCount; i++)
                    {
                        string line = lines[i];
                        if (line.Length > 4)
                        {
                            line = line.Substring(4);
                        }

                        stringBuilder.AppendLine(line);
                    }

                    newJson = stringBuilder.ToString();
                }

                return newJson;
            }
        }
    }
}
