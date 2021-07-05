using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Controllers
{
   [AutoValidateAntiforgeryToken]
    public class BookController : Controller
    {
        private DataContext context;

        private IEnumerable<Booking> Bookings => context.Bookings;
        private IEnumerable<Room> Rooms => context.Rooms;
        public BookController(DataContext data)
        {
            context = data;
        }


        public IActionResult Index()
        {
            return View(context.Bookings.Include(b=>b.Room));
        }


        public IActionResult Create()
        {
            return View("BookEditor", BookViewModelFactory.Create(new Booking(), Rooms)); 
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.BookingId = default;
               
                context.Bookings.Add(booking);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("BookEditor",
                BookViewModelFactory.Create(booking, Rooms));
        }


        public async Task<IActionResult> Edit(int id)
        {
           Booking b = await context.Bookings.FindAsync(id);
            BookingViewModel model = BookViewModelFactory.Edit(b, Rooms);
            return View("BookEditor", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Booking booking, Room room)
        {
            if (ModelState.IsValid)
            {
               booking.BookingId = default;
                booking.TotalFee = room.Price;
                context.Bookings.Update(booking);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("BookEditor",
                BookViewModelFactory.Edit(booking, Rooms));
        }


        public async Task<IActionResult> Delete(int id)
        {
            BookingViewModel model = BookViewModelFactory.Delete(
                await context.Bookings.FindAsync(id), Rooms);
                
            return View("BookEditor", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Booking booking)
        {
            context.Bookings.Remove(booking);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
