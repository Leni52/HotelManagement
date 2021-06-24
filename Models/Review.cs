using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class Review
    {

        public int ReviewId { get; set; }

        [Required]
        public int RoomNumber { get; set; }
        public virtual  Room Room { get; set; }

        //Reviewer info
        [Required]
        [Display(Name ="Reviewer Name")]
        public string  ReviewerName { get; set; }
        [Required]
        [Display(Name ="Reviewer Email")]
        public string  ReviewerEmail { get; set; }
        [Required]
        public string  Description { get; set; }
    }
}