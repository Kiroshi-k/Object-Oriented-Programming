namespace Lab3_5.BLL.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Student
    {
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public int Course { get; set; }                // 1..6
        public Gender Gender { get; set; }

        // Місце проживання (місто/село/тощо)
        public string Residence { get; set; } = string.Empty;

        // Для тих, хто живе в гуртожитку – формат "номерГуртожитку.кiмната", напр. "1.101"
        public string? DormRoom { get; set; }

        // Додаткове вміння: кататися на ковзанах
        public bool CanSkate { get; set; }

        public bool LivesInDorm => !string.IsNullOrWhiteSpace(DormRoom);
    }
}


