using System;
using Files.Solutions;
using NUnit.Framework;

namespace Files.Tests
{
    [TestFixture]
    public class DecoderTests
    {
        [TestCase("DecoderTests\\67.result", "Yo", "Nice", "it is my life it is now or never i aint gonna live forever i just wanna live while i am alive it is my life ")]
        [TestCase("DecoderTests\\test1.result", "masha", "end", "hello")]
        [TestCase("DecoderTests\\test2.result", "masha", "end", "")]
        public void Test(string cipherFile, string letterId, string wordEndId, string expectedResult)
        {
            var decoder = new Decoder();
            Assert.That(decoder.Decode(cipherFile, letterId, wordEndId), Is.EqualTo(expectedResult));
        }
    }
}
