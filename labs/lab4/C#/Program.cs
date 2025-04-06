using System;
using LineLibrary;

namespace LineConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть x: ");
            double x = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть y: ");
            double y = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть кут у радіанах: ");
            double angle = Convert.ToDouble(Console.ReadLine());

            // Створюємо відрізок
            Segment seg = new Segment(x, y, angle);

            // Виводимо
            Console.WriteLine("Початок: ({0}, {1})", seg.GetX1(), seg.GetY1());
            Console.WriteLine("Кінець:  ({0}, {1})", seg.GetX2(), seg.GetY2());
            Console.WriteLine("Довжина: {0}", seg.Length());
            Console.WriteLine("Кут з OX: {0}", seg.AngleWithOx());
        }
    }
}
