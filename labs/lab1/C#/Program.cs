using System;

namespace RectangleApp
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

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

            // Створюємо об’єкт класу Rectangle
            Rectangle rect = new Rectangle(x1, y1, x2, y2, x3, y3, x4, y4);

            // Виводимо збережені координати
            Console.WriteLine("\nВведений прямокутник має вершини:");
            Console.WriteLine($"({rect.X1}, {rect.Y1}), " +
                              $"({rect.X2}, {rect.Y2}), " +
                              $"({rect.X3}, {rect.Y3}), " +
                              $"({rect.X4}, {rect.Y4})");

            // Виводимо площу та периметр
            Console.WriteLine($"Площа: {rect.GetArea()}");
            Console.WriteLine($"Периметр: {rect.GetPerimeter()}");

            // Обнулення
            rect.Reset();
            Console.WriteLine("\nПісля обнулення даних:");
            Console.WriteLine($"Площа: {rect.GetArea()}");
            Console.WriteLine($"Периметр: {rect.GetPerimeter()}");

            Console.ReadKey();
        }
    }
}
