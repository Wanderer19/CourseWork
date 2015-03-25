using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OOP.Implementation;

namespace OOP.Tasks
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
