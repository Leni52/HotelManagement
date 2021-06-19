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
        public static void SeedDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var context = serviceScope.ServiceProvider.GetService<DataContext>())
            {
                SeedDatabase(context);
            }
        }

        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();

            if (!context.Rooms.Any() && !context.RoomTypes.Any() && !context.Reviews.Any())
            {
                Review rv1 = new Review()
                {
                    ReviewerName = "Max",
                    ReviewerEmail = "max@max.com",
                    //ID=1,
                    //RoomId = 1,
                    Description = "Nice room"
                }; ;
                RoomType r1 = new RoomType()
                {
                    BasePrice = 100,
                    Description = "Economic class",
                    //ID = 1,
                    ImageUrl = "img/1.jpg",
                    Name = "RoomType1"
                };
                context.Rooms.AddRange(
                    new Room
                    {
                        Number = 100,
                        Available = true,
                        Description = "Very Nice room",
                        MaximumGuests = 3,

                    }

                );
                context.SaveChanges();
            }
        }
    }
}
