using System;

namespace BLL
{
    // власний виняток предметної області
    public class StudentValidationException : Exception
    {
        public StudentValidationException(string message) : base(message) { }
    }
}
