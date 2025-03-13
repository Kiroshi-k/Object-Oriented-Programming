using System;

namespace Lab1_3_Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1) Створимо три вектори, використовуючи різні конструктори
            Vector V1 = new Vector(3.0, 4.0);   // Параметричний
            Vector V2 = new Vector();          // За замовчуванням -> (0,0)
            Vector V3 = new Vector(V1);        // Копія V1

            // Для наочності призначимо V2 = (1,1) (хоч він був (0,0))
            V2 = new Vector(1.0, 1.0);

            Console.WriteLine("Початкові вектори:");
            Console.WriteLine($"V1 = ({V1.GetX()}, {V1.GetY()}), довжина = {V1.Length()}");
            Console.WriteLine($"V2 = ({V2.GetX()}, {V2.GetY()}), довжина = {V2.Length()}");
            Console.WriteLine($"V3 = ({V3.GetX()}, {V3.GetY()}), довжина = {V3.Length()}");
            Console.WriteLine();

            // 2) "Збільшити" V2 у 2 рази (подвоїти).
            // Найпростіше - додати його до самого себе: V2 = V2 + V2
            V2 = V2 + V2;
            Console.WriteLine("Після збільшення V2 у 2 рази:");
            Console.WriteLine($"V2 = ({V2.GetX()}, {V2.GetY()}), довжина = {V2.Length()}");
            Console.WriteLine();

            // 3) "Вирівняти" V3 під довжину V1, тобто зробити довжину V3 такою ж, як і V1
            double lenV3 = V3.Length();
            double lenV1 = V1.Length();

            if (lenV3 != 0.0)
            {
                double scale = lenV3 / lenV1; // Співвідношення довжин
                V3 = V3 / scale;             // Поділимо координати, щоб довжина співпала з V1
            }

            Console.WriteLine("Після \"вирівнювання\" V3 під довжину V1:");
            Console.WriteLine($"V3 = ({V3.GetX()}, {V3.GetY()}), довжина = {V3.Length()}");
            Console.WriteLine();

            // 4) "Помістити" результат у V1 (тобто присвоїти V1 значення V3)
            V1 = new Vector(V3);

            Console.WriteLine("Після \"поміщення\" V3 у V1:");
            Console.WriteLine($"V1 = ({V1.GetX()}, {V1.GetY()}), довжина = {V1.Length()}");
            Console.WriteLine($"V2 = ({V2.GetX()}, {V2.GetY()}), довжина = {V2.Length()}");
            Console.WriteLine($"V3 = ({V3.GetX()}, {V3.GetY()}), довжина = {V3.Length()}");

            Console.ReadLine();
        }
    }
}
