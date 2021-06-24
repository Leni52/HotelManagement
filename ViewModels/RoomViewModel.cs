using HotelManagement.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagement.ViewModels
{
    public class RoomViewModel
    {
        public Room room { get; set; }

        public string Action { get; set; } = "Create";
        //the name of the action method for the current task

        public bool ReadOnly { get; set; } = false;
        //readonly specifies whether the user can edit the data
        public string Theme { get; set; } = "primary";
        //Theme specifies the current Bootstrap theme for the content
        public bool ShowAction { get; set; } = true;
        //ShowAction is used to control the visibility of the button 
        //that submits the form

        public IEnumerable<RoomType> roomTypes { get; set; } =
            Enumerable.Empty<RoomType>();

        //Booking
        //1 room - N Bookings
        public IEnumerable<Booking> Bookings { get; set; }

        //Review
        //1 room - N Reviews

        public IEnumerable<Review> Reviews { get; set; }




    }
}