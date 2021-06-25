using HotelManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Helpers
{   public static class SeedData
    {
       

        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();

            if (!context.Rooms.Any() && !context.RoomTypes.Any() && !context.Reviews.Any())
            {
                Review rv1 = new Review()
                {
                     
                     RoomNumber=100,
                     ReviewerName = "Max",
                     ReviewerEmail = "max@max.com",
                     Description = "Nice room"
                }; 
                RoomType r1 = new RoomType()
                {
                 
                    Name = "RoomType1",
                    BasePrice = 1000,
                    Description = "Economic class",
                    ImageUrl = "img/1.jpg",
                    
                };
                context.Rooms.AddRange(
                    new Room
                    {
                        
                        Number = 100,
                        RoomType=r1,
                        Available = true,
                        Price=100,
                        Description = "Very Nice room",
                        MaximumGuests = 3,


                    }

                );



                Review rv2 = new Review()
                {

                    RoomNumber = 101,
                    ReviewerName = "Tom",
                    ReviewerEmail = "tom@tom.com",
                    Description = "Nice room"
                };
                RoomType r2 = new RoomType()
                {

                    Name = "RoomType2",
                    BasePrice = 2000,
                    Description = "Economic class",
                    ImageUrl = "img/2.jpg",

                };
                context.Rooms.AddRange(
                    new Room
                    {

                        Number = 101,
                        RoomType = r2,
                        Available = true,
                        Price = 2000,
                        Description = "Very Nice room",
                        MaximumGuests = 2,


                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
