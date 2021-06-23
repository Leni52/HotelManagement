using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Room
    {
        public Guid ID { get; set; }
        [Required]
        public int Number { get; set; }
        public virtual RoomType RoomType { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool Available { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int MaximumGuests { get; set; }

        public virtual List<Review> Reviews {get; set;}
    public virtual List<Booking> Bookings {get; set;}

    }
}
