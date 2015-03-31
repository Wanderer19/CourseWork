using System;
using System.Linq;
using DataStructure.Solutions.LinkedListTasks.LinkedListUtils;
using NUnit.Framework;

namespace DataStructure.Tests
{
    [TestFixture]
    public class LinkedListTests
    {
        private LinkedList<int> list;

        [SetUp]
        public void SetUp()
        {
            list = new LinkedList<int>();
        }

        [Test]
        public void EmptyList()
        {
            Assert.That(list.IsEmpty(), Is.True);
            Assert.That(list.ToArray(), Is.EqualTo(Enumerable.Empty<int>()));
            Assert.Throws<InvalidOperationException>(() => list.GetFirstItem());
            Assert.Throws<InvalidOperationException>(() => list.GetLastItem());
        }

        [Test]
        public void Test2()
        {
            list.EmplaceBack(1);
            
            Assert.That(list.IsEmpty(), Is.False);
            Assert.That(list.ToArray(), Is.EqualTo(new[] { 1 }));
            Assert.That(list.GetFirstItem(), Is.EqualTo(1));
            Assert.That(list.GetLastItem(), Is.EqualTo(1));
        }

        [Test]
        public void Test3()
        {
            list.EmplaceBack(1);
            list.EmplaceBack(2);
            list.EmplaceFront(-1);
            list.EmplaceBack(5);
            list.EmplaceFront(-1);
            
            Assert.That(list.IsEmpty(), Is.False);
            Assert.That(list.ToArray(), Is.EqualTo(new[] {-1, -1, 1, 2, 5 }));
            Assert.That(list.GetFirstItem(), Is.EqualTo(-1));
            Assert.That(list.GetLastItem(), Is.EqualTo(5));
        }

        [Test]
        public void Test4()
        {
            list.EmplaceBack(1);
            list.EmplaceBack(2);
            list.EmplaceFront(-1);
            list.EmplaceBack(5);
            list.EmplaceFront(-1);

            list.Clear();
            Assert.That(list.IsEmpty(), Is.True);
            Assert.That(list.ToArray(), Is.EqualTo(Enumerable.Empty<int>()));
            Assert.Throws<InvalidOperationException>(() => list.GetFirstItem());
            Assert.Throws<InvalidOperationException>(() => list.GetLastItem());
        }
    }
}
