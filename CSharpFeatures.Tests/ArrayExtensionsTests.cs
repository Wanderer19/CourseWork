using System;
using CSharpFeatures.Solutions;
using NUnit.Framework;

namespace CSharpFeatures.Tests
{
    [TestFixture]
    public class ArrayExtensionsTests
    {
        [Test]
        public void SwapTest1()
        {
            var array = new int[] {1, 2, 3, 4, 5};
            array.Swap(1, 3);

            var expectedArray = new int[] {1, 4, 3, 2, 5};
            Assert.That(array, Is.EqualTo(expectedArray));
        }


        [Test]
        public void SwapTest2()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };
            array.Swap(0, 0);

            var expectedArray = new int[] { 1, 2, 3, 4, 5 };
            Assert.That(array, Is.EqualTo(expectedArray));
        }


        [Test]
        public void SwapTest3()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };

            Assert.Throws<ArgumentOutOfRangeException>(() => array.Swap(-1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => array.Swap(6, 0));
        }

        [Test]
        public void SliceTest1()
        {
            var array = new int[] {1};
            var expectedSlice = new int[] {1};

            var actualSlice = array.Slice(0, 1);
            Assert.That(actualSlice, Is.EqualTo(expectedSlice));
        }

        [Test]
        public void SliceTest2()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };
            var expectedSlice = new int[] { 3, 4 };

            var actualSlice = array.Slice(2, 2);
            Assert.That(actualSlice, Is.EqualTo(expectedSlice));
        }

        [Test]
        public void SliceTest3()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };
            var expectedSlice = new int[] { 3, 4, 5 };

            var actualSlice = array.Slice(2, 10);
            Assert.That(actualSlice, Is.EqualTo(expectedSlice));
        }


        [Test]
        public void SliceTest4()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };

            Assert.Throws<ArgumentOutOfRangeException>(() => array.Slice(-1, 10));

            Assert.Throws<ArgumentException>(() => array.Slice(0,-1));
        }

        [Test]
        public void SliceTest5()
        {
            var array = new int[] {1, 2, 3, 4, 5};

            Assert.Throws<ArgumentException>(() => array.Slice(0, -1));
        }

        [Test]
        public void ShuffleTest()
        {
            var array = new int[] {1, 2, 3};

            var expected = new int[] {1, 2, 3};

            array.Shuffle();
            
            Assert.That(array, Is.EquivalentTo(expected));
        }
    }
}
