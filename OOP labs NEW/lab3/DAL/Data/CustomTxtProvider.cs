using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DAL.Data
{
    public class CustomTxtProvider<T> : IDataProvider<T> where T : class
    {
        public string FileExtension => ".txt";
        public string Title => "Custom TXT (CSV)";

        // ручна серiалiзацiя для Student
        public void Serialize(string path, IEnumerable<T> items)
        {
            var sb = new StringBuilder();
            foreach (var it in items)
            {
                var s = it as DAL.Entities.Student;
                sb.AppendLine(string.Join(";",
                    s!.Surname, s.Name, s.Course, s.StudentCard, s.Sex, s.Residence, s.Role1, s.Role2, s.Skill));
            }
            File.WriteAllText(path, sb.ToString());
        }
        public List<T> Deserialize(string path)
        {
            var list = new List<T>();
            if (!File.Exists(path)) return list;

            foreach (var line in File.ReadAllLines(path).Where(l => !string.IsNullOrWhiteSpace(l)))
            {
                var p = line.Split(';');
                var s = new DAL.Entities.Student
                {
                    Surname = p[0],
                    Name = p[1],
                    Course = int.Parse(p[2]),
                    StudentCard = p[3],
                    Sex = Enum.Parse<DAL.Entities.Sex>(p[4]),
                    Residence = p[5],
                    Role1 = Enum.Parse<DAL.Entities.ExtraRole>(p[6]),
                    Role2 = Enum.Parse<DAL.Entities.ExtraRole>(p[7]),
                    Skill = p[8],
                };
                list.Add((T)(object)s);
            }
            return list;
        }
    }
}
