using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        [Required]
        public int Number { get; set; }
        public int  RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; }

        
        [Column(TypeName = "decimal(8, 2)")]
        [Required(ErrorMessage = "Please enter a price")]
        [Range(1, 999999, ErrorMessage = "Please enter a positive price")]

        public decimal Price { get; set; }

        [Required]
        public bool Available { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int MaximumGuests { get; set; }

        public  int ReviewId{ get; set; }
        public IEnumerable<Review> Review {get; set;}

        public int BookingId { get; set; }
        public IEnumerable<Booking> Booking {get; set;}
        //1 room - many reviews
        //1 room - many bookings
    }
}
