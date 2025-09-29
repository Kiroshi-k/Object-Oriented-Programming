using System;

namespace Lab31.Domain
{
    public enum Gender { Unknown = 0, Male = 1, Female = 2 }

    public abstract class Person
    {
        public string FirstName;   
        public string LastName;    

        protected Person(string first, string last)
        {
            if (string.IsNullOrWhiteSpace(first)) throw new ArgumentException("FirstName is required");
            if (string.IsNullOrWhiteSpace(last)) throw new ArgumentException("LastName is required");
            FirstName = first.Trim();
            LastName = last.Trim();
        }

        public string FullName => $"{FirstName} {LastName}";
    }

    public interface ICanPlay { void Play(); }
    public interface ISkater { void Skate(); }

    public sealed class Student : Person, ISkater
    {
       
        public string StudentId;   
        public int Course;         
        public Gender Gender;

        // для проживання
        public bool LivesInDorm;           // якщо true використовуємо DormNumber/Room
        public int DormNumber;             // номер гуртожитку
        public string DormRoom;            // кімната
        public string City;                // інакше місто проживання

        public Student(string first, string last, string studentId, int course, Gender gender)
            : base(first, last)
        {
            if (string.IsNullOrWhiteSpace(studentId)) throw new ArgumentException("StudentId is required");
            if (course < 1 || course > 6) throw new ArgumentException("Course must be 1..6");
            StudentId = studentId.Trim();
            Course = course;
            Gender = gender;
        }

        public void SetDorm(int dormNumber, string room)
        {
            LivesInDorm = true;
            DormNumber = dormNumber;
            DormRoom = room ?? "";
            City = null;
        }

        public void SetCity(string city)
        {
            LivesInDorm = false;
            City = city ?? "";
            DormNumber = 0;
            DormRoom = null;
        }

        public void Skate() {  }
    }

    public sealed class Musician : Person, ICanPlay
    {
        public string Instrument; 
        public Musician(string first, string last, string instrument = null) : base(first, last)
        {
            Instrument = instrument ?? "";
        }
        public void Play() {  }
    }

    public sealed class Pilot : Person
    {
        public string License; 
        public Pilot(string first, string last, string license = null) : base(first, last)
        {
            License = license ?? "";
        }
    }
}
