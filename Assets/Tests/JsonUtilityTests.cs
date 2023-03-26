using System;
using System.Collections;
using System.Collections.Generic;
using AillieoUtils.TypeX.StringExt;
using NUnit.Framework;
using UnityEngine;

namespace AillieoUtils.TypeX.Tests
{
    public class JsonUtilityTests
    {
        [Test]
        public void ToJson()
        {
            string[] ss = new string[] { "a", "b", "c\nd", "e" };
            Vector3[] vs = new Vector3[] { Vector3.one, Vector3.zero };
            string j1 = JsonUtilityExt.JsonUtilityExt.ArrayToJson(vs, false);
            string j2 = JsonUtilityExt.JsonUtilityExt.ArrayToJson(vs, true);
            Debug.LogError(j1);
            Debug.LogError(j2);
        }

        [Test]
        public void FromJson()
        {

        }
    }
}
