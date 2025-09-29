using ExprLib;

var arr = new Expr[]
{
    new Expr(1, 3, 5),
    new Expr(4.1, 2, 10),    // помилкова ситуація
    new Expr(-2, 0, 0)
};

for (int i = 0; i < arr.Length; ++i)
{
    try
    {
        Console.WriteLine($"Obj {i} = {arr[i].Evaluate()}");
    }
    catch (InvalidArgumentException ex)
    {
        Console.WriteLine($"Obj {i} ERROR: {ex.Message}");
    }
}
