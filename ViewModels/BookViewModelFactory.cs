using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.ViewModels
{
    public class BookViewModelFactory
    {

        public static BookingViewModel Details(Booking b)
        {
            return new BookingViewModel
            {
               Booking = b,
                Action = "Details",
               
                Theme = "info",
                ShowAction = false,
               
            };
        }

        /////////////////////
        ///CREATE
        ///


        public static BookingViewModel Create(Booking b, 
            IEnumerable<Room>rooms)
        {
            return new BookingViewModel
            {
                Booking=b,
                Rooms = rooms,
                
            };

        }


        ///////////////////
        /////EDIT
        ///


        public static BookingViewModel Edit(Booking b, IEnumerable<Room> rooms)
        {
            return new BookingViewModel
            {
                Booking=b,
                Rooms=rooms,
                Theme = "warning",
                Action = "Edit"
            };
        }

        ////////////////////
        //////DELETE
        ///

        public static BookingViewModel Delete(Booking b,
            IEnumerable<Room> rooms)
        {
            return new BookingViewModel
            {

               Booking=b,

                Theme = "danger",
                Action = "Delete",
               
            };
        }
    }
}
