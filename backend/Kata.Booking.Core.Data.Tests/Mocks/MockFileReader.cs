using Kata.Booking.Core.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Booking.Core.Data.Tests.Mocks
{
    internal class MockFileReader
    {
        public string ReadPath { get; private set; }
        public string ReadContent { get { return ""; } }

        public string ReadAllText(string path)
        {
            return JsonConvert.SerializeObject(Stubs.RoomStubs.OneRoom());
        }
    }
}
