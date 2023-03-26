using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AillieoUtils.TypeX.StringExt;
using NUnit.Framework;
using UnityEngine;

namespace AillieoUtils.TypeX.Tests
{
    public class StringSplitTests
    {
        [Test]
        public void Split()
        {
            string s1 = "1A,2A,3A,4A,5A,6A";

            var l = new List<StringSegment>(s1.SplitNonAlloc(','));

            //UnityEngine.Profiling.Profiler.BeginSample("Split1");
            var sna = s1.SplitNonAlloc(',');
            //UnityEngine.Profiling.Profiler.EndSample();
            //UnityEngine.Profiling.Profiler.BeginSample("Split2");
            var snac = sna.Count();
            //UnityEngine.Profiling.Profiler.EndSample();

            UnityEngine.Debug.Log(string.Join("\n", s1.SplitNonAlloc(',')));
            UnityEngine.Debug.Log(string.Join("\n", l));
        }
    }
}
