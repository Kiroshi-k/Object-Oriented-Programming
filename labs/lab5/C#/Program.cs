using System;
using RiadkyLib;

class Program {
    // метод для демонстрації поліморфізму
    static void Demonstrate(Riadky obj) {
        Console.WriteLine("Довжина: " + obj.GetLength());
        Console.WriteLine("Оброблений рядок: " + obj.InsertChar());
    }

    static void Main() {
        Console.Write("Введіть рядок: ");
        string input = Console.ReadLine();

        Riadky[] arr = {
            new VelykiLitery(input),
            new MaliLitery(input)
        };

        Console.WriteLine("\n--- VelykiLitery ---");
        Demonstrate(arr[0]);

        Console.WriteLine("\n--- MaliLitery ---");
        Demonstrate(arr[1]);
    }
}
