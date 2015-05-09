using CSharpFeatures.Solutions;
using NUnit.Framework;

namespace CSharpFeatures.Tests
{
    [TestFixture]
    public class GameFieldTests
    {
        [Test]
        public void Test()
        {
            var field = new GameField(3);
            field[0,0] = CellMark.Cross;
            field[0, 2] = CellMark.Cross;
            field[2, 1] = CellMark.Zero;


            var expectedRows = new[]
            {
                new[] {CellMark.Cross, CellMark.Empty, CellMark.Cross},
                new[] {CellMark.Empty, CellMark.Empty, CellMark.Empty,},
                new[] {CellMark.Empty, CellMark.Zero, CellMark.Empty,}
            };

            var expectedColumns = new[]
            {
                new[] {CellMark.Cross, CellMark.Empty, CellMark.Empty},
                new[] {CellMark.Empty, CellMark.Empty, CellMark.Zero,},
                new[] {CellMark.Cross, CellMark.Empty, CellMark.Empty,}
            };

            var expectedLeftDiagonal = new[] {CellMark.Cross, CellMark.Empty, CellMark.Empty};
            var expectedRightDiagonal = new[] {CellMark.Cross, CellMark.Empty, CellMark.Empty,};
            

            Assert.That(field.GetRows(), Is.EqualTo(expectedRows));
            Assert.That(field.GetColumns(), Is.EqualTo(expectedColumns));
            Assert.That(field.GetLeftDiagonal(), Is.EqualTo(expectedLeftDiagonal));
            Assert.That(field.GetRightDiaonal(), Is.EqualTo(expectedRightDiagonal));

            Assert.That(field.HasWinner(), Is.False);

            field[0,1] = CellMark.Cross;
            Assert.That(field.HasWinner(), Is.True);
        }
    }
}
