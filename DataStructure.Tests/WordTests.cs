using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataStructure.Solutions.DictionaryTasks.PrefixSuffixUtils;
using NUnit.Framework;

namespace DataStructure.Tests
{
    [TestFixture]
    public class WordTests
    {
        [Test]
        public void Test1()
        {
            var word = new Word("Masha");
            var actualPrefixes = word.GetPrefixes();
            var expectedPrefixes = new List<string>() { "Masha", "Mash", "Mas", "Ma", "M" };

            var actualSuffixes = word.GetSuffixes();
            var expectedSuffixes = new List<string>() { "a", "ha", "sha", "asha", "Masha" };
            Assert.That(actualPrefixes, Is.EquivalentTo(expectedPrefixes));
            Assert.That(actualSuffixes, Is.EquivalentTo(expectedSuffixes));
        }

        [Test]
        public void Test2()
        {
            var word = new Word("");
            var actualPrefixes = word.GetPrefixes();
            var expectedPrefixes = new List<string>() { };

            var actualSuffixes = word.GetSuffixes();
            var expectedSuffixes = new List<string>() { };
            Assert.That(actualPrefixes, Is.EquivalentTo(expectedPrefixes));
            Assert.That(actualSuffixes, Is.EquivalentTo(expectedSuffixes));
        }

        [Test]
        public void Test3()
        {
            var word = new Word("f");
            var actualPrefixes = word.GetPrefixes();
            var expectedPrefixes = new List<string>() { "f" };

            var actualSuffixes = word.GetSuffixes();
            var expectedSuffixes = new List<string>() { "f" };
            Assert.That(actualPrefixes, Is.EquivalentTo(expectedPrefixes));
            Assert.That(actualSuffixes, Is.EquivalentTo(expectedSuffixes));
        }

        [Test]
        public void Test4()
        {
            var words = new Word[] {new Word("конкурентоспособность"), new Word("неконкурентоспособность")};
            var result = Solver.Solve(words);
            var result2 = Solver.SolveSecond(words);

            Assert.That(new[] { result.Item1, result.Item2 }, Is.EquivalentTo(new[] { "конкурентоспособность", "неконкурентоспособность" }));
            Assert.That(result.Item3, Is.EqualTo("конкурентоспособность"));
            Assert.That(new[] { result2.Item1, result2.Item2 }, Is.EquivalentTo(new[] { "конкурентоспособность", "неконкурентоспособность" }));
            Assert.That(result2.Item3, Is.EqualTo("конкурентоспособность"));
        }

        [Test]
        public void Test5()
        {
            var words = File.ReadAllLines("ruwords.txt").Select(word => new Word(word)).ToArray();
            var result = Solver.Solve(words);
            var result2 = Solver.SolveSecond(words);

            Assert.That(result.Item3.Length, Is.EqualTo(21));
            Assert.That(result2.Item3.Length, Is.EqualTo(21));
        }
    }
}
