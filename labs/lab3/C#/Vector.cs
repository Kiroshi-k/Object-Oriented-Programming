namespace Lab1_3_Vectors
{
    public class Vector
    {
        private double x;
        private double y;

        // Конструктор за замовчуванням
        public Vector()
        {
            x = 0.0;
            y = 0.0;
        }

        // Конструктор з параметрами
        public Vector(double xVal, double yVal)
        {
            x = xVal;
            y = yVal;
        }

        // Конструктор копіювання
        public Vector(Vector other)
        {
            x = other.x;
            y = other.y;
        }

        // Метод обчислення довжини
        public double Length()
        {
            return System.Math.Sqrt(x * x + y * y);
        }

        // Гетери (щоб зчитати координати)
        public double GetX() { return x; }
        public double GetY() { return y; }

        // Перевантаження оператора +
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y);
        }

        // Перевантаження оператора / (ділення на число)
        public static Vector operator /(Vector a, double val)
        {
            // Для спрощення не робимо перевірку на val == 0
            return new Vector(a.x / val, a.y / val);
        }
    }
}
