using System.Collections.Generic;
using System.IO;
using SimpleBank.Core.Repositories.Abstractions;

namespace SimpleBank.Core.Repositories.Implementations
{
    public class FileDataStore : IDataWriter<string>, IDataReader<string>
    {
        private readonly string _filePath;

        public FileDataStore(string filePath)
        {
            _filePath = filePath;
        }

        public void Write(IEnumerable<string> data)
        {
            File.WriteAllLines(_filePath, data);
        }

        public IEnumerable<string> Read()
        {
            return File.ReadAllLines(_filePath);
        }
    }
}