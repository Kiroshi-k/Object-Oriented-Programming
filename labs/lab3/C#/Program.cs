using System;

namespace Lab1_3_Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1) Створюємо три вектори
            Vector V1 = new Vector(3.0, 4.0);  // Параметричний
            Vector V2 = new Vector();          // За замовчуванням
            Vector V3 = new Vector(V1);        // Копія V1

            // Ініціалізуємо V2 (0,0) -> (1,1)
            V2 = new Vector(1.0, 1.0);

            Console.WriteLine("Початкові вектори:");
            ShowVectorInfo("V1", V1);
            ShowVectorInfo("V2", V2);
            ShowVectorInfo("V3", V3);
            Console.WriteLine();

            // 2) Збільшити V2 у 2 рази
            V2 = V2 + V2;
            Console.WriteLine("Після збільшення V2 у 2 рази:");
            ShowVectorInfo("V2", V2);
            Console.WriteLine();

            // 3) Вирівняти V3 під довжину V1
            double lenV3 = V3.Length();
            double lenV1 = V1.Length();
            if (lenV3 != 0.0)
            {
                double scale = lenV3 / lenV1;
                V3 = V3 / scale;
            }
            Console.WriteLine("Після \"вирівнювання\" V3 під довжину V1:");
            ShowVectorInfo("V3", V3);
            Console.WriteLine();

            // 4) Помістити результат у V1
            V1 = new Vector(V3);
            Console.WriteLine("Після \"поміщення\" V3 у V1:");
            ShowVectorInfo("V1", V1);
            ShowVectorInfo("V2", V2);
            ShowVectorInfo("V3", V3);
            Console.WriteLine();

            // --- Демонстрація перевантажених методів Length() ---
            double normalLen = V1.Length();
            double scaledLen = V1.Length(0.5);
            Console.WriteLine($"Length(V1) без параметрів  = {normalLen}");
            Console.WriteLine($"Length(V1) при scale=0.5   = {scaledLen}");

            Console.ReadLine();
        }

        static void ShowVectorInfo(string name, Vector v)
        {
            Console.WriteLine($"{name} = ({v.GetX()}, {v.GetY()}), length = {v.Length()}");
        }
    }
}
