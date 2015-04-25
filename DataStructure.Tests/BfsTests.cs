using System;
using System.Linq;
using DataStructure.Solutions.QueueTasks.BFSTask;
using NUnit.Framework;

namespace DataStructure.Tests
{
    [TestFixture]
    public class BfsTests
    {
        [Test]
        public void TestGraphWithOneVertex()
        {
            var graph = new int[1, 1] {{0}};
            var actualPath = Bfs.SearchPath(graph, 0, 0, 1).ToArray();
            var expectedPath = Enumerable.Empty<Tuple<int, int>>();

            Assert.That(actualPath, Is.EqualTo(expectedPath));
        }

        [Test]
        public void TestGraphWithTwoVertices()
        {
            var graph = new int[2, 2] { { -1, 1 }, {1, -1} };
            var actualPath = Bfs.SearchPath(graph, 0, 1, 2).ToArray();
            var expectedPath = new[] {Tuple.Create(0, 1)};

            Assert.That(actualPath, Is.EqualTo(expectedPath));
        }

        [Test]
        public void TestComplexGraph()
        {
            var graph = new int[6, 6] { { -1, 1, 1, 1, -1, -1}, { 1, -1, 1, -1, -1, -1}, {1, 1, -1, -1, -1, -1}, {1, -1, -1, -1,1, -1},{-1, -1, -1, 1, -1, 1}, {-1, -1, 1, -1, 1, -1} };
            var actualPath = Bfs.SearchPath(graph, 0, 5, 6).ToArray();
            var expectedPath = new[] { Tuple.Create(0, 2), Tuple.Create(2, 5) };

            Assert.That(actualPath, Is.EqualTo(expectedPath));
        }
    }
}
