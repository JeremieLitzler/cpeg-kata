using Kata.Booking.Core.Contracts;
using Newtonsoft.Json;

namespace Kata.Booking.Core.Data
{
    public class DatabaseReader : Base, IDatabaseReader
    {
        public List<T> ReadDatabase<T>(string dabatabaseFileName)
        {
            string databaseFilePath = BuildFilePath(dabatabaseFileName);
            ValidatePath(databaseFilePath);
            lock (LockObject)
            {
                //No DI because we want to test actually reading of the files.
                string json = File.ReadAllText(databaseFilePath);
                if (string.IsNullOrEmpty(json))
                {
                    return new List<T>();   
                }

                List<T> objectsList = JsonConvert.DeserializeObject<List<T>>(json);
                return objectsList;
            }
        }
    }
}