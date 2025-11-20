using System.Text.Json;
using Lab3_5.BLL.Abstractions;
using Lab3_5.BLL.Models;

namespace Lab3_5.DAL
{
    public class JsonStudentRepository : IStudentRepository
    {
        private readonly string _filePath;

        public JsonStudentRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IList<Student> GetAll()
        {
            if (!File.Exists(_filePath))
                return new List<Student>();

            var json = File.ReadAllText(_filePath);
            if (string.IsNullOrWhiteSpace(json))
                return new List<Student>();

            var data = JsonSerializer.Deserialize<List<Student>>(json);
            return data ?? new List<Student>();
        }

        public void SaveAll(IList<Student> students)
        {
            var json = JsonSerializer.Serialize(students,
                new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(_filePath, json);
        }
    }
}
