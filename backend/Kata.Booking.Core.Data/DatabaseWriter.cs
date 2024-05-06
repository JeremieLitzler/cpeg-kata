using Kata.Booking.Core.Contracts;
using Kata.Booking.Core.Tools.Extensions;
using Newtonsoft.Json;

namespace Kata.Booking.Core.Data
{
    public class DatabaseWriter : Base
    {
        private readonly IFileWriter _fileWriter;
        private string _databaseFile;
        public DatabaseWriter(IFileWriter fileWriter, string databaseFile)
        {
            _fileWriter = fileWriter;
            _databaseFile = databaseFile;
        }

        public void Add<T>(T entity)
        {
            lock (LockObject)
            {
                var currentDatabase = new DatabaseReader().ReadDatabase<T>(this._databaseFile);

                currentDatabase.Add(entity);

                string newJson = JsonConvert.SerializeObject(currentDatabase, Formatting.Indented);
                _fileWriter.WriteAllText(BuildFilePath(this._databaseFile), newJson);
            }
        }
        public void Remove<T>(string id) where T : IWithId
        {
            lock (LockObject)
            {
                var currentDatabase = new DatabaseReader().ReadDatabase<T>(this._databaseFile);

                currentDatabase.RemoveAllById(id);

                string newJson = JsonConvert.SerializeObject(currentDatabase, Formatting.Indented);
                _fileWriter.WriteAllText(BuildFilePath(this._databaseFile), newJson);
            }
        }

    }
}