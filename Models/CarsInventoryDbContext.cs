using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarInventoryAPI.Models
{
    public class CarsInventoryDbContext: DbContext
    {
         public CarsInventoryDbContext(DbContextOptions<CarsInventoryDbContext> options) : base(options)
        {
        }

        public DbSet<CarTypes> CarTypes { get; set; }
    }
}