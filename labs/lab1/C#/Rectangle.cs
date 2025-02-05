namespace RectangleApp
{
    public class Rectangle
    {
        private double x1, y1, x2, y2, x3, y3, x4, y4;

        public double X1 { get { return x1; } }
        public double Y1 { get { return y1; } }
        public double X2 { get { return x2; } }
        public double Y2 { get { return y2; } }
        public double X3 { get { return x3; } }
        public double Y3 { get { return y3; } }
        public double X4 { get { return x4; } }
        public double Y4 { get { return y4; } }

        // Конструктор з параметрами – координатами 4-х вершин
        public Rectangle(double x1, double y1,
                         double x2, double y2,
                         double x3, double y3,
                         double x4, double y4)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
            this.x4 = x4;
            this.y4 = y4;
        }

        // Метод обчислення площі
        public double GetArea()
        {
            double sideAB = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            double sideBC = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            return sideAB * sideBC;
        }

        // Метод обчислення периметра
        public double GetPerimeter()
        {
            double sideAB = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            double sideBC = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            return 2 * (sideAB + sideBC);
        }

        // Метод обнулення (скидання координат у 0)
        public void Reset()
        {
            x1 = y1 = x2 = y2 = x3 = y3 = x4 = y4 = 0;
        }
    }
}
