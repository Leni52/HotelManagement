using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.ViewModels
{
    public class BookingViewModel
    {
        public Booking Booking { get; set; }
     
        public IEnumerable<Room> Rooms { get; set; }
      
        public string Theme { get; set; } = "primary";
        public string Action { get; set; } = "Create";

        public bool ShowAction { get; set; } = true;
        public bool ReadOnly { get; set; } = false;
    }
}
