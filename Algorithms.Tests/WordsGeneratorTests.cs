using System.Linq;
using Algorithms.Solutions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class WordsGeneratorTests
    {
        [Test]
        public void Test1()
        {
            var generator = new WordsGenerator(new char[0]);
            var actualWords = generator.GetWords(1);
            var expectedWords = Enumerable.Empty<string>();

            Assert.That(actualWords, Is.EquivalentTo(expectedWords));
        }

        [Test]
        public void Test2()
        {
            var generator = new WordsGenerator(new []{'a'});
            var actualWords = generator.GetWords(1);
            var expectedWords = new[] {"a"};

            Assert.That(actualWords, Is.EquivalentTo(expectedWords));
        }

        [Test]
        public void Test3()
        {
            var generator = new WordsGenerator(new[] { 'a' });
            var actualWords = generator.GetWords(3);
            var expectedWords = new[] { "aaa" };

            Assert.That(actualWords, Is.EquivalentTo(expectedWords));
        }

        [Test]
        public void Test4()
        {
            var generator = new WordsGenerator(new[] { 'a', 'b'});
            var actualWords = generator.GetWords(1);
            var expectedWords = new[] { "a", "b" };

            Assert.That(actualWords, Is.EquivalentTo(expectedWords));
        }

        [Test]
        public void Test5()
        {
            var generator = new WordsGenerator(new[] { 'a', 'b' });
            var actualWords = generator.GetWords(2);
            var expectedWords = new[] { "aa", "bb", "ab", "ba" };

            Assert.That(actualWords, Is.EquivalentTo(expectedWords));
        }


        [Test]
        public void Test6()
        {
            var generator = new WordsGenerator(new[] { 'a', 'b' });
            var actualWords = generator.GetWords(3);
            var expectedWords = new[] { "aaa", "bbb", "aab", "baa", "aba", "bba", "abb", "bab" };

            Assert.That(actualWords, Is.EquivalentTo(expectedWords));
        }

        [Test]
        public void Test7()
        {
            var generator = new WordsGenerator(new[] { 'a', 'b', 'c' });
            var actualWords = generator.GetWords(2);
            var expectedWords = new[] { "aa", "bb", "cc", "ab", "ac", "ba", "bc", "ca", "cb"};

            Assert.That(actualWords, Is.EquivalentTo(expectedWords));
        }
    }
}
