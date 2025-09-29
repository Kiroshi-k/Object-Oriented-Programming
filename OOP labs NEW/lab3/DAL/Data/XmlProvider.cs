using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DAL.Data
{
    public class XmlProvider<T> : IDataProvider<T>
    {
        public string FileExtension => ".xml";
        public string Title => "XML";
        public void Serialize(string path, IEnumerable<T> items)
        {
            var ser = new XmlSerializer(typeof(List<T>));
            using var fs = File.Create(path);
            ser.Serialize(fs, new List<T>(items));
        }
        public List<T> Deserialize(string path)
        {
            if (!File.Exists(path)) return new();
            var ser = new XmlSerializer(typeof(List<T>));
            using var fs = File.OpenRead(path);
            return (List<T>?)ser.Deserialize(fs) ?? new();
        }
    }
}
