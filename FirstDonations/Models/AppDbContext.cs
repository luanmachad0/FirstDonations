using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDonations.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Donation> Donations { get; set; }
        public DbSet<Part> Parts { get; set; }
    }
}
