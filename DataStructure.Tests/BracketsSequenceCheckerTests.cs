using DataStructure.Solutions.StackTasks;
using NUnit.Framework;

namespace DataStructure.Tests
{
    [TestFixture]
    public class BracketSequenceCheckerTests
    {
        [TestCase("", true)]
        [TestCase("jnlfwgwlr", true)]
        [TestCase("()", true)]
        [TestCase("[()]", true)]
        [TestCase("[[()<>])", false)]
        [TestCase("((((()))", false)]
        [TestCase("(", false)]
        [TestCase("<lolo>isinve<<>>([]){{()}pqkwjbgnafekdwldwkjbs}", true)]
        public void Test(string sequence, bool expectedResult)
        {
            Assert.That(BracketSequenceChecker.Check(sequence), Is.EqualTo(expectedResult));
        }
    }
}
