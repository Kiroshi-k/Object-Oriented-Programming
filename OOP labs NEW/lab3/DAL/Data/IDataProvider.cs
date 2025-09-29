using System.Collections.Generic;

namespace DAL.Data
{
    public interface IDataProvider<T>
    {
        void Serialize(string path, IEnumerable<T> items);
        List<T> Deserialize(string path);
        string FileExtension { get; }
        string Title { get; }
    }
}
