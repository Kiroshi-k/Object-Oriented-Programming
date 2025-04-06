namespace LineLibrary
{
    public class Segment : Line
    {
        // Конструктор за замовчуванням
        public Segment() : base() { }

        // Конструктор із 3 параметрами (x, y, angle)
        // Явно викликаємо базовий конструктор на 4 параметри
        public Segment(double x, double y, double angle)
            : base(x, y,
                   x + System.Math.Cos(angle),
                   y + System.Math.Sin(angle))
        {
        }

        // Конструктор копіювання
        public Segment(Segment other) : base(other) { }

        // Метод обчислення кута з віссю OX
        public double AngleWithOx()
        {
            double dx = x2 - x1;
            double dy = y2 - y1;
            return System.Math.Atan2(dy, dx);
        }
    }
}
