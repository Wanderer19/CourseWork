using System;

namespace OOP.Solutions
{
    public class Complex 
    {
        public double Real { get; private set; }
        public double Imaginary { get; private set; }
        
        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public Complex Add(Complex other)
        {
            return new Complex(Real + other.Real, Imaginary + other.Imaginary);
        }

        public Complex Sub(Complex other)
        {
            return new Complex(Real - other.Real, Imaginary - other.Imaginary);
        }

        public Complex Mult(Complex other)
        {
            return new Complex(Real*other.Real - Imaginary*other.Imaginary, Real*other.Imaginary + Imaginary*other.Real);
        }

        public Complex Conjugate()
        {
            return new Complex(Real, Imaginary*(-1));
        }

        public Complex Devide(Complex other)
        {
            var k = other.Real*other.Real + other.Imaginary*other.Imaginary;
            const double tolerance = 0.0001;
            if (Math.Abs(k) < tolerance)
            {
                throw new InvalidOperationException();
            }
            var tmp = Mult(other.Conjugate());

            return new Complex(1/k*tmp.Real, 1/k*tmp.Imaginary);
        }

        public override bool Equals(object obj)
        {
            var other = (Complex) obj;
            const double tolerance = 0.0001;
            return Math.Abs(Real - other.Real) < tolerance && Math.Abs(Imaginary - other.Imaginary) < tolerance;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Real.GetHashCode() * 397) ^ Imaginary.GetHashCode();
            }
        }

        public override string ToString()
        {
            return string.Format("[ {0} + {1}i ]", Real, Imaginary);
        }
    }
}
