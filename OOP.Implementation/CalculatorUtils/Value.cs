namespace OOP.Implementation.CalculatorUtils
{
    public abstract class Value
    {
        protected abstract Value Add(Value other);

        protected abstract Value Sub(Value other);

        protected abstract Value Mult(Value other);

        protected abstract Value Devide(Value other);
    }
}
