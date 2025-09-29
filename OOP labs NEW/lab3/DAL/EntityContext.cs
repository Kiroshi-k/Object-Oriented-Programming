using System.Collections.Generic;
using DAL.Data;
using DAL.Entities;

namespace DAL
{
    // Контекст рiвня доступу до даних (обгортка над провайдерами)
    public class EntityContext
    {
        private readonly IDataProvider<Student> _provider;
        public string ProviderTitle => _provider.Title;
        public string Extension => _provider.FileExtension;

        public EntityContext(IDataProvider<Student> provider) => _provider = provider;

        public void Save(string path, IEnumerable<Student> students) => _provider.Serialize(path, students);
        public List<Student> Load(string path) => _provider.Deserialize(path);
    }
}
