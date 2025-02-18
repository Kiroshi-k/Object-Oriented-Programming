using System;
using RectangleLibrary; // простір імен нашої "бібліотеки" з класом Rectangle

namespace RectangleConsole
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1) Виклик конструктора за замовчуванням
            Rectangle rectDefault = new Rectangle();
            Console.WriteLine("rectDefault (через конструктор за замовчуванням):");
            Console.WriteLine($"  x1={rectDefault.X1}, y1={rectDefault.Y1} ... (всі 0)\n");

            // 2) Виклик конструктора з параметрами
            Console.WriteLine("Введіть координати x1, y1:");
            double x1 = Convert.ToDouble(Console.ReadLine());
            double y1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введіть координати x2, y2:");
            double x2 = Convert.ToDouble(Console.ReadLine());
            double y2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введіть координати x3, y3:");
            double x3 = Convert.ToDouble(Console.ReadLine());
            double y3 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введіть координати x4, y4:");
            double x4 = Convert.ToDouble(Console.ReadLine());
            double y4 = Convert.ToDouble(Console.ReadLine());

            Rectangle rectParam = new Rectangle(x1, y1, x2, y2, x3, y3, x4, y4);
            Console.WriteLine("\nrectParam (конструктор з параметрами):");
            Console.WriteLine($"  Кути: ({rectParam.X1},{rectParam.Y1}) " +
                              $"({rectParam.X2},{rectParam.Y2}) " +
                              $"({rectParam.X3},{rectParam.Y3}) " +
                              $"({rectParam.X4},{rectParam.Y4})");
            Console.WriteLine($"  Площа: {rectParam.GetArea()}");
            Console.WriteLine($"  Периметр: {rectParam.GetPerimeter()}\n");

            // 3) “Копі-конструктор”
            Rectangle rectCopy = new Rectangle(rectParam);
            Console.WriteLine("rectCopy (через конструктор копіювання):");
            Console.WriteLine($"  Кути: ({rectCopy.X1},{rectCopy.Y1}) " +
                              $"({rectCopy.X2},{rectCopy.Y2}) " +
                              $"({rectCopy.X3},{rectCopy.Y3}) " +
                              $"({rectCopy.X4},{rectCopy.Y4})");
            Console.WriteLine($"  Площа: {rectCopy.GetArea()}");
            Console.WriteLine($"  Периметр: {rectCopy.GetPerimeter()}");

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}
