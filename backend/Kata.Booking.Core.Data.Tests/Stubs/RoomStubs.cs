using Kata.Booking.Core.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Booking.Core.Data.Tests.Stubs
{
    public class RoomStubs
    {
        public static Room OneRoom()
        {

            var roomId = Guid.NewGuid().ToString();
            var roomName = "CPEG Headquarters";
            var entity = new Room() { Id = roomId, Name = roomName };
            return entity;
        }
    }
}
