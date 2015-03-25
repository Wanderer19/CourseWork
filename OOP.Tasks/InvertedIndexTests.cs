using System.Collections.Generic;
using NUnit.Framework;
using OOP.Implementation.InvertedIndexUtils;

namespace OOP.Tasks
{
    [TestFixture]
    public class InvertedIndexTests
    {
        [TestCaseSource("GetInputs")]
        public void Test(Document[] documents,  Dictionary<string, List<int>> expectedInvertedIndex)
        {
            Assert.That(InvertedIndexBuilder.BuildInvertedIndex(documents), Is.EqualTo(expectedInvertedIndex));
            Assert.That(InvertedIndexBuilder.BuildInvertedIndexSecondVersion(documents), Is.EqualTo(expectedInvertedIndex));
        }

        private static IEnumerable<object[]> GetInputs()
        {
            yield return new object[] {new Document[0], new Dictionary<string, List<int>>()};
            yield return new object[]
            {
                new[]{new Document(1, "LOL"), }, 
                new Dictionary<string, List<int>>()
                {
                    {"lol", new List<int>(){1}}
                }
            };
            yield return new object[]
            {
                new Document[]{new Document(1, "lol Lol"), }, 
                new Dictionary<string, List<int>>()
                {
                    {"lol", new List<int>(){1}}
                }
            };
        } 
    }
}
