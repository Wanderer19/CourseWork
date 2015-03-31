using System.Linq;
using DataStructure.Solutions.BinaryTreeTasks.BinaryTreeUtils;
using NUnit.Framework;

namespace DataStructure.Tests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        private BinaryTree<int> tree;
       
        [SetUp]
        public void SetUp()
        {
            tree = new BinaryTree<int>();
        }

        [Test]
        public void Test()
        {
            Assert.That(tree.Find(0), Is.False);
            Assert.That(tree.Find(1), Is.False);
        }

        [Test]
        public void Test1()
        {
            tree.AddToTree(1);
            
            Assert.That(tree.Find(1), Is.True);
        }

        [Test]
        public void Test2()
        {
            tree.AddToTree(2);
            tree.AddToTree(1);
            tree.AddToTree(5);

            Assert.That(tree.Find(1), Is.True);
            Assert.That(tree.Find(2), Is.True);
            Assert.That(tree.Find(5), Is.True);
            Assert.That(tree.Find(10), Is.False);
        }

        [Test]
        public void Test3()
        {
            var elements = tree.InfixTraverse().ToList();

            Assert.That(elements, Is.EqualTo(Enumerable.Empty<int>()));
        }

        [Test]
        public void Test4()
        {
            tree.AddToTree(1);
            var elements = tree.InfixTraverse().ToArray();

            Assert.That(elements, Is.EqualTo(new []{1}));
        }

        [Test]
        public void Test5()
        {
            tree.AddToTree(8);
            tree.AddToTree(3);
            tree.AddToTree(10);
            tree.AddToTree(1);
            tree.AddToTree(6);
            tree.AddToTree(14);
            tree.AddToTree(4);
            tree.AddToTree(7);
            tree.AddToTree(13);
            var elements = tree.InfixTraverse().ToArray();
            var expected = new[] {1, 3, 4, 6, 7,8, 10, 13, 14};
            Assert.That(elements, Is.EqualTo(expected));
        }

        [Test]
        public void Test6()
        {
            tree.AddToTree(8);
            tree.AddToTree(3);
            tree.AddToTree(10);
            tree.AddToTree(1);
            tree.AddToTree(6);
            tree.AddToTree(14);
            tree.AddToTree(4);
            tree.AddToTree(7);
            tree.AddToTree(13);
            var elements = tree.PrefixTraverse().ToArray();
            var expected = new[] { 8, 3, 1, 6, 4, 7, 10, 14, 13};
            Assert.That(elements, Is.EqualTo(expected));
        }

        [Test]
        public void Test7()
        {
            tree.AddToTree(8);
            tree.AddToTree(3);
            tree.AddToTree(10);
            tree.AddToTree(1);
            tree.AddToTree(6);
            tree.AddToTree(14);
            tree.AddToTree(4);
            tree.AddToTree(7);
            tree.AddToTree(13);
            var elements = tree.PostfixTraverse().ToArray();
            var expected = new[] { 1, 4, 7, 6, 3, 13, 14, 10, 8 };
            Assert.That(elements, Is.EqualTo(expected));
        }
    }
}
