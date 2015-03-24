﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PracticalWork.Algorithms;
using PracticalWork.Algorithms.SortersUtils;

namespace Algorithms.Tasks
{
    [TestFixture]
    public class SortersTests
    {
        [TestCase(new int[0], new int[0])]
        [TestCase(new []{-1}, new []{-1})]
        [TestCase(new []{-1, -100, 1, 5, 2, 19}, new []{-100, -1, 1, 2, 5, 19})]
        public void Test1(int [] initialArray, int[] expectedArray)
        {
            Sorters.BubbleSort(initialArray);
            Assert.That(initialArray, Is.EqualTo(expectedArray));
        }

        [TestCase(new string[0], new string[0])]
        [TestCase(new[] { "a" }, new[] { "a"})]
        [TestCase(new[] {"b", "a", "aa", "ca", "ac"}, new[] { "a", "aa", "ac", "b", "ca" })]
        public void Test2(string[] initialArray, string[] expectedArray)
        {
            Sorters.BubbleSort(initialArray);
            Assert.That(initialArray, Is.EqualTo(expectedArray));
        }

        [TestCase(new int[0], new int[0])]
        [TestCase(new[] { -1 }, new[] { -1 })]
        [TestCase(new[] { -1, -100, 1, 5, 2, 19 }, new[] { -100, -1, 1, 2, 5, 19 })]
        public void Test3(int[] initialArray, int[] expectedArray)
        {
            Sorters.SelectSort(initialArray);
            Assert.That(initialArray, Is.EqualTo(expectedArray));
        }

        [TestCase(new string[0], new string[0])]
        [TestCase(new[] { "a" }, new[] { "a" })]
        [TestCase(new[] { "b", "a", "aa", "ca", "ac" }, new[] { "a", "aa", "ac", "b", "ca" })]
        public void Test4(string[] initialArray, string[] expectedArray)
        {
            Sorters.SelectSort(initialArray);
            Assert.That(initialArray, Is.EqualTo(expectedArray));
        }
    }
}