using System;
using DataStructure.Solutions.StackTasks.StackUtils;
using NUnit.Framework;

namespace DataStructure.Tests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<int> stack;

        [SetUp]
        public void SetUp()
        {
            stack = new Stack<int>();
        }

        [Test]
        public void Test()
        {
            Assert.That(stack.IsEmpty(), Is.True);
        }

        [Test]
        public void Test1()
        {
            stack.Push(1);
            Assert.That(stack.IsEmpty(), Is.False);
        }

        [Test]
        public void Test2()
        {
            stack.Push(1);
            var element = stack.Pop();

            Assert.That(stack.IsEmpty(), Is.True);
            Assert.That(element, Is.EqualTo(1));
        }

        [Test]
        public void Test3()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            var peek = stack.Peek();
           
            Assert.That(peek, Is.EqualTo(3));
            Assert.That(stack.Pop(), Is.EqualTo(3));
            Assert.That(stack.Pop(), Is.EqualTo(2));
            Assert.That(stack.Pop(), Is.EqualTo(1));
            Assert.That(stack.IsEmpty(), Is.True);
        }

        [Test]
        public void Test4()
        {
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Test5()
        {
            stack.Push(1);
            stack.Push(2);

            stack.Clear();
            Assert.That(stack.IsEmpty(), Is.True);
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Test6()
        {
            stack.Push(1);
            stack.Push(2);

            stack.Pop();
            stack.Pop();
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }
    }
}
