using System;

namespace HotelManagement.Models
{
    public class RoomType
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public string Description { get; set; }

        public string ImageUrl { get; set; }


    }
}