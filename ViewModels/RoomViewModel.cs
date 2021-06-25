using HotelManagement.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagement.ViewModels
{
    public class RoomViewModel
    {
       
        public Room Room { get; set; }
        public string Action { get; set; } = "Create";
        //the name of the action method for the current task

        public bool ReadOnly { get; set; } = false;
        //readonly specifies whether the user can edit the data
        public string Theme { get; set; } = "primary";
        //Theme specifies the current Bootstrap theme for the content
        public bool ShowAction { get; set; } = true;
        //ShowAction is used to control the visibility of the button 
        //that submits the form

        //1 room - 1 roomType

        public IEnumerable<RoomType> RoomTypes { get; set; } =
            Enumerable.Empty<RoomType>();

        //Booking
        //1 room - N Bookings
        public IEnumerable<Booking> Bookings { get; set; } =
            Enumerable.Empty<Booking>();


        //Review
        //1 room - N Reviews

        public IEnumerable<Review> Reviews { get; set; } =
            Enumerable.Empty<Review>();




    }
}