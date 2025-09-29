using Lab31.Domain;
using System;
using System.IO;
using System.Reflection;

namespace Lab31.IO
{
    /// <summary>
    /// Проста модель з єдиним файлом-джерелом, у якому можуть бути Student/Musician/Pilot.
    /// Жодних колекцій — лише масиви і лічильники.
    /// Формат:
    ///   Student VasiaPupkin
    ///   { "firstname": "Vasia", "lastname": "Pupkin", "studentId":"KB123", "course":"1",
    ///     "gender":"Female", "dorm":"3,217" };
    /// </summary>
    public sealed class TextFileDataSource
    {
        private readonly string _path;

        public TextFileDataSource(string path) { _path = path; }

        public void SaveAll(Student[] students, int studentCount,
                            Musician[] musicians, int musicianCount,
                            Pilot[] pilots, int pilotCount)
        {
            using var w = new StreamWriter(_path, false);
            for (int i = 0; i < studentCount; i++)
            {
                var s = students[i];
                w.WriteLine($"Student {s.FirstName}{s.LastName}");
                w.WriteLine("{");
                w.WriteLine($"  \"firstname\": \"{s.FirstName}\",");
                w.WriteLine($"  \"lastname\": \"{s.LastName}\",");
                w.WriteLine($"  \"studentId\": \"{s.StudentId}\",");
                w.WriteLine($"  \"course\": \"{s.Course}\",");
                w.WriteLine($"  \"gender\": \"{s.Gender}\"{(s.LivesInDorm ? "," : "")}");
                if (s.LivesInDorm)
                {
                    w.WriteLine($"  \"dorm\": \"{s.DormNumber},{s.DormRoom}\"");
                }
                else
                {
                    w.WriteLine($"  \"city\": \"{s.City}\"");
                }
                w.WriteLine("};");
            }

            for (int i = 0; i < musicianCount; i++)
            {
                var m = musicians[i];
                w.WriteLine($"Musician {m.FirstName}{m.LastName}");
                w.WriteLine("{");
                w.WriteLine($"  \"firstname\": \"{m.FirstName}\",");
                w.WriteLine($"  \"lastname\": \"{m.LastName}\",");
                w.WriteLine($"  \"instrument\": \"{m.Instrument}\"");
                w.WriteLine("};");
            }

            for (int i = 0; i < pilotCount; i++)
            {
                var p = pilots[i];
                w.WriteLine($"Pilot {p.FirstName}{p.LastName}");
                w.WriteLine("{");
                w.WriteLine($"  \"firstname\": \"{p.FirstName}\",");
                w.WriteLine($"  \"lastname\": \"{p.LastName}\",");
                w.WriteLine($"  \"license\": \"{p.License}\"");
                w.WriteLine("};");
            }
        }

        // Завантаження з файла у три масиви + Повертаємо реальні лічильники через out.
        public void LoadAll(Student[] students, out int studentCount,
                            Musician[] musicians, out int musicianCount,
                            Pilot[] pilots, out int pilotCount)
        {
            studentCount = musicianCount = pilotCount = 0;

            if (!File.Exists(_path)) return;

            using var r = new StreamReader(_path);
            string line;
            while ((line = ReadNonEmpty(r)) != null)
            {
                // тут очікуємо "Type Name"
                var header = line.Trim();
                var space = header.IndexOf(' ');
                if (space <= 0) throw new InvalidDataException("Bad header line: " + header);
                var type = header.Substring(0, space);

                // далі має бути блок { ... };
                string block = ReadBlock(r); 

                // прибираємо лапки і пробіли (типу міні парсер)
                ParseKeyValues(block, out string first, out string last,
                               out string studentId, out string courseStr,
                               out string genderStr, out string dorm, out string city,
                               out string instrument, out string license);

                switch (type)
                {
                    case "Student":
                        {
                            var g = ParseGender(genderStr);
                            int course = SafeInt(courseStr, 1);
                            var s = new Student(first, last, studentId, course, g);
                            if (!string.IsNullOrWhiteSpace(dorm))
                            {
                                // формат "номер,кімната"
                                var parts = dorm.Split(',');
                                int dormNo = SafeInt(parts[0], 0);
                                var room = parts.Length > 1 ? parts[1] : "";
                                s.SetDorm(dormNo, room);
                            }
                            else
                            {
                                s.SetCity(city ?? "");
                            }
                            students[studentCount++] = s;
                        }
                        break;

                    case "Musician":
                        {
                            var m = new Musician(first, last, instrument ?? "");
                            musicians[musicianCount++] = m;
                        }
                        break;

                    case "Pilot":
                        {
                            var p = new Pilot(first, last, license ?? "");
                            pilots[pilotCount++] = p;
                        }
                        break;

                    default:
                        throw new InvalidDataException("Unknown type: " + type);
                }
            }
        }

        private static string ReadNonEmpty(StreamReader r)
        {
            string s;
            while ((s = r.ReadLine()) != null)
            {
                s = s.Trim();
                if (s.Length == 0) continue;
                return s;
            }
            return null;
        }

        private static string ReadBlock(StreamReader r)
        {
            string open = ReadNonEmpty(r);
            if (open == null || !open.StartsWith("{"))
                throw new InvalidDataException("Expected '{'");

            // зчитуємо до рядка з "};"
            string line, acc = "";
            while ((line = r.ReadLine()) != null)
            {
                if (line.Trim() == "};") break;
                acc += line + "\n";
            }
            return acc;
        }

        private static void ParseKeyValues(
            string block,
            out string first, out string last,
            out string studentId, out string course, out string gender,
            out string dorm, out string city,
            out string instrument, out string license)
        {
            first = last = studentId = course = gender = dorm = city = instrument = license = null;

            var lines = block.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                var raw = lines[i].Trim().TrimEnd(',');
                if (raw.Length == 0) continue;
                // очікуємо: "key": "value"
                int c = raw.IndexOf(':');
                if (c <= 0) continue;
                var k = raw.Substring(0, c).Trim().Trim('"');
                var v = raw.Substring(c + 1).Trim().Trim('"');

                switch (k)
                {
                    case "firstname": first = v; break;
                    case "lastname": last = v; break;
                    case "studentId": studentId = v; break;
                    case "course": course = v; break;
                    case "gender": gender = v; break;
                    case "dorm": dorm = v; break;
                    case "city": city = v; break;
                    case "instrument": instrument = v; break;
                    case "license": license = v; break;
                }
            }
        }

        private static int SafeInt(string s, int defVal)
        {
            if (int.TryParse(s, out var x)) return x;
            return defVal;
        }

        private static Gender ParseGender(string s)
        {
            if (string.Equals(s, "Female", StringComparison.OrdinalIgnoreCase)) return Gender.Female;
            if (string.Equals(s, "Male", StringComparison.OrdinalIgnoreCase)) return Gender.Male;
            return Gender.Unknown;
        }
    }
}
