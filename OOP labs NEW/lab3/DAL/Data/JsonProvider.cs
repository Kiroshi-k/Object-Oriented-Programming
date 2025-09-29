using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DAL.Data
{
    public class JsonProvider<T> : IDataProvider<T>
    {
        public string FileExtension => ".json";
        public string Title => "JSON";
        public void Serialize(string path, IEnumerable<T> items)
        {
            var json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }
        public List<T> Deserialize(string path)
        {
            if (!File.Exists(path)) return new();
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new();
        }
    }
}
