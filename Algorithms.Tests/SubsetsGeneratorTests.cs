using System.Collections.Generic;
using System.Linq;
using Algorithms.Solutions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class SubsetsGeneratorTests
    {
        [Test]
        public void Test1()
        {
            var set = new int[] {};
            var expectedSubsets = new List<int[]>(){new int[0]};
            var actualSubsets = SubsetsGenerator.GenerateSubstes(set).ToList();

            Assert.That(actualSubsets, Is.EqualTo(expectedSubsets));
        }

        [Test]
        public void Test2()
        {
            var set = new int[] { 1 };
            var expectedSubsets = new List<int[]>() { new int[0], new int[]{1} };
            var actualSubsets = SubsetsGenerator.GenerateSubstes(set).ToList();

            Assert.That(actualSubsets, Is.EquivalentTo(expectedSubsets));
        }

        [Test]
        public void Test3()
        {
            var set = new int[] { 1, 2 };
            var expectedSubsets = new List<int[]>() { new int[0], new int[] { 1 }, new int[] { 2 }, new int[] { 1, 2 } };
            var actualSubsets = SubsetsGenerator.GenerateSubstes(set).ToList();

            Assert.That(actualSubsets, Is.EquivalentTo(expectedSubsets));
        }

        [Test]
        public void Test4()
        {
            var set = new int[] { 1, 2, 3, 4 };
            var expectedSubsets = new List<int[]>()
            {
                new int[0], new int[] { 1 }, new int[] { 2 }, new int[] { 3 }, new int[] { 4 },
                new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 1, 4 }, new int[] { 2, 3 }, 
                new int[] { 2, 4 }, new int[] { 3, 4 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 4 }, new int[]{1, 3, 4},
                new int[] { 2, 3, 4 }, new int[] { 1, 2, 3 ,4 },
            };
            var actualSubsets = SubsetsGenerator.GenerateSubstes(set).ToList();

            Assert.That(actualSubsets, Is.EquivalentTo(expectedSubsets));
        }
    }
}
