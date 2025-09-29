namespace ExprLib;

public class InvalidArgumentException : Exception
{
    public InvalidArgumentException(string msg) : base(msg) { }
}

public static class MathEx
{
    public static double SafeLn(double x)
    {
        if (x <= 0)
            throw new InvalidArgumentException("ln(x): x must be > 0");
        return Math.Log(x);
    }
}
