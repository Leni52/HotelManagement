using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Room
    {
        public Guid ID { get; set; }
        public int Number { get; set; }
        public virtual RoomType RoomType { get; set; }

        public decimal Price { get; set; }

        public bool Available { get; set; }
        public string Description { get; set; }
        public int MaximumGuests { get; set; }

        public virtual List<Review> Reviews {get; set;}
    public virtual List<Booking> Bookings {get; set;}

    }
}
