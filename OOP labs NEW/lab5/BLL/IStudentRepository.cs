using Lab3_5.BLL.Models;

namespace Lab3_5.BLL.Abstractions
{
    public interface IStudentRepository
    {
        IList<Student> GetAll();
        void SaveAll(IList<Student> students);
    }
}
