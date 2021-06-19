using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class RoomType
    {
        public Guid ID { get; set; }
        [Required]
        [Display(Name="Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter a price")]
       // [Range(1,999999), ErrorMessage="Please enter a positive price"]
        public decimal BasePrice { get; set; }
        public string Description { get; set; }

        public string ImageUrl { get; set; }


    }
}