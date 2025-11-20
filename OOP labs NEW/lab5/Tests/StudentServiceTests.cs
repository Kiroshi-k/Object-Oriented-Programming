using Lab3_5.BLL.Abstractions;
using Lab3_5.BLL.Models;
using Lab3_5.BLL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab3_5.Tests
{
    [TestClass]
    public class StudentServiceTests
    {
        private static Student CreateStudent(
            string lastName,
            int course,
            Gender gender,
            bool livesInDorm,
            bool canSkate = false)
        {
            return new Student
            {
                LastName = lastName,
                FirstName = "Тест",
                Course = course,
                Gender = gender,
                Residence = livesInDorm ? "Київ" : "Село",
                DormRoom = livesInDorm ? "1.101" : null,
                CanSkate = canSkate
            };
        }

        [TestMethod]
        public void CountFirstCourseDormStudents_ReturnsCorrectNumber()
        {
            // Arrange
            var students = new[]
            {
                CreateStudent("Іванов", 1, Gender.Male,   true),
                CreateStudent("Петров", 1, Gender.Male,   false),
                CreateStudent("Сидорова", 2, Gender.Female, true)
            };
            var repo = new InMemoryStudentRepository(students);
            var service = new StudentService(repo);

            // Act
            var result = service.CountFirstCourseDormStudents();

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void AssignRoomsByGender_SplitsByGenderAndFillsRooms()
        {
            // Arrange
            var students = new[]
            {
                CreateStudent("А", 1, Gender.Male,   true),
                CreateStudent("Б", 1, Gender.Male,   true),
                CreateStudent("В", 1, Gender.Female, true),
            };
            var repo = new InMemoryStudentRepository(students);
            var service = new StudentService(repo);

            // Act
            var rooms = service.AssignRoomsByGender(bedsPerRoom: 2);

            // Assert
            Assert.AreEqual(2, rooms.Count); // одна кімната для хлопців, одна для дівчат
            Assert.IsTrue(rooms.Values.All(room =>
                room.All(s => s.DormRoom != null)));

            var maleRoom = rooms.Single(r => r.Value[0].Gender == Gender.Male);
            Assert.AreEqual(2, maleRoom.Value.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AssignRoomsByGender_Throws_WhenBedsPerRoomIsZero()
        {
            // Arrange
            var students = new[]
            {
                CreateStudent("А", 1, Gender.Male, true),
            };
            var repo = new InMemoryStudentRepository(students);
            var service = new StudentService(repo);

            // Act
            service.AssignRoomsByGender(0);   // Assert — через ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CountFirstCourseDormStudents_Throws_OnInvalidCourse()
        {
            // Arrange
            var students = new[]
            {
                CreateStudent("А", 0, Gender.Male, true), // курс 0 – не можна
            };
            var repo = new InMemoryStudentRepository(students);
            var service = new StudentService(repo);

            // Act
            service.CountFirstCourseDormStudents();
        }

        [TestMethod]
        public void SkatingStudents_FilterAndPercentage()
        {
            // Arrange
            var students = new[]
            {
                CreateStudent("А", 1, Gender.Male,   true, canSkate: true),
                CreateStudent("Б", 1, Gender.Male,   true, canSkate: false),
                CreateStudent("В", 1, Gender.Female, true, canSkate: true),
            };
            var repo = new InMemoryStudentRepository(students);
            var service = new StudentService(repo);

            // Act
            var skaters = service.GetSkatingStudents();
            var percent = service.GetSkatingStudentsPercentage();

            // Assert
            Assert.AreEqual(2, skaters.Count);
            Assert.AreEqual(2.0 / 3.0 * 100.0, percent, 0.001);
        }
    }

    // заглушка
    internal class InMemoryStudentRepository : IStudentRepository
    {
        private readonly List<Student> _students;

        public InMemoryStudentRepository(IEnumerable<Student> students)
        {
            _students = students.ToList();
        }

        public IList<Student> GetAll() => _students;

        public void SaveAll(IList<Student> students)
        {
            _students.Clear();
            _students.AddRange(students);
        }
    }
}
