using Lab3_5.BLL.Models;
using Lab3_5.BLL.Services;
using Lab3_5.DAL;
using System.Text;

namespace Lab3_5.PL
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            var repo = new JsonStudentRepository("students.json");
            var service = new StudentService(repo);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Лабораторна 3.5, варіант 3");
                Console.WriteLine("1 - Показати всіх студентів");
                Console.WriteLine("2 - Порахувати студентів 1-го курсу в гуртожитку");
                Console.WriteLine("3 - Розселити студентів по кімнатах за статтю");
                Console.WriteLine("4 - Показати тих, хто катається на ковзанах");
                Console.WriteLine("0 - Вихід");
                Console.Write("Ваш вибір: ");

                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            ShowStudents(repo.GetAll());
                            break;

                        case "2":
                            int count = service.CountFirstCourseDormStudents();
                            Console.WriteLine($"Студентів 1-го курсу в гуртожитку: {count}");
                            break;

                        case "3":
                            var rooms = service.AssignRoomsByGender();
                            Console.WriteLine("Розселення:");
                            foreach (var r in rooms)
                            {
                                var students = string.Join(", ",
                                    r.Value.Select(s => $"{s.LastName} {s.FirstName}"));
                                Console.WriteLine($"{r.Key}: {students}");
                            }
                            break;

                        case "4":
                            var skaters = service.GetSkatingStudents();
                            Console.WriteLine("Студенти, які катаються на ковзанах:");
                            foreach (var s in skaters)
                                Console.WriteLine($"{s.LastName} {s.FirstName}, курс {s.Course}");
                            Console.WriteLine($"Це {service.GetSkatingStudentsPercentage():0.##}% від усіх.");
                            break;

                        case "0":
                            return;

                        default:
                            Console.WriteLine("Невірний пункт меню.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }

                Console.WriteLine("\nНатисніть будь-яку клавішу...");
                Console.ReadKey();
            }
        }

        private static void ShowStudents(IList<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Список студентів порожній.");
                return;
            }

            foreach (var s in students)
            {
                var dormInfo = s.LivesInDorm ? $"гуртожиток {s.DormRoom}" : s.Residence;
                var skate = s.CanSkate ? "катається на ковзанах" : "не катається";
                Console.WriteLine($"{s.LastName} {s.FirstName}, курс {s.Course}, " +
                                  $"{s.Gender}, {dormInfo}, {skate}");
            }
        }
    }
}
