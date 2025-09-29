using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

#pragma warning disable SYSLIB0011
namespace DAL.Data
{
    public class BinaryProvider<T> : IDataProvider<T>
    {
        public string FileExtension => ".bin";
        public string Title => "Binary";
        public void Serialize(string path, IEnumerable<T> items)
        {
            using var fs = File.Create(path);
            var bf = new BinaryFormatter();
            bf.Serialize(fs, new List<T>(items));
        }
        public List<T> Deserialize(string path)
        {
            if (!File.Exists(path)) return new();
            using var fs = File.OpenRead(path);
            var bf = new BinaryFormatter();
            return (List<T>)(bf.Deserialize(fs) ?? new List<T>());
        }
    }
}
