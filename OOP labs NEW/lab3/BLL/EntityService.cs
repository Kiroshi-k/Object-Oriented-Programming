using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DAL.Entities;

namespace BLL
{
    // Бiзнес-логiка але без Console/Stream тут
    public class EntityService
    {
        private readonly EntityContext _ctx;
        public EntityService(EntityContext ctx) => _ctx = ctx;

        public void SaveStudents(string path, IEnumerable<Student> items) => _ctx.Save(path, items);

        public List<Student> LoadStudents(string path) => _ctx.Load(path);

        // Перевiрки 
        public void Validate(Student s)
        {
            if (s.Course < 1 || s.Course > 6) throw new StudentValidationException("Курс повинен бути 1..6");
            if (string.IsNullOrWhiteSpace(s.Surname)) throw new StudentValidationException("Порожнє прiзвище");
            if (string.IsNullOrWhiteSpace(s.StudentCard)) throw new StudentValidationException("Немає номера квитка");
        }

        // Варiант 3 (табл.2): кiлькiсть студенток 1 курсу, що живуть у гуртожитку
        public int CountFirstCourseGirlsInDorm(IEnumerable<Student> items)
            => items.Count(s => s.Sex == Sex.Female && s.Course == 1 && s.LivesInDorm);

        // Для частини 1: порiвняння масиву й колекцiї (List)
        public (int fromArray, int fromList) CompareArrayVsCollection(Student[] arr, List<Student> list)
        {
            int a = CountFirstCourseGirlsInDorm(arr);
            int b = CountFirstCourseGirlsInDorm(list);
            return (a, b);
        }
    }
}
