using System.Collections.Generic;
using System.Linq;
using Algorithms.Solutions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class PermutationsGeneratorTests
    {
        [Test]
        public void Test1()
        {
            var items = new List<int>();
            var actualPermutations = PermutationsGenerator<int>.GetPermutations(items).ToList();
            var expectedPermutations = new List<List<int>>(){new List<int>()};

            Assert.That(actualPermutations, Is.EqualTo(expectedPermutations));
        }

        [Test]
        public void Test2()
        {
            var items = new List<int>() { 1 };
            var actualPermutations = PermutationsGenerator<int>.GetPermutations(items).ToList();
            var expectedPermutations = new List<List<int>>() { new List<int>() { 1 } };

            Assert.That(actualPermutations, Is.EqualTo(expectedPermutations));
        }

        [Test]
        public void Test3()
        {
            var items = new List<int>() { 1, 2 };
            var actualPermutations = PermutationsGenerator<int>.GetPermutations(items).ToList();
            var expectedPermutations = new List<List<int>>() { new List<int>() { 1, 2 }, new List<int>() { 2, 1 } };

            Assert.That(actualPermutations, Is.EquivalentTo(expectedPermutations));
        }

        [Test]
        public void Test4()
        {
            var items = new List<int>() { 1, 2, 3 };
            var actualPermutations = PermutationsGenerator<int>.GetPermutations(items).ToList();
            var expectedPermutations = new List<List<int>>() { new List<int>() { 1, 2, 3 }, new List<int>() { 1, 3, 2 }, new List<int>() { 2, 3, 1 }, new List<int>() { 2, 1, 3 }, new List<int>() { 3, 1, 2 }, new List<int>() { 3, 2, 1 } };

            Assert.That(actualPermutations, Is.EquivalentTo(expectedPermutations));
        }

        [Test]
        public void Test5()
        {
            var items = new List<int>() { 1, 2, 3, 4 };
            var actualPermutations = PermutationsGenerator<int>.GetPermutations(items).ToList();
            var expectedPermutations = new List<List<int>>()
            {
                new List<int>() { 1, 2, 3 , 4},
                new List<int>() { 1, 2, 4, 3 }, 
                new List<int>() { 1, 3, 2, 4}, 
                new List<int>() { 1, 3, 4, 2 },
                new List<int>() { 1, 4, 2, 3 },
                new List<int>() { 1, 4, 3, 2 },

                new List<int>() { 2, 1, 3 , 4},
                new List<int>() { 2, 1, 4, 3 }, 
                new List<int>() { 2, 3, 1, 4}, 
                new List<int>() { 2, 3, 4, 1 },
                new List<int>() { 2, 4, 1, 3 },
                new List<int>() { 2, 4, 3, 1 },

                new List<int>() { 3, 2, 1 , 4},
                new List<int>() { 3, 2, 4, 1 }, 
                new List<int>() { 3, 1, 2, 4}, 
                new List<int>() { 3, 1, 4, 2 },
                new List<int>() { 3, 4, 2, 1 },
                new List<int>() { 3, 4, 1, 2 },

                new List<int>() { 4, 2, 3 , 1},
                new List<int>() { 4, 2, 1, 3 }, 
                new List<int>() { 4, 3, 2, 1}, 
                new List<int>() { 4, 3, 1, 2 },
                new List<int>() { 4, 1, 2, 3 },
                new List<int>() { 4, 1, 3, 2 },
            };

            Assert.That(actualPermutations, Is.EquivalentTo(expectedPermutations));
        }
    }
}
