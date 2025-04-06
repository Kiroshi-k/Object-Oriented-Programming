namespace LineLibrary
{
    public class Line
    {
        protected double x1, y1;  // Координати початку
        protected double x2, y2;  // Координати кінця

        // 1) Конструктор за замовчуванням
        public Line()
        {
            x1 = y1 = x2 = y2 = 0;
        }

        // 2) Конструктор з параметрами
        public Line(double startX, double startY, double endX, double endY)
        {
            x1 = startX;
            y1 = startY;
            x2 = endX;
            y2 = endY;
        }

        // 3) Конструктор копіювання (не завжди потрібен у C#, але для наочності)
        public Line(Line other)
        {
            x1 = other.x1;
            y1 = other.y1;
            x2 = other.x2;
            y2 = other.y2;
        }

        // Гетери
        public double GetX1() { return x1; }
        public double GetY1() { return y1; }
        public double GetX2() { return x2; }
        public double GetY2() { return y2; }

        // Метод обчислення довжини
        public double Length()
        {
            double dx = x2 - x1;
            double dy = y2 - y1;
            return System.Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
