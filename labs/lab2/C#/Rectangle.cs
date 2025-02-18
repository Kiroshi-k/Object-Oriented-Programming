namespace RectangleLibrary
{
    public class Rectangle
    {
        private double x1, y1, x2, y2, x3, y3, x4, y4;

        // 1) Конструктор за замовчуванням
        public Rectangle()
        {
            x1 = y1 = x2 = y2 = x3 = y3 = x4 = y4 = 0;
        }

        // 2) Конструктор з параметрами
        public Rectangle(double px1, double py1,
                         double px2, double py2,
                         double px3, double py3,
                         double px4, double py4)
        {
            x1 = px1; y1 = py1;
            x2 = px2; y2 = py2;
            x3 = px3; y3 = py3;
            x4 = px4; y4 = py4;
        }

        // 3) "Конструктор копіювання" (не стандартний, але можна реалізувати)
        public Rectangle(Rectangle other)
        {
            this.x1 = other.x1; this.y1 = other.y1;
            this.x2 = other.x2; this.y2 = other.y2;
            this.x3 = other.x3; this.y3 = other.y3;
            this.x4 = other.x4; this.y4 = other.y4;
        }

        // 4) "Деструктор" у C# (фіналізатор)
        ~Rectangle()
     

        // Методи обчислення площі/периметра
        public double GetArea()
        {
            double sideAB = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            double sideBC = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            return sideAB * sideBC;
        }

        public double GetPerimeter()
        {
            double sideAB = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            double sideBC = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            return 2 * (sideAB + sideBC);
        }

        // Гетери. Можна оформити як властивості лише для читання
        public double X1 { get { return x1; } }
        public double Y1 { get { return y1; } }
        public double X2 { get { return x2; } }
        public double Y2 { get { return y2; } }
        public double X3 { get { return x3; } }
        public double Y3 { get { return y3; } }
        public double X4 { get { return x4; } }
        public double Y4 { get { return y4; } }
    }
}
