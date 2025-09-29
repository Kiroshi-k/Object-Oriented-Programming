using System;
using System.Collections.Generic;
using DAL;
using DAL.Data;
using DAL.Entities;
using BLL;

namespace PL
{
    public static class Menu
    {
        public static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("ЛР 3.3 Серiалiзацiя та 3-рiвнева архiтектура");
                Console.WriteLine("1) Демонстрацiя частини 1 (масив, колекцiя, рiзнi серiалiзацiї)");
                Console.WriteLine("2) Варiант 3 (табл.2): завантажити з файлу та порахувати студенток 1 курсу у гуртожитку");
                Console.WriteLine("0) Вихiд");
                Console.Write("Обери пункт: ");
                var k = Console.ReadLine();
                if (k == "1") Part1Demo();
                else if (k == "2") Variant3Task();
                else if (k == "0") return;
                else Pause("Невiдомий пункт");
            }
        }

        // вибiр провайдера
        private static EntityContext ChooseContext()
        {
            Console.WriteLine("Формат файлу:");
            Console.WriteLine("1) JSON  2) XML  3) Binary  4) Custom TXT");
            Console.Write("Обери: ");
            var key = Console.ReadLine();
            return key switch
            {
                "1" => new EntityContext(new JsonProvider<Student>()),
                "2" => new EntityContext(new XmlProvider<Student>()),
                "3" => new EntityContext(new BinaryProvider<Student>()),
                "4" => new EntityContext(new CustomTxtProvider<Student>()),
                _ => new EntityContext(new JsonProvider<Student>()),
            };
        }

        private static string AskPath(string suggestedName, string ext)
        {
            Console.Write($"Введи шлях до файлу (enter = {suggestedName}{ext}): ");
            var p = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(p)) p = suggestedName + ext;
            return p!;
        }

        // Частина 1 
        private static void Part1Demo()
        {
            var ctx = ChooseContext();
            var path = AskPath("students_demo", ctx.Extension);

            // Масив (array)
            Student[] arr =
            {
                new(){ Surname="iваненко", Name="Аня", Course=1, StudentCard="AB123", Sex=Sex.Female, Residence="3.215", Role1=ExtraRole.Musician },
                new(){ Surname="Петренко", Name="Олег", Course=2, StudentCard="CD456", Sex=Sex.Male, Residence="квартира" },
                new(){ Surname="Сидоренко", Name="Марiя", Course=1, StudentCard="EF789", Sex=Sex.Female, Residence="5.402", Role2=ExtraRole.Pilot },
            };

            // Колекцiя (List)
            var list = new List<Student>(arr);

            var service = new EntityService(ctx);

            // Зберiгаємо (серiалiзацiя)
            service.SaveStudents(path, list);

            // Читаємо назад (десерiалiзацiя)
            var loaded = service.LoadStudents(path);

            // Порiвняння масив vs колекцiя
            var (a, b) = service.CompareArrayVsCollection(arr, loaded);

            Console.WriteLine($"\nЗбережено у форматi: {ctx.ProviderTitle}");
            Console.WriteLine($"Файл: {path}");
            Console.WriteLine("Прочитано студентiв: " + loaded.Count);
            Console.WriteLine($"Дiвчат 1 курсу у гуртожитку (array): {a}");
            Console.WriteLine($"Дiвчат 1 курсу у гуртожитку (list):  {b}");
            Console.WriteLine("\nВмiст:");
            loaded.ForEach(s => Console.WriteLine(" - " + s));

            Pause();
        }

        //  Варiант 3 (табл.2) 
        private static void Variant3Task()
        {
            var ctx = ChooseContext();
            var path = AskPath("students_input", ctx.Extension);
            var service = new EntityService(ctx);

            var students = service.LoadStudents(path);
            Console.WriteLine($"З файлу {path} прочитано: {students.Count} студ.");

            int count = service.CountFirstCourseGirlsInDorm(students);
            Console.WriteLine($"Кiлькiсть студенток 1 курсу, що проживають у гуртожитку: {count}");

            if (count > 0)
            {
                Console.WriteLine("\nСписок:");
                foreach (var s in students)
                    if (s.Sex == Sex.Female && s.Course == 1 && s.LivesInDorm)
                        Console.WriteLine(" - " + s);
            }
            else
            {
                Console.WriteLine("\nПiдказка: додай кiлька записiв i збережи через пункт 1.");
            }

            Pause();
        }

        private static void Pause(string? msg = null)
        {
            if (!string.IsNullOrWhiteSpace(msg)) Console.WriteLine(msg);
            Console.WriteLine("\nНатисни Enter щоб продовжити...");
            Console.ReadLine();
        }
    }
}
