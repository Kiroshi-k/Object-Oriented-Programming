using Lab31.Domain;
using System;
using System.Reflection;

namespace Lab31.UI
{
    public static class ConsoleMenu
    {
        public static void PrintHeader(string title)
        {
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(title);
            Console.WriteLine(new string('=', 60));
        }

        public static void ShowCountAndList(Student[] students, int count)
        {
            // 1) рахуємо студентОК 1 курсу, що в гуртожитку
            int target = 0;
            for (int i = 0; i < count; i++)
            {
                var s = students[i];
                if (s != null &&
                    s.Course == 1 &&
                    s.Gender == Gender.Female &&
                    s.LivesInDorm)
                {
                    target++;
                }
            }

            Console.WriteLine($"Кількість студенток 1-го курсу, що проживають у гуртожитку: {target}");
            Console.WriteLine();

            // 2) перераховуємо їх
            for (int i = 0; i < count; i++)
            {
                var s = students[i];
                if (s != null &&
                    s.Course == 1 &&
                    s.Gender == Gender.Female &&
                    s.LivesInDorm)
                {
                    Console.WriteLine($"- {s.FullName} | ID: {s.StudentId} | Гурт.: {s.DormNumber}, кімн. {s.DormRoom}");
                }
            }
            Console.WriteLine();
        }
    }
}
