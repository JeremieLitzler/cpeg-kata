using Kata.Booking.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Booking.Core.Business.Wrappers
{
    internal class FileWriter : IFileWriter
    {
        public void WriteAllText(string path, string content)
        {
            File.WriteAllText(path, content);
        }
    }
}
