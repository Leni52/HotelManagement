using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DataContext context;

        public RoomRepository(DataContext context)
        {
            this.context = context;
        }

        //add a room
        public Room Add(Room room)
        {
            context.Add(room);
            context.SaveChanges();
            return room;
        }

        public Room Delete(int id)
        {
            Room room = context.Rooms.Find(id);
            if (room != null)
            {
                context.Rooms.Remove(room);
                context.SaveChanges();
            }
            return room;
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return context.Rooms;
        }

        public Room GetRoom(int id)
        {
            return context.Rooms.Find(id);
        }

        public Room Update(Room updatedRoom)
        {
            var room = context.Rooms.Attach(updatedRoom);
            room.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedRoom;
        }
    }
}
