using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models.Contexts
{
    public class IdentityContext:IdentityDbContext
    {


        public IdentityContext(DbContextOptions<IdentityContext> opts)
          : base(opts)
        {
        }
    }
}
