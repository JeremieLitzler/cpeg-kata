namespace Kata.Booking.Core.Data
{
    public abstract class Base
    {
        private static readonly object locker = new object();
        public static object LockObject => locker;

        public static string BuildFilePath(string fileName)
        {
            // Get the base directory of the library (assuming the library is a .dll)
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            // Define the subdirectory and filename

            // Combine the paths to get the full path
            string filePath = Path.Combine(basePath, fileName);
            return filePath;
        }
        public static void ValidatePath(string filePath)
        {
            // Use the filePath to open or read the file
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"{filePath} doesn't exist");
            }

        }

    }
}
