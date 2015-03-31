using System.Collections.Generic;
using NUnit.Framework;
using OOP.Implementation;

namespace DataStructure.Tests
{
    [TestFixture]
    public class FrequencyDictionaryTests
    {
        [TestCaseSource("GetInputs")]
        public void Test(string text, Dictionary<string, int> expectedResult)
        {
            var actualResult1 = FrequencyDictionary.GetFrequenciesAtText(text);
            var actualResult2 = FrequencyDictionary.GetFrequenciesAtTextSecondVersion(text);

            Assert.That(actualResult1, Is.EqualTo(expectedResult));
            Assert.That(actualResult2, Is.EqualTo(expectedResult));
        }

        private static IEnumerable<object[]> GetInputs()
        {
            yield return new object[] { "", new Dictionary<string, int>() };
            yield return new object[] { "lalala", new Dictionary<string, int>() { { "lalala", 1 } } };
            yield return new object[] { "la la", new Dictionary<string, int>() { { "la", 2 } } };
            yield return new object[] { "la la,todo lol.lol!!!!!     uuu", new Dictionary<string, int>() { { "la", 2 }, { "todo", 1 }, { "lol", 2 }, {"uuu", 1} } };
            yield return new object[] { "la la,todo lol.lol", new Dictionary<string, int>() { { "la", 2 }, { "todo", 1 }, { "lol", 2 } } };
        }
    }
}
