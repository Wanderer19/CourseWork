using System;
using Algorithms.Solutions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class SearcherTests
    {
        [TestCase(new int[]{}, 0, -1)]
        [TestCase(new[] { 1}, 1, 0)]
        [TestCase(new[] { 1}, 2, -1)]
        [TestCase(new []{1, 2, 3}, 2, 1)]
        [TestCase(new[] { -1, 0, 2, 3}, 3, 3)]
        [TestCase(new[] { -1, 10, 5}, 100, -1)]
        [TestCase(new[] { "ab", "a", "ac", "ddd"}, "ddd", 3)]
        [TestCase(new[] { "ab", "a", "ac", "ddd" }, "dda", -1)]
        public void LinearSearcherTest<T>(T[] array, T key, int expected) where T : IComparable
        {
            var searcher = new Searcher<T>();
            Assert.That(searcher.LinearSearch(array, key), Is.EqualTo(expected));
        }

        [TestCase(new int[] { }, 0, -1)]
        [TestCase(new[] { 1 }, 1, 0)]
        [TestCase(new[] { 1 }, 2, -1)]
        [TestCase(new[] { 1, 2, 3 }, 2, 1)]
        [TestCase(new[] { -1, 0, 2, 3 }, 3, 3)]
        [TestCase(new[] { -1, 5, 10 }, 100, -1)]
        [TestCase(new[] { "a", "ab", "ac", "ddd" }, "ddd", 3)]
        [TestCase(new[] { "a", "ab", "ac", "ddd" }, "dda", -1)]
        public void BinarySearchTest<T>(T[] array, T key, int expected) where T : IComparable
        {
            var searcher = new Searcher<T>();
            Assert.That(searcher.BinarySearch(array, key), Is.EqualTo(expected));
        }
    }
}
