// -----------------------------------------------------------------------
// <copyright file="StringSplitTests.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.Tests
{
    using System;
    using System.Linq;
    using AillieoUtils.TypeX.StringExt;
    using NUnit.Framework;

    public class StringSplitTests
    {
        [Test]
        public void Split1()
        {
            string input = "hello world";
            char separator = ' ';
            var result = input.SplitNonAlloc(separator, 2);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("hello", result.ElementAt(0).ToString());
            Assert.AreEqual("world", result.ElementAt(1).ToString());
        }

        [Test]
        public void Split2()
        {
            string input = "hello world i am aillieo";
            char separator = ' ';
            var result = input.SplitNonAlloc(separator, 3);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("hello", result.ElementAt(0).ToString());
            Assert.AreEqual("world", result.ElementAt(1).ToString());
            Assert.AreEqual("universe", result.ElementAt(2).ToString());
        }

        [Test]
        public void Split3()
        {
            string input = "helloworld";
            char separator = ' ';
            var result = input.SplitNonAlloc(separator, 2);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("helloworld", result.ElementAt(0).ToString());
        }

        [Test]
        public void Split4()
        {
            string input = "hello world i am aillieo";
            char separator = ' ';
            var result = input.SplitNonAlloc(separator, 2);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("hello", result.ElementAt(0).ToString());
            Assert.AreEqual("world universe", result.ElementAt(1).ToString());
        }

        [Test]
        public void Split5()
        {
            string input = "hello world  i am aillieo ";
            char separator = ' ';
            var result = input.SplitNonAlloc(separator, 3, StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("hello", result.ElementAt(0).ToString());
            Assert.AreEqual("world", result.ElementAt(1).ToString());
            Assert.AreEqual("universe", result.ElementAt(2).ToString());
        }
    }
}
