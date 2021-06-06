using System;

namespace HotelManagement.Models
{
    public class Booking
    {
        public Guid ID { get; set; }

        public Guid RoomId { get; set; }

        public virtual  Room Room { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Guests { get; set; }
        public decimal TotalFee { get; set; }
        public bool  Paid { get; set; }

        //Customer info
        public string  CustomerName { get; set; }
        public string  CustomerEmail { get; set; }
        public string  CustomerPhone { get; set; }
        public string  CustomerAdress { get; set; }
        public string CustomerCity { get; set; }
        public string OtherRequests { get; set; }
    }
}