using System;
using System.Collections.Generic;
using NUnit.Framework;
using OOP.Solutions.FigureUtils;

namespace OOP.Tests
{
    [TestFixture]
    public class FigureTests
    {
        [TestCaseSource("GetInputs")]
        public void Test(IFigure figure, double expectedArea, double expectedPerimeter)
        {
            Assert.That(figure.GetArea(), Is.EqualTo(expectedArea));
            Assert.That(figure.GetPerimeter(), Is.EqualTo(expectedPerimeter));
        }

        private static IEnumerable<object[]> GetInputs()
        {
            yield return new object[] { new Square(2), 4, 8 };
            yield return new object[] { new Square(0), 0, 0 };
            yield return new object[] { new Rectangle(2, 5), 10, 14 };
            yield return new object[] { new Triangle(1, 2, 3), Math.Sqrt(360), 6 };
        }

        [Test]
        public void Test1()
        {
            var figures = new IFigure[] { new Rectangle(1, 2), new Square(1), new Triangle(1, 2, 3) };

            foreach (var figure in figures)
            {
                figure.Draw();
            }
        }
    }
}
