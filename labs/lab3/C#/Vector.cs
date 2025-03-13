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

        // --- Перевантаження методів (function overloading) ---
        // 1) Довжина без параметрів
        public double Length()
        {
            return System.Math.Sqrt(x * x + y * y);
        }

        // 2) Довжина з масштабом
        public double Length(double scale)
        {
            // Масштабуємо координати на scale => довжина змінюється у scale разів
            return this.Length() * scale;
        }

        // Гетери
        public double GetX() { return x; }
        public double GetY() { return y; }

        // --- Перевантаження операторів ---
        // Додавання векторів
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y);
        }

        // Ділення вектора на число
        public static Vector operator /(Vector a, double val)
        {
            // Не перевіряємо val на 0
            return new Vector(a.x / val, a.y / val);
        }
    }
}
