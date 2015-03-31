using System;
using System.Collections.Generic;
using NUnit.Framework;
using OOP.Solutions;

namespace OOP.Tests
{
    [TestFixture]
    public class ComplexTests
    {
        [TestCaseSource("GetInputsForAddition")]
        public void Addition(Complex first, Complex second, Complex expectedResult)
        {
            Assert.That(first.Add(second), Is.EqualTo(expectedResult));
        }

        [TestCaseSource("GetInputsForSubtraction")]
        public void Subtraction(Complex first, Complex second, Complex expectedResult)
        {
            Assert.That(first.Sub(second), Is.EqualTo(expectedResult));
        }

        [TestCaseSource("GetInputsForMultiplication")]
        public void Multiplication(Complex first, Complex second, Complex expectedResult)
        {
            Assert.That(first.Mult(second), Is.EqualTo(expectedResult));
        }

        [TestCaseSource("GetInputsForConjugate")]
        public void Conjugate(Complex first, Complex expectedResult)
        {
            Assert.That(first.Conjugate(), Is.EqualTo(expectedResult));
        }

        [TestCaseSource("GetGoodInputsForDivision")]
        public void GoodDivision(Complex first, Complex second, Complex expectedResult)
        {
            Assert.That(first.Devide(second), Is.EqualTo(expectedResult));
        }

        [Test]
        public void BadDivision()
        {
            var first = new Complex(1, 1);
            var second = new Complex(0, 0);

            Assert.Throws<InvalidOperationException>(() => first.Devide(second));
        }

        private IEnumerable<object[]> GetInputsForAddition()
        {
            yield return new object[] { new Complex(1, 2), new Complex(1, 3), new Complex(2, 5), };
            yield return new object[] { new Complex(1, 2), new Complex(1, 2), new Complex(2, 4), };
            yield return new object[] { new Complex(1.05, 2), new Complex(1, 3), new Complex(2.05, 5), };
            yield return new object[] { new Complex(1.96, 2.4), new Complex(1.03, 3), new Complex(2.99, 5.4) };
            yield return new object[] { new Complex(1.96, -2.4), new Complex(1.03, 3), new Complex(2.99, 0.6) };
        }

        private IEnumerable<object[]> GetInputsForSubtraction()
        {
            yield return new object[] { new Complex(1, 2), new Complex(1, 3), new Complex(0, -1), };
            yield return new object[] { new Complex(1, 2), new Complex(1, 2), new Complex(0, 0), };
            yield return new object[] { new Complex(1.05, 2), new Complex(1, 3), new Complex(0.05, -1), };
            yield return new object[] { new Complex(1.96, 4.4), new Complex(1.03, 3), new Complex(0.93, 1.4) };
        }

        private IEnumerable<object[]> GetInputsForMultiplication()
        {
            yield return new object[] { new Complex(1, 2), new Complex(1, 3), new Complex(-5, 5) };
            yield return new object[] { new Complex(1, 2), new Complex(1, 2), new Complex(-3, 4) };
            yield return new object[] { new Complex(1.05, 2), new Complex(1, 3), new Complex(-4.95, 5.15) };
            yield return new object[] { new Complex(1.96, 4.4), new Complex(1.03, 3), new Complex(-11.1812, 10.412) };
        }

        private IEnumerable<object[]> GetGoodInputsForDivision()
        {
            yield return new object[] { new Complex(1, 2), new Complex(1, 3), new Complex(0.7, -0.1) };
            yield return new object[] { new Complex(1, 2), new Complex(1, 2), new Complex(1, 0) };
            yield return new object[] { new Complex(1.05, 2), new Complex(1, 3), new Complex(0.705, -0.115) };
        }

        private IEnumerable<object[]> GetInputsForConjugate()
        {
            yield return new object[] { new Complex(1, 2), new Complex(1, -2) };
            yield return new object[] { new Complex(1, -2), new Complex(1, 2) };
            yield return new object[] { new Complex(-1.05, 2), new Complex(-1.05, -2) };
            yield return new object[] { new Complex(0, 0), new Complex(0, 0) };
        }
    }
}
