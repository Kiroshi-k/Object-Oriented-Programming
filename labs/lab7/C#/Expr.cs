namespace ExprLib;

public class Expr
{
    private readonly double _a, _c, _d;
    public Expr(double a, double c, double d)
    {
        _a = a; _c = c; _d = d;
    }

    public double Evaluate()
    {
        double numerator   = 2 * _c - _d / 23.0;
        double lnArgument  = 1.0 - _a / 4.0;
        double denominator = MathEx.SafeLn(lnArgument);
        if (denominator == 0.0)
            throw new InvalidArgumentException("Division by zero");
        return numerator / denominator;
    }
}
