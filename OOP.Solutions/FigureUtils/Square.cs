using System;

namespace OOP.Solutions.FigureUtils
{
    public class Square : IFigure
    {
        private readonly double sideSize;

        public Square(double sideSize)
        {
            this.sideSize = sideSize;
        }

        public double GetArea()
        {
            return sideSize * sideSize;
        }

        public double GetPerimeter()
        {
            return 4 * sideSize;
        }

        public void Draw()
        {
            Console.WriteLine("Square = {0}", sideSize);
        }
    }
}
