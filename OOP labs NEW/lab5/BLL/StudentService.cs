using System.Text.RegularExpressions;
using Lab3_5.BLL.Abstractions;
using Lab3_5.BLL.Models;

namespace Lab3_5.BLL.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _repository;
        private static readonly Regex DormRegex = new(@"^\d+\.\d+$");

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        // --- Валідація даних на рівні бізнес-логіки ---
        private void ValidateStudent(Student s)
        {
            if (s.Course < 1 || s.Course > 6)
                throw new ArgumentException("Курс повинен бути від 1 до 6.");

            if (!string.IsNullOrWhiteSpace(s.DormRoom) &&
                !DormRegex.IsMatch(s.DormRoom))
            {
                throw new ArgumentException("Неправильний формат гуртожитку. Очікується 'номер.кiмната'.");
            }
        }

        private IList<Student> LoadAndValidateAll()
        {
            var students = _repository.GetAll();
            foreach (var s in students)
                ValidateStudent(s);

            return students;
        }

        // 1) Обчислити кількість студентів 1-го курсу, які проживають у гуртожитку
        public int CountFirstCourseDormStudents()
        {
            var students = LoadAndValidateAll();
            return students.Count(s => s.Course == 1 && s.LivesInDorm);
        }

        public IList<Student> GetFirstCourseDormStudents()
        {
            var students = LoadAndValidateAll();
            return students
                .Where(s => s.Course == 1 && s.LivesInDorm)
                .ToList();
        }

        // 2) Поселення в кімнати за ознакою статі
      
        public Dictionary<string, List<Student>> AssignRoomsByGender(int bedsPerRoom = 2)
        {
            if (bedsPerRoom <= 0)
                throw new ArgumentException("bedsPerRoom має бути > 0.");

            var students = LoadAndValidateAll()
                .Where(s => s.LivesInDorm) // розселяємо тільки тих, хто в гуртожитку
                .OrderBy(s => s.Gender)
                .ThenBy(s => s.LastName)
                .ToList();

            var result = new Dictionary<string, List<Student>>();

            int roomCounterMale = 101;
            int roomCounterFemale = 201;

            foreach (var group in students.GroupBy(s => s.Gender))
            {
                int roomCounter = group.Key == Gender.Male ? roomCounterMale : roomCounterFemale;
                var buffer = new List<Student>();

                foreach (var s in group)
                {
                    buffer.Add(s);

                    if (buffer.Count == bedsPerRoom)
                    {
                        var roomKey = $"1.{roomCounter}";
                        result[roomKey] = new List<Student>(buffer);
                        foreach (var st in buffer)
                            st.DormRoom = roomKey;
                        buffer.Clear();
                        roomCounter++;
                    }
                }

                if (buffer.Count > 0)
                {
                    var roomKey = $"1.{roomCounter}";
                    result[roomKey] = new List<Student>(buffer);
                    foreach (var st in buffer)
                        st.DormRoom = roomKey;
                }
            }

            _repository.SaveAll(students);
            return result;
        }

        // --- Додаткове вміння: кататися на ковзанах ---

        public IList<Student> GetSkatingStudents()
        {
            var students = LoadAndValidateAll();
            return students.Where(s => s.CanSkate).ToList();
        }

        public double GetSkatingStudentsPercentage()
        {
            var students = LoadAndValidateAll();
            if (students.Count == 0) return 0;

            double skaters = students.Count(s => s.CanSkate);
            return skaters / students.Count * 100.0;
        }
    }
}
