using System;
using Lab31.Domain;
using Lab31.IO;
using Lab31.UI;

namespace Lab31
{
    internal class Program
    {
        // фіксовані масиви (ті без колекцій)
        private static readonly Student[] _students = new Student[256];
        private static readonly Musician[] _musicians = new Musician[64];
        private static readonly Pilot[] _pilots = new Pilot[64];

        private static int _studentCount, _musicianCount, _pilotCount;

        static void Main()
        {
            var dataPath = "data.txt";
            var ds = new TextFileDataSource(dataPath);

            // файлу ще немає? - згенеруємо заглушку
            if (!System.IO.File.Exists(dataPath))
            {
                SeedDemoData();
                ds.SaveAll(_students, _studentCount, _musicians, _musicianCount, _pilots, _pilotCount);
            }

            // чистимо масиви перед завантаженням
            Array.Clear(_students, 0, _students.Length);
            Array.Clear(_musicians, 0, _musicians.Length);
            Array.Clear(_pilots, 0, _pilots.Length);
            _studentCount = _musicianCount = _pilotCount = 0;

            // читаємо з файлу
            ds.LoadAll(_students, out _studentCount, _musicians, out _musicianCount, _pilots, out _pilotCount);

            ConsoleMenu.PrintHeader("Демонстрація ЛР 3.1 — робота з файлами та сутностями (варіант 3)");
            ConsoleMenu.ShowCountAndList(_students, _studentCount);

            Console.WriteLine("Натисніть будь-яку клавішу, щоб завершити...");
            Console.ReadKey(true);
        }

        private static void SeedDemoData()
        {
            // 3 студентки 1го курсу у гуртожитку (Заглушка якщо немає файлу з даними)
            _students[_studentCount++] = MakeStudent("Anna", "Shevchenko", "KB0001", 1, Gender.Female, dorm: "3,217");
            _students[_studentCount++] = MakeStudent("Iryna", "Melnyk", "KB0002", 1, Gender.Female, dorm: "3,105");
            _students[_studentCount++] = MakeStudent("Olena", "Koval", "KB0003", 1, Gender.Female, dorm: "2,12");
            _students[_studentCount++] = MakeStudent("Taras", "Bondar", "KB0004", 1, Gender.Male, city: "Kyiv");
            _students[_studentCount++] = MakeStudent("Sergiy", "Marchenko", "KB0005", 2, Gender.Male, city: "Kharkiv");
            _students[_studentCount++] = MakeStudent("Nadiya", "Hrytsenko", "KB0006", 3, Gender.Female, dorm: "1,301");

            _musicians[_musicianCount++] = new Musician("Mykola", "Lysenko", "piano");
            _pilots[_pilotCount++] = new Pilot("Petro", "Antonov", "PPL(A)");
        }

        private static Student MakeStudent(string fn, string ln, string id, int course, Gender g, string dorm = null, string city = null)
        {
            var s = new Student(fn, ln, id, course, g);
            if (!string.IsNullOrWhiteSpace(dorm))
            {
                var parts = dorm.Split(',');
                int dormNo = int.Parse(parts[0]);
                var room = parts.Length > 1 ? parts[1] : "";
                s.SetDorm(dormNo, room);
            }
            else
            {
                s.SetCity(city ?? "");
            }
            return s;
        }
    }
}
