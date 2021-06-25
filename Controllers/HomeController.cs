using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Controllers
{
    public class HomeController : Controller
    {
        private DataContext context;
        private IEnumerable<RoomType> roomTypes => context.RoomTypes;
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
        public async Task<IActionResult> Details(int? id)
        {
            
            Room r = await context.Rooms.FirstAsync(r => r.RoomId == id);

            RoomViewModel model = ViewModelFactory.Details(r);
             return View("RoomEditor", model);
            
            
            /*
            if (id == null)
            {
                return NotFound();
            }
            var s = await context.Rooms.Include(s => s.RoomType).FirstOrDefaultAsync(s => s.RoomId == id);
            if (s == null)
            {
                return NotFound();
            }
            return View("RoomEditor",s);
        */
        }

        public IActionResult Create()
        {
            return View("RoomEditor", ViewModelFactory.Create(new Room(),
             roomTypes, reviews));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Room room)
        {
            if (ModelState.IsValid)
            {
                room.RoomId = default;
                room.RoomType = default;
                room.Review = default;
                context.Rooms.Add(room);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("RoomEditor",
                ViewModelFactory.Create(room, roomTypes, reviews));
        }

    }
}
