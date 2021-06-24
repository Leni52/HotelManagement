using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Controllers
{
    public class HomeController : Controller
    {
        private DataContext context;
        private IEnumerable<RoomType> rooms => context.RoomTypes;
        private IEnumerable<Review> reviews => context.Reviews;

        private IEnumerable<Booking> bookings => context.Bookings;

        public HomeController(DataContext data)
        {
            context = data;
        }


        public IActionResult Index()
        {
            return View(context.Rooms.Include(r=>r.RoomType));
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        /////////////////////////////////////////////////////
        ///

      
    }
}
