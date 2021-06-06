using System;

namespace HotelManagement.Models
{
    public class Review
    {

        public Guid ID { get; set; }

        public Guid RoomId { get; set; }
        public virtual  Room Room { get; set; }

        //Reviewer info
        public string  ReviewerName { get; set; }
        public string  ReviewerEmail { get; set; }
        public string  Description { get; set; }
    }
}