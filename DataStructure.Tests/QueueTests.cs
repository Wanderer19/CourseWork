using System;
using DataStructure.Solutions.QueueTasks.QueueUtils;
using NUnit.Framework;

namespace DataStructure.Tests
{
    [TestFixture]
    public class QueueTests
    {
        private Queue<int> queue;

        [SetUp]
        public void SetUp()
        {
            queue = new Queue<int>();
        }

        [Test]
        public void Test1()
        {
            Assert.That(queue.IsEmpty(), Is.True);
        }

        [Test]
        public void Test2()
        {
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test]
        public void Test3()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.That(queue.IsEmpty(), Is.False);
        }

        [Test]
        public void Test4()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.That(queue.Dequeue(), Is.EqualTo(1));
            Assert.That(queue.Dequeue(), Is.EqualTo(2));
        }

        [Test]
        public void Test5()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.That(queue.Peek(), Is.EqualTo(1));
        }

        [Test]
        public void Test6()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);

            queue.Dequeue();
            queue.Dequeue();

            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }
    }
}
