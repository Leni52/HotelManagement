using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public interface IRoomRepository
    {
        Room GetRoom(int id);
        IEnumerable<Room> GetAllRooms();
        Room Add(Room room);
        Room Update(Room updatedRoom);
        Room Delete(int id);
    }
}
