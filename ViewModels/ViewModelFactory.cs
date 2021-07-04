using HotelManagement.Models;
using HotelManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    /// <summary>
    /// ROOMS
    /// </summary>
    public class ViewModelFactory
    {
        public static RoomViewModel Details(Room r)
        {
            return new RoomViewModel
            {
                Room = r,
                Action = "Details",
                ReadOnly = true,
                Theme = "info",
                ShowAction = false,
                RoomTypes = r == null ? Enumerable.Empty<RoomType>() :
                  new List<RoomType> { r.RoomType }
             

            };
        }

        /////////////////////
        ///CREATE
        ///


        public static RoomViewModel Create(Room room, IEnumerable<RoomType> roomTypes)
        {
            return new RoomViewModel
            {
                Room = room,
                RoomTypes = roomTypes,
                //Reviews = reviews
            };

        }


        ///////////////////
        /////EDIT
        ///

        
        public static RoomViewModel Edit(Room room, IEnumerable<RoomType> roomTypes)
        {
            return new RoomViewModel
            {
                Room = room,
                RoomTypes = roomTypes,
                Theme = "warning",
                Action = "Edit"
            };
        }

        ////////////////////
        //////DELETE
        ///

        public static RoomViewModel Delete(Room room, IEnumerable<RoomType> roomTypes)
        {
            return new RoomViewModel
            {

                Room = room,
                RoomTypes = roomTypes,
                
                Theme = "danger",
                Action = "Delete",
                //ReadOnly = true
            };
        }
    }
}
