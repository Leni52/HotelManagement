using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.ViewModels
{
    public class ViewModelFactory
    {
        public static RoomViewModel Details(Room r)
        {
            return new RoomViewModel
            {
                room = r,
                Action = "Details",
                ReadOnly = true,
                Theme = "info",
                ShowAction = false,
                roomTypes = r == null ? Enumerable.Empty<RoomType>() :
                new List<RoomType> { r.RoomType },



            };
        }
    }
}
