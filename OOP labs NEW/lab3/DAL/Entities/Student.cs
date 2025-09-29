using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DAL.Entities
{
    // Стать
    public enum Sex { Male, Female }

    // Додаткові сутності
    public enum ExtraRole { None, Musician, Pilot }

    // Серіалізований клас сутності за табл.2 (варіант 3)
    [Serializable]
    public class Student
    {
        public string Surname { get; set; } = "";
        public string Name { get; set; } = "";
        public int Course { get; set; }            // 1..4
        public string StudentCard { get; set; } = ""; // номер квитка
        public Sex Sex { get; set; } = Sex.Male;
        public string Residence { get; set; } = "";   // для гуртожитку: "номер.кімната" (наприклад "5.312")
        public ExtraRole Role1 { get; set; } = ExtraRole.None; // Musician
        public ExtraRole Role2 { get; set; } = ExtraRole.None; // Pilot
        public string Skill { get; set; } = "Кататися на ковзанах";

        // Допоміжне: чи живе у гуртожитку (рядок у форматі N.room)
        [XmlIgnore, JsonIgnore]
        public bool LivesInDorm =>
            !string.IsNullOrWhiteSpace(Residence) && Residence.Contains('.') &&
            int.TryParse(Residence.Split('.')[0], out _);

        public override string ToString()
            => $"{Surname} {Name}, курс {Course}, {Sex}, квиток {StudentCard}, проживання: {Residence}";
    }
}
