using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace HotelManagement.Controllers
{
   
    public class HomeController : Controller
    {
        private DataContext context;
        private IEnumerable<RoomType> RoomTypes => context.RoomTypes;
        private IEnumerable<Review> Reviews => context.Reviews;

        private IEnumerable<Booking> bookings => context.Bookings;

        public HomeController(DataContext data)
        {
            context = data;
        }

        [AllowAnonymous]
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
            
            Room r = await context.Rooms.Include(r=>r.RoomType).FirstAsync(r => r.RoomId == id);

            RoomViewModel model = ViewModelFactory.Details(r);
             return View("RoomEditor", model);
            
            
          
    
        }
        [HttpGet]
    
        public IActionResult Create()
        {
            return View("RoomEditor", ViewModelFactory.Create(new Room(),
             RoomTypes));
        }
       
        [HttpPost]
      
        public async Task<IActionResult> Create([FromForm] Room room)
        {
            if (ModelState.IsValid)
            {
                room.RoomId = default;
                
               
                context.Rooms.Add(room);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("RoomEditor",
                ViewModelFactory.Create(room, RoomTypes));
        }

        ////////////////////
        /// <summary>
        ///
        /// 
       
        public async Task<IActionResult> Edit(int id)
        {
            Room r = await context.Rooms.FindAsync(id);
            RoomViewModel model = ViewModelFactory.Edit(r, RoomTypes);
            return View("RoomEditor", model);
        }
        [HttpPost]
       
        public async Task<IActionResult> Edit([FromForm]Room room)
        {
            if (ModelState.IsValid)
            {
                room.RoomType = default;

                context.Rooms.Update(room);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("RoomEditor", ViewModelFactory.Edit(room, RoomTypes));


        }

        public async Task<IActionResult> Delete(int id)
        {

            RoomViewModel model = ViewModelFactory.Delete(await
                context.Rooms.FindAsync(id), RoomTypes);
            return View("RoomEditor", model);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(Room room)
        {
            context.Rooms.Remove(room);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}
