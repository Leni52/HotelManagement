using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class Booking
    {
        public int BookingId { get; set; }


        [Required]
        public int RoomNumber { get; set; }
        public virtual  Room Room { get; set; }

        public DateTime DateCreated { get; set; }
        [Required]
        [Display(Name = "Check in Date")]
        public DateTime CheckIn { get; set; }
        [Required]
        [Display(Name = "Check out date")]
        public DateTime CheckOut { get; set; }
        [Required]
        [Display(Name = "Number of guests")]
        public int Guests { get; set; }
        [Required]
        [Display(Name = "Total Fee")]
        public decimal TotalFee { get; set; }
        [Required]
        public bool  Paid { get; set; }

        //Customer info
        [Required]
        [Display(Name = "Customer Name")]
        public string  CustomerName { get; set; }
        [Required]
        [Display(Name = "Customer Email")]
        public string  CustomerEmail { get; set; }
        [Required]

        [Display(Name = "Customer Phone")]
        public string  CustomerPhone { get; set; }
        [Required]
        [Display(Name = "Customer Address")]
        public string  CustomerAdress { get; set; }
        [Display(Name = "Customer City")]
        public string CustomerCity { get; set; }
        [Display(Name = "Other Requests")]
        public string OtherRequests { get; set; }
    }
}