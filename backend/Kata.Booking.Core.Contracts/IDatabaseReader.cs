using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Booking.Core.Contracts
{
    public interface IDatabaseReader
    {
        List<T> ReadDatabase<T>(string connectionStr);
    }
}
